using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SCLibrary;
using UCUP.Networking;
using System.IO;

namespace SC
{
    public partial class Form_AddSales : Form
    {

        public Form_AddSales()
        {
            InitializeComponent();
            this.Load += Form_AddSales_Load;
        }

        private void Form_AddSales_Load(object sender, EventArgs e)
        {
            LoadData();
            Region_list_Label.Text = "";
            Segment_list_Label.Text = "";
        }

        List<string> list_region_id = new List<string>();
        List<string> list_segment_id = new List<string>();

        string list_region_acc = "";
        private void pic_barang_Click(object sender, EventArgs e)
        {
            
        }

        void LoadData()
        {
            DataTable dt_region = DBSql.DoGetData("select distinct region_name, region_id from tbl_customers").Tables[0];
            for (int i = 0; i < dt_region.Rows.Count; i++)
            {
                Region_Combobox.Items.Add(dt_region.Rows[i][0].ToString());
                list_region_id.Add(dt_region.Rows[i][1].ToString());
            }

            DataTable dt_segment = DBSql.DoGetData("select distinct segment, segment_id from tbl_customers").Tables[0];
            for (int i = 0; i < dt_segment.Rows.Count; i++)
            {
                Segment_Combobox.Items.Add(dt_segment.Rows[i][0].ToString());
                list_segment_id.Add(dt_segment.Rows[i][1].ToString());
            }

            
        }

        private void Button_AddSales_Click(object sender, EventArgs e)
        {
            try
            {
                byte[] data = AppUtility.StringToByte("{\"user_id\":\""+User_Textbox.Text+"\",\"pass_id\":\""+Pass_Textbox.Text+"\",\"fullname\":\""+SalesName_Textbox.Text+"\",\"region_name\":\""+list_region_acc.Substring(0, list_region_acc.Length-1)+"\",\"phone\":\""+PH_Textbox.Text+"\",\"user_roles\":\"3\",\"segment\":\""+Segment_list_Label.Text.Substring(0, Segment_list_Label.Text.Length-1)+"\"}");
                SimpleREST rest = new SimpleREST("http://ultimindserver.mywire.org:3000/register/user");
                rest.RequestAsync(data, delegate (bool status, string message, StreamReader reader)
                {
                    if (status)
                    {
                        if (reader!=null)
                        {
                            string output = reader.ReadToEnd();
                            if (!string.IsNullOrEmpty(output))
                            {
                                MessageBox.Show(output);
                            }
                        }else
                        {
                            if (reader!=null)
                            {
                                string output = reader.ReadToEnd();
                                MessageBox.Show(output);

                            }
                        }
                        this.Close();
                    }
                }, "Content-Type", "application/json");
                

            }
            catch (Exception) {
                PicBox_Validation.Visible = true;
                
            }
            
            
        }

        private void AddSalesmanForm_Load(object sender, EventArgs e)
        {
            
            tooltip_validation.SetToolTip(PicBox_Validation, "Username Sudah Digunakan");
        }

        private void Button_CancelSales_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RegionList_Button_Click(object sender, EventArgs e)
        {
            if (Region_Combobox.Text == "")
            {
                MessageBox.Show("Pilih WIlayah Terlebih Dahulu", "Wilayah required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (Region_list_Label.Text.Contains(Region_Combobox.Text))
            {
                return;
            }
            Region_list_Label.Text += Region_Combobox.Text+",";
            list_region_acc += list_region_id[Region_Combobox.SelectedIndex]+",";


        }

        private void Segment_ButtonList_Click(object sender, EventArgs e)
        {
            if (Segment_Combobox.Text == "")
            {
                MessageBox.Show("Pilih Bidang Usaha Terlebih Dahulu", "Bidang Usaha required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (Segment_list_Label.Text.Contains(Segment_Combobox.Text))
            {
                return;
            }
            Segment_list_Label.Text += Segment_Combobox.Text + ",";
        }

        private void ClearRegion_Button_Click(object sender, EventArgs e)
        {
            Region_list_Label.Text = "";
        }

        private void ClearSegment_Button_Click(object sender, EventArgs e)
        {
            Segment_list_Label.Text = "";
        }
    }
}
