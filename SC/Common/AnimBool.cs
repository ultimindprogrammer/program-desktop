using System;
using UCUP;
using UCUP.Animation;
using System.Windows.Forms;

namespace SC.Common
{
    public class AnimBool<T>
    {
        //Publilc Property
        public bool state {
            get { return m_state; }
            set {
                if (value != m_state) {
                    //Swap Value
                    var temp = m_valStart;
                    m_valStart = m_valEnd;
                    m_valEnd = temp;

                    m_tweener.Start();
                    m_timer.Start();
                    m_state = value;
                }
            }
        }
        public T valueStart {
            get { return m_valStart; }
            set { m_valStart = value; }
        }
        public T valueEnd {
            get { return m_valEnd; }
            set { m_valEnd = value; }
        }
        public int updateInterval {
            get { return m_updateInterval; }
            set { m_updateInterval = value; }
        }
        public TweenSetting setting {
            get { return m_tweener.setting; }
            set { m_tweener.setting = value; }
        }
        public TweenDelegate<T> tweenDelegate {
            get { return m_tweener.tweenDelegate; }
            set { m_tweener.tweenDelegate = value; }
        }
        public Tweener<T> tweener {
            get { return m_tweener; }
        }
        public float progress {
            get { return m_tweener.progress; }
        }

        //Private Field
        private int m_updateInterval = 20;
        private Timer m_timer;
        private Tweener<T> m_tweener;
        private T m_valStart, m_valEnd;
        private bool m_state;
        public AnimBool() {
            m_timer = new Timer();
            m_timer.Interval = 20;
            m_timer.Tick += OnUpdate;

            m_tweener = new Tweener<T>();
        }

        private void OnUpdate(object sender, EventArgs e)
        {
            m_tweener.Update((float)m_updateInterval / 1000f);
            if (m_tweener.status == TweenStatus.Stop)
                m_timer.Stop();
        }
    }
}
