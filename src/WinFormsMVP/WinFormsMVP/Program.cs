namespace WinFormsMVP
{
    using System;
    using System.Windows.Forms;

    using LightInject;

    using WinFormsMVP.Contracts;

    static class Program
    {
        private static ServiceContainer container;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            IocConfig();
            //Application.Run(new FrmMain());
            var presenter = new ProductPresenter(container.GetInstance<IProductView>(), container.GetInstance<IProductRepository>(),container.GetInstance<IOpenFileDialog>());

            Application.Run((Form) presenter.View);
        }

        /// <summary>
        /// IoC Registration
        /// </summary>
        static void IocConfig()
        {
             container = new ServiceContainer();
            container.Register<IFileLoader,FileLoader>();
            container.Register<IProductMapper,ProductMapper>();
            container.Register<IOpenFileDialog,OpenFileDialogWrapper>();
            container.Register<IProductRepository,ProductRepository>();
            container.Register<IProductView,FrmMain>();
        }
    }
}
