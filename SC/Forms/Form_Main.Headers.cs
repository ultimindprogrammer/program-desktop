using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SCLibrary;
using UCUP.Utility;
using DevExpress.Utils.Animation;
namespace SC
{
    partial class Form_Main
    {
        CheckButton[] m_navHeaderButtons;
        Color m_navHeaderButtonDefaultColor, m_navHeaderButtonCheckedColor;
        Timer m_navHeaderTimeUpdater, m_navChangeWaitTime;

        private void Initialize_NavHeaderArea()
        {
            m_navHeaderButtonDefaultColor = Color.FromArgb(255, 41, 50, 91);
            m_navHeaderButtonCheckedColor = Color.FromArgb(255, 81, 102, 155);

            Panel_LowerHeader.Paint += Panel_LowerHeader_Paint;
            Header_Label_Name.Text = App.userInfo.fullname + " | " + (App.userInfo.userType == UserType.SuperAdmin ? "Super Admin" : "Admin");
            Console.WriteLine(App.userInfo.user_role);

            m_navHeaderButtons = new CheckButton[5];
            m_navHeaderButtons[0] = Header_Button_Dashboard;
            m_navHeaderButtons[1] = Header_Button_Order;
            m_navHeaderButtons[2] = Header_Button_Product;
            m_navHeaderButtons[3] = Header_Button_Customer;
            m_navHeaderButtons[4] = Header_Button_Sales;
            Header_Button_Dashboard.Checked = true;
            Event_OnNavSelectedPageChanged(0);

            for (int i = 0; i < 5; i++)
            {
                m_navHeaderButtons[i].CheckedChanged += Event_OnNavButtonChanged;
            }

            DateTime dt = DateTime.Now;
            Label_Date_Day.Text = dt.Day.ToString();
            Label_Date_MonthYear.Text = ((MonthOfYear)dt.Month).ToString().Substring(0, 3) + " " + dt.Year;

            m_navHeaderTimeUpdater = new Timer();
            m_navHeaderTimeUpdater.Interval = 1000;
            m_navHeaderTimeUpdater.Tick += Event_OnHeaderTimeUpdate;
            m_navHeaderTimeUpdater.Start();

            m_navChangeWaitTime = new Timer();
            m_navChangeWaitTime.Interval = NavFrame.TransitionAnimationProperties.FrameInterval * NavFrame.TransitionAnimationProperties.FrameCount;
            NavFrame.TransitionManager.BeforeTransitionStarts += NavFrame_OnTransitionStart;
            NavFrame.TransitionManager.AfterTransitionEnds += NavFrame_OnTransitionEnd;
        }


        private void NavFrame_OnTransitionStart(DevExpress.Utils.Animation.ITransition transition, System.ComponentModel.CancelEventArgs e)
        {
           
        }
        private void NavFrame_OnTransitionEnd(DevExpress.Utils.Animation.ITransition transition, EventArgs e)
        {
            Event_OnNavSelectedPageChanged(NavFrame.SelectedPageIndex);
        }

        private void Panel_LowerHeader_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Size panelSize = Panel_LowerHeader.Size;
            Pen drawPen = new Pen(Brushes.LightGray, 5);
            g.DrawLine(drawPen, 0, panelSize.Height, panelSize.Width, panelSize.Height);
        }

        private void Event_OnHeaderTimeUpdate(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            Label_Date_Day.Text = dt.Day.ToString();
            Label_Date_MonthYear.Text = ((MonthOfYear)dt.Month).ToString().Substring(0, 3) + " " + dt.Year;
        }

        private void Event_OnNavButtonChanged(object sender, EventArgs e)
        {
            CheckButton cb = (CheckButton)sender;
            for (int i = 0; i < 5; i++)
            {
                m_navHeaderButtons[i].CheckedChanged -= Event_OnNavButtonChanged;
                m_navHeaderButtons[i].Checked = m_navHeaderButtons[i] == cb;
                //m_navHeaderButtons[i].BackColor = m_navHeaderButtons[i].Checked ? m_navHeaderButtonCheckedColor : m_navHeaderButtonDefaultColor;
                if (m_navHeaderButtons[i].Checked)
                    NavFrame.SelectedPageIndex = i;
                m_navHeaderButtons[i].CheckedChanged += Event_OnNavButtonChanged;
            }
        }
    }
}
