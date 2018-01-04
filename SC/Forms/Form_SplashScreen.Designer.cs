namespace SC
{
    partial class Form_SplashScreen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_SplashScreen));
            this.Logo = new System.Windows.Forms.PictureBox();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.Tittle2 = new System.Windows.Forms.Label();
            this.Label_Status = new System.Windows.Forms.Label();
            this.Tittle = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Logo
            // 
            this.Logo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Logo.Image = ((System.Drawing.Image)(resources.GetObject("Logo.Image")));
            this.Logo.Location = new System.Drawing.Point(63, 85);
            this.Logo.Name = "Logo";
            this.Logo.Size = new System.Drawing.Size(148, 132);
            this.Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Logo.TabIndex = 0;
            this.Logo.TabStop = false;
            // 
            // ProgressBar
            // 
            this.ProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgressBar.Location = new System.Drawing.Point(6, 231);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(264, 11);
            this.ProgressBar.TabIndex = 3;
            // 
            // Tittle2
            // 
            this.Tittle2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Tittle2.AutoSize = true;
            this.Tittle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tittle2.Location = new System.Drawing.Point(34, 43);
            this.Tittle2.Name = "Tittle2";
            this.Tittle2.Size = new System.Drawing.Size(212, 33);
            this.Tittle2.TabIndex = 2;
            this.Tittle2.Text = "Order Manager";
            this.Tittle2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Label_Status
            // 
            this.Label_Status.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_Status.AutoSize = true;
            this.Label_Status.Location = new System.Drawing.Point(6, 250);
            this.Label_Status.Name = "Label_Status";
            this.Label_Status.Size = new System.Drawing.Size(61, 13);
            this.Label_Status.TabIndex = 4;
            this.Label_Status.Text = "Initializing...";
            // 
            // Tittle
            // 
            this.Tittle.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.Tittle.AutoSize = true;
            this.Tittle.CausesValidation = false;
            this.Tittle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Tittle.Location = new System.Drawing.Point(59, 16);
            this.Tittle.Name = "Tittle";
            this.Tittle.Size = new System.Drawing.Size(152, 24);
            this.Tittle.TabIndex = 1;
            this.Tittle.Text = "Sinar Continental";
            this.Tittle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.Tittle);
            this.groupBox1.Controls.Add(this.Label_Status);
            this.groupBox1.Controls.Add(this.Tittle2);
            this.groupBox1.Controls.Add(this.ProgressBar);
            this.groupBox1.Controls.Add(this.Logo);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(276, 276);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // Form_SplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Controls.Add(this.groupBox1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_SplashScreen";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_SplashScreen";
            ((System.ComponentModel.ISupportInitialize)(this.Logo)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Logo;
        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.Label Tittle2;
        private System.Windows.Forms.Label Label_Status;
        private System.Windows.Forms.Label Tittle;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}