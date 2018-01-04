using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using SC.Component;
using SCLibrary.Utility;
using UCUP;
namespace SC
{
    public partial class CircleButtonControl : UserControl
    {
        private List<CircleButton> m_buttons;
        private Color m_colorBorder, m_colorNormal, m_colorPressed, m_colorHover;
        private int m_selectedButton;
        private MouseButtons m_mouseEvent;

        //EventHandler
        public event EventHandler OnButtonClicked;
        public UCUPAction<CircleButton,bool> OnButtonHover;

        //Property
        public Color borderColor
        {
            get { return m_colorBorder; }
            set { m_colorBorder = value; }
        }
        public Color colorNormal
        {
            get { return m_colorNormal; }
            set { m_colorNormal = value; }
        }
        public Color colorPressed
        {
            get { return m_colorPressed; }
            set { m_colorPressed = value; }
        }
        public Color colorHover
        {
            get { return m_colorHover; }
            set { m_colorHover = value; }
        }
        public List<CircleButton> buttons {
            get { return m_buttons; }
            set { m_buttons = value; }
        }

        //Contructor
        public CircleButtonControl()
        {
            InitializeComponent();
            m_buttons = new List<CircleButton>();
            this.MouseMove += CircleButtonControl_OnMouseEvent;
            this.MouseDown += CircleButtonControl_OnMouseEvent;
            this.MouseClick += CircleButtonControl_OnMouseEventClick;
            this.MouseLeave += CircleButtonControl_MouseLeave;
            DoubleBuffered = true;
        }

        //Public Method
        public CircleButton AddButton() {
            CircleButton newBtn = new CircleButton();
            m_buttons.Add(newBtn);
            return newBtn;
        }
        public void RemoveButton(CircleButton btn) {
            m_buttons.Remove(btn);
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.CompositingQuality = CompositingQuality.HighSpeed;
            Rectf thisRect = new RectangleF(this.Location, this.Size).ToRectf();

            Vector2 cursorPos = this.PointToClient(Cursor.Position).ToVector2();

            m_selectedButton = -1;
            int len = m_buttons.Count;
            for (int i = 0; i < len; i++)
            {
                var btn = m_buttons[i];
                btn.colorNormal = m_colorNormal;
                btn.colorBorder = m_colorBorder;
                btn.colorHover = m_colorHover;
                btn.colorPressed = m_colorPressed;
                btn.rect = new Rectf(thisRect.width * i / len, 0, thisRect.height, thisRect.height);
                if (btn.Enabled)
                {
                    btn.Hovered = btn.rect.Contains(cursorPos);
                    if (btn.Hovered)
                    {
                        if (OnButtonHover != null)
                            OnButtonHover.Invoke(btn, true);
                        btn.Pressed = m_mouseEvent == MouseButtons.Left;
                        if (btn.Pressed)
                            m_selectedButton = i;
                    }
                    else
                    {
                        if (OnButtonHover != null)
                            OnButtonHover.Invoke(btn, false);
                        btn.Pressed = false;
                    }
                }
                btn.Paint(g);
            }
        }

        private void CircleButtonControl_MouseLeave(object sender, EventArgs e)
        {
            this.Invalidate();
        }
        private void CircleButtonControl_OnMouseEvent(object sender, MouseEventArgs e)
        {
            m_mouseEvent = e.Button;
            this.Invalidate();
        }
        private void CircleButtonControl_OnMouseEventClick(object sender, MouseEventArgs e) {
            if (m_selectedButton != -1) {
                if (OnButtonClicked != null)
                    OnButtonClicked.Invoke(m_buttons[m_selectedButton],null);
            }
            this.Invalidate();
        }
    }
}
