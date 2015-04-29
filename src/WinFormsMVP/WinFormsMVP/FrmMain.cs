namespace WinFormsMVP
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Forms;

    using WinFormsMVP.Contracts;
    using WinFormsMVP.Models;

    public partial class FrmMain : Form ,IProductView
    {
        private ProductPresenter productPresenter;
        
        #region Constructor
        public FrmMain()
        {
            InitializeComponent();
        } 
        #endregion

        #region IProductView Implementation
        public void Initialize(ProductPresenter presenter)
        {
            this.productPresenter = presenter;
        }

        public string GetFileName()
        {
            return this.txtFileName.Text;
        }

        public void ShowProducts(IEnumerable<Product> products)
        {
            this.listView1.Items.Clear();
            foreach (var item in products.Select(product => new ListViewItem(new[]
                                                                                 {
                                                                                     product.Id.ToString(),
                                                                                     product.Name,
                                                                                     product.UnitPrice.ToString("C"),
                                                        
                                                                                 })))
            {
                this.listView1.Items.Add(item);
            }
        }

        public void SetFileName(string fileName)
        {
            this.txtFileName.Text = fileName;
            this.btnLoad.Enabled = true;
        } 
        #endregion

        #region Event Handlers
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            this.productPresenter.BrowseForFileName();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            this.productPresenter.GetProducts();
        } 
        #endregion
    }
}
