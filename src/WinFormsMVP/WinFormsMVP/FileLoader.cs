namespace WinFormsMVP
{
    using System.IO;

    using WinFormsMVP.Contracts;

    public class FileLoader :IFileLoader
    {
        /// <summary>
        /// Loads the specified file name.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>Stream of opened file</returns>
        public Stream Load(string fileName)
        {
            return new FileStream(fileName, FileMode.Open);
        }
    }
}