using CashRegister.ConsoleApp.Infrastructures;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashRegister.ConsoleApp.Pages
{
    class ShoppingCartPage : MenuPage
    {
        public ShoppingCartPage(Program program) : base("Shopping menu", program,
          new Option("Cash Register", () => program.NavigateTo<ShoppingRegister>()))
        {
        }
    }
}
