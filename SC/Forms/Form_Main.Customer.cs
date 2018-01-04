using System;
using System.Drawing;
using System.Windows.Forms;
using SC.Component;
using SC.Properties;
namespace SC
{
    partial class Form_Main
    {
        CircleButtonControl[] m_customerNavButtons;
        private void Initialize_Customer() {
            #region NavButton
            m_customerNavButtons = new CircleButtonControl[3];
            int len = m_customerNavButtons.Length;
            for (int i = 0; i < len; i++) {
                m_customerNavButtons[i] = new CircleButtonControl();
            }
            Customer_NavButtonPart1.Controls.Add(m_customerNavButtons[0]);
            Customer_NavButtonPart2.Controls.Add(m_customerNavButtons[1]);
            Customer_NavButtonPart3.Controls.Add(m_customerNavButtons[2]);
            for (int i = 0; i < len; i++)
            {
                var ctrl = m_customerNavButtons[i];
                ctrl.Dock = DockStyle.Fill;
                ctrl.OnButtonClicked += Event_OnCustomerNavButtonClicked;
                ctrl.borderColor = Color.White;
                ctrl.colorNormal = Color.FromArgb(41, 51, 90);
                ctrl.colorHover = Color.FromArgb(81, 102, 155);
                ctrl.colorPressed = Color.FromArgb(29, 35, 65);
                CircleButton btn = null;
                switch (i)
                {
                    case 0:
                        btn = ctrl.AddButton();
                        btn.overlayImage = Resources.Icon_Filter_Filter;
                        btn.tag = "Filter_Filter";

                        btn = ctrl.AddButton();
                        btn.overlayImage = Resources.Icon_Filter_Cancel;
                        btn.tag = "Filter_Cancel";

                        break;
                    case 1:
                        btn = ctrl.AddButton();
                        btn.overlayImage = Resources.Icon_Arrow_Left;
                        btn.tag = "PrevPage";

                        btn = ctrl.AddButton();
                        btn.overlayImage = Resources.Icon_Arrow_Right;
                        btn.tag = "NextPage";
                        break;
                    case 2:
                        btn = ctrl.AddButton();
                        btn.tag = "Add";

                        btn = ctrl.AddButton();
                        btn.overlayImage = Resources.Icon_X;
                        btn.tag = "Delete";
                        break;
                }
            }
            #endregion

            Customer_GridView.RowCellStyle += Customer_GridView_RowCellStyle;
            Customer_GridView.DoubleClick += OnGridDoubleClicked;
        }

        private void Customer_GridView_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            //var status = Customer_GridView.GetRowCellValue(e.RowHandle, Customer_GridView.Columns[9]).ToString();
            //switch (status) {
            //    case "Waiting":
            //        e.Appearance.BackColor = Color.OrangeRed;
            //        break;
            //    case "Rejected":
            //        e.Appearance.BackColor = Color.PaleVioletRed;
            //        break;
            //}
        }
        private void CustomerUpdateGrid() {
            FormUtility.LoadDatabaseToGrid(
            "SELECT customer_id as CUSTOMER_ID, customer_name as NAMA_CUSTOMER, segment as SEGMENT, region_name as WILAYAH, market as MARKET from tbl_customers inner join tbl_users on tbl_users.user_id=tbl_customers.sales_id",
            Customer_Grid, null);
        }
    }
}
