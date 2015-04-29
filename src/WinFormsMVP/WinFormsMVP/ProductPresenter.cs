namespace WinFormsMVP
{
    using System.Windows.Forms;

    using WinFormsMVP.Contracts;

    /// <summary>
    /// Represents Product Presenter
    /// </summary>
    public class ProductPresenter
    {
        private readonly IProductView productView;

        private readonly IProductRepository productRepository;

        private readonly IOpenFileDialog openFileDialog;

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductPresenter" /> class.
        /// </summary>
        /// <param name="productView">The product view.</param>
        /// <param name="productRepository">The product repository.</param>
        /// <param name="openFileDialog">The open file dialog.</param>
        public ProductPresenter(IProductView productView, IProductRepository productRepository, IOpenFileDialog openFileDialog)
        {
            this.productView = productView;
            this.productRepository = productRepository;
            this.openFileDialog = openFileDialog;
        }

        #endregion

        /// <summary>
        /// Gets the products.
        /// </summary>
        public void GetProducts()
        {
            var products = this.productRepository.GetByFileName(this.productView.GetFileName());
            this.productView.ShowProducts(products);
        }

        /// <summary>
        /// Browses the name of for file.
        /// </summary>
        public void BrowseForFileName()
        {
            this.openFileDialog.Filter = "XML Document (*.xml)|*.xml|All Files (*.*)|*.*";
            var result = openFileDialog.ShowDialog();
            if (result == DialogResult.OK) this.productView.SetFileName(this.openFileDialog.FileName);
        }
    }
}