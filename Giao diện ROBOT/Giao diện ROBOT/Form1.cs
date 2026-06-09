using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Giao_diện_ROBOT
{     
    
    public partial class Form1 : Form
    {
        private const string Text = "Connecting to RoboDK ";
        private Mat homePose;
        private RoboDK RDK = null;
        private RoboDK.Item robot = null;
        private object link;
        private Item joints_home;
        // Use the TextBox controls declared in InitializeComponent: giatritoadoX, textBox1, GiatritoadoZ

        // flag to prevent recursive TextChanged handlers when updating controls programmatically
        private bool updatingPosition = false;

        public object DeltaKinematics { get; private set; }

        public Form1()
        {
            InitializeComponent();
            if (System.ComponentModel.LicenseManager.UsageMode == System.ComponentModel.LicenseUsageMode.Designtime)
                return;

        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dichuyentruX = new System.Windows.Forms.Button();
            this.dichuyencongX = new System.Windows.Forms.Button();
            this.dichuyentruY = new System.Windows.Forms.Button();
            this.dichuyencongY = new System.Windows.Forms.Button();
            this.dichuyentruZ = new System.Windows.Forms.Button();
            this.dichuyencongZ = new System.Windows.Forms.Button();
            this.PictureROBOT = new System.Windows.Forms.PictureBox();
            this.Parameter = new System.Windows.Forms.GroupBox();
            this.txtparameter = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.giatritoadoX = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.GiatritoadoZ = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Giatritheta3 = new System.Windows.Forms.TextBox();
            this.Giatritheta2 = new System.Windows.Forms.TextBox();
            this.Giatritheta1 = new System.Windows.Forms.TextBox();
            this.theta3 = new System.Windows.Forms.Label();
            this.theta2 = new System.Windows.Forms.Label();
            this.theta1 = new System.Windows.Forms.Label();
            this.buttonhome = new System.Windows.Forms.Button();
            this.SelectRB = new System.Windows.Forms.Button();
            this.updatetoado = new System.Windows.Forms.Button();
            this.capnhatgoc = new System.Windows.Forms.Button();
            this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.PictureROBOT)).BeginInit();
            this.Parameter.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dichuyentruX
            // 
            this.dichuyentruX.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.dichuyentruX.Location = new System.Drawing.Point(23, 73);
            this.dichuyentruX.Name = "dichuyentruX";
            this.dichuyentruX.Size = new System.Drawing.Size(74, 37);
            this.dichuyentruX.TabIndex = 0;
            this.dichuyentruX.Text = "-X";
            this.dichuyentruX.UseVisualStyleBackColor = true;
            this.dichuyentruX.Click += new System.EventHandler(this.button1_Click);
            // 
            // dichuyencongX
            // 
            this.dichuyencongX.Location = new System.Drawing.Point(128, 73);
            this.dichuyencongX.Name = "dichuyencongX";
            this.dichuyencongX.Size = new System.Drawing.Size(74, 37);
            this.dichuyencongX.TabIndex = 1;
            this.dichuyencongX.Text = "+X";
            this.dichuyencongX.UseVisualStyleBackColor = true;
            this.dichuyencongX.Click += new System.EventHandler(this.dichuyencongX_Click);
            // 
            // dichuyentruY
            // 
            this.dichuyentruY.Location = new System.Drawing.Point(23, 116);
            this.dichuyentruY.Name = "dichuyentruY";
            this.dichuyentruY.Size = new System.Drawing.Size(74, 42);
            this.dichuyentruY.TabIndex = 2;
            this.dichuyentruY.Text = "-Y";
            this.dichuyentruY.UseVisualStyleBackColor = true;
            this.dichuyentruY.Click += new System.EventHandler(this.button3_Click);
            // 
            // dichuyencongY
            // 
            this.dichuyencongY.Location = new System.Drawing.Point(128, 116);
            this.dichuyencongY.Name = "dichuyencongY";
            this.dichuyencongY.Size = new System.Drawing.Size(74, 42);
            this.dichuyencongY.TabIndex = 3;
            this.dichuyencongY.Text = "+Y";
            this.dichuyencongY.UseVisualStyleBackColor = true;
            this.dichuyencongY.Click += new System.EventHandler(this.button4_Click);
            // 
            // dichuyentruZ
            // 
            this.dichuyentruZ.Location = new System.Drawing.Point(23, 164);
            this.dichuyentruZ.Name = "dichuyentruZ";
            this.dichuyentruZ.Size = new System.Drawing.Size(74, 43);
            this.dichuyentruZ.TabIndex = 4;
            this.dichuyentruZ.Text = "-Z";
            this.dichuyentruZ.UseVisualStyleBackColor = true;
            this.dichuyentruZ.Click += new System.EventHandler(this.button5_Click);
            // 
            // dichuyencongZ
            // 
            this.dichuyencongZ.Location = new System.Drawing.Point(128, 164);
            this.dichuyencongZ.Name = "dichuyencongZ";
            this.dichuyencongZ.Size = new System.Drawing.Size(74, 43);
            this.dichuyencongZ.TabIndex = 5;
            this.dichuyencongZ.Text = "+Z";
            this.dichuyencongZ.UseVisualStyleBackColor = true;
            this.dichuyencongZ.Click += new System.EventHandler(this.button6_Click);
            // 
            // PictureROBOT
            // 
            this.PictureROBOT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PictureROBOT.Location = new System.Drawing.Point(226, 18);
            this.PictureROBOT.Name = "PictureROBOT";
            this.PictureROBOT.Size = new System.Drawing.Size(500, 544);
            this.PictureROBOT.TabIndex = 7;
            this.PictureROBOT.TabStop = false;
            // 
            // Parameter
            // 
            this.Parameter.Controls.Add(this.txtparameter);
            this.Parameter.Location = new System.Drawing.Point(752, 18);
            this.Parameter.Name = "Parameter";
            this.Parameter.Size = new System.Drawing.Size(302, 544);
            this.Parameter.TabIndex = 8;
            this.Parameter.TabStop = false;
            this.Parameter.Text = "Parameter";
            this.Parameter.Enter += new System.EventHandler(this.Parameter_Enter);
            // 
            // txtparameter
            // 
            this.txtparameter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtparameter.Location = new System.Drawing.Point(3, 16);
            this.txtparameter.Name = "txtparameter";
            this.txtparameter.Size = new System.Drawing.Size(296, 525);
            this.txtparameter.TabIndex = 0;
            this.txtparameter.Text = "";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.updatetoado);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.giatritoadoX);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.GiatritoadoZ);
            this.groupBox1.Location = new System.Drawing.Point(23, 262);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(178, 135);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Positions";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Z";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 20;
            this.label2.Text = "Y";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "X";
            // 
            // giatritoadoX
            // 
            this.giatritoadoX.Location = new System.Drawing.Point(49, 20);
            this.giatritoadoX.Name = "giatritoadoX";
            this.giatritoadoX.Size = new System.Drawing.Size(100, 20);
            this.giatritoadoX.TabIndex = 4;
            this.giatritoadoX.TextChanged += new System.EventHandler(this.giatritoadoX_TextChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(49, 46);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 3;
            // 
            // GiatritoadoZ
            // 
            this.GiatritoadoZ.Location = new System.Drawing.Point(49, 72);
            this.GiatritoadoZ.Name = "GiatritoadoZ";
            this.GiatritoadoZ.Size = new System.Drawing.Size(100, 20);
            this.GiatritoadoZ.TabIndex = 2;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.capnhatgoc);
            this.groupBox2.Controls.Add(this.Giatritheta3);
            this.groupBox2.Controls.Add(this.Giatritheta2);
            this.groupBox2.Controls.Add(this.Giatritheta1);
            this.groupBox2.Controls.Add(this.theta3);
            this.groupBox2.Controls.Add(this.theta2);
            this.groupBox2.Controls.Add(this.theta1);
            this.groupBox2.Location = new System.Drawing.Point(23, 413);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(178, 146);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Degrees";
            // 
            // Giatritheta3
            // 
            this.Giatritheta3.Location = new System.Drawing.Point(50, 72);
            this.Giatritheta3.Name = "Giatritheta3";
            this.Giatritheta3.Size = new System.Drawing.Size(100, 20);
            this.Giatritheta3.TabIndex = 18;
            // 
            // Giatritheta2
            // 
            this.Giatritheta2.Location = new System.Drawing.Point(50, 46);
            this.Giatritheta2.Name = "Giatritheta2";
            this.Giatritheta2.Size = new System.Drawing.Size(100, 20);
            this.Giatritheta2.TabIndex = 17;
            // 
            // Giatritheta1
            // 
            this.Giatritheta1.Location = new System.Drawing.Point(50, 19);
            this.Giatritheta1.Name = "Giatritheta1";
            this.Giatritheta1.Size = new System.Drawing.Size(100, 20);
            this.Giatritheta1.TabIndex = 5;
            // 
            // theta3
            // 
            this.theta3.AutoSize = true;
            this.theta3.Location = new System.Drawing.Point(4, 73);
            this.theta3.Name = "theta3";
            this.theta3.Size = new System.Drawing.Size(19, 13);
            this.theta3.TabIndex = 16;
            this.theta3.Text = "θ3";
            // 
            // theta2
            // 
            this.theta2.AutoSize = true;
            this.theta2.Location = new System.Drawing.Point(4, 49);
            this.theta2.Name = "theta2";
            this.theta2.Size = new System.Drawing.Size(19, 13);
            this.theta2.TabIndex = 15;
            this.theta2.Text = "θ2";
            // 
            // theta1
            // 
            this.theta1.AutoSize = true;
            this.theta1.Location = new System.Drawing.Point(4, 26);
            this.theta1.Name = "theta1";
            this.theta1.Size = new System.Drawing.Size(19, 13);
            this.theta1.TabIndex = 14;
            this.theta1.Text = "θ1";
            // 
            // buttonhome
            // 
            this.buttonhome.Location = new System.Drawing.Point(23, 213);
            this.buttonhome.Name = "buttonhome";
            this.buttonhome.Size = new System.Drawing.Size(179, 33);
            this.buttonhome.TabIndex = 9;
            this.buttonhome.Text = "Home";
            this.buttonhome.UseVisualStyleBackColor = true;
            this.buttonhome.Click += new System.EventHandler(this.button7_Click);
            // 
            // SelectRB
            // 
            this.SelectRB.Location = new System.Drawing.Point(23, 18);
            this.SelectRB.Name = "SelectRB";
            this.SelectRB.Size = new System.Drawing.Size(179, 32);
            this.SelectRB.TabIndex = 21;
            this.SelectRB.Text = "Select ";
            this.SelectRB.UseMnemonic = false;
            this.SelectRB.UseVisualStyleBackColor = true;
            this.SelectRB.Click += new System.EventHandler(this.button8_Click_1);
            // 
            // updatetoado
            // 
            this.updatetoado.Location = new System.Drawing.Point(49, 98);
            this.updatetoado.Name = "updatetoado";
            this.updatetoado.Size = new System.Drawing.Size(101, 31);
            this.updatetoado.TabIndex = 22;
            this.updatetoado.Text = "Update position";
            this.updatetoado.UseVisualStyleBackColor = true;
            // 
            // capnhatgoc
            // 
            this.capnhatgoc.Location = new System.Drawing.Point(49, 98);
            this.capnhatgoc.Name = "capnhatgoc";
            this.capnhatgoc.Size = new System.Drawing.Size(101, 31);
            this.capnhatgoc.TabIndex = 23;
            this.capnhatgoc.Text = "Update Degrees";
            this.capnhatgoc.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip2
            // 
            this.contextMenuStrip2.Name = "contextMenuStrip2";
            this.contextMenuStrip2.Size = new System.Drawing.Size(61, 4);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1078, 622);
            this.Controls.Add(this.SelectRB);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonhome);
            this.Controls.Add(this.Parameter);
            this.Controls.Add(this.PictureROBOT);
            this.Controls.Add(this.dichuyencongZ);
            this.Controls.Add(this.dichuyentruZ);
            this.Controls.Add(this.dichuyencongY);
            this.Controls.Add(this.dichuyentruY);
            this.Controls.Add(this.dichuyencongX);
            this.Controls.Add(this.dichuyentruX);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PictureROBOT)).EndInit();
            this.Parameter.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }
        public bool Check_RDK()
        {
            // check if the RDK object has been initialised:
            if (RDK == null)
            {
                Console.WriteLine ("RoboDK has not been started");
                return false;
            }

            // Check if the RDK API is connected
            if (!RDK.Connected())
            {
                Console.WriteLine("Connecting to RoboDK...");
                // Attempt to connect to the RDK API
                if (!RDK.Connect())
                {
                    Console.WriteLine("Problems using the RoboDK API. The RoboDK API is not available...");
                    return false;
                }
            }
            return true;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            {
                try
                {
                    InitializeRuntime();
                }
                catch (NotImplementedException)
                {
                    // Log or handle missing implementation and continue
                }

                MessageBox.Show(Text);
            }
            // This will create a new icon in the windows toolbar that shows how we can lock/unlock the application
            //  Setup_Notification_Icon();

            // Start RoboDK here if we want to start it before the Form is displayed
            if (!Check_RDK())
            {
                // RoboDK starts here. We can optionally pass arguments to start it hidden or start it remotely on another computer provided the computer IP.
                // If RoboDK was already running it will just connect to the API. We can force a new RoboDK instance and specify a communication port
                RDK = new RoboDK();

                // Check if RoboDK started properly
                
            }
            MessageBox.Show("RoboDK Connected");
        }

        private void InitializeRuntime()
        {
            throw new NotImplementedException();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MoveXYZ(-10, 0, 0);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            MoveXYZ(0, 0, 10);
        }

        private void Parameter_Enter(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Ensure RDK connection: create and connect if necessary so a single click works
            try
            {
                if (RDK == null)
                {
                    RDK = new RoboDK();
                }

                if (!RDK.Connected())
                {
                    bool ok = RDK.Connect();
                    if (!ok)
                    {
                        MessageBox.Show("RoboDK is not connected.");
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to initialize RoboDK: " + ex.Message);
                return;
            }

            // Delete all TempTarget items created by MoveXYZ
            try
            {
                while (true)
                {
                    RoboDK.Item t = RDK.getItem("TempTarget");
                    if (t == null || !t.Valid())
                        break;
                    t.Delete();
                }
            }
            catch (Exception ex)
            {
                // optional: show or log the error
                Console.WriteLine("Error deleting TempTarget: " + ex.Message);
            }

            // Do not pre-reset the textboxes here. UpdatePosition/UpdateJointAngles will refresh UI after the move.

            // Move robot to Home
            if (robot == null || !robot.Valid())
            {
                MessageBox.Show("Please select a robot first.");
                return;
            }

            try
            {
                // Try to get the robot's configured home joints
                double[] homeJoints = robot.JointsHome();

                if (homeJoints != null && homeJoints.Length > 0)
                {
                    // Move to home joints (blocking)
                    robot.MoveJ(homeJoints);
                    // Wait for the robot to finish moving, then refresh UI
                    try { robot.WaitMove(); } catch { }
                    UpdatePosition();
                    UpdateJointAngles();
                    return;
                }

                // Fallback: try to find a target named "Home"
                RoboDK.Item homeTarget = RDK.getItem("Home");
                if (homeTarget != null && homeTarget.Valid())
                {
                    robot.MoveJ(homeTarget); // MoveJ(Item) uses the target item
                    try { robot.WaitMove(); } catch { }
                    UpdatePosition();
                    UpdateJointAngles();
                    return;
                }

                // Optionally, try other common names
                string[] altNames = { "HOME", "HomePosition", "Home_Target", "HomePose" };
                foreach (var nm in altNames)
                {
                    homeTarget = RDK.getItem(nm);
                    if (homeTarget != null && homeTarget.Valid())
                    {
                        robot.MoveJ(homeTarget);
                        try { robot.WaitMove(); } catch { }
                        UpdatePosition();
                        UpdateJointAngles();
                        return;
                    }
                }

                // No home information found
                MessageBox.Show("No home joints or Home target defined for the selected robot. Define a home in RoboDK (Robot -> Set home position) or create a target named 'Home'.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to move robot to home: " + ex.Message);
            }
        } 
        private void UpdatePosition()
        {
            if (robot == null || !robot.Valid()) return;

            // Get current pose (meters)
            Mat pose = robot.Pose();
            double[] p = pose.Pos(); // p[0]=X, p[1]=Y, p[2]=Z

            try
            {
                // If running on non-UI thread, marshal to UI thread
                if (this.InvokeRequired)
                {
                    this.Invoke(new Action(UpdatePosition));
                    return;
                }

                updatingPosition = true;
                // Update the actual TextBox controls created in InitializeComponent
                try { giatritoadoX.Text = p[0].ToString("F3"); } catch { }
                try { textBox1.Text = p[1].ToString("F3"); } catch { }
                try { GiatritoadoZ.Text = p[2].ToString("F3"); } catch { }
            }
            catch
            {
                // handle UI update failures silently or log them
            }
            finally
            {
                updatingPosition = false;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dichuyencongX_Click(object sender, EventArgs e)
        {
            MoveXYZ(10, 0, 0);

        }

        private void button3_Click(object sender, EventArgs e)
        {
            MoveXYZ(0, -10, 0);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            MoveXYZ(0, 10, 0);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            MoveXYZ(0, 0, -10);

        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            RDK = new RoboDK();

            bool ok = RDK.Connect();

            MessageBox.Show(ok.ToString());
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "RoboDK Files (*.rdk;*.robot)|*.rdk;*.robot|All Files (*.*)|*.*";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                RDK.AddFile(dlg.FileName);

                robot = RDK.ItemUserPick("Select Robot"); // no cast

                if (robot == null || !robot.Valid())
                {
                    MessageBox.Show("Robot Not Found");
                    return;
                }

                MessageBox.Show("Robot Connected");
            }

        }
        private void MoveXYZ(double dx, double dy, double dz)
        {

            if (robot == null || !robot.Valid())
            {
                MessageBox.Show("Please select a robot first");
                return;
            }

            Mat pose = robot.Pose();

            double[] p = pose.Pos();

            pose.setPos(new double[]
            {
        p[0] + dx,
        p[1] + dy,
        p[2] + dz
            });

            // Create a target using the RoboDK.Item type and use it directly
            RoboDK.Item target = RDK.AddTarget("TempTarget");
            target.setPose(pose);
            robot.MoveL(target);

            // Update UI with pose and joint values
            UpdatePosition();
            UpdateJointAngles();

            // Also compute Delta kinematics angles (DeltaKinematics expects mm)
            try
            {
                Mat newPose = robot.Pose();
                double[] pp = newPose.Pos(); // in meters
                // convert to mm for local DeltaKinematics implementation
                double x_mm = pp[0] * 1000.0;
                double y_mm = pp[1] * 1000.0;
                double z_mm = pp[2] * 1000.0;
                double[] deltaAngles = RobotDelta.DeltaKinematics.Inverse(x_mm, y_mm, z_mm);
                if (deltaAngles != null && deltaAngles.Length == 3)
                {
                    try { Giatritheta1.Text = deltaAngles[0].ToString("F2"); } catch { }
                    try { Giatritheta2.Text = deltaAngles[1].ToString("F2"); } catch { }
                    try { Giatritheta3.Text = deltaAngles[2].ToString("F2"); } catch { }
                }
            }
            catch
            {
                // ignore diagnostics here
            }
        }
        private void UpdateJointAngles()
        {
            if (robot == null)
                return;

            double[] joints = robot.Joints();
            if (joints == null || joints.Length < 3)
                return;

            // Update the degree labels (theta1/2/3) and the angle textboxes (Giatritheta1/2/3)
           
            try { Giatritheta1.Text = joints[0].ToString("F2"); } catch { }
            try { Giatritheta2.Text = joints[1].ToString("F2"); } catch { }
            try { Giatritheta3.Text = joints[2].ToString("F2"); } catch { }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void giatritoadoX_TextChanged(object sender, EventArgs e)
        {
            // Ignore TextChanged events triggered by programmatic updates
            if (updatingPosition) return;

            if (robot == null || !robot.Valid()) return;

            // If user edits the X textbox manually, you may want to parse and move the robot.
            // For now, just refresh the displayed position from the robot to keep values consistent.
            UpdatePosition();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {

        }
    }
    }
       
        

    
