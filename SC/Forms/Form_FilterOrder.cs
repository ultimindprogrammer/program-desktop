using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SCLibrary.Sql;
using SCLibrary.Request;
using SCLibrary;
using SCLibrary.Doc.Xls;
using System.Collections.Specialized;
using UCUP.Threading;

namespace SC
{
    public partial class Form_FilterOrder : Form
    {
        public string filterRegion, filterSalesman, filterBidUsaha;
        public bool status_filter_order = false;
        public Form_FilterOrder()
        {
            InitializeComponent();
            this.FormClosing += Form_FilterOrder_FormClosing;
            Value_Filter();
        }

        private void Form_FilterOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!status_filter_order)
            {
                status_filter_order = false;
            }
        }

        private void Value_Filter()
        {
            

            DataTable dt = DBSql.DoGetData("select distinct region_name from tbl_customers").Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Region_Combobox.Items.Add(dt.Rows[i][0].ToString());
            }

            DataTable dt_sales = DBSql.DoGetData("select fullname from tbl_users where user_roles='3'").Tables[0];
            for (int i = 0; i < dt_sales.Rows.Count; i++)
            {
                Sales_ComboBox.Items.Add(dt_sales.Rows[i][0].ToString());
            }

            DataTable dt_segment = DBSql.DoGetData("select distinct segment from tbl_customers").Tables[0];
            for (int i = 0; i < dt_segment.Rows.Count; i++)
            {
                Segment_ComboBox.Items.Add(dt_segment.Rows[i][0].ToString());
            }
        }

        private void Set_Button_Click(object sender, EventArgs e)
        {
            filterRegion = Region_Combobox.Text;
            filterBidUsaha = Segment_ComboBox.Text;
            filterSalesman = Sales_ComboBox.Text;
            status_filter_order = true;
            this.Close();
        }
    }
}
