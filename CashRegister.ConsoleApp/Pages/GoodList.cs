using CashRegister.ConsoleApp.Data;
using CashRegister.ConsoleApp.Infrastructures;
using CashRegister.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashRegister.ConsoleApp.Pages
{
    class GoodList : Page
    {
        public GoodList(Program program) : base("Goods list", program)
        {
        }

        public override void Display()
        {
            base.Display();

            if (GoodData.Instance.Goods.Count == 0)
            {
                Output.WriteLine("");
                Output.WriteLine(ConsoleColor.White, "No good are found. Please add goods.");
            }
            else
            {
                Output.WriteLine("Item\tPrice\tOffer\tOffer price");
                foreach (Good good in GoodData.Instance.Goods)
                {
                    Output.WriteLine($"{good.Item}\t£{good.Price}\t{good.OfferItemNumber}\t£{good.OfferPrice}");
                }
            }
            Output.WriteLine("");

            Input.ReadString("Press [Enter] to navigate back");
            Program.NavigateBack();
        }
    }
}
