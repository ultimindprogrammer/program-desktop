using System;
using System.Windows.Forms;
using System.Drawing;
using SCLibrary.Utility;
namespace SC
{
    public class Overlay_Form : Form
    {
        public Overlay_Form()
        {
            this.BackColor = Color.DarkGray;
            this.Opacity = 0.30;
            this.FormBorderStyle = FormBorderStyle.None;
            this.ControlBox = false;
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.Manual;
            this.AutoScaleMode = AutoScaleMode.None;
        }

        public void ShowForm(Form parent) {
            if (this.Owner != null)
            {
                this.Owner.LocationChanged -= OnParentLocationChange;
                this.Owner.ClientSizeChanged -= OnParentSizeChanged;
                if (!this.Owner.IsDisposed && Environment.OSVersion.Version.Major >= 6)
                    Native.Dwm_SetWindowAttribute(this.Owner.Handle);
                this.Owner = null;
                this.Close();
            }

            Console.WriteLine(parent);
            this.Show(parent);
            this.Location = this.Owner.PointToScreen(Point.Empty);
            this.ClientSize = this.Owner.ClientSize;
            this.Owner.Focus();

            this.Owner.LocationChanged += OnParentLocationChange;
            this.Owner.ClientSizeChanged += OnParentSizeChanged;

            if (!this.Owner.IsDisposed && Environment.OSVersion.Version.Major >= 6)
                Native.Dwm_SetWindowAttribute(this.Owner.Handle);
        }

        public void CloseForm() {
            this.Close();
        }

        private void OnParentLocationChange(object sender, EventArgs e) {
            if(this.Owner != null)
                this.Location = this.Owner.PointToScreen(Point.Empty);
        }
        private void OnParentSizeChanged(object sender, EventArgs e) {
            if (this.Owner != null)
                this.ClientSize = this.Owner.ClientSize;
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            this.Owner.LocationChanged -= OnParentLocationChange;
            this.Owner.ClientSizeChanged -= OnParentSizeChanged;
            if (!this.Owner.IsDisposed && Environment.OSVersion.Version.Major >= 6)
                Native.Dwm_SetWindowAttribute(this.Owner.Handle);
            base.OnFormClosing(e);
        }
        protected override void OnActivated(EventArgs e)
        {
            this.BeginInvoke(new Action(() => this.Owner.Activate()));
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Overlay_Form
            // 
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "Overlay_Form";
            this.ResumeLayout(false);

        }
    }
}