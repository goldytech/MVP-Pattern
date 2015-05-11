namespace MVP_Patterns.Tests
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Windows.Forms;

    using Moq;

    using WinFormsMVP;
    using WinFormsMVP.Contracts;
    using WinFormsMVP.Models;

    using Xunit;

    [ExcludeFromCodeCoverage]
    public class ProductPresenterTest
    {
        private readonly Mock<IProductView> mockProductView;

        private readonly Mock<IProductRepository> mockProductRepo;

        private readonly Mock<IOpenFileDialog> mockOpenFileDialog;

        public ProductPresenterTest()
        {
            this.mockProductView = new Mock<IProductView>();
            this.mockProductRepo = new Mock<IProductRepository>();
            this.mockOpenFileDialog = new Mock<IOpenFileDialog>();
        }

        [Fact]
        public void Should_Initialize_View()
        {
            

            var sut = new ProductPresenter(this.mockProductView.Object, this.mockProductRepo.Object, this.mockOpenFileDialog.Object);

            mockProductView.Verify(p=>p.Initialize(sut),Times.Once());

           Assert.Same(this.mockProductView.Object,sut.View);
        }

        [Fact]
        public void Should_Get_Products_From_Repo()
        {
            var sut = new ProductPresenter(this.mockProductView.Object, this.mockProductRepo.Object, this.mockOpenFileDialog.Object);

            var prodList = new List<Product>
                               {
                                   new Product { Id = 1, Name = "ABC", UnitPrice = 100 },
                                   new Product { Id = 2, Name = "XYZ", UnitPrice = 200 }
                               };
            this.mockProductRepo.Setup(x => x.GetByFileName(It.IsAny<string>())).Returns(prodList);

            sut.GetProducts();

            this.mockProductRepo.Verify(p=>p.GetByFileName(It.IsAny<string>()),Times.Once);
        }

        [Fact]
        public void Should_Set_FileName()
        {
            var sut = new ProductPresenter(mockProductView.Object, mockProductRepo.Object, mockOpenFileDialog.Object);
            mockOpenFileDialog.Setup(o => o.ShowDialog()).Returns(DialogResult.OK);
            sut.BrowseForFileName();
            mockProductView.Verify(x=>x.SetFileName(It.IsAny<string>()),Times.Once());

        }
    }
}