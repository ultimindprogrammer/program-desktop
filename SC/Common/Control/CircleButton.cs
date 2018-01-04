using System;
using System.ComponentModel;
using System.Drawing;
using UCUP;
using SCLibrary.Utility;
namespace SC.Component
{
    public class CircleButton
    {
        private Bitmap m_overlayImage;
        private Color m_disabledColor = Color.LightGray,m_borderColor, m_normalColor, m_pressedColor, m_hoverColor;
        private Pen _pen;
        private Rectf m_rect;
        private bool m_stateHovered, m_statePressed, m_enabled = true;
        private string m_tag,m_tooltip;
        private byte m_alpha = 255;
        
        //Property
        public Bitmap overlayImage {
            get { return m_overlayImage; }
            set { m_overlayImage = value; }
        }
        public Color colorBorder {
            get { return m_borderColor; }
            set { m_borderColor = value; }
        }
        public Color colorNormal {
            get { return m_normalColor; }
            set { m_normalColor = value; }
        }
        public Color colorPressed {
            get { return m_pressedColor; }
            set { m_pressedColor = value; }
        }
        public Color colorHover {
            get { return m_hoverColor; }
            set { m_hoverColor = value; }
        }
        public Color colorDisabled {
            get { return m_disabledColor; }
            set { m_disabledColor = value; }
        }
        public Rectf rect {
            get { return m_rect; }
            set { m_rect = value; }
        }
        public string tag {
            get { return m_tag; }
            set { m_tag = value; }
        }
        public string tooltip {
            get { return m_tooltip; }
            set { m_tooltip = value; }
        }
        public bool Enabled {
            get { return m_enabled; }
            set { m_enabled = value; }
        }
        public bool Hovered {
            get { return m_stateHovered; }
            set {
                m_stateHovered = value;
                if(m_stateHovered)
                    m_statePressed = false;
            }
        }
        public bool Pressed {
            get { return m_statePressed; }
            set {
                m_statePressed = value;
                if(m_statePressed)
                    m_stateHovered = false;
            }
        }
        public byte Alpha {
            get { return m_alpha; }
            set { m_alpha = value; }
        }

        //Constructor
        public CircleButton() {
            _pen = new Pen(Color.White);
        }

        //Method
        public void Paint(Graphics graphic) {
            //Drawing Background
            if (!m_enabled)
            {
                _pen.Color = Color.FromArgb(m_alpha,m_disabledColor);
            }
            else {
                if (m_stateHovered)
                    _pen.Color = Color.FromArgb(m_alpha, m_hoverColor);
                else if (m_statePressed)
                    _pen.Color = Color.FromArgb(m_alpha, m_pressedColor);
                else
                    _pen.Color = Color.FromArgb(m_alpha, m_normalColor);
            }
            
            graphic.FillEllipse(_pen.Brush, m_rect.ToRectangleF());

            //Drawing Border
            _pen.Color = m_borderColor;
            graphic.DrawEllipse(_pen, m_rect.ToRectangleF());

            //Drawing Overlay
            if (m_overlayImage != null)
            {
                Rectf imgRect = m_rect;
                imgRect.width /= 1.5f;
                imgRect.height /= 1.5f;
                imgRect.x += imgRect.width/4f;
                imgRect.y += imgRect.height/4f;
                graphic.DrawImage(m_overlayImage, imgRect.ToRectangleF());
            }
        }
    }
}
