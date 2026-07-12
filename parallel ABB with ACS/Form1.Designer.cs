namespace parallel_ABB_with_ACS
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private bool stopAll = false;
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.enbale = new System.Windows.Forms.Button();
            this.Communication_set = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.Porttxt = new System.Windows.Forms.TextBox();
            this.IPtxt = new System.Windows.Forms.TextBox();
            this.POrtlabel1 = new System.Windows.Forms.Label();
            this.IPlabel1 = new System.Windows.Forms.Label();
            this.rdoSimu = new System.Windows.Forms.RadioButton();
            this.rdoTCP = new System.Windows.Forms.RadioButton();
            this.grpParameters = new System.Windows.Forms.GroupBox();
            this.txtPE2 = new System.Windows.Forms.TextBox();
            this.txtPE1 = new System.Windows.Forms.TextBox();
            this.txtFVEL2 = new System.Windows.Forms.TextBox();
            this.txtPE0 = new System.Windows.Forms.TextBox();
            this.txtFVEL1 = new System.Windows.Forms.TextBox();
            this.txtFVEL0 = new System.Windows.Forms.TextBox();
            this.TXTPOSAX2 = new System.Windows.Forms.Label();
            this.TXTPOSAX1 = new System.Windows.Forms.Label();
            this.Po_err_AX0 = new System.Windows.Forms.Label();
            this.txtFPOS2 = new System.Windows.Forms.TextBox();
            this.txtFPOS1 = new System.Windows.Forms.TextBox();
            this.TXTPOSAX0 = new System.Windows.Forms.Label();
            this.AC_AX0 = new System.Windows.Forms.Label();
            this.txtRPOS2 = new System.Windows.Forms.TextBox();
            this.txtFPOS0 = new System.Windows.Forms.TextBox();
            this.txtRPOS1 = new System.Windows.Forms.TextBox();
            this.FB_PO_AX0 = new System.Windows.Forms.Label();
            this.txtRPOS0 = new System.Windows.Forms.TextBox();
            this.Po_ax0 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.capnhatgoc = new System.Windows.Forms.Button();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.theta1 = new System.Windows.Forms.Label();
            this.Giatritheta1 = new System.Windows.Forms.TextBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.Giatritheta2 = new System.Windows.Forms.TextBox();
            this.theta2 = new System.Windows.Forms.Label();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.Giatritheta3 = new System.Windows.Forms.TextBox();
            this.theta3 = new System.Windows.Forms.Label();
            this.btnHallAll = new System.Windows.Forms.Button();
            this.btnSethome = new System.Windows.Forms.Button();
            this.grpSpeed = new System.Windows.Forms.GroupBox();
            this.txtJerk = new System.Windows.Forms.TextBox();
            this.txtKdec = new System.Windows.Forms.TextBox();
            this.txtDec = new System.Windows.Forms.TextBox();
            this.txtAcc = new System.Windows.Forms.TextBox();
            this.txtVel = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Status_lb = new System.Windows.Forms.GroupBox();
            this.lblPRG_Status = new System.Windows.Forms.Label();
            this.lblstop2 = new System.Windows.Forms.Label();
            this.lblstop1 = new System.Windows.Forms.Label();
            this.lblstop0 = new System.Windows.Forms.Label();
            this.labelEnable2 = new System.Windows.Forms.Label();
            this.labelACC2 = new System.Windows.Forms.Label();
            this.labelPosi2 = new System.Windows.Forms.Label();
            this.labelMov2 = new System.Windows.Forms.Label();
            this.labelEnable1 = new System.Windows.Forms.Label();
            this.labelACC1 = new System.Windows.Forms.Label();
            this.labelPosi1 = new System.Windows.Forms.Label();
            this.labelMov1 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.labelEnable0 = new System.Windows.Forms.Label();
            this.labelACC0 = new System.Windows.Forms.Label();
            this.labelPosi0 = new System.Windows.Forms.Label();
            this.labelMov0 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.grpJog = new System.Windows.Forms.GroupBox();
            this.Value_JOG = new System.Windows.Forms.Label();
            this.txtJogStep = new System.Windows.Forms.TextBox();
            this.dichuyentruX = new System.Windows.Forms.Button();
            this.dichuyentruY = new System.Windows.Forms.Button();
            this.dichuyentruZ = new System.Windows.Forms.Button();
            this.dichuyencongX = new System.Windows.Forms.Button();
            this.dichuyencongY = new System.Windows.Forms.Button();
            this.dichuyencongZ = new System.Windows.Forms.Button();
            this.Sharpemodepositions = new System.Windows.Forms.GroupBox();
            this.cboShape = new System.Windows.Forms.ComboBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.GiatritoadoZ = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.giatritoadoX = new System.Windows.Forms.TextBox();
            this.updatetoado = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.STopall_ = new System.Windows.Forms.Label();
            this.Communication_set.SuspendLayout();
            this.grpParameters.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox12.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.groupBox14.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.grpSpeed.SuspendLayout();
            this.Status_lb.SuspendLayout();
            this.grpJog.SuspendLayout();
            this.Sharpemodepositions.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // enbale
            // 
            this.enbale.Location = new System.Drawing.Point(253, 20);
            this.enbale.Name = "enbale";
            this.enbale.Size = new System.Drawing.Size(127, 32);
            this.enbale.TabIndex = 43;
            this.enbale.Text = "enable all";
            this.enbale.UseVisualStyleBackColor = true;
            this.enbale.Click += new System.EventHandler(this.enbale_Click);
            // 
            // Communication_set
            // 
            this.Communication_set.Controls.Add(this.btnClose);
            this.Communication_set.Controls.Add(this.btnOpen);
            this.Communication_set.Controls.Add(this.Porttxt);
            this.Communication_set.Controls.Add(this.IPtxt);
            this.Communication_set.Controls.Add(this.POrtlabel1);
            this.Communication_set.Controls.Add(this.IPlabel1);
            this.Communication_set.Controls.Add(this.rdoSimu);
            this.Communication_set.Controls.Add(this.rdoTCP);
            this.Communication_set.Location = new System.Drawing.Point(12, 12);
            this.Communication_set.Name = "Communication_set";
            this.Communication_set.Size = new System.Drawing.Size(223, 113);
            this.Communication_set.TabIndex = 0;
            this.Communication_set.TabStop = false;
            this.Communication_set.Text = "Communication Setting";
            // 
            // btnClose
            // 
            this.btnClose.Enabled = false;
            this.btnClose.Location = new System.Drawing.Point(118, 68);
            this.btnClose.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(96, 37);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Disconnect";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(6, 69);
            this.btnOpen.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(96, 37);
            this.btnOpen.TabIndex = 8;
            this.btnOpen.Text = "Connect";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // Porttxt
            // 
            this.Porttxt.Enabled = false;
            this.Porttxt.Location = new System.Drawing.Point(118, 44);
            this.Porttxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Porttxt.Name = "Porttxt";
            this.Porttxt.Size = new System.Drawing.Size(96, 20);
            this.Porttxt.TabIndex = 7;
            this.Porttxt.Text = "701";
            // 
            // IPtxt
            // 
            this.IPtxt.Enabled = false;
            this.IPtxt.Location = new System.Drawing.Point(118, 20);
            this.IPtxt.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.IPtxt.Name = "IPtxt";
            this.IPtxt.Size = new System.Drawing.Size(96, 20);
            this.IPtxt.TabIndex = 5;
            this.IPtxt.Text = "10.0.0.100";
            // 
            // POrtlabel1
            // 
            this.POrtlabel1.AutoSize = true;
            this.POrtlabel1.Location = new System.Drawing.Point(95, 46);
            this.POrtlabel1.Name = "POrtlabel1";
            this.POrtlabel1.Size = new System.Drawing.Size(26, 13);
            this.POrtlabel1.TabIndex = 4;
            this.POrtlabel1.Text = "Port";
            // 
            // IPlabel1
            // 
            this.IPlabel1.AutoSize = true;
            this.IPlabel1.Location = new System.Drawing.Point(95, 23);
            this.IPlabel1.Name = "IPlabel1";
            this.IPlabel1.Size = new System.Drawing.Size(17, 13);
            this.IPlabel1.TabIndex = 3;
            this.IPlabel1.Text = "IP";
            // 
            // rdoSimu
            // 
            this.rdoSimu.AutoSize = true;
            this.rdoSimu.Location = new System.Drawing.Point(6, 42);
            this.rdoSimu.Name = "rdoSimu";
            this.rdoSimu.Size = new System.Drawing.Size(68, 17);
            this.rdoSimu.TabIndex = 2;
            this.rdoSimu.TabStop = true;
            this.rdoSimu.Text = "Simulator";
            this.rdoSimu.UseVisualStyleBackColor = true;
            // 
            // rdoTCP
            // 
            this.rdoTCP.AutoSize = true;
            this.rdoTCP.Location = new System.Drawing.Point(6, 19);
            this.rdoTCP.Name = "rdoTCP";
            this.rdoTCP.Size = new System.Drawing.Size(46, 17);
            this.rdoTCP.TabIndex = 1;
            this.rdoTCP.TabStop = true;
            this.rdoTCP.Text = "TCP";
            this.rdoTCP.UseVisualStyleBackColor = true;
            this.rdoTCP.CheckedChanged += new System.EventHandler(this.rdoTCP_CheckedChanged);
            // 
            // grpParameters
            // 
            this.grpParameters.Controls.Add(this.txtPE2);
            this.grpParameters.Controls.Add(this.txtPE1);
            this.grpParameters.Controls.Add(this.txtFVEL2);
            this.grpParameters.Controls.Add(this.txtPE0);
            this.grpParameters.Controls.Add(this.txtFVEL1);
            this.grpParameters.Controls.Add(this.txtFVEL0);
            this.grpParameters.Controls.Add(this.TXTPOSAX2);
            this.grpParameters.Controls.Add(this.TXTPOSAX1);
            this.grpParameters.Controls.Add(this.Po_err_AX0);
            this.grpParameters.Controls.Add(this.txtFPOS2);
            this.grpParameters.Controls.Add(this.txtFPOS1);
            this.grpParameters.Controls.Add(this.TXTPOSAX0);
            this.grpParameters.Controls.Add(this.AC_AX0);
            this.grpParameters.Controls.Add(this.txtRPOS2);
            this.grpParameters.Controls.Add(this.txtFPOS0);
            this.grpParameters.Controls.Add(this.txtRPOS1);
            this.grpParameters.Controls.Add(this.FB_PO_AX0);
            this.grpParameters.Controls.Add(this.txtRPOS0);
            this.grpParameters.Controls.Add(this.Po_ax0);
            this.grpParameters.Location = new System.Drawing.Point(12, 184);
            this.grpParameters.Name = "grpParameters";
            this.grpParameters.Size = new System.Drawing.Size(580, 107);
            this.grpParameters.TabIndex = 2;
            this.grpParameters.TabStop = false;
            this.grpParameters.Text = "Parameters";
            // 
            // txtPE2
            // 
            this.txtPE2.Location = new System.Drawing.Point(458, 71);
            this.txtPE2.Name = "txtPE2";
            this.txtPE2.ReadOnly = true;
            this.txtPE2.Size = new System.Drawing.Size(115, 20);
            this.txtPE2.TabIndex = 6;
            this.txtPE2.Text = "0.000";
            this.txtPE2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtPE1
            // 
            this.txtPE1.Location = new System.Drawing.Point(458, 49);
            this.txtPE1.Name = "txtPE1";
            this.txtPE1.ReadOnly = true;
            this.txtPE1.Size = new System.Drawing.Size(115, 20);
            this.txtPE1.TabIndex = 6;
            this.txtPE1.Text = "0.000";
            this.txtPE1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtFVEL2
            // 
            this.txtFVEL2.Location = new System.Drawing.Point(338, 72);
            this.txtFVEL2.Name = "txtFVEL2";
            this.txtFVEL2.ReadOnly = true;
            this.txtFVEL2.Size = new System.Drawing.Size(115, 20);
            this.txtFVEL2.TabIndex = 6;
            this.txtFVEL2.Text = "0.000";
            this.txtFVEL2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtPE0
            // 
            this.txtPE0.Location = new System.Drawing.Point(458, 23);
            this.txtPE0.Name = "txtPE0";
            this.txtPE0.ReadOnly = true;
            this.txtPE0.Size = new System.Drawing.Size(116, 20);
            this.txtPE0.TabIndex = 6;
            this.txtPE0.Text = "0.000";
            this.txtPE0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtFVEL1
            // 
            this.txtFVEL1.Location = new System.Drawing.Point(338, 49);
            this.txtFVEL1.Name = "txtFVEL1";
            this.txtFVEL1.ReadOnly = true;
            this.txtFVEL1.Size = new System.Drawing.Size(115, 20);
            this.txtFVEL1.TabIndex = 6;
            this.txtFVEL1.Text = "0.000";
            this.txtFVEL1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtFVEL0
            // 
            this.txtFVEL0.Location = new System.Drawing.Point(338, 26);
            this.txtFVEL0.Name = "txtFVEL0";
            this.txtFVEL0.ReadOnly = true;
            this.txtFVEL0.Size = new System.Drawing.Size(116, 20);
            this.txtFVEL0.TabIndex = 6;
            this.txtFVEL0.Text = "0.000";
            this.txtFVEL0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TXTPOSAX2
            // 
            this.TXTPOSAX2.AutoSize = true;
            this.TXTPOSAX2.Location = new System.Drawing.Point(7, 82);
            this.TXTPOSAX2.Name = "TXTPOSAX2";
            this.TXTPOSAX2.Size = new System.Drawing.Size(70, 13);
            this.TXTPOSAX2.TabIndex = 47;
            this.TXTPOSAX2.Text = "Position AX.2";
            // 
            // TXTPOSAX1
            // 
            this.TXTPOSAX1.AutoSize = true;
            this.TXTPOSAX1.Location = new System.Drawing.Point(7, 56);
            this.TXTPOSAX1.Name = "TXTPOSAX1";
            this.TXTPOSAX1.Size = new System.Drawing.Size(70, 13);
            this.TXTPOSAX1.TabIndex = 46;
            this.TXTPOSAX1.Text = "Position AX.1";
            // 
            // Po_err_AX0
            // 
            this.Po_err_AX0.AutoSize = true;
            this.Po_err_AX0.Location = new System.Drawing.Point(475, 10);
            this.Po_err_AX0.Name = "Po_err_AX0";
            this.Po_err_AX0.Size = new System.Drawing.Size(72, 13);
            this.Po_err_AX0.TabIndex = 5;
            this.Po_err_AX0.Text = "Position Error ";
            // 
            // txtFPOS2
            // 
            this.txtFPOS2.Location = new System.Drawing.Point(216, 71);
            this.txtFPOS2.Name = "txtFPOS2";
            this.txtFPOS2.ReadOnly = true;
            this.txtFPOS2.Size = new System.Drawing.Size(115, 20);
            this.txtFPOS2.TabIndex = 6;
            this.txtFPOS2.Text = "0.000";
            this.txtFPOS2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtFPOS1
            // 
            this.txtFPOS1.Location = new System.Drawing.Point(216, 49);
            this.txtFPOS1.Name = "txtFPOS1";
            this.txtFPOS1.ReadOnly = true;
            this.txtFPOS1.Size = new System.Drawing.Size(115, 20);
            this.txtFPOS1.TabIndex = 6;
            this.txtFPOS1.Text = "0.000";
            this.txtFPOS1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TXTPOSAX0
            // 
            this.TXTPOSAX0.AutoSize = true;
            this.TXTPOSAX0.Location = new System.Drawing.Point(7, 33);
            this.TXTPOSAX0.Name = "TXTPOSAX0";
            this.TXTPOSAX0.Size = new System.Drawing.Size(70, 13);
            this.TXTPOSAX0.TabIndex = 45;
            this.TXTPOSAX0.Text = "Position AX.0";
            // 
            // AC_AX0
            // 
            this.AC_AX0.AutoSize = true;
            this.AC_AX0.Location = new System.Drawing.Point(361, 10);
            this.AC_AX0.Name = "AC_AX0";
            this.AC_AX0.Size = new System.Drawing.Size(80, 13);
            this.AC_AX0.TabIndex = 5;
            this.AC_AX0.Text = "Actual Velocity ";
            // 
            // txtRPOS2
            // 
            this.txtRPOS2.Location = new System.Drawing.Point(95, 71);
            this.txtRPOS2.Name = "txtRPOS2";
            this.txtRPOS2.ReadOnly = true;
            this.txtRPOS2.Size = new System.Drawing.Size(115, 20);
            this.txtRPOS2.TabIndex = 6;
            this.txtRPOS2.Text = "0.000";
            this.txtRPOS2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtFPOS0
            // 
            this.txtFPOS0.Location = new System.Drawing.Point(216, 26);
            this.txtFPOS0.Name = "txtFPOS0";
            this.txtFPOS0.ReadOnly = true;
            this.txtFPOS0.Size = new System.Drawing.Size(116, 20);
            this.txtFPOS0.TabIndex = 6;
            this.txtFPOS0.Text = "0.000";
            this.txtFPOS0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtRPOS1
            // 
            this.txtRPOS1.Location = new System.Drawing.Point(95, 49);
            this.txtRPOS1.Name = "txtRPOS1";
            this.txtRPOS1.ReadOnly = true;
            this.txtRPOS1.Size = new System.Drawing.Size(116, 20);
            this.txtRPOS1.TabIndex = 6;
            this.txtRPOS1.Text = "0.000";
            this.txtRPOS1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // FB_PO_AX0
            // 
            this.FB_PO_AX0.AutoSize = true;
            this.FB_PO_AX0.Location = new System.Drawing.Point(230, 10);
            this.FB_PO_AX0.Name = "FB_PO_AX0";
            this.FB_PO_AX0.Size = new System.Drawing.Size(76, 13);
            this.FB_PO_AX0.TabIndex = 5;
            this.FB_PO_AX0.Text = "Feedback Pos";
            // 
            // txtRPOS0
            // 
            this.txtRPOS0.Location = new System.Drawing.Point(96, 26);
            this.txtRPOS0.Name = "txtRPOS0";
            this.txtRPOS0.ReadOnly = true;
            this.txtRPOS0.Size = new System.Drawing.Size(116, 20);
            this.txtRPOS0.TabIndex = 6;
            this.txtRPOS0.Text = "0.000";
            this.txtRPOS0.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Po_ax0
            // 
            this.Po_ax0.AutoSize = true;
            this.Po_ax0.Location = new System.Drawing.Point(120, 10);
            this.Po_ax0.Name = "Po_ax0";
            this.Po_ax0.Size = new System.Drawing.Size(50, 13);
            this.Po_ax0.TabIndex = 5;
            this.Po_ax0.Text = " Position ";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(253, 59);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(126, 30);
            this.button3.TabIndex = 44;
            this.button3.Text = "disable all";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.disable_Click);
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.button2);
            this.groupBox11.Controls.Add(this.groupBox12);
            this.groupBox11.Controls.Add(this.groupBox13);
            this.groupBox11.Controls.Add(this.groupBox14);
            this.groupBox11.Location = new System.Drawing.Point(12, 297);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(580, 58);
            this.groupBox11.TabIndex = 22;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "Positions";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(466, 17);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(108, 34);
            this.button2.TabIndex = 22;
            this.button2.Text = "Update position";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.textBox10);
            this.groupBox12.Controls.Add(this.label9);
            this.groupBox12.Location = new System.Drawing.Point(10, 11);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(143, 40);
            this.groupBox12.TabIndex = 23;
            this.groupBox12.TabStop = false;
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(14, 14);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(123, 20);
            this.textBox10.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(-1, 17);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "X";
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.textBox11);
            this.groupBox13.Controls.Add(this.label10);
            this.groupBox13.Location = new System.Drawing.Point(159, 11);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(143, 40);
            this.groupBox13.TabIndex = 0;
            this.groupBox13.TabStop = false;
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(14, 13);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(123, 20);
            this.textBox11.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(-3, 17);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(14, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "Y";
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.label11);
            this.groupBox14.Controls.Add(this.textBox12);
            this.groupBox14.Location = new System.Drawing.Point(313, 11);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(144, 40);
            this.groupBox14.TabIndex = 0;
            this.groupBox14.TabStop = false;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(-2, 17);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(14, 13);
            this.label11.TabIndex = 21;
            this.label11.Text = "Z";
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(14, 14);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(124, 20);
            this.textBox12.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.capnhatgoc);
            this.groupBox3.Controls.Add(this.groupBox7);
            this.groupBox3.Controls.Add(this.groupBox8);
            this.groupBox3.Controls.Add(this.groupBox9);
            this.groupBox3.Location = new System.Drawing.Point(12, 361);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(580, 66);
            this.groupBox3.TabIndex = 21;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Degrees";
            // 
            // capnhatgoc
            // 
            this.capnhatgoc.Location = new System.Drawing.Point(466, 19);
            this.capnhatgoc.Name = "capnhatgoc";
            this.capnhatgoc.Size = new System.Drawing.Size(108, 35);
            this.capnhatgoc.TabIndex = 23;
            this.capnhatgoc.Text = "Update Degrees";
            this.capnhatgoc.UseVisualStyleBackColor = true;
            this.capnhatgoc.Click += new System.EventHandler(this.capnhatgoc_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.theta1);
            this.groupBox7.Controls.Add(this.Giatritheta1);
            this.groupBox7.Location = new System.Drawing.Point(6, 15);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(143, 39);
            this.groupBox7.TabIndex = 24;
            this.groupBox7.TabStop = false;
            // 
            // theta1
            // 
            this.theta1.AutoSize = true;
            this.theta1.Location = new System.Drawing.Point(-3, 16);
            this.theta1.Name = "theta1";
            this.theta1.Size = new System.Drawing.Size(19, 13);
            this.theta1.TabIndex = 14;
            this.theta1.Text = "θ1";
            // 
            // Giatritheta1
            // 
            this.Giatritheta1.Location = new System.Drawing.Point(15, 13);
            this.Giatritheta1.Name = "Giatritheta1";
            this.Giatritheta1.Size = new System.Drawing.Size(122, 20);
            this.Giatritheta1.TabIndex = 5;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.Giatritheta2);
            this.groupBox8.Controls.Add(this.theta2);
            this.groupBox8.Location = new System.Drawing.Point(159, 15);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(143, 39);
            this.groupBox8.TabIndex = 25;
            this.groupBox8.TabStop = false;
            // 
            // Giatritheta2
            // 
            this.Giatritheta2.Location = new System.Drawing.Point(14, 13);
            this.Giatritheta2.Name = "Giatritheta2";
            this.Giatritheta2.Size = new System.Drawing.Size(122, 20);
            this.Giatritheta2.TabIndex = 17;
            // 
            // theta2
            // 
            this.theta2.AutoSize = true;
            this.theta2.Location = new System.Drawing.Point(-3, 16);
            this.theta2.Name = "theta2";
            this.theta2.Size = new System.Drawing.Size(19, 13);
            this.theta2.TabIndex = 15;
            this.theta2.Text = "θ2";
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.Giatritheta3);
            this.groupBox9.Controls.Add(this.theta3);
            this.groupBox9.Location = new System.Drawing.Point(314, 15);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(144, 39);
            this.groupBox9.TabIndex = 26;
            this.groupBox9.TabStop = false;
            // 
            // Giatritheta3
            // 
            this.Giatritheta3.Location = new System.Drawing.Point(14, 13);
            this.Giatritheta3.Name = "Giatritheta3";
            this.Giatritheta3.Size = new System.Drawing.Size(124, 20);
            this.Giatritheta3.TabIndex = 18;
            // 
            // theta3
            // 
            this.theta3.AutoSize = true;
            this.theta3.Location = new System.Drawing.Point(-3, 16);
            this.theta3.Name = "theta3";
            this.theta3.Size = new System.Drawing.Size(19, 13);
            this.theta3.TabIndex = 16;
            this.theta3.Text = "θ3";
            // 
            // btnHallAll
            // 
            this.btnHallAll.Location = new System.Drawing.Point(253, 132);
            this.btnHallAll.Name = "btnHallAll";
            this.btnHallAll.Size = new System.Drawing.Size(127, 47);
            this.btnHallAll.TabIndex = 10;
            this.btnHallAll.Text = "Stop All";
            this.btnHallAll.UseVisualStyleBackColor = true;
            this.btnHallAll.Click += new System.EventHandler(this.btnHallAll_Click);
            // 
            // btnSethome
            // 
            this.btnSethome.Location = new System.Drawing.Point(253, 95);
            this.btnSethome.Name = "btnSethome";
            this.btnSethome.Size = new System.Drawing.Size(127, 30);
            this.btnSethome.TabIndex = 7;
            this.btnSethome.Text = "   Home  ";
            this.btnSethome.UseVisualStyleBackColor = true;
            this.btnSethome.Click += new System.EventHandler(this.btnSethome_Click);
            // 
            // grpSpeed
            // 
            this.grpSpeed.Controls.Add(this.txtJerk);
            this.grpSpeed.Controls.Add(this.txtKdec);
            this.grpSpeed.Controls.Add(this.txtDec);
            this.grpSpeed.Controls.Add(this.txtAcc);
            this.grpSpeed.Controls.Add(this.txtVel);
            this.grpSpeed.Controls.Add(this.label7);
            this.grpSpeed.Controls.Add(this.label6);
            this.grpSpeed.Controls.Add(this.label5);
            this.grpSpeed.Controls.Add(this.label4);
            this.grpSpeed.Controls.Add(this.label3);
            this.grpSpeed.Location = new System.Drawing.Point(12, 438);
            this.grpSpeed.Name = "grpSpeed";
            this.grpSpeed.Size = new System.Drawing.Size(295, 141);
            this.grpSpeed.TabIndex = 0;
            this.grpSpeed.TabStop = false;
            this.grpSpeed.Text = "speed settings";
            // 
            // txtJerk
            // 
            this.txtJerk.Location = new System.Drawing.Point(137, 111);
            this.txtJerk.Name = "txtJerk";
            this.txtJerk.Size = new System.Drawing.Size(140, 20);
            this.txtJerk.TabIndex = 4;
            this.txtJerk.Text = "0";
            this.txtJerk.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtKdec
            // 
            this.txtKdec.Location = new System.Drawing.Point(137, 88);
            this.txtKdec.Name = "txtKdec";
            this.txtKdec.Size = new System.Drawing.Size(140, 20);
            this.txtKdec.TabIndex = 3;
            this.txtKdec.Text = "0";
            this.txtKdec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtDec
            // 
            this.txtDec.Location = new System.Drawing.Point(137, 65);
            this.txtDec.Name = "txtDec";
            this.txtDec.Size = new System.Drawing.Size(140, 20);
            this.txtDec.TabIndex = 2;
            this.txtDec.Text = "0";
            this.txtDec.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtAcc
            // 
            this.txtAcc.Location = new System.Drawing.Point(137, 42);
            this.txtAcc.Name = "txtAcc";
            this.txtAcc.Size = new System.Drawing.Size(140, 20);
            this.txtAcc.TabIndex = 1;
            this.txtAcc.Text = "0";
            this.txtAcc.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtVel
            // 
            this.txtVel.Location = new System.Drawing.Point(137, 19);
            this.txtVel.Name = "txtVel";
            this.txtVel.Size = new System.Drawing.Size(140, 20);
            this.txtVel.TabIndex = 0;
            this.txtVel.Text = "0";
            this.txtVel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 115);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 5;
            this.label7.Text = "Jerk (JERK)";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 92);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Kill Deceleration (KDEC)";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 69);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Deceleration (DEC)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Acceleration (ACC)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Velocity (VEL)";
            // 
            // Status_lb
            // 
            this.Status_lb.Controls.Add(this.lblPRG_Status);
            this.Status_lb.Controls.Add(this.lblstop2);
            this.Status_lb.Controls.Add(this.lblstop1);
            this.Status_lb.Controls.Add(this.lblstop0);
            this.Status_lb.Controls.Add(this.labelEnable2);
            this.Status_lb.Controls.Add(this.labelACC2);
            this.Status_lb.Controls.Add(this.labelPosi2);
            this.Status_lb.Controls.Add(this.labelMov2);
            this.Status_lb.Controls.Add(this.labelEnable1);
            this.Status_lb.Controls.Add(this.labelACC1);
            this.Status_lb.Controls.Add(this.labelPosi1);
            this.Status_lb.Controls.Add(this.labelMov1);
            this.Status_lb.Controls.Add(this.label27);
            this.Status_lb.Controls.Add(this.label28);
            this.Status_lb.Controls.Add(this.label29);
            this.Status_lb.Controls.Add(this.label25);
            this.Status_lb.Controls.Add(this.labelEnable0);
            this.Status_lb.Controls.Add(this.labelACC0);
            this.Status_lb.Controls.Add(this.labelPosi0);
            this.Status_lb.Controls.Add(this.labelMov0);
            this.Status_lb.Controls.Add(this.label19);
            this.Status_lb.Controls.Add(this.label20);
            this.Status_lb.Controls.Add(this.label23);
            this.Status_lb.Controls.Add(this.label24);
            this.Status_lb.Location = new System.Drawing.Point(396, 12);
            this.Status_lb.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Status_lb.Name = "Status_lb";
            this.Status_lb.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Status_lb.Size = new System.Drawing.Size(196, 167);
            this.Status_lb.TabIndex = 19;
            this.Status_lb.TabStop = false;
            this.Status_lb.Text = "Status";
            // 
            // lblPRG_Status
            // 
            this.lblPRG_Status.AutoSize = true;
            this.lblPRG_Status.Location = new System.Drawing.Point(6, 142);
            this.lblPRG_Status.Name = "lblPRG_Status";
            this.lblPRG_Status.Size = new System.Drawing.Size(42, 13);
            this.lblPRG_Status.TabIndex = 11;
            this.lblPRG_Status.Text = "Disable";
            // 
            // lblstop2
            // 
            this.lblstop2.Image = ((System.Drawing.Image)(resources.GetObject("lblstop2.Image")));
            this.lblstop2.Location = new System.Drawing.Point(159, 138);
            this.lblstop2.Name = "lblstop2";
            this.lblstop2.Size = new System.Drawing.Size(19, 17);
            this.lblstop2.TabIndex = 41;
            this.lblstop2.Tag = "17";
            // 
            // lblstop1
            // 
            this.lblstop1.Image = ((System.Drawing.Image)(resources.GetObject("lblstop1.Image")));
            this.lblstop1.Location = new System.Drawing.Point(119, 137);
            this.lblstop1.Name = "lblstop1";
            this.lblstop1.Size = new System.Drawing.Size(19, 17);
            this.lblstop1.TabIndex = 40;
            this.lblstop1.Tag = "17";
            // 
            // lblstop0
            // 
            this.lblstop0.Image = ((System.Drawing.Image)(resources.GetObject("lblstop0.Image")));
            this.lblstop0.Location = new System.Drawing.Point(76, 138);
            this.lblstop0.Name = "lblstop0";
            this.lblstop0.Size = new System.Drawing.Size(19, 17);
            this.lblstop0.TabIndex = 10;
            this.lblstop0.Tag = "17";
            // 
            // labelEnable2
            // 
            this.labelEnable2.Image = ((System.Drawing.Image)(resources.GetObject("labelEnable2.Image")));
            this.labelEnable2.Location = new System.Drawing.Point(155, 108);
            this.labelEnable2.Name = "labelEnable2";
            this.labelEnable2.Size = new System.Drawing.Size(27, 29);
            this.labelEnable2.TabIndex = 35;
            // 
            // labelACC2
            // 
            this.labelACC2.Image = ((System.Drawing.Image)(resources.GetObject("labelACC2.Image")));
            this.labelACC2.Location = new System.Drawing.Point(155, 57);
            this.labelACC2.Name = "labelACC2";
            this.labelACC2.Size = new System.Drawing.Size(27, 29);
            this.labelACC2.TabIndex = 33;
            // 
            // labelPosi2
            // 
            this.labelPosi2.Image = ((System.Drawing.Image)(resources.GetObject("labelPosi2.Image")));
            this.labelPosi2.Location = new System.Drawing.Point(155, 80);
            this.labelPosi2.Name = "labelPosi2";
            this.labelPosi2.Size = new System.Drawing.Size(27, 32);
            this.labelPosi2.TabIndex = 34;
            // 
            // labelMov2
            // 
            this.labelMov2.Image = ((System.Drawing.Image)(resources.GetObject("labelMov2.Image")));
            this.labelMov2.Location = new System.Drawing.Point(155, 31);
            this.labelMov2.Name = "labelMov2";
            this.labelMov2.Size = new System.Drawing.Size(27, 29);
            this.labelMov2.TabIndex = 32;
            // 
            // labelEnable1
            // 
            this.labelEnable1.Image = ((System.Drawing.Image)(resources.GetObject("labelEnable1.Image")));
            this.labelEnable1.Location = new System.Drawing.Point(115, 108);
            this.labelEnable1.Name = "labelEnable1";
            this.labelEnable1.Size = new System.Drawing.Size(27, 29);
            this.labelEnable1.TabIndex = 31;
            // 
            // labelACC1
            // 
            this.labelACC1.Image = ((System.Drawing.Image)(resources.GetObject("labelACC1.Image")));
            this.labelACC1.Location = new System.Drawing.Point(115, 57);
            this.labelACC1.Name = "labelACC1";
            this.labelACC1.Size = new System.Drawing.Size(27, 29);
            this.labelACC1.TabIndex = 29;
            // 
            // labelPosi1
            // 
            this.labelPosi1.Image = ((System.Drawing.Image)(resources.GetObject("labelPosi1.Image")));
            this.labelPosi1.Location = new System.Drawing.Point(115, 80);
            this.labelPosi1.Name = "labelPosi1";
            this.labelPosi1.Size = new System.Drawing.Size(27, 32);
            this.labelPosi1.TabIndex = 30;
            // 
            // labelMov1
            // 
            this.labelMov1.Image = ((System.Drawing.Image)(resources.GetObject("labelMov1.Image")));
            this.labelMov1.Location = new System.Drawing.Point(115, 31);
            this.labelMov1.Name = "labelMov1";
            this.labelMov1.Size = new System.Drawing.Size(27, 29);
            this.labelMov1.TabIndex = 28;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(162, 18);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(13, 13);
            this.label27.TabIndex = 25;
            this.label27.Text = "2";
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(122, 18);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(13, 13);
            this.label28.TabIndex = 26;
            this.label28.Text = "1";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(79, 19);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(13, 13);
            this.label29.TabIndex = 27;
            this.label29.Text = "0";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(6, 18);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(43, 13);
            this.label25.TabIndex = 23;
            this.label25.Text = "Axis No";
            // 
            // labelEnable0
            // 
            this.labelEnable0.Image = ((System.Drawing.Image)(resources.GetObject("labelEnable0.Image")));
            this.labelEnable0.Location = new System.Drawing.Point(72, 109);
            this.labelEnable0.Name = "labelEnable0";
            this.labelEnable0.Size = new System.Drawing.Size(27, 29);
            this.labelEnable0.TabIndex = 22;
            // 
            // labelACC0
            // 
            this.labelACC0.Image = ((System.Drawing.Image)(resources.GetObject("labelACC0.Image")));
            this.labelACC0.Location = new System.Drawing.Point(72, 58);
            this.labelACC0.Name = "labelACC0";
            this.labelACC0.Size = new System.Drawing.Size(27, 29);
            this.labelACC0.TabIndex = 21;
            // 
            // labelPosi0
            // 
            this.labelPosi0.Image = ((System.Drawing.Image)(resources.GetObject("labelPosi0.Image")));
            this.labelPosi0.Location = new System.Drawing.Point(72, 81);
            this.labelPosi0.Name = "labelPosi0";
            this.labelPosi0.Size = new System.Drawing.Size(27, 32);
            this.labelPosi0.TabIndex = 21;
            // 
            // labelMov0
            // 
            this.labelMov0.Image = ((System.Drawing.Image)(resources.GetObject("labelMov0.Image")));
            this.labelMov0.Location = new System.Drawing.Point(72, 32);
            this.labelMov0.Name = "labelMov0";
            this.labelMov0.Size = new System.Drawing.Size(27, 29);
            this.labelMov0.TabIndex = 20;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(6, 116);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(40, 13);
            this.label19.TabIndex = 19;
            this.label19.Text = "Enable";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(6, 90);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(56, 13);
            this.label20.TabIndex = 2;
            this.label20.Text = "In Position";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(6, 64);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(66, 13);
            this.label23.TabIndex = 1;
            this.label23.Text = "Accelerating";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(6, 39);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(42, 13);
            this.label24.TabIndex = 0;
            this.label24.Text = "Moving";
            // 
            // grpJog
            // 
            this.grpJog.Controls.Add(this.Value_JOG);
            this.grpJog.Controls.Add(this.txtJogStep);
            this.grpJog.Controls.Add(this.dichuyentruX);
            this.grpJog.Controls.Add(this.dichuyentruY);
            this.grpJog.Controls.Add(this.dichuyentruZ);
            this.grpJog.Controls.Add(this.dichuyencongX);
            this.grpJog.Controls.Add(this.dichuyencongY);
            this.grpJog.Controls.Add(this.dichuyencongZ);
            this.grpJog.Location = new System.Drawing.Point(325, 440);
            this.grpJog.Name = "grpJog";
            this.grpJog.Size = new System.Drawing.Size(267, 139);
            this.grpJog.TabIndex = 0;
            this.grpJog.TabStop = false;
            this.grpJog.Text = "Jog";
            // 
            // Value_JOG
            // 
            this.Value_JOG.AutoSize = true;
            this.Value_JOG.Location = new System.Drawing.Point(2, 26);
            this.Value_JOG.Name = "Value_JOG";
            this.Value_JOG.Size = new System.Drawing.Size(34, 13);
            this.Value_JOG.TabIndex = 42;
            this.Value_JOG.Text = "Value";
            // 
            // txtJogStep
            // 
            this.txtJogStep.Location = new System.Drawing.Point(42, 23);
            this.txtJogStep.Name = "txtJogStep";
            this.txtJogStep.Size = new System.Drawing.Size(218, 20);
            this.txtJogStep.TabIndex = 12;
            this.txtJogStep.Text = "0";
            this.txtJogStep.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dichuyentruX
            // 
            this.dichuyentruX.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.dichuyentruX.Location = new System.Drawing.Point(5, 94);
            this.dichuyentruX.Name = "dichuyentruX";
            this.dichuyentruX.Size = new System.Drawing.Size(75, 36);
            this.dichuyentruX.TabIndex = 6;
            this.dichuyentruX.Text = "-X";
            this.dichuyentruX.UseVisualStyleBackColor = true;
            this.dichuyentruX.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dichuyentruX_MouseDown);
            this.dichuyentruX.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Jog_MouseUp);
            // 
            // dichuyentruY
            // 
            this.dichuyentruY.Location = new System.Drawing.Point(93, 93);
            this.dichuyentruY.Name = "dichuyentruY";
            this.dichuyentruY.Size = new System.Drawing.Size(77, 36);
            this.dichuyentruY.TabIndex = 8;
            this.dichuyentruY.Text = "-Y";
            this.dichuyentruY.UseVisualStyleBackColor = true;
            this.dichuyentruY.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dichuyentruY_MouseDown);
            this.dichuyentruY.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Jog_MouseUp);
            // 
            // dichuyentruZ
            // 
            this.dichuyentruZ.Location = new System.Drawing.Point(185, 94);
            this.dichuyentruZ.Name = "dichuyentruZ";
            this.dichuyentruZ.Size = new System.Drawing.Size(75, 35);
            this.dichuyentruZ.TabIndex = 10;
            this.dichuyentruZ.Text = "-Z";
            this.dichuyentruZ.UseVisualStyleBackColor = true;
            this.dichuyentruZ.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dichuyentruZ_MouseDown);
            this.dichuyentruZ.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Jog_MouseUp);
            // 
            // dichuyencongX
            // 
            this.dichuyencongX.Location = new System.Drawing.Point(5, 54);
            this.dichuyencongX.Name = "dichuyencongX";
            this.dichuyencongX.Size = new System.Drawing.Size(75, 34);
            this.dichuyencongX.TabIndex = 7;
            this.dichuyencongX.Text = "+X";
            this.dichuyencongX.UseVisualStyleBackColor = true;
            this.dichuyencongX.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dichuyencongX_MouseDown);
            this.dichuyencongX.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Jog_MouseUp);
            // 
            // dichuyencongY
            // 
            this.dichuyencongY.Location = new System.Drawing.Point(93, 53);
            this.dichuyencongY.Name = "dichuyencongY";
            this.dichuyencongY.Size = new System.Drawing.Size(77, 34);
            this.dichuyencongY.TabIndex = 9;
            this.dichuyencongY.Text = "+Y";
            this.dichuyencongY.UseVisualStyleBackColor = true;
            this.dichuyencongY.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dichuyencongY_MouseDown);
            this.dichuyencongY.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Jog_MouseUp);
            // 
            // dichuyencongZ
            // 
            this.dichuyencongZ.Location = new System.Drawing.Point(185, 52);
            this.dichuyencongZ.Name = "dichuyencongZ";
            this.dichuyencongZ.Size = new System.Drawing.Size(75, 36);
            this.dichuyencongZ.TabIndex = 11;
            this.dichuyencongZ.Text = "+Z";
            this.dichuyencongZ.UseVisualStyleBackColor = true;
            this.dichuyencongZ.MouseDown += new System.Windows.Forms.MouseEventHandler(this.dichuyencongZ_MouseDown);
            this.dichuyencongZ.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Jog_MouseUp);
            // 
            // Sharpemodepositions
            // 
            this.Sharpemodepositions.Controls.Add(this.cboShape);
            this.Sharpemodepositions.Location = new System.Drawing.Point(12, 128);
            this.Sharpemodepositions.Name = "Sharpemodepositions";
            this.Sharpemodepositions.Size = new System.Drawing.Size(223, 51);
            this.Sharpemodepositions.TabIndex = 29;
            this.Sharpemodepositions.TabStop = false;
            this.Sharpemodepositions.Text = "Sharpe_mode";
            // 
            // cboShape
            // 
            this.cboShape.FormattingEnabled = true;
            this.cboShape.Location = new System.Drawing.Point(6, 19);
            this.cboShape.Name = "cboShape";
            this.cboShape.Size = new System.Drawing.Size(208, 21);
            this.cboShape.TabIndex = 27;
            this.cboShape.SelectedIndexChanged += new System.EventHandler(this.cboShape_SelectedIndexChanged);
            // 
            // groupBox10
            // 
            this.groupBox10.Location = new System.Drawing.Point(313, 11);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(144, 40);
            this.groupBox10.TabIndex = 0;
            this.groupBox10.TabStop = false;
            // 
            // GiatritoadoZ
            // 
            this.GiatritoadoZ.Location = new System.Drawing.Point(14, 14);
            this.GiatritoadoZ.Name = "GiatritoadoZ";
            this.GiatritoadoZ.Size = new System.Drawing.Size(124, 20);
            this.GiatritoadoZ.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(-2, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 13);
            this.label8.TabIndex = 21;
            // 
            // groupBox6
            // 
            this.groupBox6.Location = new System.Drawing.Point(159, 11);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(143, 40);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-3, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 20;
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(14, 13);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(123, 20);
            this.textBox9.TabIndex = 3;
            // 
            // groupBox5
            // 
            this.groupBox5.Location = new System.Drawing.Point(6, 11);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(143, 40);
            this.groupBox5.TabIndex = 23;
            this.groupBox5.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-1, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 19;
            // 
            // giatritoadoX
            // 
            this.giatritoadoX.Location = new System.Drawing.Point(14, 14);
            this.giatritoadoX.Name = "giatritoadoX";
            this.giatritoadoX.Size = new System.Drawing.Size(123, 20);
            this.giatritoadoX.TabIndex = 4;
            // 
            // updatetoado
            // 
            this.updatetoado.Location = new System.Drawing.Point(464, 16);
            this.updatetoado.Name = "updatetoado";
            this.updatetoado.Size = new System.Drawing.Size(75, 34);
            this.updatetoado.TabIndex = 22;
            this.updatetoado.Text = "Update position";
            this.updatetoado.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.updatetoado);
            this.groupBox4.Controls.Add(this.groupBox5);
            this.groupBox4.Controls.Add(this.groupBox6);
            this.groupBox4.Controls.Add(this.groupBox10);
            this.groupBox4.Location = new System.Drawing.Point(15, 141);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(547, 63);
            this.groupBox4.TabIndex = 20;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Positions";
            // 
            // STopall_
            // 
            this.STopall_.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.STopall_.Image = ((System.Drawing.Image)(resources.GetObject("STopall_.Image")));
            this.STopall_.Location = new System.Drawing.Point(259, 142);
            this.STopall_.Name = "STopall_";
            this.STopall_.Size = new System.Drawing.Size(30, 30);
            this.STopall_.TabIndex = 45;
            this.STopall_.Tag = "17";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 587);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.enbale);
            this.Controls.Add(this.Status_lb);
            this.Controls.Add(this.Sharpemodepositions);
            this.Controls.Add(this.grpParameters);
            this.Controls.Add(this.Communication_set);
            this.Controls.Add(this.grpJog);
            this.Controls.Add(this.grpSpeed);
            this.Controls.Add(this.groupBox11);
            this.Controls.Add(this.btnSethome);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.STopall_);
            this.Controls.Add(this.btnHallAll);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Communication_set.ResumeLayout(false);
            this.Communication_set.PerformLayout();
            this.grpParameters.ResumeLayout(false);
            this.grpParameters.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            this.groupBox13.ResumeLayout(false);
            this.groupBox13.PerformLayout();
            this.groupBox14.ResumeLayout(false);
            this.groupBox14.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.grpSpeed.ResumeLayout(false);
            this.grpSpeed.PerformLayout();
            this.Status_lb.ResumeLayout(false);
            this.Status_lb.PerformLayout();
            this.grpJog.ResumeLayout(false);
            this.grpJog.PerformLayout();
            this.Sharpemodepositions.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox Communication_set;
        private System.Windows.Forms.Label POrtlabel1;
        private System.Windows.Forms.Label IPlabel1;
        private System.Windows.Forms.RadioButton rdoSimu;
        private System.Windows.Forms.RadioButton rdoTCP;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.TextBox Porttxt;
        private System.Windows.Forms.TextBox IPtxt;
        private System.Windows.Forms.GroupBox grpParameters;
        private System.Windows.Forms.Button btnHallAll;
        private System.Windows.Forms.Button btnSethome;
        private System.Windows.Forms.TextBox txtFVEL0;
        private System.Windows.Forms.TextBox txtPE0;
        private System.Windows.Forms.TextBox txtFPOS0;
        private System.Windows.Forms.Label AC_AX0;
        private System.Windows.Forms.TextBox txtRPOS0;
        private System.Windows.Forms.Label Po_err_AX0;
        private System.Windows.Forms.Label FB_PO_AX0;
        private System.Windows.Forms.Label Po_ax0;
        private System.Windows.Forms.GroupBox grpJog;
        private System.Windows.Forms.GroupBox grpSpeed;
        private System.Windows.Forms.TextBox txtJerk;
        private System.Windows.Forms.TextBox txtKdec;
        private System.Windows.Forms.TextBox txtDec;
        private System.Windows.Forms.TextBox txtAcc;
        private System.Windows.Forms.TextBox txtVel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox Status_lb;
        private System.Windows.Forms.Label labelEnable2;
        private System.Windows.Forms.Label labelACC2;
        private System.Windows.Forms.Label labelPosi2;
        private System.Windows.Forms.Label labelMov2;
        private System.Windows.Forms.Label labelEnable1;
        private System.Windows.Forms.Label labelACC1;
        private System.Windows.Forms.Label labelPosi1;
        private System.Windows.Forms.Label labelMov1;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label labelEnable0;
        private System.Windows.Forms.Label labelACC0;
        private System.Windows.Forms.Label labelPosi0;
        private System.Windows.Forms.Label labelMov0;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Button dichuyentruX;
        private System.Windows.Forms.Button dichuyentruY;
        private System.Windows.Forms.Button dichuyentruZ;
        private System.Windows.Forms.Button dichuyencongX;
        private System.Windows.Forms.Button dichuyencongY;
        private System.Windows.Forms.Button dichuyencongZ;
        private System.Windows.Forms.GroupBox Sharpemodepositions;
        private System.Windows.Forms.ComboBox cboShape;
        private System.Windows.Forms.TextBox txtJogStep;
        private System.Windows.Forms.Label Value_JOG;
        private System.Windows.Forms.Label lblPRG_Status;
        private System.Windows.Forms.Label lblstop2;
        private System.Windows.Forms.Label lblstop1;
        private System.Windows.Forms.Label lblstop0;
        private System.Windows.Forms.TextBox txtFVEL2;
        private System.Windows.Forms.TextBox txtPE2;
        private System.Windows.Forms.TextBox txtFPOS2;
        private System.Windows.Forms.TextBox txtRPOS2;
        private System.Windows.Forms.TextBox txtFVEL1;
        private System.Windows.Forms.TextBox txtPE1;
        private System.Windows.Forms.TextBox txtFPOS1;
        private System.Windows.Forms.TextBox txtRPOS1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button capnhatgoc;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Label theta1;
        private System.Windows.Forms.TextBox Giatritheta1;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.TextBox Giatritheta2;
        private System.Windows.Forms.Label theta2;
        private System.Windows.Forms.GroupBox groupBox9;
        private System.Windows.Forms.TextBox Giatritheta3;
        private System.Windows.Forms.Label theta3;
        private System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox12;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox14;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.TextBox GiatritoadoZ;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox giatritoadoX;
        private System.Windows.Forms.Button updatetoado;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button enbale;
        private System.Windows.Forms.Label TXTPOSAX2;
        private System.Windows.Forms.Label TXTPOSAX1;
        private System.Windows.Forms.Label TXTPOSAX0;
        private System.Windows.Forms.Label STopall_;
    }
}

