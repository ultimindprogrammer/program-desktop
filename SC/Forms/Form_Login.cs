using System;
using System.Windows.Forms;
using SCLibrary;
using System.Drawing;
namespace SC
{
    public partial class Form_Login : Form
    {
        internal AppContext _context;
        private Size m_tempLoginPanelSize, m_tempTittlePanelSize;
        public Form_Login()
        {
            InitializeComponent();
            m_tempLoginPanelSize = Panel_Login.Size;
            m_tempTittlePanelSize = Panel_Tittle.Size;
            _adjustPanels();
            this.SizeChanged += Form_Login_SizeChanged;
        }

        private void Form_Login_SizeChanged(object sender, EventArgs e)
        {
            _adjustPanels();
        }

        private void _adjustPanels() {
            Size mySize = this.Size;
            RectangleF leftSide = new RectangleF(0, 0, (float)mySize.Width / 2f, mySize.Height);
            RectangleF rightSide = new RectangleF((float)mySize.Width / 2f, 0, (float)mySize.Width / 2f, mySize.Height);
            PointF leftSideCenterPos = new PointF(leftSide.Location.X + (float)leftSide.Width / 2f, leftSide.Location.Y + (float)leftSide.Height / 2f);
            PointF rightSideCenterPos = new PointF(rightSide.Location.X + (float)rightSide.Width / 2f, rightSide.Location.Y + (float)rightSide.Height / 2f);
            Panel_Tittle.Location = new Point((int)(leftSideCenterPos.X - m_tempTittlePanelSize.Width/2f), (int)(leftSideCenterPos.Y - m_tempTittlePanelSize.Height/2f));
            Panel_Login.Location = new Point((int)(rightSideCenterPos.X - m_tempLoginPanelSize.Width/2f), (int)(rightSideCenterPos.Y - m_tempLoginPanelSize.Height/2f));
        }
        private void _doLogin()
        {
            DBClass.Out_Login form = new DBClass.Out_Login();
            form.user_id = InputField_Username.Text;
            form.pass_id = InputField_Password.Text;
            _context.Show_Overlay(this);

            App.DoLogin(form, delegate (bool status, string message)
            {
                if (status)
                {
                    Console.WriteLine("UserType: " + App.userInfo.userType);
                    if ((int)App.userInfo.userType > 2)
                    {
                        MessageBox.Show("Maaf akun anda tidak dapat digunakan untuk mengakses aplikasi ini", "Akses Ditolak", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        _context.Show_MainForm();
                        this.Close();
                        this.Dispose();
                    }
                }
                else
                    MessageBox.Show(message, "ERROR");
                _context.Hide_Overlay();
            });
        }

        //UI Event
        #region UI Event
        private void OnLoginButtonPressed(object sender, EventArgs e)
        {
            _doLogin();
        }

        private void OnTextValidate(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                _doLogin();
        }
        private void OnCloseButtonPressed(object sender, EventArgs e) {
            _context.RequestExit();
            this.Close();
        }
        private void OnMinimizeButtonPressed(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        #endregion


    }
}
