using System;
using System.Drawing;
using System.Windows.Forms;
using SCLibrary.Utility;
using UCUP;
using UCUP.Animation;
using UCUP.Image.Color;
using UCUP.Math;
namespace SC.Common
{
    public class ToastControl : UserControl
    {
        private Panel Indicator;
        private Label Label_Tittle;
        private Button Label_BtnClose;
        private Label Label_Text;

        //Private Field
        private Vector2 m_startPos, m_endPos;
        private Tweener<Vector2> m_tweener;
        private Color m_baseColor;
        private Form m_lastParent;
        private Point m_offset;
        private Timer m_timer;

        //Public Property
        public string tittle {
            get { return Label_Tittle.Text; }
            set { Label_Tittle.Text = value; }
        }
        public string message {
            get { return Label_Text.Text; }
            set { Label_Text.Text = value; }
        }
        public Color indicatorColor {
            get { return m_baseColor; }
            set {
                m_baseColor = value;
                HSLAPix pix = value.ToRGBA();
                Indicator.BackColor = ((RGBAPix)pix).ToWinColor();
                pix.l += 0.15f;
                pix.l = UMath.Clamp(pix.l, 0.0f, 1.0f);
                this.BackColor = ((RGBAPix)pix).ToWinColor();
            }
        }
        public TweenType tweenType {
            get { return m_tweener.type; }
            set { m_tweener.type = value; }
        }
        public float tweenDuration {
            get { return m_tweener.duration; }
            set { m_tweener.duration = value; }
        }
        public Point offsetPosition {
            get { return m_offset; }
            set { m_offset = value; }
        }

        public Action OnToastShow, OnToastHide;

        //Constructor
        public ToastControl()
        {
            InitializeComponent();

            m_tweener = new Tweener<Vector2>();
            m_tweener.duration = 0.5f;
            m_tweener.type = TweenType.EaseOutExpo;
            m_tweener.mode = TweenMode.Once;
            m_tweener.forceTween = true;
            m_tweener.tweenDelegate = delegate (ref Vector2 val)
            {
                val.x = Tween.DoTween(m_startPos.x, m_endPos.x, m_tweener.progress, m_tweener.type);
                val.y = Tween.DoTween(m_startPos.y, m_endPos.y, m_tweener.progress, m_tweener.type);
                this.Location = val.ToPoint();
            };

            m_timer = new Timer();
            m_timer.Interval = 30;
            m_timer.Tick += OnUpdate;
        }

        private void InitializeComponent()
        {
            this.Indicator = new System.Windows.Forms.Panel();
            this.Label_Tittle = new System.Windows.Forms.Label();
            this.Label_Text = new System.Windows.Forms.Label();
            this.Label_BtnClose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Indicator
            // 
            this.Indicator.Location = new System.Drawing.Point(0, 0);
            this.Indicator.Name = "Indicator";
            this.Indicator.Size = new System.Drawing.Size(15, 73);
            this.Indicator.TabIndex = 0;
            // 
            // Label_Tittle
            // 
            this.Label_Tittle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_Tittle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label_Tittle.Location = new System.Drawing.Point(19, 4);
            this.Label_Tittle.Name = "Label_Tittle";
            this.Label_Tittle.Size = new System.Drawing.Size(271, 23);
            this.Label_Tittle.TabIndex = 1;
            this.Label_Tittle.Text = "Tittle";
            // 
            // Label_Text
            // 
            this.Label_Text.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_Text.Location = new System.Drawing.Point(22, 27);
            this.Label_Text.Name = "Label_Text";
            this.Label_Text.Size = new System.Drawing.Size(297, 35);
            this.Label_Text.TabIndex = 2;
            this.Label_Text.Text = "label2";
            // 
            // Label_BtnClose
            // 
            this.Label_BtnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label_BtnClose.BackColor = System.Drawing.Color.Transparent;
            this.Label_BtnClose.FlatAppearance.BorderSize = 0;
            this.Label_BtnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Label_BtnClose.Location = new System.Drawing.Point(296, 2);
            this.Label_BtnClose.Name = "Label_BtnClose";
            this.Label_BtnClose.Size = new System.Drawing.Size(23, 23);
            this.Label_BtnClose.TabIndex = 3;
            this.Label_BtnClose.Text = "X";
            this.Label_BtnClose.UseVisualStyleBackColor = false;
            this.Label_BtnClose.Click += new System.EventHandler(this.Label_BtnClose_Click);
            // 
            // ToastControl
            // 
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.Label_BtnClose);
            this.Controls.Add(this.Label_Text);
            this.Controls.Add(this.Label_Tittle);
            this.Controls.Add(this.Indicator);
            this.Name = "ToastControl";
            this.Size = new System.Drawing.Size(322, 71);
            this.ResumeLayout(false);

        }

        protected override void OnParentChanged(EventArgs e)
        {
            if (m_lastParent != null)
                m_lastParent.SizeChanged -= OnSizeChanged;
            base.OnParentChanged(e);
            m_lastParent = ParentForm;
            m_lastParent.SizeChanged += OnSizeChanged;
            CalculatePosition();
        }

        private void OnUpdate(object sender, EventArgs e)
        {
            m_tweener.Update((float)m_timer.Interval / 1000f);
            if (m_tweener.status == TweenStatus.Stop)
                m_timer.Stop();
        }

        private void OnSizeChanged(object sender, EventArgs e)
        {
            //ReCalculate
            CalculatePosition();
        }

        private void CalculatePosition() {
            Form form = m_lastParent;
            var formSize = m_lastParent.ClientSize;
            var thisSize = this.Size;
            m_startPos = new Point(formSize.Width, formSize.Height - thisSize.Height + m_offset.Y).ToVector2();
            m_endPos = new Point(formSize.Width - thisSize.Width + m_offset.X, formSize.Height - thisSize.Height + m_offset.Y).ToVector2();
            if (m_tweener.status == TweenStatus.Stop)
                this.Location = m_endPos.ToPoint();
            this.BringToFront();
        }

        public void ShowToast() {
            OnToastShow?.Invoke();
            m_tweener.Start();
            m_timer.Start();
        }

        private void Label_BtnClose_Click(object sender, EventArgs e)
        {
            this.HideToast();
        }

        public void HideToast() {
            OnToastHide?.Invoke();
            m_tweener.StartReverse();
            m_timer.Start();
        }
    }
}
