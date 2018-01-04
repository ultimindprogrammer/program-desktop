using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SCLibrary;

namespace SC
{
    public partial class Form_TambahCustomer : Form
    {
        public bool status_add_customer = false;

        DateTime date = DateTime.Now;
        List<string> list_region_id = new List<string>();
        List<string> list_segment_id = new List<string>();
        List<string> list_market_id = new List<string>();
        
        public Form_TambahCustomer()
        {
            InitializeComponent();
            this.Load += From_TambahCustomer_Load;
            Add_Button.Click += Add_Button_Click;
            Console.WriteLine(date.Year + "-" + (date.Month < 10 ? "0" + date.Month : "" + date.Month) + "-" + (date.Day < 10 ? "0" + date.Day : "" + date.Day) + " " + (date.Hour < 10 ? "0" + date.Hour : "" + date.Hour) + ":" + (date.Minute < 10 ? "0" + date.Minute : "" + date.Minute) + ":" + (date.Second < 10 ? "0" + date.Second : date.Second + ""));
        }

        static bool ValidationForm(params System.Windows.Forms.Control[] control)
        {
            int i = 0;
            bool m_validation_status = true;
            while (m_validation_status && i < control.Length)
            {
                if (control[i].Text == "")
                {
                    m_validation_status = false;
                }
                i++;
            }
            return m_validation_status;
        }

        static void ClearForm(params System.Windows.Forms.Control[] control)
        {
            for (int i = 0; i < control.Length; i++)
            {
                control[i].Text = "";
            }
        }

        private void Add_Button_Click(object sender, EventArgs e)
        {
            if (!ValidationForm(CustID_Textbox, Cust_Textbox, Segment_ComboBox, Addr_Textbox, Country_Textbox, Region_ComboBox, Market_ComboBox, CP_Textbox, PH_Textbox, MPH_Textbox, fx_Textbox))
            {
                MessageBox.Show("Semua Form Harus Diisi", "Form Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string queryInsert = "insert ignore into tbl_customers (customer_id, customer_name, segment_id, segment, address1, country, city, region_id, region_name, market_id, market, contact_person, phone, mobile_phone, fax, sales_id, status_approval) "+
                "values ('" + CustID_Textbox.Text + "','" + Cust_Textbox.Text + "','" + list_segment_id[Segment_ComboBox.SelectedIndex] + "','" + Segment_ComboBox.Text + "','" + Addr_Textbox.Text + "','" + Country_Textbox.Text + "','" + "-" + "','" + list_region_id[Region_ComboBox.SelectedIndex] + "','" + Region_ComboBox.Text + "','" + list_market_id[Market_ComboBox.SelectedIndex] + "','" + Market_ComboBox.Text + "','" + CP_Textbox.Text + "','" + PH_Textbox.Text + "','" + MPH_Textbox.Text + "','" + fx_Textbox.Text + "','" + "-" + "','" + "Approve" + "')";
            if (DBSql.DoCommand(queryInsert))
            {
                status_add_customer = true;
                this.Close();
            }else
            {
                MessageBox.Show("Customer ID Sudah Digunakan", "Add Customer", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Reset_Button_Click(object sender, EventArgs e)
        {
            ClearForm(CustID_Textbox, Cust_Textbox, Segment_ComboBox, Addr_Textbox, Country_Textbox, Region_ComboBox, Market_ComboBox, CP_Textbox, PH_Textbox, MPH_Textbox, fx_Textbox);
        }

        private void From_TambahCustomer_Load(object sender, EventArgs e)
        {
            LoadData();
            
        }

        void LoadData()
        {

            DataTable dt_region = DBSql.DoGetData("select distinct region_name from tbl_customers").Tables[0];
            for (int i = 0; i < dt_region.Rows.Count; i++)
            {
                Region_ComboBox.Items.Add(dt_region.Rows[i][0].ToString());
            }

            DataTable dt_region_id = DBSql.DoGetData("select distinct region_id from tbl_customers").Tables[0];
            for (int i = 0; i < dt_region_id.Rows.Count; i++)
            {
                list_region_id.Add(dt_region_id.Rows[i][0].ToString());
            }

            DataTable dt_segment = DBSql.DoGetData("select distinct segment from tbl_customers").Tables[0];
            for (int i = 0; i < dt_segment.Rows.Count; i++)
            {
                Segment_ComboBox.Items.Add(dt_segment.Rows[i][0].ToString());
            }

            DataTable dt_segment_id = DBSql.DoGetData("select distinct segment_id from tbl_customers").Tables[0];
            for (int i = 0; i < dt_segment_id.Rows.Count; i++)
            {
                list_segment_id.Add(dt_segment_id.Rows[i][0].ToString());
            }

            DataTable dt_market_id = DBSql.DoGetData("select distinct market_id from tbl_customers").Tables[0];
            for (int i = 0; i < dt_market_id.Rows.Count; i++)
            {
                list_market_id.Add(dt_market_id.Rows[i][0].ToString());
            }

            DataTable dt_market = DBSql.DoGetData("select distinct market from tbl_customers").Tables[0];
            for (int i = 0; i < dt_market.Rows.Count; i++)
            {
                Market_ComboBox.Items.Add(dt_market.Rows[i][0].ToString());
            }

        }

        
    }
}
