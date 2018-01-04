namespace SC
{
    partial class Form_ProductFilter
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
            this.label1 = new System.Windows.Forms.Label();
            this.Set_Button = new System.Windows.Forms.Button();
            this.Contract_Combobox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Design_ComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Family_ComboBox = new System.Windows.Forms.ComboBox();
            this.Product_ComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Contract: ";
            // 
            // Set_Button
            // 
            this.Set_Button.Location = new System.Drawing.Point(15, 138);
            this.Set_Button.Name = "Set_Button";
            this.Set_Button.Size = new System.Drawing.Size(75, 23);
            this.Set_Button.TabIndex = 6;
            this.Set_Button.Text = "Set";
            this.Set_Button.UseVisualStyleBackColor = true;
            this.Set_Button.Click += new System.EventHandler(this.Set_Button_Click);
            // 
            // Contract_Combobox
            // 
            this.Contract_Combobox.FormattingEnabled = true;
            this.Contract_Combobox.Location = new System.Drawing.Point(117, 4);
            this.Contract_Combobox.Name = "Contract_Combobox";
            this.Contract_Combobox.Size = new System.Drawing.Size(150, 21);
            this.Contract_Combobox.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Design:";
            // 
            // Design_ComboBox
            // 
            this.Design_ComboBox.FormattingEnabled = true;
            this.Design_ComboBox.Location = new System.Drawing.Point(117, 31);
            this.Design_ComboBox.Name = "Design_ComboBox";
            this.Design_ComboBox.Size = new System.Drawing.Size(150, 21);
            this.Design_ComboBox.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Product Name:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "Family Name";
            // 
            // Family_ComboBox
            // 
            this.Family_ComboBox.FormattingEnabled = true;
            this.Family_ComboBox.Location = new System.Drawing.Point(117, 90);
            this.Family_ComboBox.Name = "Family_ComboBox";
            this.Family_ComboBox.Size = new System.Drawing.Size(150, 21);
            this.Family_ComboBox.TabIndex = 13;
            // 
            // Product_ComboBox
            // 
            this.Product_ComboBox.FormattingEnabled = true;
            this.Product_ComboBox.Location = new System.Drawing.Point(117, 63);
            this.Product_ComboBox.Name = "Product_ComboBox";
            this.Product_ComboBox.Size = new System.Drawing.Size(150, 21);
            this.Product_ComboBox.TabIndex = 12;
            // 
            // Form_ProductFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 180);
            this.Controls.Add(this.Family_ComboBox);
            this.Controls.Add(this.Product_ComboBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Design_ComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Set_Button);
            this.Controls.Add(this.Contract_Combobox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_ProductFilter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_ProductFilter";
            this.Load += new System.EventHandler(this.Form_ProductFilter_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Set_Button;
        private System.Windows.Forms.ComboBox Contract_Combobox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox Design_ComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox Family_ComboBox;
        private System.Windows.Forms.ComboBox Product_ComboBox;
    }
}