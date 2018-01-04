using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using SCLibrary;
using SC.Component;
using SC.Common;
namespace SC
{
    partial class Form_Main
    {
        private void Initialize_GUI() {
            #region Toast Setup
            Toast.toast = new ToastControl();
            this.Controls.Add(Toast.toast);
            Toast.toast.offsetPosition = new Point(0, -Footer_Panel.Height);
            Toast.toast.Visible = false;
            Toast.waitTime = 5; //Second
            #endregion
        }

        /// <summary>
        /// Buat nampilin Child Windows Form
        /// </summary>
        /// <param name="form"></param>
        public void ShowForm(Form form)
        {
            _context.Show_Overlay(this);
            form.FormClosed += OnChildFormClosed;
            form.ShowInTaskbar = false;
            form.MaximizeBox = false;
            form.MinimizeBox = false;
            form.StartPosition = FormStartPosition.CenterParent;
            form.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            form.ShowDialog();
        }
        /// <summary>
        /// Buat Sembunyiin Child Windows Form
        /// </summary>
        /// <param name="form"></param>
        public void CloseForm(Form form)
        {
            form.Close();
            form.Dispose();
        }

        private void OnChildFormClosed(object sender, FormClosedEventArgs e)
        {
            _context.Hide_Overlay();
        }

        private void OnGridDoubleClicked(object sender, EventArgs e)
        {
            var grid = (GridView)sender;
            var pos = grid.GridControl.PointToClient(Cursor.Position);
            var hitInfo = grid.CalcHitInfo(pos);
            if (hitInfo.RowHandle < 0)
                return;

            switch (grid.Name) {
                case "Order_GridView":
                    Event_OnOrderGridDoubleClicked(hitInfo);
                    break;
                case "Product_GridView":
                    Event_OnProductGridDoubleClicked(hitInfo);
                    break;
                case "Customer_GridView":
                    Event_OnCustomerGridDoubleClicked(hitInfo);
                    break;
                case "Sales_GridView":
                    Event_OnSalesGridDoubleClicked(hitInfo);
                    break;
            }
        }
    }

    #region Toast
    enum ToastIndicator {
        Ok,
        Error,
        Warning
    }

    internal static class Toast {
        private static ToastControl m_toast;
        private static Timer m_timer;
        public static ToastControl toast {
            get { return m_toast; }
            internal set {
                if (m_toast != null)
                    m_toast.OnToastHide -= OnToastHide;
                m_toast = value;
                if (m_toast != null)
                    m_toast.OnToastHide += OnToastHide;
            }
        }
        public static int waitTime {
            get { return m_timer.Interval/1000; }
            set { m_timer.Interval = value*1000; }
        }

        static Toast() {
            m_timer = new Timer();
            m_timer.Tick += OnUpdate;
        }

        private static void OnUpdate(object sender, EventArgs e)
        {
            m_toast.HideToast();
        }
        public static void ShowToast(string message, string tittle, ToastIndicator indicator) {
            switch (indicator) {
                case ToastIndicator.Ok:
                    ShowToast(message, tittle, Color.PaleGreen);
                    break;
                case ToastIndicator.Warning:
                    ShowToast(message, tittle, Color.PaleGoldenrod);
                    break;
                case ToastIndicator.Error:
                    ShowToast(message, tittle, Color.PaleVioletRed);
                    break;
            }
        }
        public static void ShowToast(string message, string tittle,Color indicatorColor = default(Color)) {
            m_timer.Stop();
            m_toast.message = message;
            m_toast.tittle = tittle;
            if (indicatorColor.IsEmpty)
                m_toast.indicatorColor = Color.PaleGreen;
            else
                m_toast.indicatorColor = indicatorColor;
            m_toast.ShowToast();
            m_toast.Visible = true;
            m_timer.Start();
        }
        public static void HideToast() {
            m_toast.HideToast();
        }
        private static void OnToastHide() {
            m_timer.Stop();
        }
    }
    #endregion
}