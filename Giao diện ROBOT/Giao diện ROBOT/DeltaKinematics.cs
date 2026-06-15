using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotDelta
{
    public class DeltaKinematics
    {
        // Public wrapper to compute inverse kinematics: returns null on failure or array[3] with angles in degrees
        public static double[] Inverse(double x, double y, double z)
        {
            double t1, t2, t3;
            int status = DeltaRobot.delta_calcInverse(x, y, z, out t1, out t2, out t3);
            if (status != 0) return null;
            return new double[] { t1, t2, t3 };
        }

        // Public wrapper for forward kinematics: returns null on failure or array[3] with x,y,z
        public static double[] Forward(double t1, double t2, double t3)
        {
            double x, y, z;
            int status = DeltaRobot.delta_calcForward(t1, t2, t3, out x, out y, out z);
            if (status != 0) return null;
            return new double[] { x, y, z };
        }

        public static class DeltaRobot
        {
            // ================================
            // THÔNG SỐ HÌNH HỌC ROBOT
            // ================================
            // e: bán kính đế di động
            static double e = 156.321;// e=E/2√3 Với L1 cạnh bên tam giác đế di động 

            // f: bán kính đế cố định
            static double f = 692.820;// f=F/2√3 Với L2 cạnh bên tam giác đế cố định 

            // re: chiều dài cánh tay (forearm)
            static double re = 800;

            // rf: chiều dài cẳng tay (bicep)
            static double rf = 350;

            // ================================
            // THÔNG SỐ HẰNG SỐ LƯỢNG GIÁC
            // ================================

            static double sqrt3 = Math.Sqrt(3.0);
            const double pi = Math.PI;
            static double sin120 = sqrt3 / 2.0;
            static double cos120 = -0.5;
            static double tan60 = sqrt3;
            static double sin30 = 0.5;
            static double tan30 = 1.0 / sqrt3;
            private static int yDelta;

            // ================================
            // ĐỘNG HỌC THUẬN (FORWARD)
            // INPUT: theta1, theta2, theta3 (độ)
            // OUTPUT: (x0, y0, z0)
            // ================================
            // cấu trúc hàm:
            // public static int tên_hàm(tham_số, out biến...)
            public static int delta_calcForward(
                double theta1,
                double theta2,
                double theta3,
                out double x0,
                out double y0,
                out double z0)
            {
                // khởi tạo giá trị mặc định
                x0 = 0;
                y0 = 0;
                z0 = 0;

                // chuyển đơn vị độ sang radian
                double dtr = pi / 180.0;

                theta1 *= dtr; // θ1(rad)=θ1(deg)⋅pi / 180.0
                theta2 *= dtr; // θ2(rad)=θ2(deg)⋅pi / 180.0
                theta3 *= dtr; // θ3(rad)=θ3(deg)⋅pi / 180.0

                // khoảng cách từ tâm đến cạnh
                double t = (f - e) * tan30 / 2.0;

                // ===== Tọa độ các khớp J1, J2, J3 =====
                double yj1 = -(t + rf * Math.Cos(theta1));
                double zj1 = -rf * Math.Sin(theta1);

                double yj2 = (t + rf * Math.Cos(theta2)) * sin30;
                double xj2 = yj2 * tan60;
                double zj2 = -rf * Math.Sin(theta2);

                double yj3 = (t + rf * Math.Cos(theta3)) * sin30;
                double xj3 = -yj3 * tan60;
                double zj3 = -rf * Math.Sin(theta3);

                // ===== Tính toán trung gian =====
                double dnm = (yj2 - yj1) * xj3 - (yj3 - yj1) * xj2;

                double w1 = yj1 * yj1 + zj1 * zj1;
                double w2 = xj2 * xj2 + yj2 * yj2 + zj2 * zj2;
                double w3 = xj3 * xj3 + yj3 * yj3 + zj3 * zj3;

                // ===== Tính x0, y0 theo z =====
                double a1 = (zj2 - zj1) * (yj3 - yj1) - (zj3 - zj1) * (yj2 - yj1);

                double b1 =
                    -((w2 - w1) * (yj3 - yj1) - (w3 - w1) * (yj2 - yj1)) / 2.0;

                double a2 =
                    -(zj2 - zj1) * xj3 + (zj3 - zj1) * xj2;

                double b2 =
                    ((w2 - w1) * xj3 - (w3 - w1) * xj2) / 2.0;

                // ===== Giải phương trình bậc 2 theo z =====
                double a = a1 * a1 + a2 * a2 + dnm * dnm;

                double b =
                    2 * (a1 * b1 + a2 * (b2 - yj1 * dnm) - zj1 * dnm * dnm);

                double c =
                    (b2 - yj1 * dnm) * (b2 - yj1 * dnm)
                    + b1 * b1
                    + dnm * dnm * (zj1 * zj1 - re * re);

                double d = b * b - 4.0 * a * c; // delta

                // nếu vô nghiệm
                if (d < 0)
                {
                    return -1;
                }

                // nghiệm trong hệ Delta
                z0 = -0.5 * (b + Math.Sqrt(d)) / a;
                x0 = (a1 * z0 + b1) / dnm;
                y0 = (a2 * z0 + b2) / dnm;

                // Chuyển sang hệ RoboDK
                double xDelta = x0;
                double zDelta = z0;

                x0 = -yDelta;
                y0 = -xDelta;

                // Offset Z 
                z0 = zDelta - 316.969;

                return 0;
            }

            // ================================
            // HÀM PHỤ: TÍNH GÓC TRONG MẶT PHẲNG YZ
            // ================================
            private static int delta_calcAngleYZ(
                double x0,
                double y0,
                double z0,
                out double theta)
            {
                theta = 0;

                // dịch hệ tọa độ
                double yj1 = -0.5 * (1.0 / sqrt3) * f;
                y0 = y0 - 0.5 * (1.0 / sqrt3) * e;

                // dạng đường thẳng: z = a + b*y
                double a =
                    (x0 * x0 + y0 * y0 + z0 * z0
                    + rf * rf - re * re - yj1 * yj1)
                    / (2.0 * z0);

                double b = (yj1 - y0) / z0;

                // delta
                double d =
                    -(a + b * yj1) * (a + b * yj1)
                    + rf * (b * b * rf + rf);

                if (d < 0)
                {
                    return -1;
                }

                // chọn nghiệm ngoài
                double yj =
                    (yj1 - a * b - Math.Sqrt(d))
                    / (b * b + 1);

                double zj = a + b * yj;

                // tính góc theta
                theta =
            Math.Atan(-zj / (yj1 - yj))
            * 180.0 / pi;

                if (yj > yj1)
                {
                    theta += 180.0;
                }

                // làm tròn 6 số lẻ
                theta = Math.Round(theta, 3);

                // đổi giá trị -0.0 -> 0.0 
                if (Math.Abs(theta) < 0.001)
                {
                    theta = 0;
                }

                return 0;
            }

            // ================================
            // ĐỘNG HỌC NGHỊCH (INVERSE)
            // INPUT: x0, y0, z0
            // OUTPUT: theta1, theta2, theta3
            // ================================
            public static int delta_calcInverse(
                double x0,
                double y0,
                double z0,
                out double theta1,
                out double theta2,
                out double theta3)
            {
                // khởi tạo giá trị mặc định
                theta1 = 0;
                theta2 = 0;
                theta3 = 0;
                // Chuyển hệ Delta <-> robodk

                double xRobo = x0;
                double yRobo = y0;
                double zRobo = z0;

                x0 = -yRobo;
                y0 = -xRobo;

                // Offset Z
                z0 = zRobo - 316.969;
                int status;

                // Tay 1 của robot trong mặt phẳng YZ
                status = delta_calcAngleYZ(x0, y0, z0, out theta1);

                if (status != 0)
                {
                    return -1;
                }

                // ================================
                // Tay 2 và tay 3 của robot trong mặt phẳng YZ
                // sau khi đã quay hệ tọa độ
                // ================================

                // TAY 2 quay +120 độ
                double xj2 = x0 * cos120 + y0 * sin120;
                double yj2 = y0 * cos120 - x0 * sin120;

                status = delta_calcAngleYZ(xj2, yj2, z0, out theta2);

                if (status != 0)
                {
                    return -1;
                }

                // TAY 3 quay -120 độ
                double xj3 = x0 * cos120 - y0 * sin120;
                double yj3 = y0 * cos120 + x0 * sin120;

                status = delta_calcAngleYZ(xj3, yj3, z0, out theta3);

                return status;
            }

            // ================================
            // TEST
            // ================================
            static void MainTest(string[] args)
            {
                // test forward
                Console.WriteLine("=== FORWARD ===");

                double x, y, z;

                int err = delta_calcForward(
                    0,
                    0,
                    0,
                    out x,
                    out y,
                    out z);
                // đổi kết quả hiển thị -0 -> 0
                if (Math.Abs(x) < 0.001) x = 0;
                if (Math.Abs(y) < 0.001) y = 0;
                if (Math.Abs(z) < 0.001) z = 0;

                Console.WriteLine($"x = {x:F3}");
                Console.WriteLine($"y = {y:F3}");
                Console.WriteLine($"z = {z:F3}");

                // test inverse
                Console.WriteLine("\n=== INVERSE ===");

                double t1, t2, t3;

                err = delta_calcInverse(
                    x,
                    y,
                    z,
                    out t1,
                    out t2,
                    out t3);

                Console.WriteLine("theta1 = " + t1);
                Console.WriteLine("theta2 = " + t2);
                Console.WriteLine("theta3 = " + t3);
            }
        }
    }
}