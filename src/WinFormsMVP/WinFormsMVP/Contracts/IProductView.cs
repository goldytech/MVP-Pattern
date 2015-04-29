namespace WinFormsMVP.Contracts
{
    using System.Collections.Generic;

    using WinFormsMVP.Models;

    public interface IProductView
    {
        void Initialize(ProductPresenter presenter);
        string GetFileName();
        void ShowProducts(IEnumerable<Product> products);
        void SetFileName(string fileName); 
    }
}