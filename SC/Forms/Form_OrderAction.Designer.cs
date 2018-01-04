namespace SC
{
    partial class Form_OrderAction
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
            this.Approve_Button = new System.Windows.Forms.Button();
            this.Decline_Button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Customer_Label = new System.Windows.Forms.Label();
            this.Segment_Label = new System.Windows.Forms.Label();
            this.Region_Label = new System.Windows.Forms.Label();
            this.Salesman_Label = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Status_Label = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Notes_rtb = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Detail_Grid = new DevExpress.XtraGrid.GridControl();
            this.Detail_GridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.Detail_Grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Detail_GridView)).BeginInit();
            this.SuspendLayout();
            // 
            // Approve_Button
            // 
            this.Approve_Button.Location = new System.Drawing.Point(29, 574);
            this.Approve_Button.Name = "Approve_Button";
            this.Approve_Button.Size = new System.Drawing.Size(165, 42);
            this.Approve_Button.TabIndex = 0;
            this.Approve_Button.Text = "Approve";
            this.Approve_Button.UseVisualStyleBackColor = true;
            this.Approve_Button.Click += new System.EventHandler(this.Approve_Button_Click);
            // 
            // Decline_Button
            // 
            this.Decline_Button.Location = new System.Drawing.Point(652, 573);
            this.Decline_Button.Name = "Decline_Button";
            this.Decline_Button.Size = new System.Drawing.Size(165, 44);
            this.Decline_Button.TabIndex = 1;
            this.Decline_Button.Text = "Decline";
            this.Decline_Button.UseVisualStyleBackColor = true;
            this.Decline_Button.Click += new System.EventHandler(this.Decline_Button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Customer: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 24);
            this.label2.TabIndex = 3;
            this.label2.Text = "Wilayah: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(28, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 24);
            this.label3.TabIndex = 4;
            this.label3.Text = "Bidang Usaha: ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(28, 146);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 24);
            this.label4.TabIndex = 5;
            this.label4.Text = "Salesman: ";
            // 
            // Customer_Label
            // 
            this.Customer_Label.AutoSize = true;
            this.Customer_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Customer_Label.Location = new System.Drawing.Point(199, 24);
            this.Customer_Label.Name = "Customer_Label";
            this.Customer_Label.Size = new System.Drawing.Size(103, 24);
            this.Customer_Label.TabIndex = 6;
            this.Customer_Label.Text = "Salesman: ";
            // 
            // Segment_Label
            // 
            this.Segment_Label.AutoSize = true;
            this.Segment_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Segment_Label.Location = new System.Drawing.Point(199, 64);
            this.Segment_Label.Name = "Segment_Label";
            this.Segment_Label.Size = new System.Drawing.Size(103, 24);
            this.Segment_Label.TabIndex = 7;
            this.Segment_Label.Text = "Salesman: ";
            // 
            // Region_Label
            // 
            this.Region_Label.AutoSize = true;
            this.Region_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Region_Label.Location = new System.Drawing.Point(199, 106);
            this.Region_Label.Name = "Region_Label";
            this.Region_Label.Size = new System.Drawing.Size(103, 24);
            this.Region_Label.TabIndex = 8;
            this.Region_Label.Text = "Salesman: ";
            // 
            // Salesman_Label
            // 
            this.Salesman_Label.AutoSize = true;
            this.Salesman_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Salesman_Label.Location = new System.Drawing.Point(199, 146);
            this.Salesman_Label.Name = "Salesman_Label";
            this.Salesman_Label.Size = new System.Drawing.Size(103, 24);
            this.Salesman_Label.TabIndex = 9;
            this.Salesman_Label.Text = "Salesman: ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(28, 188);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 24);
            this.label5.TabIndex = 10;
            this.label5.Text = "Status: ";
            // 
            // Status_Label
            // 
            this.Status_Label.AutoSize = true;
            this.Status_Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Status_Label.Location = new System.Drawing.Point(199, 188);
            this.Status_Label.Name = "Status_Label";
            this.Status_Label.Size = new System.Drawing.Size(103, 24);
            this.Status_Label.TabIndex = 11;
            this.Status_Label.Text = "Salesman: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(28, 231);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 24);
            this.label6.TabIndex = 12;
            this.label6.Text = "Note";
            // 
            // Notes_rtb
            // 
            this.Notes_rtb.Location = new System.Drawing.Point(203, 231);
            this.Notes_rtb.Name = "Notes_rtb";
            this.Notes_rtb.Size = new System.Drawing.Size(614, 116);
            this.Notes_rtb.TabIndex = 13;
            this.Notes_rtb.Text = "";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(28, 353);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(110, 24);
            this.label7.TabIndex = 15;
            this.label7.Text = "Detail Order";
            // 
            // Detail_Grid
            // 
            this.Detail_Grid.Location = new System.Drawing.Point(203, 353);
            this.Detail_Grid.MainView = this.Detail_GridView;
            this.Detail_Grid.Name = "Detail_Grid";
            this.Detail_Grid.Size = new System.Drawing.Size(614, 214);
            this.Detail_Grid.TabIndex = 16;
            this.Detail_Grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.Detail_GridView});
            // 
            // Detail_GridView
            // 
            this.Detail_GridView.ActiveFilterEnabled = false;
            this.Detail_GridView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.Detail_GridView.GridControl = this.Detail_Grid;
            this.Detail_GridView.Name = "Detail_GridView";
            this.Detail_GridView.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.False;
            this.Detail_GridView.OptionsBehavior.AllowFixedGroups = DevExpress.Utils.DefaultBoolean.True;
            this.Detail_GridView.OptionsBehavior.AllowPartialGroups = DevExpress.Utils.DefaultBoolean.False;
            this.Detail_GridView.OptionsBehavior.AllowPixelScrolling = DevExpress.Utils.DefaultBoolean.True;
            this.Detail_GridView.OptionsBehavior.AllowSortAnimation = DevExpress.Utils.DefaultBoolean.True;
            this.Detail_GridView.OptionsBehavior.Editable = false;
            this.Detail_GridView.OptionsBehavior.ReadOnly = true;
            this.Detail_GridView.OptionsCustomization.AllowFilter = false;
            this.Detail_GridView.OptionsCustomization.AllowQuickHideColumns = false;
            this.Detail_GridView.OptionsDetail.EnableMasterViewMode = false;
            this.Detail_GridView.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.False;
            this.Detail_GridView.OptionsEditForm.ShowOnEnterKey = DevExpress.Utils.DefaultBoolean.False;
            this.Detail_GridView.OptionsEditForm.ShowOnF2Key = DevExpress.Utils.DefaultBoolean.False;
            this.Detail_GridView.OptionsEditForm.ShowUpdateCancelPanel = DevExpress.Utils.DefaultBoolean.False;
            this.Detail_GridView.OptionsFilter.AllowAutoFilterConditionChange = DevExpress.Utils.DefaultBoolean.False;
            this.Detail_GridView.OptionsFilter.AllowColumnMRUFilterList = false;
            this.Detail_GridView.OptionsFilter.AllowFilterEditor = false;
            this.Detail_GridView.OptionsFilter.AllowFilterIncrementalSearch = false;
            this.Detail_GridView.OptionsFilter.AllowMRUFilterList = false;
            this.Detail_GridView.OptionsFilter.UseNewCustomFilterDialog = true;
            this.Detail_GridView.OptionsFind.AllowFindPanel = false;
            this.Detail_GridView.OptionsImageLoad.AsyncLoad = true;
            this.Detail_GridView.OptionsMenu.EnableColumnMenu = false;
            this.Detail_GridView.OptionsMenu.EnableFooterMenu = false;
            this.Detail_GridView.OptionsMenu.EnableGroupPanelMenu = false;
            this.Detail_GridView.OptionsMenu.ShowAutoFilterRowItem = false;
            this.Detail_GridView.OptionsMenu.ShowSplitItem = false;
            this.Detail_GridView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.Detail_GridView.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
            this.Detail_GridView.OptionsView.ColumnAutoWidth = false;
            this.Detail_GridView.OptionsView.EnableAppearanceEvenRow = true;
            this.Detail_GridView.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.Detail_GridView.OptionsView.ShowGroupPanel = false;
            this.Detail_GridView.OptionsView.ShowIndicator = false;
            this.Detail_GridView.OptionsView.WaitAnimationOptions = DevExpress.XtraEditors.WaitAnimationOptions.Indicator;
            // 
            // Form_OrderAction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(852, 630);
            this.Controls.Add(this.Detail_Grid);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Notes_rtb);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Status_Label);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Salesman_Label);
            this.Controls.Add(this.Region_Label);
            this.Controls.Add(this.Segment_Label);
            this.Controls.Add(this.Customer_Label);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Decline_Button);
            this.Controls.Add(this.Approve_Button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_OrderAction";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_OrderAction";
            this.Load += new System.EventHandler(this.Form_OrderAction_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Detail_Grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Detail_GridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Approve_Button;
        private System.Windows.Forms.Button Decline_Button;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label Customer_Label;
        private System.Windows.Forms.Label Segment_Label;
        private System.Windows.Forms.Label Region_Label;
        private System.Windows.Forms.Label Salesman_Label;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label Status_Label;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RichTextBox Notes_rtb;
        private System.Windows.Forms.Label label7;
        private DevExpress.XtraGrid.GridControl Detail_Grid;
        private DevExpress.XtraGrid.Views.Grid.GridView Detail_GridView;
    }
}