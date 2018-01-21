using CashRegister.ConsoleApp.Data;
using CashRegister.ConsoleApp.Infrastructures;
using CashRegister.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashRegister.ConsoleApp.Pages
{
    class GoodAdd : Page
    {
        public GoodAdd(Program program) : base("Add new good", program)
        {
        }

        public override void Display()
        {
            base.Display();

            Output.WriteLine("");

            Good good = new Good();
            good.Item = Input.ReadString("Item name:");

            if (!string.IsNullOrEmpty(good.Item))
            {
                good.Price = Input.ReadDouble("Price:", 0.1, 100);
                good.OfferItemNumber = Input.ReadInt("Number item for offer:", 0, 10);
                good.OfferPrice = Input.ReadDouble("Offer price:", 0, 100);

                Tuple<bool, string> rtn = GoodData.Instance.AddNewGood(good);
                if (rtn.Item1)
                    Output.WriteLine("Good is saved!");
                else
                    Output.WriteLine(ConsoleColor.Red, $"I can't save your item: {rtn.Item2}");
            }
            else
            {
                Output.WriteLine(ConsoleColor.Red, "Name not valid!");
            }

            Input.ReadString("Press [Enter] to navigate back");
            Program.NavigateBack();
        }
    }
}
