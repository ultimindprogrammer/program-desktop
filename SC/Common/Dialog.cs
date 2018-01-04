using System;
using System.Windows.Forms;
namespace SC
{
    public sealed class Dialog
    {
        private static OpenFileDialog m_openFileDialog;
        private static SaveFileDialog m_saveFileDialog;

        private static Action<bool, string> m_validateAction;
        private static int m_selected;
        static Dialog() {
            m_openFileDialog = new OpenFileDialog();
            m_saveFileDialog = new SaveFileDialog();
            
            //OpenFileDialog
            m_openFileDialog.AddExtension = true;
            m_openFileDialog.AutoUpgradeEnabled = true;
            m_openFileDialog.SupportMultiDottedExtensions = false;
            m_openFileDialog.FileOk += FileOkEvent;

            //SaveFileDialog
            m_saveFileDialog.AddExtension = true;
            m_saveFileDialog.AutoUpgradeEnabled = true;
            m_saveFileDialog.OverwritePrompt = true;
            m_saveFileDialog.SupportMultiDottedExtensions = false;
            m_saveFileDialog.FileOk += FileOkEvent;
        }

        public static void ShowOpenFileDialog(string title, string filter, Action<bool, string> onValidate) {
            if (onValidate == null)
                throw new ArgumentNullException("OnValidate is Empty/Null");
            m_selected = 0;
            m_validateAction = onValidate;
            m_openFileDialog.Title = title;
            m_openFileDialog.Filter = filter;
            m_openFileDialog.ShowDialog();
        }

        public static void ShowSaveFileDialog(string title, string filter, Action<bool, string> onValidate) {
            if (onValidate == null)
                throw new ArgumentNullException("OnValidate is Empty/Null");
            m_selected = 1;
            m_validateAction = onValidate;
            m_saveFileDialog.Title = title;
            m_saveFileDialog.Filter = filter;
            m_saveFileDialog.ShowDialog();
        }

        private static void FileOkEvent(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(m_selected == 0)
                m_validateAction(!e.Cancel, m_openFileDialog.FileName);
            else
                m_validateAction(!e.Cancel, m_saveFileDialog.FileName);
        }
    }
}
