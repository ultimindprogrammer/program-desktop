using System.Windows.Forms;
namespace SC
{
    public class AppContext : ApplicationContext
    {
        private bool m_exitRequest;
        //Registered Main Form
        private Form_Main m_mainForm;
        private Form_Login m_loginForm;
        private Form_SplashScreen m_splashScreen;
        private Overlay_Form m_overlay;
        private Timer m_timer;

        //Property
        //internal Form_Main _mainForm { get { return m_mainForm; } }
        //internal Form_Login _loginForm { get { return m_loginForm; } }
        //internal Form_SplashScreen _splashScreen { get { return m_splashScreen; } }

        //Constructor
        public AppContext() {
            Show_SplashScreen();
            m_timer = new Timer();
        }

        //~AppContext() {
        //    ExitThread();
        //}

        //Method
        internal void Show_SplashScreen() {
            if (m_splashScreen == null || m_splashScreen.IsDisposed) {
                m_splashScreen = new Form_SplashScreen();
                m_splashScreen.FormClosing += OnFormClosing;
                m_splashScreen.FormClosed += OnFormClosed;
            }
            m_splashScreen._context = this;
            m_splashScreen.Show();
        }
        internal void Show_LoginForm() {
            if (m_loginForm == null || m_loginForm.IsDisposed) {
                m_loginForm = new Form_Login();
                m_loginForm.FormClosing += OnFormClosing;
                m_loginForm.FormClosed += OnFormClosed;
            }

            m_loginForm._context = this;
            m_loginForm.Show();
        }
        internal void Show_MainForm() {
            if (m_mainForm == null || m_mainForm.IsDisposed) {
                m_mainForm = new Form_Main();
                m_mainForm.FormClosing += OnFormClosing;
                m_mainForm.FormClosed += OnFormClosed;
            }
            m_mainForm._context = this;
            m_mainForm.Show();
        }
        internal void Show_Overlay(Form form) {
            if (m_overlay != null) {
                m_overlay.Close();
                m_overlay.Dispose();
            }
            m_overlay = new Overlay_Form();
            m_overlay.BackColor = System.Drawing.Color.Black;
            m_overlay.ShowForm(form);
        }
        internal void Hide_Overlay() {
            if (m_overlay != null){
                m_overlay.CloseForm();
                m_overlay.Dispose();
                m_overlay = null;
            }
        }
        //EventCallback
        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            if (m_exitRequest) {
                ExitThread();
            }
        }
        private void OnFormClosing(object sender, FormClosingEventArgs e) {
            if (sender is Form_SplashScreen) {
                if(!m_exitRequest)
                    e.Cancel = true;
            }
        }

        //Public Method
        public void RequestExit() {
            if (!m_exitRequest)
                m_exitRequest = true;
        }
    }
}
