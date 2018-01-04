using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SCLibrary;
using SCLibrary.Sql;
using SCLibrary.Request;
using System.IO;
using System.Net;
using System.Collections.Specialized;


namespace SC
{
    public partial class Form_Nego : Form
    {
        public Form_Nego()
        {
            InitializeComponent();
        }
        List<string> status_approval = new List<string>();
        void Display_nego()
        {
            
            FormUtility.LoadDatabaseToGrid("select tbl_negos.customer_id as CUSTOMER_ID, tbl_customers.customer_name as CUSTOMER, tbl_users.fullname as SALESMAN, design_name as DESIGN_NAME, price_before as HARGA, price_after as HARGA_NEGO, tgl_nego as TGL_NEGO, status_desc as STATUS, reason as NOTE from tbl_negos inner join tbl_customers on tbl_customers.customer_id=tbl_negos.customer_id inner join tbl_users on tbl_users.user_id=tbl_negos.sales_id",
                Nego_Grid, null);
        }

        private void Form_Nego_Load(object sender, EventArgs e)
        {
            Display_nego();
        }

        private void Decline_Button_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Nego_GridView.GetSelectedRows().Length; i++)
            {
                int nNego = Nego_GridView.GetSelectedRows()[i];
                string keyPointA = Nego_GridView.GetRowCellValue(nNego, "CUSTOMER_ID").ToString();
                string keyPointB = Nego_GridView.GetRowCellValue(nNego, "DESIGN_NAME").ToString();
                DBSql.DoCommand("update tbl_negos set status_approval='2', status_desc='Declined' where customer_id='"+keyPointA+"' and design_name='"+keyPointB+"' and status_approval='0'");
            }
            Display_nego();
        }

        private void Approve_Button_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < Nego_GridView.GetSelectedRows().Length; i++)
            {
                int nNego = Nego_GridView.GetSelectedRows()[i];
                string keyPointA = Nego_GridView.GetRowCellValue(nNego, "CUSTOMER_ID").ToString();
                string keyPointB = Nego_GridView.GetRowCellValue(nNego, "DESIGN_NAME").ToString();
                DBSql.DoCommand("update tbl_negos set status_approval='1', status_desc='Approved' where customer_id='" + keyPointA + "' and design_name='" + keyPointB + "' and status_approval='0'");
            }
            Display_nego();
        }
    }
}
