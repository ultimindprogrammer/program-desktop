using System.Drawing;
using System.Windows.Forms;
using UCUP.Animation;
using SCLibrary.Utility;
using SCLibrary;
using System.Net.NetworkInformation;
using System;
using UCUP.Math;
namespace SC
{
    public partial class Form_SplashScreen : Form
    {
        //Internal Field
        internal AppContext _context;
        //Private Field
        private Timer m_animTimer;
        private Tweener<float> m_tweener;
        private Sequence m_sequence;
        private PingReply m_pingReply;
        //Constructor
        public Form_SplashScreen()
        {
            InitializeComponent();

            //ProgressBar Setup
            ProgressBar.Maximum = 100;
            ProgressBar.Step = 1;
            ProgressBar.Value = 0;

            //Animation Setup
            this.Opacity = 0.0f;

            m_animTimer = new Timer();
            m_animTimer.Interval = 17; //ms
            m_animTimer.Tick += AnimEvent;

            m_tweener = new Tweener<float>();
            m_tweener.duration = 0.3f; //second;
            m_tweener.tweenDelegate = delegate (ref float value)
            {
                value = Tween.DoTween(0f, 1f, m_tweener.progress, m_tweener.type);
                this.Opacity = value;
            };

            m_tweener.Start();
            m_animTimer.Start();

            //Sequence Execution
            m_sequence = new Sequence();
            m_sequence.OnEachActionStart = OnEachActionStart;
            m_sequence.OnEachActionFinish = OnEachActionFinish;
            m_sequence.OnSequenceFinish = OnSequenceFinish;
            m_sequence.AddAction(delegate
            {
                //Initialize App
                App.Initialize();
            });
            m_sequence.AddAction(delegate
            {
                //Pinging Server
                Ping ping = new Ping();
                m_pingReply = ping.Send(DB.ipString);
            });
            m_sequence.AddAction(delegate
            {
                //Testing Connection
                DBSql.Test();
            });
        }
        private void OnEachActionFinish(Exception e,int id) {
            if (e != null)
            {
                MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _context.RequestExit();
                this.Close();
                this.Dispose();
            }
            else {
                ProgressBar.Value = (int)(UMath.Clamp(m_sequence.progress,0.0f,1.0f)*100);
            }
        }
        private void OnEachActionStart(int id) {
            switch (id)
            {
                case 0:
                    Label_Status.Text = "Initializing";
                    break;
                case 1:
                    Label_Status.Text = "Check Connection to Database";
                    break;
                case 2:
                    Label_Status.Text = "Testing Connection to Database";
                    break;
            }
        }
        private void OnSequenceFinish()
        {
            _context.Show_LoginForm();
            this.Dispose();
        }

        #region Event
        private void AnimEvent(object sender, System.EventArgs e)
        {
            m_tweener.Update((float)m_animTimer.Interval/1000f);
            if (m_tweener.status == TweenStatus.Stop)
            {
                m_animTimer.Stop();
                //HACK : Nebeng dulu
                m_sequence.Run();
            }
        }
        #endregion
    }
}
