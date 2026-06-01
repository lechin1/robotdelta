using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RoboDk.API;

namespace Giao_diện_ROBOT
{           
    public partial class Form1 : Form
    {
        RoboDK RDK = new RoboDK();
        Item robot;
        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.PictureROBOT = new System.Windows.Forms.PictureBox();
            this.Parameter = new System.Windows.Forms.GroupBox();
            this.txtparameter = new System.Windows.Forms.RichTextBox();
            this.buttonhome = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toadoX = new System.Windows.Forms.Label();
            this.ToadoY = new System.Windows.Forms.Label();
            this.ToadoZ = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.theta3 = new System.Windows.Forms.Label();
            this.theta2 = new System.Windows.Forms.Label();
            this.theta1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PictureROBOT)).BeginInit();
            this.Parameter.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button1.Location = new System.Drawing.Point(19, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(74, 65);
            this.button1.TabIndex = 0;
            this.button1.Text = "-X";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(127, 18);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(74, 65);
            this.button2.TabIndex = 1;
            this.button2.Text = "+X";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(19, 101);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(74, 65);
            this.button3.TabIndex = 2;
            this.button3.Text = "-Y";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(127, 101);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(74, 65);
            this.button4.TabIndex = 3;
            this.button4.Text = "+Y";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(24, 185);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(71, 65);
            this.button5.TabIndex = 4;
            this.button5.Text = "-Z";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(127, 185);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(74, 65);
            this.button6.TabIndex = 5;
            this.button6.Text = "+Z";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
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
            // buttonhome
            // 
            this.buttonhome.Location = new System.Drawing.Point(24, 271);
            this.buttonhome.Name = "buttonhome";
            this.buttonhome.Size = new System.Drawing.Size(179, 54);
            this.buttonhome.TabIndex = 9;
            this.buttonhome.Text = "Home";
            this.buttonhome.UseVisualStyleBackColor = true;
            this.buttonhome.Click += new System.EventHandler(this.button7_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // toadoX
            // 
            this.toadoX.AutoSize = true;
            this.toadoX.Location = new System.Drawing.Point(4, 26);
            this.toadoX.Name = "toadoX";
            this.toadoX.Size = new System.Drawing.Size(23, 13);
            this.toadoX.TabIndex = 14;
            this.toadoX.Text = "X:0";
            // 
            // ToadoY
            // 
            this.ToadoY.AutoSize = true;
            this.ToadoY.Location = new System.Drawing.Point(4, 49);
            this.ToadoY.Name = "ToadoY";
            this.ToadoY.Size = new System.Drawing.Size(23, 13);
            this.ToadoY.TabIndex = 15;
            this.ToadoY.Text = "Y:0";
            this.ToadoY.Click += new System.EventHandler(this.label3_Click);
            // 
            // ToadoZ
            // 
            this.ToadoZ.AutoSize = true;
            this.ToadoZ.Location = new System.Drawing.Point(4, 73);
            this.ToadoZ.Name = "ToadoZ";
            this.ToadoZ.Size = new System.Drawing.Size(23, 13);
            this.ToadoZ.TabIndex = 16;
            this.ToadoZ.Text = "Z:0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 501);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Z:0";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ToadoZ);
            this.groupBox1.Controls.Add(this.ToadoY);
            this.groupBox1.Controls.Add(this.toadoX);
            this.groupBox1.Location = new System.Drawing.Point(25, 349);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(178, 98);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Positions";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.theta3);
            this.groupBox2.Controls.Add(this.theta2);
            this.groupBox2.Controls.Add(this.theta1);
            this.groupBox2.Location = new System.Drawing.Point(24, 464);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(178, 98);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Degrees";
            // 
            // theta3
            // 
            this.theta3.AutoSize = true;
            this.theta3.Location = new System.Drawing.Point(4, 73);
            this.theta3.Name = "theta3";
            this.theta3.Size = new System.Drawing.Size(28, 13);
            this.theta3.TabIndex = 16;
            this.theta3.Text = "θ3:0";
            // 
            // theta2
            // 
            this.theta2.AutoSize = true;
            this.theta2.Location = new System.Drawing.Point(4, 49);
            this.theta2.Name = "theta2";
            this.theta2.Size = new System.Drawing.Size(28, 13);
            this.theta2.TabIndex = 15;
            this.theta2.Text = "θ2:0";
            // 
            // theta1
            // 
            this.theta1.AutoSize = true;
            this.theta1.Location = new System.Drawing.Point(4, 26);
            this.theta1.Name = "theta1";
            this.theta1.Size = new System.Drawing.Size(28, 13);
            this.theta1.TabIndex = 14;
            this.theta1.Text = "θ1:0";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1082, 618);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.buttonhome);
            this.Controls.Add(this.Parameter);
            this.Controls.Add(this.PictureROBOT);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PictureROBOT)).EndInit();
            this.Parameter.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            var robot = RDK.getItem("");

            MessageBox.Show("Test");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Di chuyển -X");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Di chuyển +Z");
        }

        private void Parameter_Enter(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

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

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Di chuyển +X");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Di chuyển -Y");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Di chuyển +Y");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Di chuyển -Z");
        }
    }
}
