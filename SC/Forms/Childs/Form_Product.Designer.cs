namespace SC
{
    partial class Form_Product
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Product));
            this.pic_product = new DevExpress.XtraEditors.PictureEdit();
            this.lbl_part_no = new DevExpress.XtraEditors.LabelControl();
            this.btn_nav_back = new DevExpress.XtraEditors.SimpleButton();
            this.btn_upload = new DevExpress.XtraEditors.SimpleButton();
            this.btn_save = new DevExpress.XtraEditors.SimpleButton();
            this.btn_cancel = new DevExpress.XtraEditors.SimpleButton();
            this.pic_colors = new DevExpress.XtraEditors.PictureEdit();
            this.btn_upload_warna = new DevExpress.XtraEditors.SimpleButton();
            this.list_colors = new DevExpress.XtraEditors.ListBoxControl();
            this.txt_color_name = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pic_product.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_colors.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.list_colors)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_color_name.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pic_product
            // 
            this.pic_product.Cursor = System.Windows.Forms.Cursors.Default;
            this.pic_product.Location = new System.Drawing.Point(13, 74);
            this.pic_product.Name = "pic_product";
            this.pic_product.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pic_product.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pic_product.Properties.ZoomAccelerationFactor = 1D;
            this.pic_product.Size = new System.Drawing.Size(238, 287);
            this.pic_product.TabIndex = 0;
            this.pic_product.DoubleClick += new System.EventHandler(this.pic_product_DoubleClick);
            // 
            // lbl_part_no
            // 
            this.lbl_part_no.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_part_no.Appearance.Options.UseFont = true;
            this.lbl_part_no.Location = new System.Drawing.Point(77, 22);
            this.lbl_part_no.Name = "lbl_part_no";
            this.lbl_part_no.Size = new System.Drawing.Size(142, 25);
            this.lbl_part_no.TabIndex = 20;
            this.lbl_part_no.Text = "F-GGWP-80A-A";
            // 
            // btn_nav_back
            // 
            this.btn_nav_back.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_nav_back.BackgroundImage")));
            this.btn_nav_back.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_nav_back.ButtonStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btn_nav_back.Location = new System.Drawing.Point(25, 19);
            this.btn_nav_back.Name = "btn_nav_back";
            this.btn_nav_back.Size = new System.Drawing.Size(31, 31);
            this.btn_nav_back.TabIndex = 19;
            this.btn_nav_back.Click += new System.EventHandler(this.btn_nav_back_Click);
            // 
            // btn_upload
            // 
            this.btn_upload.Location = new System.Drawing.Point(77, 365);
            this.btn_upload.Name = "btn_upload";
            this.btn_upload.Size = new System.Drawing.Size(86, 36);
            this.btn_upload.TabIndex = 21;
            this.btn_upload.Text = "Unggah Desain";
            this.btn_upload.Click += new System.EventHandler(this.btn_upload_Click);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(485, 264);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(165, 57);
            this.btn_save.TabIndex = 22;
            this.btn_save.Text = "Simpan";
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.Location = new System.Drawing.Point(485, 326);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(165, 36);
            this.btn_cancel.TabIndex = 23;
            this.btn_cancel.Text = "Batal";
            // 
            // pic_colors
            // 
            this.pic_colors.Cursor = System.Windows.Forms.Cursors.Default;
            this.pic_colors.Location = new System.Drawing.Point(485, 100);
            this.pic_colors.Name = "pic_colors";
            this.pic_colors.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pic_colors.Properties.ShowMenu = false;
            this.pic_colors.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pic_colors.Properties.ZoomAccelerationFactor = 1D;
            this.pic_colors.Size = new System.Drawing.Size(165, 127);
            this.pic_colors.TabIndex = 24;
            this.pic_colors.DoubleClick += new System.EventHandler(this.pic_colors_DoubleClick);
            // 
            // btn_upload_warna
            // 
            this.btn_upload_warna.Location = new System.Drawing.Point(486, 233);
            this.btn_upload_warna.Name = "btn_upload_warna";
            this.btn_upload_warna.Size = new System.Drawing.Size(165, 25);
            this.btn_upload_warna.TabIndex = 25;
            this.btn_upload_warna.Text = "Tambah Warna";
            // 
            // list_colors
            // 
            this.list_colors.Cursor = System.Windows.Forms.Cursors.Default;
            this.list_colors.Location = new System.Drawing.Point(257, 74);
            this.list_colors.Name = "list_colors";
            this.list_colors.Size = new System.Drawing.Size(210, 287);
            this.list_colors.TabIndex = 26;
            this.list_colors.SelectedIndexChanged += new System.EventHandler(this.list_colors_SelectedIndexChanged);
            this.list_colors.Click += new System.EventHandler(this.list_colors_Click);
            // 
            // txt_color_name
            // 
            this.txt_color_name.Location = new System.Drawing.Point(486, 74);
            this.txt_color_name.Name = "txt_color_name";
            this.txt_color_name.Size = new System.Drawing.Size(164, 20);
            this.txt_color_name.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(531, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Nama Warna";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(254, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 29;
            this.label2.Text = "Daftar Warna";
            // 
            // Form_Product
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 411);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_color_name);
            this.Controls.Add(this.list_colors);
            this.Controls.Add(this.btn_upload_warna);
            this.Controls.Add(this.pic_colors);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_upload);
            this.Controls.Add(this.lbl_part_no);
            this.Controls.Add(this.btn_nav_back);
            this.Controls.Add(this.pic_product);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_Product";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detail Product";
            this.Load += new System.EventHandler(this.ProductForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pic_product.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_colors.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.list_colors)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_color_name.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit pic_product;
        private DevExpress.XtraEditors.LabelControl lbl_part_no;
        private DevExpress.XtraEditors.SimpleButton btn_nav_back;
        private DevExpress.XtraEditors.SimpleButton btn_upload;
        private DevExpress.XtraEditors.SimpleButton btn_save;
        private DevExpress.XtraEditors.SimpleButton btn_cancel;
        private DevExpress.XtraEditors.PictureEdit pic_colors;
        private DevExpress.XtraEditors.SimpleButton btn_upload_warna;
        private DevExpress.XtraEditors.ListBoxControl list_colors;
        private DevExpress.XtraEditors.TextEdit txt_color_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}