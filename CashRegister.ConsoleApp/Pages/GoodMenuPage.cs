using CashRegister.ConsoleApp.Infrastructures;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashRegister.ConsoleApp.Pages
{
    class GoodMenuPage : MenuPage
    {
        public GoodMenuPage(Program program)
            : base("Goods menu", program,
                  new Option("Add new good", () => program.NavigateTo<GoodAdd>()),
                  new Option("Show list of goods", () => program.NavigateTo<GoodList>()),
                  new Option("Load goods from a file", () => program.NavigateTo<GoodLoad>()),
                  new Option("Save goods in to a file", () => program.NavigateTo<GoodSave>()))
        {
        }
    }
}