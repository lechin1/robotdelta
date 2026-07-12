using ACS.SPiiPlusNET;
using RobotDelta;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
namespace parallel_ABB_with_ACS
{
    public partial class Form1 : Form
    {
       

        private IntPtr oldParent = IntPtr.Zero;
      

        private IntPtr ACSHandle = IntPtr.Zero;
        private void UpdateXYZTextbox()
        {
            textBox10.Text = currentX.ToString("F3");
            textBox11.Text = currentY.ToString("F3");
            textBox12.Text = currentZ.ToString("F3");
        }

        private void UpdateThetaTextbox(double t1, double t2, double t3)
        {
            Giatritheta1.Text = t1.ToString("F3");
            Giatritheta2.Text = t2.ToString("F3");
            Giatritheta3.Text = t3.ToString("F3");
        }
        private CancellationTokenSource jogCTS;
        private bool jogRunning = false;
        private volatile bool cancelMotion = false;
        private Api _ACS;
        private bool m_bConnected = false;
        private int m_nTotalAxis = 0;
        private int m_nTotalBuffer = 0;
        private Axis[] m_arrAxisList = null;
        private System.Windows.Forms.ComboBox cboAxisNo;
        private bool workspaceError = false;
        private bool stopAllPressed = false;
        // tọa độ gốc////
        private double currentX = 0;
        private double currentY = 0;
        private double currentZ = -937.535;
        // Added timer field so tmrMonitor references resolve
        private System.Windows.Forms.Timer tmrMonitor;
        private RobotMotion _robotMotion;
        private System.Windows.Forms.Button btnEnableAll;
        private System.Windows.Forms.Timer jogTimer;
        private enum JogDirection
        {
            None,
            XPlus,
            XMinus,
            YPlus,
            YMinus,
            ZPlus,
            ZMinus
        }

        private JogDirection currentJog = JogDirection.None;
        // open ACS window when run code//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void Form1_Load(object sender, EventArgs e)
        {

            cboShape.Items.Clear();
            cboShape.Items.Add("Circle");
            cboShape.Items.Add("Square");
            cboShape.Items.Add("Triangle");

            cboShape.SelectedIndex = -1;

            string path = @"C:\Program Files (x86)\ACS Motion Control\SPiiPlus ADK Suite v3.13.01\SPiiPlus MMI Application Studio\ACS.Framework.exe";

            if (!File.Exists(path))
            {
                return;
            }

            try
            {
                Process.Start(new ProcessStartInfo()
                {
                    FileName = path,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connected SPiiPluss MMI Application Studio");
            }

        }
        private void TernminateUMD_Connection()
        {
            try
            {
                string terminateExceptionConnName = "ACS.Framework.exe";

                ACSC_CONNECTION_DESC[] connectionList = _ACS.GetConnectionsList();
                for (int index = 0; index < connectionList.Length; index++)
                {

                    if (terminateExceptionConnName.CompareTo((string)connectionList[index].Application) != 0)
                        _ACS.TerminateConnection(connectionList[index]);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
        }
        // COONNECT/ DISCONECT BUTTON//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void btnOpen_Click(object sender, EventArgs e)
        {
            string strTemp;
            int i;
            //double lfTemp = 0.0f;

            try
            {
                if (rdoTCP.Checked)
                {
                    // TCP/IP (Ethernet) 
                    _ACS.OpenCommEthernetTCP(
                        IPtxt.Text,                             // IP Address (Default : 10.0.0.100)
                        Convert.ToInt32(Porttxt.Text.Trim())    // TCP/IP Port nubmer (default : 701)
                        );
                }
                else if (rdoSimu.Checked)
                {
                    // Simmulation mode
                    _ACS.OpenCommSimulator();
                    if (_ACS == null)
                    {
                        MessageBox.Show("ACS API is not initialized.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                m_bConnected = true;

                // Get Total number of axes
                // Using Transaction function : return string text from controller, we need to convert to integer value
                strTemp = _ACS.Transaction("?SYSINFO(13)");
                m_nTotalAxis = Convert.ToInt32(strTemp.Trim());

                // When we are using multi axes command (ex) ToPointM, HaltM, ...), we need to allocate the array size more 1.
                // Because of the last delimeter (-1)
                m_arrAxisList = new Axis[m_nTotalAxis + 1];
                for (i = 0; i < m_nTotalAxis; i++)
                {
                    ((ComboBox)cboAxisNo).Items.Add(i.ToString());
                    m_arrAxisList[i] = (Axis)i;
                }
                // Insert '-1' at the last
                m_arrAxisList[m_nTotalAxis] = Axis.ACSC_NONE;
                ((ComboBox)cboAxisNo).SelectedIndex = 0;

                // Update current motion paramter to UI.
                UpdateProfile();

                btnOpen.Enabled = false;
                btnClose.Enabled = true;

                // Set updating timer
                tmrMonitor.Interval = 30;
                tmrMonitor.Start();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (m_bConnected) _ACS.CloseComm();

            tmrMonitor.Stop();

            btnOpen.Enabled = true;
            btnClose.Enabled = false;
        }

        /// <summary>
        /// ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        /// </summary>
        public Form1()
        {

            InitializeComponent();
            // Khởi tạo Timer JOG
            txtVel.Leave += MotionProfile_Leave;
            txtAcc.Leave += MotionProfile_Leave;
            txtDec.Leave += MotionProfile_Leave;
            txtKdec.Leave += MotionProfile_Leave;
            txtJerk.Leave += MotionProfile_Leave;
            jogTimer = new System.Windows.Forms.Timer();
            jogTimer.Interval = 150;      // 150ms
            jogTimer.Tick += JogTimer_Tick;

            // Ensure cboAxisNo exists (some designer versions may not have created it)
            if (this.cboAxisNo == null)
            {
                cboAxisNo = new System.Windows.Forms.ComboBox();
                cboAxisNo.Name = "cboAxisNo";
                cboAxisNo.Location = new System.Drawing.Point(16, 24);
                cboAxisNo.Size = new System.Drawing.Size(60, 21);
                this.Controls.Add(cboAxisNo);
            }

            // Create and wire up the timer
            tmrMonitor = new System.Windows.Forms.Timer();
            tmrMonitor.Tick += new EventHandler(tmrMonitor_Tick);
            this.Load += new EventHandler(Form1_Load);

            // Initialize ACS API (match sample behavior)
            try
            {
                _ACS = new Api();
                // For now skip registering ACS events so jog logic can run without requiring additional handler declarations.
                // _ACS.PHYSICALMOTIONEND += _ACS_PHYSICALMOTIONEND;
                // _ACS.PROGRAMEND += _ACS_PROGRAMEND;
                if (_ACS != null)
                    _robotMotion = new RobotMotion(_ACS);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to create ACS API: " + ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _ACS = null;
            }
        }

        private void _ACS_PROGRAMEND(BufferMasks axis)
        {
            throw new NotImplementedException();
        }

        private void _ACS_PHYSICALMOTIONEND(AxisMasks axis)
        {
            throw new NotImplementedException();
        }
        // speed setting//////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        private void UpdateProfile()
        {
            if (!m_bConnected) return;
            //3 trục như nhau -->chỉ cần đọc trạng thái trục 0 //////////////////////////////
            txtVel.Text = _ACS.GetVelocity(Axis.ACSC_AXIS_0).ToString();
            txtAcc.Text = _ACS.GetAcceleration(Axis.ACSC_AXIS_0).ToString();
            txtDec.Text = _ACS.GetDeceleration(Axis.ACSC_AXIS_0).ToString();
            txtKdec.Text = _ACS.GetKillDeceleration(Axis.ACSC_AXIS_0).ToString();
            txtJerk.Text = _ACS.GetJerk(Axis.ACSC_AXIS_0).ToString();
        }
        private void MotionProfile_Leave(object sender, EventArgs e)
        {
            if (!m_bConnected) return;

            try
            {
                TextBox txt = sender as TextBox;
                if (txt == null) return;

                if (!double.TryParse(txt.Text, out double value))
                    return;

                Axis[] axes =
                {
            Axis.ACSC_AXIS_0,
            Axis.ACSC_AXIS_1,
            Axis.ACSC_AXIS_2
        };

                foreach (Axis axis in axes)
                {
                    if (txt == txtVel)
                        _ACS.SetVelocityImm(axis, value);

                    else if (txt == txtAcc)
                        _ACS.SetAcceleration(axis, value);

                    else if (txt == txtDec)
                        _ACS.SetDeceleration(axis, value);

                    else if (txt == txtKdec)
                        _ACS.SetKillDeceleration(axis, value);

                    else if (txt == txtJerk)
                        _ACS.SetJerk(axis, value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void cboAxisNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateProfile();
        }
        // chua xử lý ---------------------------------------------------//
        private void tmrMonitor_Tick(object sender, EventArgs e)
        {
            if (!m_bConnected)
                return;

            try
            {
                for (int i = 0; i < 3; i++)
                {
                    //================= Đọc giá trị =================
                    double rpos = _ACS.GetRPosition((Axis)i);
                    double fpos = _ACS.GetFPosition((Axis)i);

                    double pe = (double)_ACS.ReadVariable(
                        "PE",
                        ProgramBuffer.ACSC_NONE,
                        i,
                        i);

                    double fvel = (double)_ACS.ReadVariable(
                        "FVEL",
                        ProgramBuffer.ACSC_NONE,
                        i,
                        i);

                    //================= Đọc trạng thái Motor =================
                    MotorStates state = _ACS.GetMotorState((Axis)i);

                    switch (i)
                    {
                        case 0:

                            //---------------- Position ----------------
                            txtRPOS0.Text = rpos.ToString("0.000");
                            txtFPOS0.Text = fpos.ToString("0.000");
                            txtFVEL0.Text = fvel.ToString("0.000");
                            txtPE0.Text = pe.ToString("0.000");

                            //---------------- Moving ----------------
                            labelMov0.Image =
                                ((state & MotorStates.ACSC_MST_MOVE) != 0)
                                ? Properties.Resources.On
                                : Properties.Resources.Off;

                            //---------------- Accelerating ----------------
                            labelACC0.Image =
                                ((state & MotorStates.ACSC_MST_ACC) != 0)
                                ? Properties.Resources.On
                                : Properties.Resources.Off;

                            //---------------- In Position ----------------
                            labelPosi0.Image =
                                ((state & MotorStates.ACSC_MST_INPOS) != 0)
                                ? Properties.Resources.On
                                : Properties.Resources.Off;

                            //---------------- Enable / Disable ----------------
                            if ((state & MotorStates.ACSC_MST_ENABLE) != 0)
                            {
                                labelEnable0.Image = Properties.Resources.On;
                                lblstop0.Image = Properties.Resources.Off;
                            }
                            else
                            {
                                labelEnable0.Image = Properties.Resources.Off;
                                lblstop0.Image = Properties.Resources.On;
                            }

                            break;

                        case 1:

                            //---------------- Position ----------------
                            txtRPOS1.Text = rpos.ToString("0.000");
                            txtFPOS1.Text = fpos.ToString("0.000");
                            txtFVEL1.Text = fvel.ToString("0.000");
                            txtPE1.Text = pe.ToString("0.000");

                            //---------------- Moving ----------------
                            labelMov1.Image =
                                ((state & MotorStates.ACSC_MST_MOVE) != 0)
                                ? Properties.Resources.On
                                : Properties.Resources.Off;

                            //---------------- Accelerating ----------------
                            labelACC1.Image =
                                ((state & MotorStates.ACSC_MST_ACC) != 0)
                                ? Properties.Resources.On
                                : Properties.Resources.Off;

                            //---------------- In Position ----------------
                            labelPosi1.Image =
                                ((state & MotorStates.ACSC_MST_INPOS) != 0)
                                ? Properties.Resources.On
                                : Properties.Resources.Off;

                            //---------------- Enable / Disable ----------------
                            if ((state & MotorStates.ACSC_MST_ENABLE) != 0)
                            {
                                labelEnable1.Image = Properties.Resources.On;
                                lblstop1.Image = Properties.Resources.Off;
                            }
                            else
                            {
                                labelEnable1.Image = Properties.Resources.Off;
                                lblstop1.Image = Properties.Resources.On;
                            }

                            break;

                        case 2:

                            //---------------- Position ----------------
                            txtRPOS2.Text = rpos.ToString("0.000");
                            txtFPOS2.Text = fpos.ToString("0.000");
                            txtFVEL2.Text = fvel.ToString("0.000");
                            txtPE2.Text = pe.ToString("0.000");

                            //---------------- Moving ----------------
                            labelMov2.Image =
                                ((state & MotorStates.ACSC_MST_MOVE) != 0)
                                ? Properties.Resources.On
                                : Properties.Resources.Off;

                            //---------------- Accelerating ----------------
                            labelACC2.Image =
                                ((state & MotorStates.ACSC_MST_ACC) != 0)
                                ? Properties.Resources.On
                                : Properties.Resources.Off;

                            //---------------- In Position ----------------
                            labelPosi2.Image =
                                ((state & MotorStates.ACSC_MST_INPOS) != 0)
                                ? Properties.Resources.On
                                : Properties.Resources.Off;

                            //---------------- Enable / Disable ----------------
                            if ((state & MotorStates.ACSC_MST_ENABLE) != 0)
                            {
                                labelEnable2.Image = Properties.Resources.On;
                                lblstop2.Image = Properties.Resources.Off;
                            }
                            else
                            {
                                labelEnable2.Image = Properties.Resources.Off;
                                lblstop2.Image = Properties.Resources.On;
                            }

                            break;
                    }
                }
            }
            catch
            {
                // Tránh popup liên tục nếu controller đang bận hoặc mất kết nối
            }
        }
        //------------------------------------------------------------//
        // select communication//
        private void rdoTCP_CheckedChanged(object sender, EventArgs e)
        {
            IPtxt.Enabled = true;
            Porttxt.Enabled = true;
        }

        private void rdoSimu_CheckedChanged(object sender, EventArgs e)
        {
            IPtxt.Enabled = false;
            Porttxt.Enabled = false;
        }

        /// <summary>
        /// // khởi động và dừng tất cả các đông cơ////
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void enbale_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    _ACS.Enable(Axis.ACSC_AXIS_0);
                    _ACS.Enable(Axis.ACSC_AXIS_1);
                    _ACS.Enable(Axis.ACSC_AXIS_2);

                    MessageBox.Show("All axes enabled.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void disable_Click(object sender, EventArgs e)
        {
            try
            {
                if (!m_bConnected)
                {
                    MessageBox.Show("Not connected to ACS.");
                    return;
                }

                _ACS.Disable(Axis.ACSC_AXIS_0);
                _ACS.Disable(Axis.ACSC_AXIS_1);
                _ACS.Disable(Axis.ACSC_AXIS_2);

                MessageBox.Show("All axes disabled.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Disable failed!\n" + ex.Message);
            }
        }


        /// <summary>
        /// ////////Home/////////////////////////////
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// 

        private void btnSethome_Click(object sender, EventArgs e)
        {
            try
            {
                // Tọa độ Home của robot
                currentX = 0;
                currentY = 0;
                currentZ = -937.535;
                MoveXYZ(currentX, currentY, currentZ);
                // Tính động học nghịch
                double[] theta = DeltaKinematics.Inverse(currentX, currentY, currentZ);

                if (theta == null)
                {
                    MessageBox.Show("Không tính được vị trí Home.");
                    return;
                }



                // Chạy robot về Home
                MoveJoint(theta[0], theta[1], theta[2]);
                _ACS.WaitMotionEnd(
    Axis.ACSC_AXIS_0 |
    Axis.ACSC_AXIS_1 |
    Axis.ACSC_AXIS_2,
    10000);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // Try to move to x,y,z; returns true on success
        private bool MoveXYZ(double x, double y, double z)
        {
            stopAllPressed = false;
            STopall_.Image = Properties.Resources.Off;
            double[] theta = DeltaKinematics.Inverse(x, y, z);

            if (theta == null)
            {
                HandleWorkspaceLimitReached();
                return false;
            }

            workspaceError = false;

            currentX = x;
            currentY = y;
            currentZ = z;

            // Cập nhật textbox XYZ
            textBox10.Text = x.ToString("0.000");
            textBox11.Text = y.ToString("0.000");
            textBox12.Text = z.ToString("0.000");

            // Cập nhật textbox Theta
            Giatritheta1.Text = theta[0].ToString("0.000");
            Giatritheta2.Text = theta[1].ToString("0.000");
            Giatritheta3.Text = theta[2].ToString("0.000");

            MoveJoint(theta[0], theta[1], theta[2]);

            WaitMotionDone();

            return true;
        }

        // sharp_mode/////////
        private void cboShape_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboShape.Text)
            {
                case "Circle":
                    DrawCircle();
                    break;

                case "Square":
                    DrawSquare();
                    break;

                case "Triangle":
                    DrawTriangle();
                    break;
            }
        }
        //nội suy hình//
        private void DrawLine(double x1, double y1, double x2, double y2)
        {
            double z = currentZ;

            double step = 2;

            double dx = x2 - x1;
            double dy = y2 - y1;

            double length = Math.Sqrt(dx * dx + dy * dy);

            int n = (int)(length / step);

            if (n < 1)
                n = 1;

            for (int i = 0; i <= n; i++)
            {
                if (cancelMotion)
                    return;

                double t = (double)i / n;

                double x = x1 + dx * t;
                double y = y1 + dy * t;

                MoveXYZ(x, y, z);

                WaitMotionDone();

                Application.DoEvents();
            }
        }

        private void WaitMotionDone()
        {
            while (true)
            {
                if (cancelMotion)
                    return;

                MotorStates s0 = _ACS.GetMotorState(Axis.ACSC_AXIS_0);
                MotorStates s1 = _ACS.GetMotorState(Axis.ACSC_AXIS_1);
                MotorStates s2 = _ACS.GetMotorState(Axis.ACSC_AXIS_2);

                bool moving =
                    ((s0 & MotorStates.ACSC_MST_MOVE) != 0) ||
                    ((s1 & MotorStates.ACSC_MST_MOVE) != 0) ||
                    ((s2 & MotorStates.ACSC_MST_MOVE) != 0);

                if (!moving)
                    break;

                Application.DoEvents();

                Thread.Sleep(5);
            }
        }

        // hình vuông//
        private void DrawSquare()
        {
            cancelMotion = false;

            double size = 80;

            double x1 = -size / 2;
            double y1 = -size / 2;

            double x2 = size / 2;
            double y2 = -size / 2;

            double x3 = size / 2;
            double y3 = size / 2;

            double x4 = -size / 2;
            double y4 = size / 2;

            DrawLine(x1, y1, x2, y2);
            if (cancelMotion) return;

            DrawLine(x2, y2, x3, y3);
            if (cancelMotion) return;

            DrawLine(x3, y3, x4, y4);
            if (cancelMotion) return;

            DrawLine(x4, y4, x1, y1);
            if (cancelMotion) return;

            MessageBox.Show("Square defined");
        }
        //tam giác//
        private void DrawTriangle()
        {
            cancelMotion = false;

            double size = 100;

            double h = Math.Sqrt(3) / 2 * size;

            double x1 = 0;
            double y1 = h / 2;

            double x2 = -size / 2;
            double y2 = -h / 2;

            double x3 = size / 2;
            double y3 = -h / 2;

            DrawLine(x1, y1, x2, y2);
            if (cancelMotion) return;

            DrawLine(x2, y2, x3, y3);
            if (cancelMotion) return;

            DrawLine(x3, y3, x1, y1);
            if (cancelMotion) return;

            MessageBox.Show("Triangle defined");
        }
        // hình tròn//  
        private void DrawCircle()
        {
            cancelMotion = false;

            double radius = 40;
            double z = currentZ;

            for (int i = 0; i <= 360; i += 2)
            {
                if (cancelMotion)
                    return;

                double rad = i * Math.PI / 180.0;

                double x = radius * Math.Cos(rad);
                double y = radius * Math.Sin(rad);

                MoveXYZ(x, y, z);

                WaitMotionDone();

                Application.DoEvents();
            }

            MessageBox.Show("Circle defined");
        }


        ////===============================================================================///
        ////////////Chạy JOG MODE////////////////////////////////////////////////////////
        private void MoveJoint(double t1, double t2, double t3)
        {
            Axis[] axes =
     {
        Axis.ACSC_AXIS_0,
        Axis.ACSC_AXIS_1,
        Axis.ACSC_AXIS_2,
        Axis.ACSC_NONE
    };

            double[] point =
            {
        t1,
        t2,
        t3,
        0
    };

            _ACS.ToPointM(MotionFlags.ACSC_NONE, axes, point);
            _ACS.GoM(axes);
        }
        ///

        private void HandleWorkspaceLimitReached()
        {
            // If already handled, do nothing
            if (workspaceError) return;

            workspaceError = true;

            // Stop any ongoing jog
            StopJog();

            // Show a single notification
            MessageBox.Show("Điểm nằm ngoài vùng làm việc.");
        }

        private void DisableJogButtons()
        {
            string[] names = {
        "dichuyencongX", "dichuyentruX",
        "dichuyencongY", "dichuyentruY",
        "dichuyencongZ", "dichuyentruZ"
    };

            foreach (var n in names)
            {
                var ctrl = this.Controls.Find(n, true).FirstOrDefault() as Control;
                if (ctrl != null) ctrl.Enabled = false;
            }
        }

        private void EnableJogButtons()
        {
            string[] names = {
        "dichuyencongX", "dichuyentruX",
        "dichuyencongY", "dichuyentruY",
        "dichuyencongZ", "dichuyentruZ"
    };

            foreach (var n in names)
            {
                var ctrl = this.Controls.Find(n, true).FirstOrDefault() as Control;
                if (ctrl != null) ctrl.Enabled = true;
            }

            // Clear workspace error so future checks can show again if needed
            workspaceError = false;
        }
        private void JogTimer_Tick(object sender, EventArgs e)
        {
            double step = Convert.ToDouble(txtJogStep.Text);

            double newX = currentX;
            double newY = currentY;
            double newZ = currentZ;

            switch (currentJog)
            {
                case JogDirection.XPlus:
                    newX += step;
                    break;

                case JogDirection.XMinus:
                    newX -= step;
                    break;

                case JogDirection.YPlus:
                    newY += step;
                    break;

                case JogDirection.YMinus:
                    newY -= step;
                    break;

                case JogDirection.ZPlus:
                    newZ += step;
                    break;

                case JogDirection.ZMinus:
                    newZ -= step;
                    break;
            }

            double[] theta = DeltaKinematics.Inverse(newX, newY, newZ);

            if (theta == null)
            {
                jogTimer.Stop();
                currentJog = JogDirection.None;

                MessageBox.Show("Đã tới giới hạn vùng làm việc.");

                return;
            }

            // Chỉ cập nhật khi hợp lệ
            currentX = newX;
            currentY = newY;
            currentZ = newZ;

            MoveXYZ(newX, newY, newZ);
        }
        private void dichuyencongX_MouseDown(object sender, MouseEventArgs e)
        {
            currentJog = JogDirection.XPlus;
            jogTimer.Start();
        }
        private void dichuyencongX_MouseUp(object sender, MouseEventArgs e)
        {
            jogTimer.Stop();
            currentJog = JogDirection.None;
        }
        private void dichuyentruX_MouseDown(object sender, MouseEventArgs e)
        {
            currentJog = JogDirection.XMinus;
            jogTimer.Start();
        }
        private void dichuyentruX_MouseUp(object sender, MouseEventArgs e)
        {
            jogTimer.Stop();
            currentJog = JogDirection.None;
        }
        private void dichuyencongY_MouseDown(object sender, MouseEventArgs e)
        {
            currentJog = JogDirection.YPlus;
            jogTimer.Start();
        }

        private void dichuyencongY_MouseUp(object sender, MouseEventArgs e)
        {
            jogTimer.Stop();
            currentJog = JogDirection.None;
        }
        private void dichuyentruY_MouseDown(object sender, MouseEventArgs e)
        {
            currentJog = JogDirection.YMinus;
            jogTimer.Start();
        }

        private void dichuyentruY_MouseUp(object sender, MouseEventArgs e)
        {
            jogTimer.Stop();
            currentJog = JogDirection.None;
        }
        private void dichuyencongZ_MouseDown(object sender, MouseEventArgs e)
        {
            currentJog = JogDirection.ZPlus;
            jogTimer.Start();
        }

        private void dichuyencongZ_MouseUp(object sender, MouseEventArgs e)
        {
            jogTimer.Stop();
            currentJog = JogDirection.None;
        }
        private void dichuyentruZ_MouseDown(object sender, MouseEventArgs e)
        {
            currentJog = JogDirection.ZMinus;
            jogTimer.Start();
        }

        private void dichuyentruZ_MouseUp(object sender, MouseEventArgs e)
        {
            jogTimer.Stop();
            currentJog = JogDirection.None;
        }

        /// <summary>
        /// Stops any ongoing jog operation and cleans up related resources.
        /// </summary>
        private void StopJog()
        {
            // Reset jog state
            currentJog = JogDirection.None;

            // Stop timer if used for continuous jog updates
            try
            {
                if (jogTimer != null && jogTimer.Enabled)
                    jogTimer.Stop();
            }
            catch { /* ignore timer disposal races */ }

            // Cancel and dispose CancellationTokenSource used by async jog tasks
            if (jogCTS != null)
            {
                try
                {
                    if (!jogCTS.IsCancellationRequested)
                        jogCTS.Cancel();
                }
                catch { }
                finally
                {
                    jogCTS.Dispose();
                    jogCTS = null;
                }
            }

            // Update flag
            jogRunning = false;
        }

        /// <summary>
        /// Designer/event-friendly overload if an event handler signature was wired to StopJog.
        /// </summary>
        private void StopJog(object sender, EventArgs e)
        {
            StopJog();
        }

        private void Jog_MouseUp(object sender, MouseEventArgs e)
        {
            jogTimer.Stop();
            currentJog = JogDirection.None;
        }
        // điền tọa độ góc và vị trí//////////
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                currentX = Convert.ToDouble(textBox10.Text);
                currentY = Convert.ToDouble(textBox11.Text);
                currentZ = Convert.ToDouble(textBox12.Text);

                double[] theta = DeltaKinematics.Inverse(currentX, currentY, currentZ);

                if (theta == null)
                {
                    MessageBox.Show("Điểm nằm ngoài vùng làm việc.");
                    return;
                }

                // Hiển thị góc
                Giatritheta1.Text = theta[0].ToString("F3");
                Giatritheta2.Text = theta[1].ToString("F3");
                Giatritheta3.Text = theta[2].ToString("F3");

                // Chạy ACS
                MoveJoint(theta[0], theta[1], theta[2]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void capnhatgoc_Click(object sender, EventArgs e)
        {
            try
            {
                double t1 = Convert.ToDouble(Giatritheta1.Text);
                double t2 = Convert.ToDouble(Giatritheta2.Text);
                double t3 = Convert.ToDouble(Giatritheta3.Text);

                double[] xyz = DeltaKinematics.Forward(t1, t2, t3);

                if (xyz == null)
                {
                    MessageBox.Show("Điểm nằm ngoài vùng làm việc");
                    return;
                }

                currentX = xyz[0];
                currentY = xyz[1];
                currentZ = xyz[2];

                UpdateXYZTextbox();
                UpdateThetaTextbox(t1, t2, t3);

                // Chạy robot
                MoveJoint(t1, t2, t3);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // STOP all//////////////////
        private void btnHallAll_Click(object sender, EventArgs e)
        {
            try
            {
                // Báo cho tất cả các hàm đang chạy biết phải dừng
                cancelMotion = true;

                // Dừng JOG nếu đang JOG
                StopJog();

                Axis[] axes =
                {
            Axis.ACSC_AXIS_0,
            Axis.ACSC_AXIS_1,
            Axis.ACSC_AXIS_2,
            Axis.ACSC_NONE
        };

                // Dừng chuyển động ngay
                _ACS.HaltM(axes);
                STopall_.Image = Properties.Resources.Error;
                MessageBox.Show("STOP ALL AXIS");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            ;
        }
        // trạng thái các trục///////
        private void UpdateAxisState(
      Axis axis,
      Label lblMoving,
      Label lblAcc,
      Label lblInPos,
      Label lblEnable,
      Label lblDisable)
        {
            try
            {
                MotorStates state = _ACS.GetMotorState(axis);

                //---------------- Moving ----------------
                if ((state & MotorStates.ACSC_MST_MOVE) != 0)
                    lblMoving.Image = Properties.Resources.On;
                else
                    lblMoving.Image = Properties.Resources.Off;

                //---------------- Accelerating ----------------
                if ((state & MotorStates.ACSC_MST_ACC) != 0)
                    lblAcc.Image = Properties.Resources.On;
                else
                    lblAcc.Image = Properties.Resources.Off;

                //---------------- In Position ----------------
                if ((state & MotorStates.ACSC_MST_INPOS) != 0)
                    lblInPos.Image = Properties.Resources.On;
                else
                    lblInPos.Image = Properties.Resources.Off;

                //---------------- Enable ----------------
                if ((state & MotorStates.ACSC_MST_ENABLE) != 0)
                {
                    lblEnable.Image = Properties.Resources.On;
                    lblDisable.Image = Properties.Resources.Off;
                }
                else
                {
                    lblEnable.Image = Properties.Resources.Off;
                    lblDisable.Image = Properties.Resources.On;
                }
            }
            catch
            {

            }
        }
   
    }
    }

