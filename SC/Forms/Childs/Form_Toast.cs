using System;
using System.Drawing;
using System.Windows.Forms;
using UCUP.Animation;
using SCLibrary.Utility;
using UCUP;
namespace SC.Forms
{
    public partial class Form_Toast : Form
    {
        public string tittle {
            get { return Label_Tittle.Text; }
            set { Label_Tittle.Text = value; }
        }
        public string message {
            get { return Label_Text.Text; }
            set { Label_Text.Text = value; }
        }
        public TweenSetting tweenSetting {
            get { return m_tweener.setting; }
            set { m_tweener.setting = value; }
        }

        private Tweener<Vector2> m_tweener;
        private Vector2 m_startPos, m_endPos;
        private Timer m_timer;
        public Form_Toast()
        {
            InitializeComponent();
            m_tweener = new Tweener<Vector2>();
            m_tweener.tweenDelegate = delegate (ref Vector2 val)
            {
                val.x = Tween.DoTween(m_startPos.x, m_endPos.x, m_tweener.progress, m_tweener.type);
                val.y = Tween.DoTween(m_startPos.y, m_endPos.y, m_tweener.progress, m_tweener.type);
                this.Location = val.ToPoint();
            };

            m_tweener.duration = 0.3f;
            m_tweener.mode = TweenMode.Once;
            m_tweener.type = TweenType.EaseOutExpo;
            m_tweener.forceTween = true;

            m_timer = new Timer();
            m_timer.Interval = 1;
            m_timer.Tick += OnUpdate;
        }

        private void OnUpdate(object sender, EventArgs e)
        {
            m_tweener.Update((float)m_timer.Interval / 100f);
            if (m_tweener.status == TweenStatus.Stop)
                m_timer.Stop();
        }

        public void ShowToast(Form parent) {
            if (this.Owner != null)
            {
                this.Owner.SizeChanged -= OnParentSizeChanged;
                this.Owner.LocationChanged -= OnParentLocationChanged;
            }

            this.Owner = parent;
            this.Owner.SizeChanged += OnParentSizeChanged;
            this.Owner.LocationChanged += OnParentLocationChanged;

            Rectf thisSize = new Rectangle(parent.Location, parent.ClientSize).ToRectf();

            m_startPos.x = thisSize.width;
            m_startPos.y = thisSize.height - this.Height;
            m_endPos.x = thisSize.width - this.Width;
            m_endPos.y = thisSize.height - this.Height;

            m_timer.Start();
            m_tweener.Start();
            this.Visible = false;
            this.Show();
        }

        private void OnParentLocationChanged(object sender, EventArgs e)
        {
            
        }

        private void OnParentSizeChanged(object sender, EventArgs e)
        {
            
        }
    }
}
