namespace WinFormsMVP
{
    using System;
    using System.Xml;

    using WinFormsMVP.Contracts;
    using WinFormsMVP.Models;
    using WinFormsMVP.Properties;

    public class ProductMapper :IProductMapper
    {
        /// <summary>
        /// Maps the Product POCO specified XML Attributes.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns></returns>
        public Product Map(XmlReader reader)
        {
            if (reader == null)
                throw new ArgumentNullException(Resources.ProductMapper_Map_XML_reader_used_when_mapping_cannot_be_null_);
            if (reader.Name != "product")
                throw new InvalidOperationException("XML reader is not on a product fragment.");

            var product = new Product();
            product.Id = int.Parse(reader.GetAttribute("id"));
            product.Name = reader.GetAttribute("name");
            product.UnitPrice = decimal.Parse(reader.GetAttribute("unitPrice"));
         
            return product; 
        }
    }
}