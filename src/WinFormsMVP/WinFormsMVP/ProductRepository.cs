namespace WinFormsMVP
{
    using System.Collections.Generic;
    using System.IO;
    using System.Xml;

    using WinFormsMVP.Contracts;
    using WinFormsMVP.Models;

    public class ProductRepository :IProductRepository
    {
        #region Declarations
        private readonly IFileLoader fileLoader;

        private readonly IProductMapper productMapper; 
        #endregion

        #region Constructor
        public ProductRepository(IFileLoader fileLoader, IProductMapper productMapper)
        {
            this.fileLoader = fileLoader;
            this.productMapper = productMapper;
        } 
        #endregion

        #region IProductRepository Implementation
        /// <summary>
        /// Gets the products list from XML file.
        /// </summary>
        /// <param name="fileName">Name of the file.</param>
        /// <returns>Products List</returns>
        public IEnumerable<Product> GetByFileName(string fileName)
        {
            var products = new List<Product>();
            using (Stream input = this.fileLoader.Load(fileName))
            {
                var reader = XmlReader.Create(input);
                while (reader.Read())
                {
                    if (reader.Name != "product") continue;
                    var product = this.productMapper.Map(reader);
                    products.Add(product);
                }
            }
            return products;
        } 
        #endregion
    }
}