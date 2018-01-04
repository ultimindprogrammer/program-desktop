namespace SC
{
    partial class Form_Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Login));
            this.InputField_Username = new DevExpress.XtraEditors.TextEdit();
            this.InputField_Password = new DevExpress.XtraEditors.TextEdit();
            this.Label_Tittle2 = new System.Windows.Forms.Label();
            this.Label_Tittle1 = new System.Windows.Forms.Label();
            this.Image_Logo = new System.Windows.Forms.PictureBox();
            this.Button_Login = new DevExpress.XtraEditors.SimpleButton();
            this.Button_Close = new DevExpress.XtraEditors.SimpleButton();
            this.Button_Minimize = new DevExpress.XtraEditors.SimpleButton();
            this.Label_Tittle3 = new System.Windows.Forms.Label();
            this.Label_Username = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Panel_Login = new System.Windows.Forms.Panel();
            this.Panel_Tittle = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.InputField_Username.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.InputField_Password.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Image_Logo)).BeginInit();
            this.Panel_Login.SuspendLayout();
            this.Panel_Tittle.SuspendLayout();
            this.SuspendLayout();
            // 
            // InputField_Username
            // 
            this.InputField_Username.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.InputField_Username.EditValue = "dr7";
            this.InputField_Username.Location = new System.Drawing.Point(87, 210);
            this.InputField_Username.Name = "InputField_Username";
            this.InputField_Username.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputField_Username.Properties.Appearance.Options.UseFont = true;
            this.InputField_Username.Size = new System.Drawing.Size(209, 26);
            this.InputField_Username.TabIndex = 2;
            this.InputField_Username.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnTextValidate);
            // 
            // InputField_Password
            // 
            this.InputField_Password.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.InputField_Password.EditValue = "134340";
            this.InputField_Password.Location = new System.Drawing.Point(87, 297);
            this.InputField_Password.Name = "InputField_Password";
            this.InputField_Password.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InputField_Password.Properties.Appearance.Options.UseFont = true;
            this.InputField_Password.Properties.PasswordChar = '*';
            this.InputField_Password.Size = new System.Drawing.Size(209, 26);
            this.InputField_Password.TabIndex = 7;
            this.InputField_Password.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnTextValidate);
            // 
            // Label_Tittle2
            // 
            this.Label_Tittle2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Label_Tittle2.AutoSize = true;
            this.Label_Tittle2.BackColor = System.Drawing.Color.Transparent;
            this.Label_Tittle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Tittle2.ForeColor = System.Drawing.Color.White;
            this.Label_Tittle2.Location = new System.Drawing.Point(1, 38);
            this.Label_Tittle2.Name = "Label_Tittle2";
            this.Label_Tittle2.Size = new System.Drawing.Size(198, 55);
            this.Label_Tittle2.TabIndex = 11;
            this.Label_Tittle2.Text = "ORDER";
            // 
            // Label_Tittle1
            // 
            this.Label_Tittle1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Label_Tittle1.AutoSize = true;
            this.Label_Tittle1.BackColor = System.Drawing.Color.Transparent;
            this.Label_Tittle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Tittle1.ForeColor = System.Drawing.Color.White;
            this.Label_Tittle1.Location = new System.Drawing.Point(33, 5);
            this.Label_Tittle1.Name = "Label_Tittle1";
            this.Label_Tittle1.Size = new System.Drawing.Size(238, 33);
            this.Label_Tittle1.TabIndex = 12;
            this.Label_Tittle1.Text = "Sinar Continental";
            // 
            // Image_Logo
            // 
            this.Image_Logo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Image_Logo.BackColor = System.Drawing.Color.Transparent;
            this.Image_Logo.Image = ((System.Drawing.Image)(resources.GetObject("Image_Logo.Image")));
            this.Image_Logo.Location = new System.Drawing.Point(121, 23);
            this.Image_Logo.Name = "Image_Logo";
            this.Image_Logo.Size = new System.Drawing.Size(146, 146);
            this.Image_Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Image_Logo.TabIndex = 9;
            this.Image_Logo.TabStop = false;
            // 
            // Button_Login
            // 
            this.Button_Login.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.Button_Login.Appearance.Font = new System.Drawing.Font("Tahoma", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Login.Appearance.ForeColor = System.Drawing.Color.White;
            this.Button_Login.Appearance.Options.UseFont = true;
            this.Button_Login.Appearance.Options.UseForeColor = true;
            this.Button_Login.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Button_Login.BackgroundImage")));
            this.Button_Login.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Button_Login.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.Button_Login.Location = new System.Drawing.Point(50, 359);
            this.Button_Login.Name = "Button_Login";
            this.Button_Login.Size = new System.Drawing.Size(282, 62);
            this.Button_Login.TabIndex = 0;
            this.Button_Login.Text = "MASUK";
            this.Button_Login.Click += new System.EventHandler(this.OnLoginButtonPressed);
            // 
            // Button_Close
            // 
            this.Button_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Close.Appearance.Font = new System.Drawing.Font("Lucida Sans", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Close.Appearance.ForeColor = System.Drawing.Color.White;
            this.Button_Close.Appearance.Options.UseFont = true;
            this.Button_Close.Appearance.Options.UseForeColor = true;
            this.Button_Close.AppearancePressed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Button_Close.AppearancePressed.Options.UseBackColor = true;
            this.Button_Close.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.Button_Close.Location = new System.Drawing.Point(765, 12);
            this.Button_Close.Name = "Button_Close";
            this.Button_Close.Size = new System.Drawing.Size(23, 17);
            this.Button_Close.TabIndex = 13;
            this.Button_Close.Text = "X";
            this.Button_Close.Click += new System.EventHandler(this.OnCloseButtonPressed);
            // 
            // Button_Minimize
            // 
            this.Button_Minimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Minimize.Appearance.Font = new System.Drawing.Font("Lucida Sans", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button_Minimize.Appearance.ForeColor = System.Drawing.Color.White;
            this.Button_Minimize.Appearance.Options.UseFont = true;
            this.Button_Minimize.Appearance.Options.UseForeColor = true;
            this.Button_Minimize.AppearancePressed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Button_Minimize.AppearancePressed.Options.UseBackColor = true;
            this.Button_Minimize.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.Button_Minimize.Location = new System.Drawing.Point(736, 12);
            this.Button_Minimize.Name = "Button_Minimize";
            this.Button_Minimize.Size = new System.Drawing.Size(23, 17);
            this.Button_Minimize.TabIndex = 14;
            this.Button_Minimize.Text = "−";
            this.Button_Minimize.Click += new System.EventHandler(this.OnMinimizeButtonPressed);
            // 
            // Label_Tittle3
            // 
            this.Label_Tittle3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.Label_Tittle3.AutoSize = true;
            this.Label_Tittle3.BackColor = System.Drawing.Color.Transparent;
            this.Label_Tittle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Tittle3.ForeColor = System.Drawing.Color.White;
            this.Label_Tittle3.Location = new System.Drawing.Point(46, 93);
            this.Label_Tittle3.Name = "Label_Tittle3";
            this.Label_Tittle3.Size = new System.Drawing.Size(267, 55);
            this.Label_Tittle3.TabIndex = 15;
            this.Label_Tittle3.Text = "MANAGER";
            // 
            // Label_Username
            // 
            this.Label_Username.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_Username.AutoSize = true;
            this.Label_Username.BackColor = System.Drawing.Color.Transparent;
            this.Label_Username.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Username.ForeColor = System.Drawing.Color.White;
            this.Label_Username.Location = new System.Drawing.Point(87, 184);
            this.Label_Username.Name = "Label_Username";
            this.Label_Username.Size = new System.Drawing.Size(85, 18);
            this.Label_Username.TabIndex = 16;
            this.Label_Username.Text = "Username :";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(86, 269);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 18);
            this.label1.TabIndex = 17;
            this.label1.Text = "Password :";
            // 
            // Panel_Login
            // 
            this.Panel_Login.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Panel_Login.BackColor = System.Drawing.Color.Transparent;
            this.Panel_Login.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel_Login.Controls.Add(this.label1);
            this.Panel_Login.Controls.Add(this.Image_Logo);
            this.Panel_Login.Controls.Add(this.Label_Username);
            this.Panel_Login.Controls.Add(this.InputField_Username);
            this.Panel_Login.Controls.Add(this.InputField_Password);
            this.Panel_Login.Controls.Add(this.Button_Login);
            this.Panel_Login.Cursor = System.Windows.Forms.Cursors.Default;
            this.Panel_Login.Location = new System.Drawing.Point(380, 83);
            this.Panel_Login.Name = "Panel_Login";
            this.Panel_Login.Size = new System.Drawing.Size(377, 458);
            this.Panel_Login.TabIndex = 18;
            // 
            // Panel_Tittle
            // 
            this.Panel_Tittle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.Panel_Tittle.BackColor = System.Drawing.Color.Transparent;
            this.Panel_Tittle.Controls.Add(this.Label_Tittle1);
            this.Panel_Tittle.Controls.Add(this.Label_Tittle3);
            this.Panel_Tittle.Controls.Add(this.Label_Tittle2);
            this.Panel_Tittle.Location = new System.Drawing.Point(22, 251);
            this.Panel_Tittle.Name = "Panel_Tittle";
            this.Panel_Tittle.Size = new System.Drawing.Size(316, 149);
            this.Panel_Tittle.TabIndex = 19;
            // 
            // Form_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.Controls.Add(this.Panel_Tittle);
            this.Controls.Add(this.Button_Minimize);
            this.Controls.Add(this.Button_Close);
            this.Controls.Add(this.Panel_Login);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SC Order Manager";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.InputField_Username.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.InputField_Password.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Image_Logo)).EndInit();
            this.Panel_Login.ResumeLayout(false);
            this.Panel_Login.PerformLayout();
            this.Panel_Tittle.ResumeLayout(false);
            this.Panel_Tittle.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton Button_Login;
        private DevExpress.XtraEditors.TextEdit InputField_Username;
        private DevExpress.XtraEditors.TextEdit InputField_Password;
        private System.Windows.Forms.PictureBox Image_Logo;
        private System.Windows.Forms.Label Label_Tittle2;
        private System.Windows.Forms.Label Label_Tittle1;
        private DevExpress.XtraEditors.SimpleButton Button_Close;
        private DevExpress.XtraEditors.SimpleButton Button_Minimize;
        private System.Windows.Forms.Label Label_Tittle3;
        private System.Windows.Forms.Label Label_Username;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel Panel_Login;
        private System.Windows.Forms.Panel Panel_Tittle;
    }
}