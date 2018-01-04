namespace SC.Forms
{
    partial class Form_Toast
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
            this.Indicator_Panel = new System.Windows.Forms.Panel();
            this.Button_Close = new System.Windows.Forms.Button();
            this.Label_Tittle = new System.Windows.Forms.Label();
            this.Label_Text = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Indicator_Panel
            // 
            this.Indicator_Panel.Dock = System.Windows.Forms.DockStyle.Left;
            this.Indicator_Panel.Location = new System.Drawing.Point(0, 0);
            this.Indicator_Panel.Name = "Indicator_Panel";
            this.Indicator_Panel.Size = new System.Drawing.Size(10, 87);
            this.Indicator_Panel.TabIndex = 0;
            // 
            // Button_Close
            // 
            this.Button_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Button_Close.BackColor = System.Drawing.Color.Transparent;
            this.Button_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Button_Close.Location = new System.Drawing.Point(333, 0);
            this.Button_Close.Name = "Button_Close";
            this.Button_Close.Size = new System.Drawing.Size(27, 23);
            this.Button_Close.TabIndex = 1;
            this.Button_Close.Text = "X";
            this.Button_Close.UseVisualStyleBackColor = false;
            // 
            // Label_Tittle
            // 
            this.Label_Tittle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_Tittle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Tittle.Location = new System.Drawing.Point(17, 9);
            this.Label_Tittle.Name = "Label_Tittle";
            this.Label_Tittle.Size = new System.Drawing.Size(310, 21);
            this.Label_Tittle.TabIndex = 2;
            this.Label_Tittle.Text = "This Is A Tittle";
            // 
            // Label_Text
            // 
            this.Label_Text.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_Text.Location = new System.Drawing.Point(17, 34);
            this.Label_Text.Name = "Label_Text";
            this.Label_Text.Size = new System.Drawing.Size(331, 44);
            this.Label_Text.TabIndex = 3;
            this.Label_Text.Text = "This is Info";
            // 
            // Form_Toast
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 87);
            this.Controls.Add(this.Label_Text);
            this.Controls.Add(this.Label_Tittle);
            this.Controls.Add(this.Button_Close);
            this.Controls.Add(this.Indicator_Panel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Toast";
            this.Text = "Form_Toast";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Indicator_Panel;
        private System.Windows.Forms.Button Button_Close;
        private System.Windows.Forms.Label Label_Tittle;
        private System.Windows.Forms.Label Label_Text;
    }
}