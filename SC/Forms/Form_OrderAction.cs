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


namespace SC
{
    public partial class Form_OrderAction : Form
    {
        public Form_OrderAction()
        {
            InitializeComponent();
            
        }
        void Display_data()
        {
            DataSet ds = DBSql.DoGetData("select order_no as ORDER_NO, order_date as TANGGAL, tbl_customers.segment as BIDANG_USAHA, checkouts.market as MARKET, checkouts.region as WILAYAH, checkouts.customer_name as CUSTOMER, tbl_users.fullname as SALESMAN, g_total_price as TOTAL_PEMBAYARAN, currency as KURS, checkout_status as STATUS, notes as NOTE from checkouts inner join tbl_users on tbl_users.user_id=checkouts.sales_id inner join tbl_customers on tbl_customers.customer_id=checkouts.customer_id"+
                " where checkouts.order_no='" + this.Text + "'");

            Customer_Label.Text = ds.Tables[0].Rows[0][5].ToString();
            Segment_Label.Text = ds.Tables[0].Rows[0][2].ToString();
            Region_Label.Text = ds.Tables[0].Rows[0][4].ToString();
            Salesman_Label.Text = ds.Tables[0].Rows[0][6].ToString();
            Notes_rtb.Text = ds.Tables[0].Rows[0][10].ToString();
            Status_Label.Text = ds.Tables[0].Rows[0][9].ToString();
            Approve_Button.Enabled = true;
            Decline_Button.Enabled = true;
            if (Status_Label.Text != "Waiting")
            {
                Approve_Button.Enabled = false;
                Decline_Button.Enabled = false;
            }

            FormUtility.LoadDatabaseToGrid(
                "select part_no as PART_NO, product_name as PRODUCT_NAME, family_name as FAMILY_NAME, design_name as DESIGN_NAME, colors_name as COLOR, grade as GRADE, qty as JUMLAH, unit as SATUAN, price_unit as HARGA_SATUAN, total_price as TOTAL_HARGA, total_price_dom as TOTAL_HARGA_DOMESTIK from tbl_orders where order_no='" + this.Text + "'",
                Detail_Grid, null);

        }

        private void Approve_Button_Click(object sender, EventArgs e)
        {
            if (DBSql.DoCommand("update checkouts set checkout_status='Success' where order_no='"+this.Text+"' and checkout_status='Waiting'"))
            {
                this.Close();
                MessageBox.Show("Order Approved");
            }
        }

        private void Decline_Button_Click(object sender, EventArgs e)
        {
            if (DBSql.DoCommand("update checkouts set checkout_status='Declined' where order_no='" + this.Text + "' and checkout_status='Waiting'"))
            {
                this.Close();
                MessageBox.Show("Order Declined");
            }
        }

        private void Form_OrderAction_Load(object sender, EventArgs e)
        {
            Display_data();
        }
    }
}
