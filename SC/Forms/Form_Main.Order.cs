using System;
using System.Drawing;
using System.Windows.Forms;
using SC.Component;
using SC.Properties;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using UCUP.Image.Color;
using SCLibrary.Utility;
using SC.Common;
using UCUP.Animation;
namespace SC
{
    partial class Form_Main
    {
        private CircleButtonControl[] m_orderNavButtons;
        private CheckButton[] m_orderSideBarButtons;
        private AnimBool<Size> m_orderFilterToggle;
        private void Initialize_OrderArea()
        {
            #region NavButton
            m_orderNavButtons = new CircleButtonControl[4];
            int len = m_orderNavButtons.Length;
            for (int i = 0; i < len; i++) {
                m_orderNavButtons[i] = new CircleButtonControl();
            }

            Order_NavButtonPart1.Controls.Add(m_orderNavButtons[0]);
            Order_NavButtonPart2.Controls.Add(m_orderNavButtons[1]);
            Order_NavButtonPart3.Controls.Add(m_orderNavButtons[2]);
            Order_NavButtonPart4.Controls.Add(m_orderNavButtons[3]);

            for (int i = 0; i < len; i++)
            {
                var ctrl = m_orderNavButtons[i];
                ctrl.Dock = DockStyle.Fill;
                ctrl.OnButtonClicked += Event_OnOrderNavButtonClicked;
                ctrl.borderColor = Color.White;
                ctrl.colorNormal = Color.FromArgb(41, 51, 90);
                ctrl.colorHover = Color.FromArgb(81, 102, 155);
                ctrl.colorPressed = Color.FromArgb(29, 35, 65);
                CircleButton btn = null;
                switch (i) {
                    case 0: 
                        btn = ctrl.AddButton();
                        btn.overlayImage = Resources.Icon_Check;
                        btn.tag = "Approve";
                        btn.tooltip = "Approve Order";

                        btn = ctrl.AddButton();
                        btn.overlayImage = Resources.Icon_X;
                        btn.tag = "Cancel";
                        btn.tooltip = "Cancel Order";

                        btn = ctrl.AddButton();
                        btn.overlayImage = Resources.Icon_Declined;
                        btn.tag = "Decline";
                        btn.tooltip = "Decline Order";

                        break;
                    case 1:
                        btn = ctrl.AddButton();
                        btn.overlayImage = Resources.Icon_Print;
                        btn.tag = "Print";
                        btn.tooltip = "Print";

                        btn = ctrl.AddButton();
                        btn.overlayImage = Resources.Icon_Table_Export;
                        btn.tag = "Export";
                        btn.tooltip = "Export";

                        btn = ctrl.AddButton();
                        btn.overlayImage = Resources.Icon_negosiasi;
                        btn.tag = "Negosiasi";
                        btn.tooltip = "Approve Order";
                        break;
                    case 2:
                        btn = ctrl.AddButton();
                        btn.overlayImage = Resources.Icon_Filter_Filter;
                        btn.tag = "Filter_Filter";
                        btn.tooltip = "Filter";

                        btn = ctrl.AddButton();
                        btn.overlayImage = Resources.Icon_Filter_Cancel;
                        btn.tag = "Filter_Cancel";
                        break;
                    case 3:
                        btn = ctrl.AddButton();
                        btn.overlayImage = Resources.Icon_Arrow_Left;
                        btn.tag = "PrevPage";
                        btn.tooltip = "Previous Page";

                        btn = ctrl.AddButton();
                        btn.overlayImage = Resources.Icon_Arrow_Right;
                        btn.tag = "NextPage";
                        btn.tooltip = "Next Page";
                        break;
                }
            }
            #endregion

            #region SideBarButton
            m_orderSideBarButtons = new CheckButton[5];
            m_orderSideBarButtons[0] = Order_SideBar_Button_All;
            m_orderSideBarButtons[1] = Order_SideBar_Button_Waiting;
            m_orderSideBarButtons[2] = Order_SideBar_Button_Canceled;
            m_orderSideBarButtons[3] = Order_SideBar_Button_Finished;
            m_orderSideBarButtons[4] = Order_SideBar_Button_Declined;

            m_orderSideBarButtons[0].Checked = true;
            len = m_orderSideBarButtons.Length;
            for (int i = 0; i < len; i++) {
                m_orderSideBarButtons[i].CheckedChanged += Event_OnOrderSideButtonChanged;
            }
            #endregion

            #region FilterPanel
            //Setup Animation
            m_orderFilterToggle = new AnimBool<Size>();
            m_orderFilterToggle.valueStart = new Size(214, 299);
            m_orderFilterToggle.valueEnd = new Size(0, 0);
            m_orderFilterToggle.tweenDelegate = delegate (ref Size val) {
                var v = m_orderFilterToggle;
                val.Width = (int)Tween.DoTween(v.valueStart.Width, v.valueEnd.Width, v.progress, v.setting.type);
                val.Height = (int)Tween.DoTween(v.valueStart.Height, v.valueEnd.Height, v.progress, v.setting.type);
                Order_FilterPanel.Size = val;
                Console.WriteLine("Moving");
            };

            TweenSetting tw = m_orderFilterToggle.setting;
            tw.duration = 0.3f;
            tw.forceTween = true;
            tw.mode = TweenMode.Once;
            tw.type = TweenType.EaseOutExpo;
            m_orderFilterToggle.setting = tw;
            #endregion

            Order_GridView.RowCellStyle += Event_OnOrderGridViewRowCellStyle;
            Order_GridView.DoubleClick += OnGridDoubleClicked;
        }

        private void Event_OnOrderGridViewRowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            var status = Order_GridView.GetRowCellValue(e.RowHandle, Order_GridView.Columns[9]).ToString();
            var noted = Order_GridView.GetRowCellValue(e.RowHandle, Order_GridView.Columns[10]).ToString();
            Color selectedColor = default(Color);
            switch (status)
            {
                case "Success":
                    //selectedColor = Color.Green;
                    break;
                case "Waiting":
                    selectedColor = Color.PaleGoldenrod;
                    break;
                case "Canceled":
                    selectedColor = Color.PaleVioletRed;
                        break;
                case "Declined":
                    selectedColor = Color.FromArgb(255,150,150);
                    break;
            }
            if (status == "Waiting")
            {
                if (noted != ".")
                {
                    selectedColor = Color.LimeGreen;
                }
            }
            

            if (!selectedColor.IsEmpty) {
                RGBAPix pix = selectedColor.ToRGBA();
                HSLAPix hsl = pix;
                if (Order_GridView.IsRowSelected(e.RowHandle))
                    hsl.l -= 0.10f;
                else
                {
                    if (e.RowHandle % 2 != 0)
                        hsl.l -= 0.05f;
                }
                pix = hsl;
                e.Appearance.BackColor = (pix).ToWinColor();
            }
            
        }

        private void Event_OnOrderSideButtonChanged(object sender, EventArgs e)
        {
            CheckButton cb = (CheckButton)sender;
            int len = m_orderSideBarButtons.Length;
            for (int i = 0; i < len; i++)
            {
                m_orderSideBarButtons[i].CheckedChanged -= Event_OnOrderSideButtonChanged;
                m_orderSideBarButtons[i].Checked = m_orderSideBarButtons[i] == cb;
                if (m_orderSideBarButtons[i].Checked)
                    Event_OnOrderSideButtonClicked(i);
                m_orderSideBarButtons[i].CheckedChanged += Event_OnOrderSideButtonChanged;
            }
        }
        private void OrderGridUpdate() {
            string query = "select order_no as ORDER_NO, order_date as TANGGAL, tbl_customers.segment as BIDANG_USAHA, checkouts.market as MARKET, checkouts.region as WILAYAH, checkouts.customer_name as CUSTOMER, tbl_users.fullname as SALESMAN, g_total_price as TOTAL_PEMBAYARAN, currency as KURS, checkout_status as STATUS, notes as NOTE from checkouts inner join tbl_users on tbl_users.user_id=checkouts.sales_id inner join tbl_customers on tbl_customers.customer_id=checkouts.customer_id";
            //"SELECT 'SC-A1' as COORDINATOR, checkouts.order_date as TANGGAL, checkouts.market as SEGMENT, checkouts.region as WILAYAH, checkouts.customer_name as NAMA_CUSTOMER, tbl_orders.product_name as KELOMPOK_PRODUK, tbl_orders.family_name as KELOMPOK_DESAIN, '' as SJ_NO, checkouts.order_no as ORDER_NO, tbl_orders.part_no as PART_NO, tbl_orders.design_name as DESAIN, tbl_orders.colors_name as WARNA, tbl_orders.grade as GRADE, checkouts.currency as CURRENCY, checkouts.curr_rate as CURR_RATE, tbl_orders.qty as QUANTITY, tbl_orders.price_unit as PRICE, tbl_orders.total_price as AMOUNT, tbl_orders.total_price_dom as AMOUNT_DOM, tbl_users.fullname as SALESMAN, checkouts.checkout_status as STATUS, checkouts.notes as PO FROM tbl_orders inner join checkouts on checkouts.order_no=tbl_orders.order_no inner join tbl_users on tbl_users.user_id=checkouts.sales_id"
            FormUtility.LoadDatabaseToGrid(query
             ,
             Order_Grid, delegate() {
                 Order_GridView.VisibleColumns[0].Width = 25;
             });
        }
    }
}
