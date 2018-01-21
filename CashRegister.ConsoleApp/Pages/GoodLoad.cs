using CashRegister.ConsoleApp.Data;
using CashRegister.ConsoleApp.Infrastructures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace CashRegister.ConsoleApp.Pages
{
    class GoodLoad : Page
    {
        public GoodLoad(Program program) : base("Load", program)
        {
        }

        public override void Display()
        {
            base.Display();

            Output.WriteLine("");

            if (File.Exists(FileData.GoodsFile()))
            {
                bool loadFile = true;
                if (GoodData.Instance.Goods.Count > 0)
                {
                    Output.WriteLine("Goods are already present in your list. If you load a list from file, you lost them.");
                    loadFile = Input.ReadBool("Do you want to continue?");
                }

                if (loadFile)
                {
                    Repository.GoodsRepository repo = new Repository.GoodsRepository();
                    GoodData.Instance.Goods = repo.ReadFile(FileData.GoodsFile());
                    Output.WriteLine(ConsoleColor.White, "File saved!");
                }
            }
            else
                Output.WriteLine(ConsoleColor.Red, "The file Good.json is not exist!");

            Output.WriteLine("");

            Input.ReadString("Press [Enter] to navigate back");
            Program.NavigateBack();
        }
    }
}
