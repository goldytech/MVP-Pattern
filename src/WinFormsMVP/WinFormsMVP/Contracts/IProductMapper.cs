namespace WinFormsMVP.Contracts
{
    using System.Xml;

    using WinFormsMVP.Models;

    /// <summary>
    /// Represents Product Mapper Service
    /// </summary>
    public interface IProductMapper
    {
        /// <summary>
        /// Maps the Product POCO specified XML Elements.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns></returns>
        Product Map(XmlReader reader); 
    }
}