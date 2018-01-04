using System;
using System.Data;
using System.Windows.Forms;
using SCLibrary;


namespace SC
{
    public partial class Form_ProductFilter : Form
    {
        public string filterContract, filterProduct, filterDesign, filterFamily;
        public bool status_filter = false;
        public Form_ProductFilter()
        {
            InitializeComponent();
            this.FormClosing += Form_ProductFilter_FormClosing;
            value_filter();

        }

        private void Form_ProductFilter_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!status_filter)
            {
                status_filter = false;
            }
        }

        private void value_filter()
        {

            DataTable dt_contract = DBSql.DoGetData("select distinct contract from tbl_barangs").Tables[0];
            for (int i = 0; i < dt_contract.Rows.Count; i++)
            {
                Contract_Combobox.Items.Add(dt_contract.Rows[i][0].ToString());
            }

            DataTable dt_product = DBSql.DoGetData("select distinct product_code_desc from tbl_barangs").Tables[0];
            for (int i = 0; i < dt_product.Rows.Count; i++)
            {
                Product_ComboBox.Items.Add(dt_product.Rows[i][0].ToString());
            }

            DataTable dt_design = DBSql.DoGetData("select distinct description from tbl_barangs").Tables[0];
            for (int i = 0; i < dt_design.Rows.Count; i++)
            {
                Design_ComboBox.Items.Add(dt_design.Rows[i][0].ToString());
            }

            DataTable dt_family = DBSql.DoGetData("select distinct fam_product_desc from tbl_barangs").Tables[0];
            for (int i = 0; i < dt_family.Rows.Count; i++)
            {
                Family_ComboBox.Items.Add(dt_family.Rows[i][0].ToString());
            }

        }


        private void Form_ProductFilter_Load(object sender, EventArgs e)
        {

        }

        private void Set_Button_Click(object sender, EventArgs e)
        {
            filterContract = Contract_Combobox.Text;
            filterDesign = Design_ComboBox.Text;
            filterProduct = Product_ComboBox.Text;
            filterFamily = Family_ComboBox.Text;
            status_filter = true;
            this.Close();
        }
    }
}
