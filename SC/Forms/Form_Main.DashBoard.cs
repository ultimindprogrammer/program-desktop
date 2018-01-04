using System;
using System.Drawing;
using DevExpress.XtraEditors;
namespace SC
{
	/*DashBoard_Frame*/
    partial class Form_Main
    {
        private Size m_dashBoardPanelSize;
        private PanelControl[] m_dashboardChildPanels;
        private Size[] m_dashBoardChildPanelSize;
        private Point[] m_dashBoardChildPanelPos;

		private void Initialize_DashboardArea() {
            m_dashBoardPanelSize = Dashboard_Panel.Size;
            Dashboard_Panel.SizeChanged += Dashboard_Panel_SizeChanged;
            //Dashboard_Panel.Paint += Dashboard_Panel_Paint;

            m_dashboardChildPanels = new PanelControl[4];
            m_dashboardChildPanels[0] = Dashboard_PanelInfo1;
            m_dashboardChildPanels[1] = Dashboard_PanelInfo2;
            m_dashboardChildPanels[2] = Dashboard_PanelInfo3;
            m_dashboardChildPanels[3] = Dashboard_Panel4;

            m_dashBoardChildPanelSize = new Size[4];
            m_dashBoardChildPanelPos = new Point[4];

            for (int i = 0; i < 4; i++) {
                m_dashBoardChildPanelSize[i] = m_dashboardChildPanels[i].Size;
                m_dashBoardChildPanelPos[i] = m_dashboardChildPanels[i].Location;
            }
        }

        //private void Dashboard_Panel_Paint(object sender, PaintEventArgs e)
        //{
        //    Graphics g = e.Graphics;
        //    Size size = Dashboard_Panel.Size;
        //    Rectangle rect = new Rectangle(0, 0, size.Width-1, size.Height-1);
        //    g.DrawRectangle(Pens.Gray,rect);
        //}

        private void Dashboard_Panel_SizeChanged(object sender, EventArgs e)
        {
            Size size = Dashboard_Panel.Size;
            float ratioWidth = (float)size.Width / (float)m_dashBoardPanelSize.Width;
            float ratioHeight = (float)size.Height / (float)m_dashBoardPanelSize.Height;
            for (int i = 0; i < 4; i++) {

                Point newPos = new Point();
                newPos.X = (int)(m_dashBoardChildPanelPos[i].X * ratioWidth);
                newPos.Y = (int)(m_dashBoardChildPanelPos[i].Y * ratioHeight);
                m_dashboardChildPanels[i].Location = newPos;

                Size newSize = new Size();
                newSize.Width = (int)(m_dashBoardChildPanelSize[i].Width * ratioWidth);
                newSize.Height = (int)(m_dashBoardChildPanelSize[i].Height * ratioHeight);
                m_dashboardChildPanels[i].Size = newSize;
            }
        }
    }
}
