using CashRegister.ConsoleApp.Data;
using CashRegister.ConsoleApp.Infrastructures;
using CashRegister.Library.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace CashRegister.ConsoleApp.Pages
{
    class GoodSave : Page
    {
        public GoodSave(Program program) : base("Save", program)
        {
        }

        public override void Display()
        {
            base.Display();

            Output.WriteLine("");

            if (GoodData.Instance.Goods.Count > 0)
            {
                Output.WriteLine("Here you save your list of good in to a file.");
                Output.WriteLine("The default name is Goods.json and it will create in the current directory.");
                Output.WriteLine("");

                bool rtn = Input.ReadBool("Do you want to save your goods?");
                if (rtn)
                {
                    Repository.GoodsRepository repo = new Repository.GoodsRepository();
                    bool rtnSave = repo.SaveFile(FileData.GoodsFile(), GoodData.Instance.Goods);
                    if (rtnSave)
                        Output.WriteLine("File saved!");
                    else
                        Output.WriteLine(ConsoleColor.Red, "File doesn't save!");
                }
            }
            else
            {
                Output.WriteLine("Your list is empty. I don't save empty lists.");
            }
            Output.WriteLine("");

            Input.ReadString("Press [Enter] to navigate back");
            Program.NavigateBack();
        }
    }
}
