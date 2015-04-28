namespace WinFormsMVP.Models
{
    /// <summary>
    /// Represents Product Entity
    /// </summary>
    public class Product
    {
        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>The id.</value>
        public int Id
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the product name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the product unit price.
        /// </summary>
        /// <value>The unit price.</value>
        public decimal UnitPrice
        {
            get;
            set;
        }
    }
}