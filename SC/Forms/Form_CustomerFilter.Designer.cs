namespace SC
{
    partial class Form_CustomerFilter
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
            this.label2 = new System.Windows.Forms.Label();
            this.Region_ComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Segment_ComboBox = new System.Windows.Forms.ComboBox();
            this.Set_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 16);
            this.label2.TabIndex = 17;
            this.label2.Text = "Region: ";
            // 
            // Region_ComboBox
            // 
            this.Region_ComboBox.FormattingEnabled = true;
            this.Region_ComboBox.Location = new System.Drawing.Point(118, 39);
            this.Region_ComboBox.Name = "Region_ComboBox";
            this.Region_ComboBox.Size = new System.Drawing.Size(150, 21);
            this.Region_ComboBox.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 16);
            this.label1.TabIndex = 15;
            this.label1.Text = "Segment: ";
            // 
            // Segment_ComboBox
            // 
            this.Segment_ComboBox.FormattingEnabled = true;
            this.Segment_ComboBox.Location = new System.Drawing.Point(118, 12);
            this.Segment_ComboBox.Name = "Segment_ComboBox";
            this.Segment_ComboBox.Size = new System.Drawing.Size(150, 21);
            this.Segment_ComboBox.TabIndex = 14;
            // 
            // Set_Button
            // 
            this.Set_Button.Location = new System.Drawing.Point(16, 78);
            this.Set_Button.Name = "Set_Button";
            this.Set_Button.Size = new System.Drawing.Size(91, 30);
            this.Set_Button.TabIndex = 18;
            this.Set_Button.Text = "Set";
            this.Set_Button.UseVisualStyleBackColor = true;
            this.Set_Button.Click += new System.EventHandler(this.Set_Button_Click);
            // 
            // Form_CustomerFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(366, 125);
            this.Controls.Add(this.Set_Button);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Region_ComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Segment_ComboBox);
            this.Name = "Form_CustomerFilter";
            this.Text = "Form_CustomerFilter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox Region_ComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Segment_ComboBox;
        private System.Windows.Forms.Button Set_Button;
    }
}