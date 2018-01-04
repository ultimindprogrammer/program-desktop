using System;
using System.Drawing;
using System.Windows.Forms;
using SCLibrary;
using SC.Component;
using SC.Properties;
namespace SC
{
    partial class Form_Main
    {
        private CircleButtonControl[] m_productCircleButtonList;
        private void Initialize_Product() {

            #region NavButton
            m_productCircleButtonList = new CircleButtonControl[3];
            int len = m_productCircleButtonList.Length;
            for (int i = 0; i < len; i++) {
                m_orderNavButtons[i] = new CircleButtonControl();
            }

            Product_NavButton1.Controls.Add(m_orderNavButtons[0]);
            Product_NavButton2.Controls.Add(m_orderNavButtons[1]);
            Product_NavButton3.Controls.Add(m_orderNavButtons[2]);

            for (int i = 0; i < len; i++)
            {
                var ctrl = m_orderNavButtons[i];
                ctrl.Dock = DockStyle.Fill;
                ctrl.OnButtonClicked += Event_OnProductNavButtonClicked;
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
                        btn.tag = "FilterFilter";

                        btn = ctrl.AddButton();
                        btn.overlayImage = Resources.Icon_Filter_Cancel;
                        btn.tag = "FilterCancel";

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
                        btn.overlayImage = Resources.Icon_Table_Import;
                        btn.tag = "Import";

                        btn = ctrl.AddButton();
                        btn.overlayImage = Resources.Icon_Table_Export;
                        btn.tag = "Export";
                        break;
                    case 3:
                        
                        break;
                }
            }
            #endregion

            Product_GridView.DoubleClick += OnGridDoubleClicked;
        }

        private void ProductGridUpdate() {
            FormUtility.LoadDatabaseToGrid(
                "SELECT distinct contract as CONTRACT, product_code_desc as PRODUCT_NAME, fam_product_desc as FAMILY_NAME, unit as SATUAN, description as DESIGN_NAME, price_exc as HARGA from tbl_barangs where grade ='A'",
                Product_Grid, null);
        }
    }
}
