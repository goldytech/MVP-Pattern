namespace WinFormsMVP.Contracts
{
    using System.Collections.Generic;

    using WinFormsMVP.Models;

    /// <summary>
    /// Represents Product Repository Contract
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Gets the products list from XML file.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>Products List</returns>
        IEnumerable<Product> GetByFileName(string fileName); 
    }
}