using CashRegister.Library;
using CashRegister.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashRegister.ConsoleApp.Data
{
    class GoodData
    {
        static volatile GoodsManager instance;
        static object syncRoot = new Object();

        /// <summary>
        /// Gets the instance.
        /// </summary>
        /// <value>The instance.</value>
        public static IGoodsManager Instance
        {
            get {
                if (instance == null)
                {
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new GoodsManager();
                        }
                    }
                }

                return instance;
            }
        }
    }
}
