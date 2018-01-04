namespace SC
{
    partial class Form_Nego
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
            this.Nego_Grid = new DevExpress.XtraGrid.GridControl();
            this.Nego_GridView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Approve_Button = new DevExpress.XtraEditors.SimpleButton();
            this.Decline_Button = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.Nego_Grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nego_GridView)).BeginInit();
            this.SuspendLayout();
            // 
            // Nego_Grid
            // 
            this.Nego_Grid.Location = new System.Drawing.Point(4, 74);
            this.Nego_Grid.MainView = this.Nego_GridView;
            this.Nego_Grid.Name = "Nego_Grid";
            this.Nego_Grid.Size = new System.Drawing.Size(747, 346);
            this.Nego_Grid.TabIndex = 0;
            this.Nego_Grid.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.Nego_GridView});
            // 
            // Nego_GridView
            // 
            this.Nego_GridView.GridControl = this.Nego_Grid;
            this.Nego_GridView.Name = "Nego_GridView";
            this.Nego_GridView.OptionsSelection.MultiSelect = true;
            this.Nego_GridView.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.Nego_GridView.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
            this.Nego_GridView.OptionsView.ShowGroupPanel = false;
            // 
            // Approve_Button
            // 
            this.Approve_Button.Location = new System.Drawing.Point(12, 33);
            this.Approve_Button.Name = "Approve_Button";
            this.Approve_Button.Size = new System.Drawing.Size(75, 35);
            this.Approve_Button.TabIndex = 1;
            this.Approve_Button.Text = "Approve";
            this.Approve_Button.Click += new System.EventHandler(this.Approve_Button_Click);
            // 
            // Decline_Button
            // 
            this.Decline_Button.Location = new System.Drawing.Point(107, 33);
            this.Decline_Button.Name = "Decline_Button";
            this.Decline_Button.Size = new System.Drawing.Size(75, 35);
            this.Decline_Button.TabIndex = 2;
            this.Decline_Button.Text = "Decline";
            this.Decline_Button.Click += new System.EventHandler(this.Decline_Button_Click);
            // 
            // Form_Nego
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(756, 420);
            this.Controls.Add(this.Decline_Button);
            this.Controls.Add(this.Approve_Button);
            this.Controls.Add(this.Nego_Grid);
            this.Name = "Form_Nego";
            this.Text = "Form_Nego";
            this.Load += new System.EventHandler(this.Form_Nego_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Nego_Grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Nego_GridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl Nego_Grid;
        private DevExpress.XtraGrid.Views.Grid.GridView Nego_GridView;
        private DevExpress.XtraEditors.SimpleButton Approve_Button;
        private DevExpress.XtraEditors.SimpleButton Decline_Button;
    }
}