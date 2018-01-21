using CashRegister.ConsoleApp.Data;
using CashRegister.ConsoleApp.Infrastructures;
using CashRegister.ConsoleApp.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashRegister.ConsoleApp
{
   class StartPage : Program
    {
        public StartPage()
            : base("CashRegister", breadcrumbHeader: true)
        {
            // create data directory
            FileData.CreateDataDirectory();

            // Add page in the program
            AddPage(new MainMenu(this));

            AddPage(new GoodAdd(this));
            AddPage(new GoodList(this));
            AddPage(new GoodLoad(this));
            AddPage(new GoodMenuPage(this));
            AddPage(new GoodSave(this));

            AddPage(new ShoppingCartPage(this));
            AddPage(new ShoppingRegister(this));

            // set the main page
            SetPage<MainMenu>();
        }
    }
}
