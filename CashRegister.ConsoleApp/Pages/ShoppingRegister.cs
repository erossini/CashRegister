using CashRegister.ConsoleApp.Data;
using CashRegister.ConsoleApp.Infrastructures;
using CashRegister.Library;
using CashRegister.Library.Interfaces;
using CashRegister.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashRegister.ConsoleApp.Pages
{
    class ShoppingRegister : Page
    {
        IBasketManager basketManager;

        public ShoppingRegister(Program program) : base("Cash register", program)
        {
        }

        public override void Display()
        {
            base.Display();

            if (GoodData.Instance.Goods.Count == 0)
            {
                Output.WriteLine("");
                Output.WriteLine(ConsoleColor.White, "No good added. Please add goods.");
            }
            else
            {
                basketManager = new BasketManager(GoodData.Instance);
                Output.WriteLine(ConsoleColor.White, "Start to add items in your basket. Insert 0 to close your basket.");
                string item = "";

                while (item != "0")
                {
                    item = Input.ReadString("Please enter your next item");
                    if (item != "0")
                    {
                        bool insert = basketManager.AddNewItem(item.ToUpper(), 1);
                        if (!insert)
                            Output.WriteLine("\tThis item can't be added to your basket!");
                    }
                }

                if (basketManager.BasketDetails.BasketList.Count > 0)
                {
                    Output.WriteLine("");
                    Output.WriteLine(ConsoleColor.White, "Ticket");
                    Output.WriteLine(ConsoleColor.White, "-----------");
                    Output.WriteLine("");

                    Output.WriteLine($"Item\tQty\tYour price");
                    foreach (BasketItem itm in basketManager.BasketDetails.Ticket)
                    {
                        if (itm.IsOffer)
                            Output.WriteLine(ConsoleColor.DarkCyan, $"{itm.Item}\t{itm.Quantity} x £{itm.Price}\t£{itm.FinalPrice}");
                        else
                            Output.WriteLine(ConsoleColor.DarkGray, $"{itm.Item}\t{itm.Quantity} x £{itm.Price}\t£{itm.FinalPrice}");
                    }
                    Output.WriteLine("");
                    Output.WriteLine(ConsoleColor.Gray, "-----------");
                    Output.WriteLine(ConsoleColor.Gray, $"Total: £{basketManager.GetTotalBasket()}");

                    Output.WriteLine("");
                    Output.WriteLine(ConsoleColor.Gray, "Your basket");
                    Output.WriteLine(ConsoleColor.Gray, "-----------");
                    Output.WriteLine("");

                    Output.WriteLine($"Item\tQty\tPrice\tYour price");
                    foreach (BasketItem itm in basketManager.BasketDetails.BasketList)
                    {
                        Output.WriteLine(ConsoleColor.DarkGray, $"{itm.Item}\t{itm.Quantity}\t£{itm.Price}\t£{itm.FinalPrice}");
                    }
                    Output.WriteLine("");
                    Output.WriteLine(ConsoleColor.Gray, "-----------");
                    Output.WriteLine(ConsoleColor.Gray, $"Total: £{basketManager.GetTotalBasket()}");

                    if (basketManager.BasketDetails.BasketHistory.Count > 0) {
                        Output.WriteLine("");
                        Output.WriteLine("");

                        Output.WriteLine(ConsoleColor.Gray, "Basket history");
                        Output.WriteLine(ConsoleColor.Gray, "--------------");

                        Output.WriteLine($"Item\tPrice\tTotal\tOffer\tOperation");
                        foreach (History itm in basketManager.BasketDetails.BasketHistory)
                        {
                            Output.WriteLine(ConsoleColor.DarkGray, $"{itm.ItemName}\t£{itm.Price}\t£{itm.FinalPrice}\t{itm.ApplyDiscount}\t{itm.Operation}");
                        }
                    }

                    Output.WriteLine("");
                    Repository.BasketDetailsRepository repo = new Repository.BasketDetailsRepository();
                    string filename = FileData.BasketDetailsFile(DateTime.Now.ToString("yyyyMMddHHmmssfff"));
                    if (repo.SaveDetails(filename, basketManager.BasketDetails))
                    {
                        Output.WriteLine(ConsoleColor.DarkGray, "This basket is saved on");
                        Output.WriteLine(ConsoleColor.DarkGray, filename);
                    }
                    else
                        Output.WriteLine(ConsoleColor.Red, "I can't save the basket in a file!");
                }
                else
                    Output.WriteLine("No items added to your basket.");
            }
            Output.WriteLine("");

            Input.ReadString("Press [Enter] to navigate back");
            Program.NavigateBack();
        }
    }
}
