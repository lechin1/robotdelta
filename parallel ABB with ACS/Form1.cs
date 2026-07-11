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
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace parallel_ABB_with_ACS
{
    public partial class Form1 : Form
    {

        private CancellationTokenSource jogCTS;
        private bool jogRunning = false;
        private Api _ACS;
        private bool m_bConnected = false;
        private int m_nTotalAxis = 0;
        private int m_nTotalBuffer = 0;
        private Axis[] m_arrAxisList = null;
        private System.Windows.Forms.ComboBox cboAxisNo;
        private bool workspaceError = false;
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

                strTemp = _ACS.Transaction("?SYSINFO(10)");
                m_nTotalBuffer = Convert.ToInt32(strTemp.Trim());
                for (i = 0; i < m_nTotalBuffer; i++)
                {
                    ((ComboBox)cboBufferNo).Items.Add(i.ToString());
                }
                ((ComboBox)cboBufferNo).SelectedIndex = 0;

                btnOpen.Enabled = false;
                btnClose.Enabled = true;

                // Set updating timer
                tmrMonitor.Interval = 50;
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
            jogTimer = new System.Windows.Forms.Timer();
            jogTimer.Interval = 30;      // 30ms
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

        private void UpdateProfile()
        {
            if (m_bConnected)
            {
                txtVel.Text = _ACS.GetVelocity((Axis)cboAxisNo.SelectedIndex).ToString();
                txtAcc.Text = _ACS.GetAcceleration((Axis)cboAxisNo.SelectedIndex).ToString();
                txtDec.Text = _ACS.GetDeceleration((Axis)cboAxisNo.SelectedIndex).ToString();
                txtKdec.Text = _ACS.GetKillDeceleration((Axis)cboAxisNo.SelectedIndex).ToString();
                txtJerk.Text = _ACS.GetJerk((Axis)cboAxisNo.SelectedIndex).ToString();
            }
        }
        // chua xử lý ---------------------------------------------------//
        private void tmrMonitor_Tick(object sender, EventArgs e)
        {
            // Get selected axis number
            int iAxisNo = cboAxisNo.SelectedIndex;
            // Get selected buffer number
            int iBufferNo = cboBufferNo.SelectedIndex;

            // If previously disabled due to workspace limit, re-enable when current position is valid again
            if (workspaceError)
            {
                double[] theta = DeltaKinematics.Inverse(currentX, currentY, currentZ);
                if (theta != null)
                {
                    EnableJogButtons();
                }
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
        private void cboAxisNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateProfile();
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

        ////===============================================================================///
        ////////////Chạy JOG MODE////////////////////////////////////////////////////////
        private void MoveJoint(double t1, double t2, double t3)
        {
            Axis[] axes = {
                Axis.ACSC_AXIS_0,
                Axis.ACSC_AXIS_1,
                Axis.ACSC_AXIS_2,
                Axis.ACSC_NONE   // terminator required by multi-axis API
            };

            double[] point = {
                t1,
                t2,
                t3,
                0.0 // dummy for terminator slot
            };

            _ACS.ToPointM(MotionFlags.ACSC_AMF_WAIT, axes, point);
            _ACS.GoM(axes);
        }
        // Try to move to x,y,z; returns true on success
        private bool MoveXYZ(double x, double y, double z)
        {
            double[] theta = DeltaKinematics.Inverse(x, y, z);

            if (theta == null)
            {
                // Handle workspace limit once and prevent further jog clicks
                HandleWorkspaceLimitReached();
                return false;
            }
            
            workspaceError = false;

            MoveJoint(theta[0], theta[1], theta[2]);

            return true;
        }

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

            MoveJoint(theta[0], theta[1], theta[2]);
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

       
    }
}

