using System;

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

        // Internal implementation adapted from standard Delta robot kinematics
        public static class DeltaRobot
        {
            // ================================
            // GEOMETRY PARAMETERS
            // ================================
            // e: side of the movable triangle
            static double e = 156.321;
            // f: side of the fixed triangle
            static double f = 692.820; 
            // re: forearm length
            static double re = 800;
            // rf: bicep length
            static double rf = 350;

            // trig constants
            static double sqrt3 = Math.Sqrt(3.0);
            const double pi = Math.PI;
            static double sin120 = sqrt3 / 2.0;
            static double cos120 = -0.5;
            static double tan60 = sqrt3;
            static double sin30 = 0.5;
            static double tan30 = 1.0 / sqrt3;

            // ================================
            // FORWARD KINEMATICS (Delta frame -> RoboDK frame)
            // INPUT: theta1, theta2, theta3 (degrees)
            // OUTPUT: x0, y0, z0 (RoboDK frame)
            // ================================
            public static int delta_calcForward(
                double theta1,
                double theta2,
                double theta3,
                out double x0,
                out double y0,
                out double z0)
            {
                x0 = 0;
                y0 = 0;
                z0 = 0;

                // Convert degrees to radians for trig
                double dtr = pi / 180.0;
                theta1 *= dtr;
                theta2 *= dtr;
                theta3 *= dtr;

                // distance from center to edge
                double t = (f - e) * tan30 / 2.0;

                // coordinates of the joints J1,J2,J3 in the Delta frame
                double yj1 = -(t + rf * Math.Cos(theta1));
                double zj1 = -rf * Math.Sin(theta1);

                double yj2 = (t + rf * Math.Cos(theta2)) * sin30;
                double xj2 = yj2 * tan60;
                double zj2 = -rf * Math.Sin(theta2);

                double yj3 = (t + rf * Math.Cos(theta3)) * sin30;
                double xj3 = -yj3 * tan60;
                double zj3 = -rf * Math.Sin(theta3);

                // intermediate computations
                double dnm = (yj2 - yj1) * xj3 - (yj3 - yj1) * xj2;

                double w1 = yj1 * yj1 + zj1 * zj1;
                double w2 = xj2 * xj2 + yj2 * yj2 + zj2 * zj2;
                double w3 = xj3 * xj3 + yj3 * yj3 + zj3 * zj3;

                double a1 = (zj2 - zj1) * (yj3 - yj1) - (zj3 - zj1) * (yj2 - yj1);
                double b1 = -((w2 - w1) * (yj3 - yj1) - (w3 - w1) * (yj2 - yj1)) / 2.0;

                double a2 = -(zj2 - zj1) * xj3 + (zj3 - zj1) * xj2;
                double b2 = ((w2 - w1) * xj3 - (w3 - w1) * xj2) / 2.0;

                double a = a1 * a1 + a2 * a2 + dnm * dnm;
                double b = 2 * (a1 * b1 + a2 * (b2 - yj1 * dnm) - zj1 * dnm * dnm);
                double c = (b2 - yj1 * dnm) * (b2 - yj1 * dnm) + b1 * b1 + dnm * dnm * (zj1 * zj1 - re * re);

                double d = b * b - 4.0 * a * c;
                if (d < 0)
                {
                    return -1; // no solution
                }

                // Solve quadratic for z in Delta frame
                double zDelta = -0.5 * (b + Math.Sqrt(d)) / a;
                double xDelta = (a1 * zDelta + b1) / dnm;
                double yDelta = (a2 * zDelta + b2) / dnm;

                // Convert from Delta frame to RoboDK frame.
                // delta_calcInverse used:
                //   x0_delta = -yRobo
                //   y0_delta = -xRobo
                //   z0_delta = zRobo - offset
                // So invert those:
                double xRobo = -yDelta;
                double yRobo = -xDelta;
                double zRobo = zDelta - 316.969;

                // assign outputs (RoboDK frame)
                x0 = xRobo;
                y0 = yRobo;
                z0 = zRobo;

                return 0;
            }

            // ================================
            // HELPER: compute angle in YZ plane
            // ================================
            private static int delta_calcAngleYZ(
                double x0,
                double y0,
                double z0,
                out double theta)
            {
                theta = 0;

                // translate coordinates
                double yj1 = -0.5 * (1.0 / sqrt3) * f;
                y0 = y0 - 0.5 * (1.0 / sqrt3) * e;

                // line: z = a + b*y
                double a =
                    (x0 * x0 + y0 * y0 + z0 * z0
                    + rf * rf - re * re - yj1 * yj1)
                    / (2.0 * z0);

                double b = (yj1 - y0) / z0;

                double d =
                    -(a + b * yj1) * (a + b * yj1)
                    + rf * (b * b * rf + rf);

                if (d < 0)
                {
                    return -1;
                }

                double yj =
                    (yj1 - a * b - Math.Sqrt(d))
                    / (b * b + 1);

                double zj = a + b * yj;

                theta =
                    Math.Atan(-zj / (yj1 - yj))
                    * 180.0 / pi;

                if (yj > yj1)
                {
                    theta += 180.0;
                }

                theta = Math.Round(theta, 3);

                if (Math.Abs(theta) < 0.001)
                {
                    theta = 0;
                }

                return 0;
            }

            // ================================
            // INVERSE KINEMATICS (RoboDK frame -> Delta frame)
            // INPUT: x0, y0, z0 (RoboDK frame)
            // OUTPUT: theta1, theta2, theta3 (degrees)
            // ================================
public static int delta_calcInverse(
    double x0,
    double y0,
    double z0,
    out double theta1,
    out double theta2,
    out double theta3)
{
    theta1 = 0;
    theta2 = 0;
    theta3 = 0;

    // Inputs are in RoboDK frame. Convert RoboDK -> Delta frame (inverse of forward mapping)
    // forward mapped:
    //   xRobo = -yDelta
    //   yRobo = -xDelta
    //   zRobo = zDelta + offset
    // therefore:
    double xRobo = x0;
    double yRobo = y0;
    double zRobo = z0;

    double xDelta = -yRobo;
    double yDelta = -xRobo;
    double zDelta = zRobo + 316.969; // reverse the Z offset applied in forward

    // Guard against invalid z (delta_calcAngleYZ divides by z)
    if (Math.Abs(zDelta) < 1e-12)
    {
        return -1;
    }

    int status = delta_calcAngleYZ(xDelta, yDelta, zDelta, out theta1);
    if (status != 0) return -1;

    // Arm 2 (+120 deg rotation)
    double xj2 = xDelta * cos120 + yDelta * sin120;
    double yj2 = yDelta * cos120 - xDelta * sin120;
    status = delta_calcAngleYZ(xj2, yj2, zDelta, out theta2);
    if (status != 0) return -1;

    // Arm 3 (-120 deg rotation)
    double xj3 = xDelta * cos120 - yDelta * sin120;
    double yj3 = yDelta * cos120 + xDelta * sin120;
    status = delta_calcAngleYZ(xj3, yj3, zDelta, out theta3);

    return status;
}
          
        }
    }
}