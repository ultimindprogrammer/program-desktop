using System;
using System.Drawing;
using System.Windows.Forms;
using SC.Properties;
using SC.Component;
namespace SC
{
    partial class Form_Main
    {
        CircleButtonControl[] m_salesNavButtons;
        private void Initialize_Sales()
        {
            #region NavButton
            m_salesNavButtons = new CircleButtonControl[3];
            int len = m_salesNavButtons.Length;
            for (int i = 0; i < len; i++)
            {
                m_salesNavButtons[i] = new CircleButtonControl();
            }
            Sales_NavButtonPart1.Controls.Add(m_salesNavButtons[0]);
            Sales_NavButtonPart2.Controls.Add(m_salesNavButtons[1]);
            Sales_NavButtonPart3.Controls.Add(m_salesNavButtons[2]);
            for (int i = 0; i < len; i++)
            {
                var ctrl = m_salesNavButtons[i];
                ctrl.Dock = DockStyle.Fill;
                ctrl.OnButtonClicked += Event_OnSalesNavButtonClicked;
                ctrl.borderColor = Color.White;
                ctrl.colorNormal = Color.FromArgb(41, 51, 90);
                ctrl.colorHover = Color.FromArgb(81, 102, 155);
                ctrl.colorPressed = Color.FromArgb(29, 35, 65);
                CircleButton btn = null;
                switch (i)
                {
                    case 0:
                        //btn = ctrl.AddButton();
                        //btn.overlayImage = Resources.Icon_Filter_Filter;
                        //btn.tag = "Filter_Filter";

                        //btn = ctrl.AddButton();
                        //btn.overlayImage = Resources.Icon_Filter_Cancel;
                        //btn.tag = "Filter_Cancel";

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

            Sales_GridView.DoubleClick += OnGridDoubleClicked;
        }
        private void SalesUpdateGrid() {
            
            FormUtility.LoadDatabaseToGrid(
            querySales,
            Sales_Grid, null);
        }
    }
}
