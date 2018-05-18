using GiftShopService;
using GiftShopService.Interfaces;
using GiftShopService.InventoryDB;
using System;
using System.Data.Entity;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;

namespace GiftShopView
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<FMain>());
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<DbContext, GiftDBContext>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<ICustomerService, CustomerServiceBD>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IElementService, ElementServiceBD>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IFacilitatorService, FacilitatorServiceBD>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IGiftService, GiftServiceBD>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IStorageService, StorageServiceBD>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IMainService, MainServiceBD>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IReportService, ReportServiceBD>(new HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}
