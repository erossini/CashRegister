using CashRegister.ConsoleApp.Infrastructures;
using CashRegister.ConsoleApp.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashRegister.ConsoleApp
{
    class MainMenu : MenuPage
    {
        public MainMenu(Program program)
            : base("Main Page", program,
                  new Option("Goods manager", () => program.NavigateTo<GoodMenuPage>()),
                  new Option("Shopping cart", () => program.NavigateTo<ShoppingCartPage>()))
        {
        }
    }
}
