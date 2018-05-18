using GiftShopService;
using GiftShopService.Interfaces;
using GiftShopService.InventoryDB;
using System;
using System.Data.Entity;
using System.Windows.Forms;

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
            APIClient.Connect();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FMain());
        }
        
    }
}
