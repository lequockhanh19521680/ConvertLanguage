namespace WinFormsApp1
{
    partial class MainProject
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainProject));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFile = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textInput = new System.Windows.Forms.RichTextBox();
            this.panelContainer1 = new System.Windows.Forms.Panel();
            this.panelButton = new System.Windows.Forms.Panel();
            this.convertBtn = new System.Windows.Forms.Button();
            this.panelText = new System.Windows.Forms.Panel();
            this.textExeFileName = new System.Windows.Forms.TextBox();
            this.textClassName = new System.Windows.Forms.TextBox();
            this.panelLabel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.ClassName = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textOutput = new System.Windows.Forms.RichTextBox();
            this.menuStrip.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panelContainer1.SuspendLayout();
            this.panelButton.SuspendLayout();
            this.panelText.SuspendLayout();
            this.panelLabel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(965, 28);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openFile,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.newToolStripMenuItem.Text = "New";
            // 
            // openFile
            // 
            this.openFile.Name = "openFile";
            this.openFile.Size = new System.Drawing.Size(128, 26);
            this.openFile.Text = "Open";
            this.openFile.Click += new System.EventHandler(this.openFile_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(128, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(49, 24);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripSeparator1,
            this.toolStripButton4,
            this.toolStripButton5,
            this.toolStripSeparator2,
            this.toolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 28);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(965, 27);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(29, 24);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(29, 24);
            this.toolStripButton2.Text = "toolStripButton2";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(29, 24);
            this.toolStripButton3.Text = "toolStripButton3";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(29, 24);
            this.toolStripButton4.Text = "toolStripButton4";
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(29, 24);
            this.toolStripButton5.Text = "toolStripButton5";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(27, 24);
            this.toolStripLabel1.Text = "C#";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panelContainer1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 55);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(20, 20, 20, 0);
            this.panel1.Size = new System.Drawing.Size(527, 596);
            this.panel1.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.textInput);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(20, 145);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(20);
            this.panel3.Size = new System.Drawing.Size(483, 447);
            this.panel3.TabIndex = 1;
            // 
            // textInput
            // 
            this.textInput.BackColor = System.Drawing.SystemColors.Window;
            this.textInput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textInput.Location = new System.Drawing.Point(20, 20);
            this.textInput.Name = "textInput";
            this.textInput.ReadOnly = true;
            this.textInput.Size = new System.Drawing.Size(441, 405);
            this.textInput.TabIndex = 1;
            this.textInput.Text = "";
            // 
            // panelContainer1
            // 
            this.panelContainer1.BackColor = System.Drawing.SystemColors.Control;
            this.panelContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelContainer1.Controls.Add(this.panelButton);
            this.panelContainer1.Controls.Add(this.panelText);
            this.panelContainer1.Controls.Add(this.panelLabel);
            this.panelContainer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelContainer1.Location = new System.Drawing.Point(20, 20);
            this.panelContainer1.Name = "panelContainer1";
            this.panelContainer1.Padding = new System.Windows.Forms.Padding(20);
            this.panelContainer1.Size = new System.Drawing.Size(483, 125);
            this.panelContainer1.TabIndex = 0;
            // 
            // panelButton
            // 
            this.panelButton.Controls.Add(this.convertBtn);
            this.panelButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelButton.Location = new System.Drawing.Point(321, 20);
            this.panelButton.Name = "panelButton";
            this.panelButton.Padding = new System.Windows.Forms.Padding(25);
            this.panelButton.Size = new System.Drawing.Size(138, 81);
            this.panelButton.TabIndex = 2;
            // 
            // convertBtn
            // 
            this.convertBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.convertBtn.Location = new System.Drawing.Point(25, 25);
            this.convertBtn.Name = "convertBtn";
            this.convertBtn.Size = new System.Drawing.Size(88, 31);
            this.convertBtn.TabIndex = 0;
            this.convertBtn.Text = "Convert";
            this.convertBtn.UseVisualStyleBackColor = true;
            this.convertBtn.Click += new System.EventHandler(this.convertBtn_Click);
            // 
            // panelText
            // 
            this.panelText.Controls.Add(this.textExeFileName);
            this.panelText.Controls.Add(this.textClassName);
            this.panelText.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelText.Location = new System.Drawing.Point(153, 20);
            this.panelText.Name = "panelText";
            this.panelText.Padding = new System.Windows.Forms.Padding(5);
            this.panelText.Size = new System.Drawing.Size(168, 81);
            this.panelText.TabIndex = 1;
            // 
            // textExeFileName
            // 
            this.textExeFileName.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textExeFileName.Location = new System.Drawing.Point(5, 49);
            this.textExeFileName.Name = "textExeFileName";
            this.textExeFileName.Size = new System.Drawing.Size(158, 27);
            this.textExeFileName.TabIndex = 1;
            // 
            // textClassName
            // 
            this.textClassName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textClassName.Location = new System.Drawing.Point(5, 5);
            this.textClassName.Name = "textClassName";
            this.textClassName.Size = new System.Drawing.Size(158, 27);
            this.textClassName.TabIndex = 0;
            this.textClassName.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // panelLabel
            // 
            this.panelLabel.Controls.Add(this.label2);
            this.panelLabel.Controls.Add(this.ClassName);
            this.panelLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLabel.Location = new System.Drawing.Point(20, 20);
            this.panelLabel.Name = "panelLabel";
            this.panelLabel.Padding = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.panelLabel.Size = new System.Drawing.Size(133, 81);
            this.panelLabel.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(5, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(111, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Exe File Name: ";
            // 
            // ClassName
            // 
            this.ClassName.AutoSize = true;
            this.ClassName.Dock = System.Windows.Forms.DockStyle.Top;
            this.ClassName.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ClassName.Location = new System.Drawing.Point(5, 10);
            this.ClassName.Name = "ClassName";
            this.ClassName.Size = new System.Drawing.Size(99, 18);
            this.ClassName.TabIndex = 0;
            this.ClassName.Text = "Class Name: ";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.textOutput);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(527, 55);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(20);
            this.panel2.Size = new System.Drawing.Size(438, 596);
            this.panel2.TabIndex = 3;
            // 
            // textOutput
            // 
            this.textOutput.BackColor = System.Drawing.SystemColors.Window;
            this.textOutput.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textOutput.Location = new System.Drawing.Point(20, 20);
            this.textOutput.Name = "textOutput";
            this.textOutput.ReadOnly = true;
            this.textOutput.Size = new System.Drawing.Size(394, 552);
            this.textOutput.TabIndex = 1;
            this.textOutput.Text = "";
            // 
            // MainProject
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(965, 651);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainProject";
            this.Text = "MainProject";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panelContainer1.ResumeLayout(false);
            this.panelButton.ResumeLayout(false);
            this.panelText.ResumeLayout(false);
            this.panelText.PerformLayout();
            this.panelLabel.ResumeLayout(false);
            this.panelLabel.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem openFile;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStrip toolStrip1;
        private ToolStripButton toolStripButton1;
        private ToolStripButton toolStripButton2;
        private ToolStripButton toolStripButton3;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton toolStripButton4;
        private ToolStripButton toolStripButton5;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripLabel toolStripLabel1;
        private Panel panel1;
        private Panel panel2;
        private Panel panelContainer1;
        private Panel panelButton;
        private Panel panelText;
        private Panel panelLabel;
        private TextBox textExeFileName;
        private TextBox textClassName;
        private Label label2;
        private Label ClassName;
        private Panel panel3;
        private Button convertBtn;
        private RichTextBox textInput;
        private RichTextBox textOutput;
    }
}