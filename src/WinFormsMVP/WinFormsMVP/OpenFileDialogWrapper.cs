namespace WinFormsMVP
{
    using System.Windows.Forms;

    using WinFormsMVP.Contracts;

    public class OpenFileDialogWrapper  :IOpenFileDialog
    {
        private readonly OpenFileDialog fileDialog;

        public OpenFileDialogWrapper()
        {
            fileDialog = new OpenFileDialog();
        }
        public string Filter
        {
            get
            {
                return this.fileDialog.Filter;
            }
            set
            {
                this.fileDialog.Filter = value;
            }
        }

        public string FileName
        {
            get
            {
                return this.fileDialog.FileName;
            }
        }

        public DialogResult ShowDialog()
        {
            return this.fileDialog.ShowDialog();
        }
    }
}