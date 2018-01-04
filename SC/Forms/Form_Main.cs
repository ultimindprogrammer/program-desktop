
using SC.Component;
using SCLibrary;
using SCLibrary.Doc.Xls;
using SCLibrary.Request;
using SCLibrary.Sql;
using System;
using System.Collections.Specialized;
using System.Data;
using System.IO;
using System.Windows.Forms;
using UCUP.Threading;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
namespace SC
{
    
    public partial class Form_Main : DevExpress.XtraEditors.XtraForm
    {
        DBMySQL db;
        string queryOrder = "select order_no as ORDER_NO, order_date as TANGGAL, tbl_customers.segment as BIDANG_USAHA, checkouts.market as MARKET, checkouts.region as WILAYAH, checkouts.customer_name as CUSTOMER, tbl_users.fullname as SALESMAN, g_total_price as TOTAL_PEMBAYARAN, currency as KURS, checkout_status as STATUS, notes as NOTE from checkouts inner join tbl_users on tbl_users.user_id=checkouts.sales_id inner join tbl_customers on tbl_customers.customer_id=checkouts.customer_id";
        //string queryProduct = "SELECT tbl_designs.contract as CONTRACT, accounting_group as ACCOUNTING_GROUP, tbl_designs.design_id as KODE_DESAIN, tbl_designs.design_name as DESAIN, tbl_designs.product_code KELOMPOK_PRODUK, tbl_designs.family_code as KELOMPOK_DESAIN, tbl_designs.price_inc as HARGA FROM `tbl_designs` inner join tbl_products on tbl_products.product_code=tbl_designs.product_code";

        //`id`, `contract`, `design_id`, `part_no`, `description`, `accounting_group`, `acc_gr_desc`, `product_code`, `product_code_desc`, `fam_product`, `fam_product_desc`, `prime_com`, `prime_com_desc`, `second_com`, `second_com_desc`, `unit`, `grade`, `color_code`, `color_desc`, `url_design_img`, `url_color_img`, `price_inc`, `price_exc
        string queryProduct = "SELECT distinct contract as CONTRACT, product_code_desc as PRODUCT_NAME, fam_product_desc as FAMILY_NAME, unit as SATUAN, description as DESIGN_NAME, price_exc as HARGA from tbl_barangs where grade ='A'";
        string querySales = "SELECT user_id as USERNAME, fullname as NAMA_SALES, last_login_user as TERAKHIR_LOGIN, sales_region as REGION, bidang_usaha as BIDANG_USAHA from tbl_users where user_roles='3'";
        string queryCustomer = "SELECT customer_id as CUSTOMER_ID, customer_name as NAMA_CUSTOMER, segment as SEGMENT, region_name as WILAYAH, market as MARKET from tbl_customers inner join tbl_users on tbl_users.user_id=tbl_customers.sales_id";
        private string path_image = "";

        //Internal Field
        internal AppContext _context;
        
        #region Initializer
        public Form_Main()
        {
            InitializeComponent();
            this.FormClosing += Form_Main_OnFormClosing;
            Header_Label_Logout.Click += Header_Label_Logout_Click;

            /*Initializer*/
            Initialize_GUI();
            Initialize_NavHeaderArea();
            Initialize_DashboardArea();
            Initialize_OrderArea();
            Initialize_Product();
            Initialize_Customer();
            Initialize_Sales();
            DateTime date = DateTime.Now;
            
            

        }

        private void Header_Label_Logout_Click(object sender, EventArgs e)
        {
            this.FormClosing -= Form_Main_OnFormClosing;
            this.Close();
            _context.Show_LoginForm();
        }

        private void Form_Main_OnFormClosing(object sender, FormClosingEventArgs e)
        {
            _context.Show_Overlay(this);
            DialogResult res = MessageBox.Show("Are You Sure you want to Quit?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (res == DialogResult.OK)
            {
                _context.RequestExit();
                Console.WriteLine("Requested Exit");
            }
            else
            {
                e.Cancel = true;
                _context.Hide_Overlay();
            } 
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Worker.DisposeAllWorker();
        }
        #endregion

        #region UI Event

        #region Header & Navigation
        /// <summary>
        /// Event yang dipanggil ketika Berpindah "Scene"
        /// </summary>
        /// <param name="i"></param>
        private void Event_OnNavSelectedPageChanged(int i)
        {
            //Stop All Worker
            Worker.DisposeAllWorker();

            //UnLoad All Grid
            Order_Grid.DataSource = null;
            Order_GridView.PopulateColumns();

            Product_Grid.DataSource = null;
            Product_GridView.PopulateColumns();

            switch (i)
            {
                case 0: //Dashboard Page
                    DataTable dt = null;
                    //Load Statistic
                    dt = DBSql.DoGetData("select count(*) from tbl_customers").Tables[0];
                    Dashboard_PanelInfo1_Num.Text = dt.Rows[0][0].ToString();

                    dt = DBSql.DoGetData("select count(*) from checkouts").Tables[0];
                    Dashboard_PanelInfo2_Num.Text = dt.Rows[0][0].ToString();

                    dt = DBSql.DoGetData("select count(*) from checkouts where checkout_status not like 'Success'").Tables[0];
                    Dashboard_PanelInfo3_Num.Text = dt.Rows[0][0].ToString();

                    dt = DBSql.DoGetData("select count(*) from checkouts where checkout_status='Success'").Tables[0];
                    Dashboard_PanelInfo4_Num.Text = dt.Rows[0][0].ToString();
                    break;
                case 1: //Order Page
                    OrderGridUpdate();
                    break;
                case 2: //Product Page
                    ProductGridUpdate();
                    break;
                case 3: //Customer Page
                    if (App.userInfo.userType!=UserType.SuperAdmin)
                    {
                        _context.Show_Overlay(this);
                        MessageBox.Show("Akses ditolak, Hanya Super Admin yang Diperbolehkan", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        _context.Hide_Overlay();
                        Header_Button_Dashboard.Checked = true;
                        return;
                    }
                    CustomerUpdateGrid();
                    break;
                case 4: //Sales Page
                    if (App.userInfo.userType!=UserType.SuperAdmin)
                    {
                        _context.Show_Overlay(this);
                        MessageBox.Show("Akses ditolak, Hanya Super Admin yang Diperbolehkan", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        _context.Hide_Overlay();
                        Header_Button_Dashboard.Checked = true;
                        return;
                    }
                    SalesUpdateGrid();
                    break;
            }
        }
        #endregion

        #region Order
        /// <summary>
        /// Event yang dipanggil ketika <see cref="CircleButton"/> terclick di Area <see cref="Order_NavFrmae"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Event_OnOrderNavButtonClicked(object sender, EventArgs e)
        {
            var btn = (CircleButton)sender;
            switch (btn.tag)
            {
                case "Approve":
                    for (int i = 0; i < Order_GridView.GetSelectedRows().Length; i++)
                    {
                        string order_no = Order_GridView.GetRowCellValue(Order_GridView.GetSelectedRows()[i], "ORDER_NO").ToString();
                        DBSql.DoCommand("update checkouts set checkout_status='Success' where checkout_status='Waiting' and order_no='" + order_no + "'");
                    }
                    FormUtility.LoadDatabaseToGrid(queryOrder, Order_Grid, null);
                    Toast.ShowToast(Order_GridView.GetSelectedRows().Length + " Order Approved", "Order", ToastIndicator.Ok);
                    break;
                case "Decline":
                    for (int i = 0; i < Order_GridView.GetSelectedRows().Length; i++)
                    {
                        string order_no = Order_GridView.GetRowCellValue(Order_GridView.GetSelectedRows()[i], "ORDER_NO").ToString();
                        DBSql.DoCommand("update checkouts set checkout_status='Declined' where checkout_status='Waiting' and order_no='" + order_no + "'");
                    }
                    FormUtility.LoadDatabaseToGrid(queryOrder, Order_Grid, null);
                    Toast.ShowToast(Order_GridView.GetSelectedRows().Length + " Order Declined", "Order", ToastIndicator.Ok);
                    break;
                case "Cancel":
                    for (int i = 0; i < Order_GridView.GetSelectedRows().Length; i++)
                    {
                        string order_no = Order_GridView.GetRowCellValue(Order_GridView.GetSelectedRows()[i], "ORDER_NO").ToString();
                        DBSql.DoCommand("update checkouts set checkout_status='Canceled' where checkout_status='Waiting' and order_no='" + order_no + "'");
                    }
                    FormUtility.LoadDatabaseToGrid(queryOrder, Order_Grid, null);
                    Toast.ShowToast(Order_GridView.GetSelectedRows().Length + " Order Canceled", "Order", ToastIndicator.Ok);
                    break;
                case "Print":
                    break;
                case "Export":
                    Dialog.ShowSaveFileDialog("Export Database", "Excel 97-2003 Workbook|*.xls", delegate (bool ok, string path) {
                        if (ok)
                        {
                            DataSet ds = DBSql.DoGetData("select checkouts.order_no as ORDER_NO, checkouts.order_date as TANGGAL, tbl_customers.segment as BIDANG_USAHA, checkouts.customer_name as CUSTOMER, tbl_customers.region_name as WILAYAH, tbl_orders.product_name as PRODUCT_DESC, tbl_orders.family_name as FAMILY_DESC, tbl_orders.part_no as PART_NO, tbl_orders.design_name as DESAIN, tbl_orders.colors_name as WARNA, checkouts.currency as KURS, tbl_orders.price_unit as HARGA_SATUAN, tbl_orders.qty as QTY, tbl_orders.total_price as HARGA_TOTAL, tbl_users.fullname as SALESMAN, checkouts.notes as NOTE, checkouts.checkout_status as STATUS from checkouts inner join tbl_orders on tbl_orders.order_no=checkouts.order_no inner join tbl_customers on tbl_customers.customer_id=checkouts.customer_id inner join tbl_users on tbl_users.user_id=checkouts.sales_id");
                            if (ds != null)
                            {
                                XlsData data = new XlsData(ds);
                                data.ToFile(path);

                            }
                            Toast.ShowToast("Data Berhasil Diexport", "Export Data Order", ToastIndicator.Ok);
                        }


                    });
                    break;
                case "Filter_Filter":
                    //m_orderFilterToggle.state = !m_orderFilterToggle.state;
                    Form_FilterOrder order_filter = new Form_FilterOrder();
                    order_filter.ShowDialog();
                    string query_filter = " where";
                    if (order_filter.filterRegion!="")
                    {
                        query_filter += " region='" + order_filter.filterRegion + "' AND";
                    }
                    if (order_filter.filterBidUsaha!="")
                    {
                        query_filter += " segment='"+order_filter.filterBidUsaha+"' AND";
                    }
                    if (order_filter.filterSalesman!="")
                    {
                        query_filter += " tbl_users.fullname='"+order_filter.filterSalesman+"' AND";
                    }
                    query_filter = query_filter.Substring(0, query_filter.Length - 3);
                    if (order_filter.status_filter_order)
                    {
                        FormUtility.LoadDatabaseToGrid(queryOrder + query_filter, Order_Grid, null);
                    }
                    break;
                case "Filter_Cancel":
                    FormUtility.LoadDatabaseToGrid(queryOrder, Order_Grid, null);
                    break;
                case "NextPage":
                    break;
                case "PrevPage":
                    break;
                case "Negosiasi":
                    //This is event
                    Form_Nego form_nego = new Form_Nego();
                    ShowForm(form_nego);
                    break;
            }
        }
        
        /// <summary>
        /// Event yangd dipanggil ketika <see cref="Order_SideBar_Button_Declined"/> terclick di Area <see cref="Order_NavFrmae"/>
        /// </summary>
        /// <param name="i"></param>
        private void Event_OnOrderSideButtonClicked(int i)
        {
            switch (i)
            {
                case 0: //All Button
                    FormUtility.LoadDatabaseToGrid(queryOrder, Order_Grid, null);
                    break;
                case 1: //Waiting Button
                    FormUtility.LoadDatabaseToGrid(queryOrder+" where checkout_status='Waiting'", Order_Grid, null);
                    break;
                case 2: //Canceled Button
                    FormUtility.LoadDatabaseToGrid(queryOrder+" where checkout_status='Canceled'", Order_Grid, null);
                    break;
                case 3: //Finished Button
                    FormUtility.LoadDatabaseToGrid(queryOrder + " where checkout_status='Success'", Order_Grid, null);
                    break;
                case 4:
                    FormUtility.LoadDatabaseToGrid(queryOrder + " where checkout_status='Declined'", Order_Grid, null);
                    break;
            }
        }
        private void Event_OnOrderGridDoubleClicked(GridHitInfo info) {
            //Example
            /*
            for (int i = 0; i < Order_GridView.Columns.Count; i++) {
                var value = Order_GridView.GetRowCellValue(info.RowHandle, Order_GridView.Columns[i]);
            }
            */
            Form_OrderAction order_action = new Form_OrderAction();
            order_action.Text = "" + Order_GridView.GetRowCellValue(info.RowHandle, "ORDER_NO");
            Console.WriteLine(order_action.Text);
            ShowForm(order_action);
            FormUtility.LoadDatabaseToGrid(queryOrder, Order_Grid, null);
        }
        #endregion

        #region Customer
        /// <summary>
        /// Event yangd dipanggil ketika <see cref="CircleButton"/> terclick di Area <see cref="Customer_NavFrame"/>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Event_OnCustomerNavButtonClicked(object sender, EventArgs e)
        {
            var btn = (CircleButton)sender;
            switch (btn.tag)
            {
                case "Filter_Filter":
                    Form_CustomerFilter customer_filter = new Form_CustomerFilter();
                    ShowForm(customer_filter);
                    string query_filter = " where";
                    if (customer_filter.filterRegion!="")
                    {
                        query_filter += " region_name='" + customer_filter.filterRegion + "' AND";
                    }
                    if (customer_filter.filterSegment!="")
                    {
                        query_filter += " segment='" + customer_filter.filterSegment + "' AND";
                    }
                    query_filter = query_filter.Substring(0, query_filter.Length - 3);
                    if (customer_filter.m_status_filter)
                    {
                        FormUtility.LoadDatabaseToGrid(queryCustomer + query_filter, Customer_Grid, null);
                    }
                    break;
                case "Filter_Cancel":
                    FormUtility.LoadDatabaseToGrid(queryCustomer, Customer_Grid, null);
                    break;
                case "NextPage":
                    break;
                case "PrevPage":
                    break;
                case "Add":
                    Form_TambahCustomer form_tambah_cust = new Form_TambahCustomer();
                    ShowForm(form_tambah_cust);
                    if (form_tambah_cust.status_add_customer)
                    {
                        Toast.ShowToast("Customer Berhasil Ditambahkan", "Add Customer", ToastIndicator.Ok);
                        FormUtility.LoadDatabaseToGrid(queryCustomer, Customer_Grid, null);
                    }
                    break;
                case "Delete":
                    break;
            }
        }
        private void Event_OnCustomerGridDoubleClicked(GridHitInfo info)
        {
            //Example
            /*
            for (int i = 0; i < Order_GridView.Columns.Count; i++) {
                var value = Order_GridView.GetRowCellValue(info.RowHandle, Order_GridView.Columns[i]);
            }
            */
        }
#endregion

#region Product
        /// <summary>
        /// Event yangd dipanggil ketika <see cref="CircleButton"/> terclick di Area <see cref="Product_NavFrame"/>
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        private void Event_OnProductNavButtonClicked(object obj, EventArgs e)
        {
            var btn = (CircleButton)obj;
            switch (btn.tag)
            {
                case "FilterFilter":
                    Form_ProductFilter form_filter = new Form_ProductFilter();
                    form_filter.ShowDialog();
                    string query_filter = " AND";
                    if (form_filter.filterContract != "")
                    {
                        query_filter += " contract='"+ form_filter.filterContract + "' AND";
                    }
                    if (form_filter.filterProduct != "")
                    {
                        query_filter += " product_code_desc='" + form_filter.filterProduct + "' AND";
                    }
                    if (form_filter.filterDesign != "")
                    {
                        query_filter += " description='" + form_filter.filterDesign + "' AND";
                    }
                    if (form_filter.filterFamily != "")
                    {
                        query_filter += " fam_product_desc='" + form_filter.filterFamily + "' AND";
                    }
                    query_filter = query_filter.Substring(0, query_filter.Length - 3);
                    if (form_filter.status_filter)
                    {
                        FormUtility.LoadDatabaseToGrid(queryProduct + query_filter, Product_Grid, null);
                    }
                    break;
                case "FilterCancel":
                    FormUtility.LoadDatabaseToGrid(queryProduct, Product_Grid, null);
                    break;
                case "PrevPage":
                    break;
                case "NextPage":
                    break;
                case "Import":
                    Dialog.ShowOpenFileDialog("Import Database", "Excel 97-2003 Workbook|*.xls", delegate (bool ok, string path)
                    {
                        if (ok)
                        {
                            XlsData data = new XlsData(path);
                            DataSet ds = data.ToDataSet();
                            bool status_import = false;
                            Random rand = new Random(9999);
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {

                                string query_import = "insert into tbl_barangs (contract, design_id, part_no, description, accounting_group, acc_gr_desc, product_code, product_code_desc, fam_product, fam_product_desc, prime_com, prime_com_desc, second_com, second_com_desc, unit, grade, color_code, color_desc, url_design_img, url_color_img, price_inc, price_exc) values('" + ds.Tables[0].Rows[i][0].ToString() + "','" + "des" + rand.Next(9999).ToString() + "','" + ds.Tables[0].Rows[i][1].ToString() + "','" + ds.Tables[0].Rows[i][2].ToString() + "','" + ds.Tables[0].Rows[i][3].ToString() + "','" + ds.Tables[0].Rows[i][4].ToString() + "','" + ds.Tables[0].Rows[i][5].ToString() + "','" + ds.Tables[0].Rows[i][6].ToString() + "','" + ds.Tables[0].Rows[i][7].ToString() + "','" + ds.Tables[0].Rows[i][8].ToString() + "','" + ds.Tables[0].Rows[i][9].ToString() + "','" + ds.Tables[0].Rows[i][10].ToString() + "','" + ds.Tables[0].Rows[i][11].ToString() + "','" + ds.Tables[0].Rows[i][12].ToString() + "','" + ds.Tables[0].Rows[i][13].ToString() + "','" + ds.Tables[0].Rows[i][1].ToString().Split('-')[ds.Tables[0].Rows[i][1].ToString().Split('-').Length - 1] + "','" + ds.Tables[0].Rows[i][14].ToString() + "','" + ds.Tables[0].Rows[i][15].ToString() + "','" + "-" + "','" + "-" + "','" + ds.Tables[0].Rows[i][16].ToString() + "','" + ds.Tables[0].Rows[i][17].ToString() + "')";
                                DataSet ds_check = DBSql.DoGetData("select count(*) from tbl_barangs where part_no='"+ ds.Tables[0].Rows[i][1].ToString() + "' and contract='"+ ds.Tables[0].Rows[i][0].ToString() + "'");
                                if (int.Parse(ds_check.Tables[0].Rows[0][0].ToString())==0)
                                {
                                    DataSet ds_check_part2 = DBSql.DoGetData("select design_id from tbl_barangs where description='" + ds.Tables[0].Rows[i][2].ToString() + "' and contract='" + ds.Tables[0].Rows[i][0].ToString() + "' limit 1");
                                    if (ds_check_part2.Tables[0].Rows.Count>0)
                                    {
                                        query_import = "insert into tbl_barangs (contract, design_id, part_no, description, accounting_group, acc_gr_desc, product_code, product_code_desc, fam_product, fam_product_desc, prime_com, prime_com_desc, second_com, second_com_desc, unit, grade, color_code, color_desc, url_design_img, url_color_img, price_inc, price_exc) values('" + ds.Tables[0].Rows[i][0].ToString() + "','" + ds_check_part2.Tables[0].Rows[0][0].ToString() + "','" + ds.Tables[0].Rows[i][1].ToString() + "','" + ds.Tables[0].Rows[i][2].ToString() + "','" + ds.Tables[0].Rows[i][3].ToString() + "','" + ds.Tables[0].Rows[i][4].ToString() + "','" + ds.Tables[0].Rows[i][5].ToString() + "','" + ds.Tables[0].Rows[i][6].ToString() + "','" + ds.Tables[0].Rows[i][7].ToString() + "','" + ds.Tables[0].Rows[i][8].ToString() + "','" + ds.Tables[0].Rows[i][9].ToString() + "','" + ds.Tables[0].Rows[i][10].ToString() + "','" + ds.Tables[0].Rows[i][11].ToString() + "','" + ds.Tables[0].Rows[i][12].ToString() + "','" + ds.Tables[0].Rows[i][13].ToString() + "','" + ds.Tables[0].Rows[i][1].ToString().Split('-')[ds.Tables[0].Rows[i][1].ToString().Split('-').Length - 1] + "','" + ds.Tables[0].Rows[i][14].ToString() + "','" + ds.Tables[0].Rows[i][15].ToString() + "','" + "-" + "','" + "-" + "','" + ds.Tables[0].Rows[i][16].ToString() + "','" + ds.Tables[0].Rows[i][17].ToString() + "')";
                                        DBSql.DoCommand(query_import);
                                    }else
                                    {
                                        DBSql.DoCommand(query_import);
                                    }
                                    status_import = true;
                                }
                                
                            }
                            Toast.ShowToast("Data Barang "+(status_import ? "Berhasil" : "Tidak")+" Diimport", "Import Data Barang", ToastIndicator.Ok);
                        }
                    });
                    break;
                case "Export":
                    Dialog.ShowSaveFileDialog("Export Database", "Excel 97-2003 Workbook|*.xls", delegate (bool ok, string path)
                    {
                        if (ok)
                        {
                            DataSet ds = DBSql.DoGetData("select contract as CONTRACT, part_no as PART_NO, description as DESCRIPTION, accounting_group as ACCOUNTING_GROUP, acc_gr_desc as ACC_GROUP_DESC, product_code as PRODUCT_CODE, product_code_desc as PRODUCT_CODE_DESC, fam_product as FAM_PRODUCT_CODE, fam_product_desc as FAM_PRODUCT_DESC, prime_com as PRIME_COMMODITY, prime_com_desc as PRIME_COM_DESC, second_com as SECOND_COMMODIY, second_com_desc as SECOND_COM_DESC, unit as UNIT_MEAS, grade as GRADE, color_code as COLOR_CODE, color_desc as COLOR_DESC, price_inc as PRICE_INC, price_exc as PRICE_EXC FROM tbl_barangs where grade='A'");
                            XlsData data = new XlsData(ds);
                            data.ToFile(path);
                            Toast.ShowToast("Data Barang Berhasil Diexport", "Export Data Barang", ToastIndicator.Ok);
                        }
                    });
                    break;
            }
        }
        private void Event_OnProductGridDoubleClicked(GridHitInfo info) {
            //Example
            /*
            for (int i = 0; i < Order_GridView.Columns.Count; i++) {
                var value = Order_GridView.GetRowCellValue(info.RowHandle, Order_GridView.Columns[i]);
            }
            */
            Form_Product product = new Form_Product();
            product.Text = "" + Product_GridView.GetRowCellValue(info.RowHandle, "DESIGN_NAME")+"$"+ Product_GridView.GetRowCellValue(info.RowHandle, "CONTRACT");
            ShowForm(product);
        }
    #endregion

    #region Sales
        /// <summary>
        /// Event yangd dipanggil ketika <see cref="CircleButton"/> terclick di Area <see cref="Sales_NavFrame"/>
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="e"></param>
        private void Event_OnSalesNavButtonClicked(object sender, EventArgs e)
        {
            var btn = (CircleButton)sender;
            switch (btn.tag)
            {
                case "Filter_Filter":
                    break;
                case "Filter_Cancel":
                    break;
                case "NextPage":
                    break;
                case "PrevPage":
                    break;
                case "Add":
                    Form_AddSales form_sales = new Form_AddSales();
                    ShowForm(form_sales);
                    FormUtility.LoadDatabaseToGrid(querySales, Sales_Grid, null);
                    break;
                case "Delete":
                    break;

            }
        }
        private void Event_OnSalesGridDoubleClicked(GridHitInfo info)
        {
            //Example
            /*
            for (int i = 0; i < Order_GridView.Columns.Count; i++) {
                var value = Order_GridView.GetRowCellValue(info.RowHandle, Order_GridView.Columns[i]);
            }
            */
        }
    #endregion

    #endregion

#region Core

#endregion

#region UI Callback

        private void ProductEdit_OptionPanel_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            switch (e.Button.Properties.Caption)
            {
                case "Save":
                    if (String.IsNullOrEmpty(path_image))
                    {
                        NavFrame.SelectedPageIndex = 2;
                        //MessageBox.Show("Data tidak dimasukan");
                        return;
                    }
                    NameValueCollection nvc = new NameValueCollection();
                    //nvc.Add("part_no", lbl_part_no.Text);
                    UploadImage upload = new UploadImage();
                    upload.HttpUploadFile("http://localhost/postgresql_laravel/public/upload", path_image, "foto", "image/jpeg", nvc);
                    path_image = "";
                    NavFrame.SelectedPageIndex = 2;
                    MessageBox.Show("Data berhasil dimasukan");
                    break;

                default:
                    break;
            }
        }

        private void Product_OptionPanel_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            switch (e.Button.Properties.Caption)
            {

                case "New":
                    MessageBox.Show("Fitur Belum Tersedia");
                    break;
                case "Export":
                    Dialog.ShowSaveFileDialog("Export Database", "Excel 97-2003 Workbook|*.xls", delegate (bool ok, string path)
                    {
                        if (ok)
                        {
                            string query = "SELECT tbl_designs.contract as CONTRACT, tbl_designs.design_id as KODE_DESAIN, tbl_designs.design_name as DESAIN, tbl_designs.product_code KELOMPOK_PRODUK, tbl_families.family_code as KELOMPOK_DESAIN FROM `tbl_designs` inner join tbl_products on tbl_products.product_code=tbl_designs.product_code inner join tbl_families on tbl_families.family_code=tbl_designs.family_code";
                            db.DoGetDataAsync(query, delegate (DataSet dt)
                            {
                                XlsData data = new XlsData(dt);
                                data.ToFile(path);
                            });
                        }
                    });
                    break;
                case "Import":
                    Dialog.ShowOpenFileDialog("Import Database", "Excel 97-2003 Workbook|*.xls", delegate (bool ok, string path)
                    {
                        if (ok)
                        {


                            XlsData data = new XlsData(path);
                            DataSet dataSet = data.ToDataSet();
                            //Rows[Baris][Kolom]
                            /*
                            Worker.StartWorker(delegate {
                                //Store to colors table
                                try
                                {
                                    for (int bar = 0; bar < dataSet.Tables[0].Rows.Count; bar++)
                                    {

                                        if (!db.DoCommand("update tbl_colors SET colors_id = '" + dataSet.Tables[0].Rows[bar][6].ToString() + "', accounting_group = '" + dataSet.Tables[0].Rows[bar][1].ToString() + "', colors_name = '" + dataSet.Tables[0].Rows[bar][7].ToString() + "', design_id = '" + dataSet.Tables[0].Rows[bar][4].ToString().Split('-')[1] + "', grade = '" + dataSet.Tables[0].Rows[bar][8].ToString() + "', price = 0, url_color_img = '-' " +
                                            "where colors_id='" + dataSet.Tables[0].Rows[bar][6].ToString() + "'"))
                                        {
                                            db.DoCommand("insert into tbl_colors (colors_id, accounting_group, colors_name, design_id, grade, price, url_color_img) values ('" + dataSet.Tables[0].Rows[bar][6].ToString() + "','" + dataSet.Tables[0].Rows[bar][1].ToString() + "','" + dataSet.Tables[0].Rows[bar][7].ToString() + "','" + dataSet.Tables[0].Rows[bar][4].ToString().Split('-')[1] + "','" + dataSet.Tables[0].Rows[bar][8].ToString() + "',0,'-')");
                                        }

                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("STORE COLORS EXCEPTION: " + ex.ToString());
                                }
                            }, refresh_product);
                            Worker.StartWorker(delegate {
                                try
                                {
                                    for (int bar = 0; bar < dataSet.Tables[0].Rows.Count; bar++)
                                    {

                                        if (!db.DoCommand("update tbl_designs SET design_id = '" + dataSet.Tables[0].Rows[bar][4].ToString().Split('-')[1] + "', design_name = '" + dataSet.Tables[0].Rows[bar][5].ToString() + "', product_code = '" + dataSet.Tables[0].Rows[bar][2].ToString() + "', categories_id = '" + "OFS" + "', contract = '" + dataSet.Tables[0].Rows[bar][0].ToString() + "', family_code = '" + dataSet.Tables[0].Rows[bar][3].ToString() + "', url_design_img = '-' " +
                                            "where design_id='" + dataSet.Tables[0].Rows[bar][4].ToString().Split('-')[1] + "'"))
                                        {
                                            db.DoCommand("insert into tbl_designs (design_id, design_name, product_code, categories_id, contract, family_code, url_design_img) values ('" + dataSet.Tables[0].Rows[bar][4].ToString().Split('-')[1] + "','" + dataSet.Tables[0].Rows[bar][5].ToString() + "','" + dataSet.Tables[0].Rows[bar][2].ToString() + "','" + "OFS" + "','" + dataSet.Tables[0].Rows[bar][0].ToString() + "','" + dataSet.Tables[0].Rows[bar][3].ToString() + "','-')");

                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine("STORE DESIGNS EXCEPTION: " + ex.ToString());
                                }

                            }, refresh_product);
                            //refresh_product();
                             */
                        }
                    });
                    break;
            }
        }

        private void Order_OptionPanel_ButtonClick(object sender, DevExpress.XtraBars.Docking2010.ButtonEventArgs e)
        {
            switch (e.Button.Properties.Caption)
            {
                case "Export":
                    //MessageBox.Show("Export Data");
                    Dialog.ShowSaveFileDialog("Export Data Order", "Excel 97-2003 Workbook|*.xls", delegate (bool ok, string path) {
                        if (ok)
                        {
                            db.DoGetDataAsync("SELECT 'SC-A1' as COORDINATOR, checkouts.order_date as TANGGAL, checkouts.market as SEGMENT, checkouts.region as WILAYAH, checkouts.customer_name as NAMA_CUSTOMER, tbl_orders.product_code as KELOMPOK_PRODUK, tbl_orders.family_code as KELOMPOK_DESAIN, '' as SJ_NO, checkouts.order_no as ORDER_NO, tbl_orders.part_no as PART_NO, tbl_orders.design_name as DESAIN, tbl_orders.colors_name as WARNA, tbl_orders.grade as GRADE, checkouts.currency as CURRENCY, checkouts.curr_rate as CURR_RATE, tbl_orders.qty as QUANTITY, tbl_orders.price_unit as PRICE, tbl_orders.total_price as AMOUNT, tbl_orders.total_price_dom as AMOUNT_DOM, tbl_users.fullname as SALESMAN FROM tbl_orders inner join checkouts on checkouts.order_no=tbl_orders.order_no inner join tbl_users on tbl_users.fname_id=checkouts.sales_id where checkouts.checkout_status='1'", delegate (DataSet ds) {

                                if (ds != null)
                                {
                                    XlsData data = new XlsData(ds);
                                    data.ToFile(path);
                                    db.DoCommand("update checkouts SET checkout_status='2'");
                                }
                                MessageBox.Show("Data Terupdate");
                            });
                        }

                    });
                    break;
                case "Import":
                    MessageBox.Show("Import Data");
                    break;
                default:
                    break;
            }
        }

        private void Update_Timer_Tick(object sender, EventArgs e)
        {
            //if (get_connection())
            //{
            //    DateTime now = DateTime.Now;
            //    Stopwatch hs = new Stopwatch();
            //    string or_number = "select count(*) from tbl_o_pesanans where created_at <= '" + now + "' and created_at > '" + now.AddMinutes(-4) + "' and status_update='1'";
            //    db.DoGetDataAsync("select count(*) from tbl_o_pesanans where status_update='1'", delegate (DataSet ds)
            //    {
            //        if (int.Parse(ds.Tables[0].Rows[0][0].ToString())>0)
            //        {
            //            db.DoCommand("update tbl_o_pesanans set status_update='0'");
            //            get_pesanan();
            //            if (Popup_Panel.Visible)
            //            {
            //                Popup_Panel.Visible = false;    
            //            }
            //            Popup_Panel.Visible = true;
            //            lbl_notif.Text = ds.Tables[0].Rows[0][0].ToString() + " Data Baru";


            //        }

            //    });
            //}
        }

        private void btn_load_image_Click(object sender, EventArgs e)
        {
            Dialog.ShowOpenFileDialog("Pilih Gambar", "Image Files|*.png;*.jpg;*.jpeg", delegate (bool ok, string path)
            {
                if (ok)
                {
                    var fileInfo = new FileInfo(path);
                    float fileSize = fileInfo.Length / 1024;
                    if (fileSize > 1024)
                    {
                        MessageBox.Show("File Terlalu Besar");
                        return;
                    }
                    path_image = path;
                    //pic_product.Image = Bitmap.FromFile(path);

                }
            });
        }
#endregion

#region Utility

#endregion
    }
}
