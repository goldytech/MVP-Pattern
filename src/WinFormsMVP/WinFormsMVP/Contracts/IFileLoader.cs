namespace WinFormsMVP.Contracts
{
    using System.IO;

    /// <summary>
    ///    Represents the contract File Loader Service
    /// </summary>
    public interface IFileLoader
    {
        /// <summary>
        /// Loads the specified file name.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>Stream of opened file</returns>
        Stream Load(string fileName); 
    }
}