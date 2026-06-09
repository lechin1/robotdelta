using System.Windows.Forms;

namespace Giao_diện_ROBOT
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private Button dichuyentruX;
        private Button dichuyencongX;
        private Button dichuyentruY;
        private Button dichuyencongY;
        private Button dichuyentruZ;
        private Button dichuyencongZ;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        
        private System.Windows.Forms.PictureBox PictureROBOT;
        private System.Windows.Forms.GroupBox Parameter;
        private System.Windows.Forms.RichTextBox txtparameter;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label toadoX;
        private System.Windows.Forms.Label GiatriToadoY;

        // Expose the actual TextBox fields via properties so other code can reference them reliably
        public TextBox GiatritoadoY { get { return textBox1; } }

        private TextBox GiatritoadoZ;
        private System.Windows.Forms.Label ToadoZ;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label theta3;
        private System.Windows.Forms.Label theta2;
        private System.Windows.Forms.Label theta1;

        public TextBox GiatritoadoX { get { return giatritoadoX; } }

        private System.Windows.Forms.Button buttonhome;
        private System.Windows.Forms.Button SelectRB;
        private Label label1;
        private TextBox giatritoadoX;
        private TextBox textBox1;
        private TextBox Giatritheta3;
        private TextBox Giatritheta2;
        private TextBox Giatritheta1;
        private Label label3;
        private Label label2;
        private Button updatetoado;
        private Button capnhatgoc;
        private ContextMenuStrip contextMenuStrip2;
    }
}

