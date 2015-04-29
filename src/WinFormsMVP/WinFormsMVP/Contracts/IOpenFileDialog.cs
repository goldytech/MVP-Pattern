namespace WinFormsMVP.Contracts
{
    using System.Windows.Forms;

    public interface IOpenFileDialog
    {
        string Filter
        {
            get;
            set;
        }
        string FileName
        {
            get;
        }
        DialogResult ShowDialog(); 
    }
}