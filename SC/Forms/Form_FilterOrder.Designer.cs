namespace SC
{
    partial class Form_FilterOrder
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
            this.Region_Combobox = new System.Windows.Forms.ComboBox();
            this.Set_Button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Sales_ComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Segment_ComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // Region_Combobox
            // 
            this.Region_Combobox.FormattingEnabled = true;
            this.Region_Combobox.Location = new System.Drawing.Point(118, 10);
            this.Region_Combobox.Name = "Region_Combobox";
            this.Region_Combobox.Size = new System.Drawing.Size(121, 21);
            this.Region_Combobox.TabIndex = 0;
            // 
            // Set_Button
            // 
            this.Set_Button.Location = new System.Drawing.Point(15, 105);
            this.Set_Button.Name = "Set_Button";
            this.Set_Button.Size = new System.Drawing.Size(75, 23);
            this.Set_Button.TabIndex = 1;
            this.Set_Button.Text = "Set";
            this.Set_Button.UseVisualStyleBackColor = true;
            this.Set_Button.Click += new System.EventHandler(this.Set_Button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Region: ";
            // 
            // Sales_ComboBox
            // 
            this.Sales_ComboBox.FormattingEnabled = true;
            this.Sales_ComboBox.Location = new System.Drawing.Point(118, 66);
            this.Sales_ComboBox.Name = "Sales_ComboBox";
            this.Sales_ComboBox.Size = new System.Drawing.Size(121, 21);
            this.Sales_ComboBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Salesman";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Bidang Usaha";
            // 
            // Segment_ComboBox
            // 
            this.Segment_ComboBox.FormattingEnabled = true;
            this.Segment_ComboBox.Location = new System.Drawing.Point(118, 37);
            this.Segment_ComboBox.Name = "Segment_ComboBox";
            this.Segment_ComboBox.Size = new System.Drawing.Size(121, 21);
            this.Segment_ComboBox.TabIndex = 5;
            // 
            // Form_FilterOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 144);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Segment_ComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Sales_ComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Set_Button);
            this.Controls.Add(this.Region_Combobox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_FilterOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_FilterOrder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox Region_Combobox;
        private System.Windows.Forms.Button Set_Button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Sales_ComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox Segment_ComboBox;
    }
}