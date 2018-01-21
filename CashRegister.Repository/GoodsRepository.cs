using CashRegister.Library.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CashRegister.Repository
{
    /// <summary>
    /// Class GoodsRepository.
    /// </summary>
    public class GoodsRepository : GenericRepository<Good>
    {
        /// <summary>
        /// Reads the goods.
        /// </summary>
        /// <param name="filepath">The filepath.</param>
        /// <returns>List&lt;Good&gt;.</returns>
        public List<Good> ReadGoods(string filepath) {
            return base.ReadFile(filepath);
        }

        /// <summary>
        /// Saves the goods.
        /// </summary>
        /// <param name="filepath">The filepath.</param>
        /// <param name="items">The items.</param>
        /// <returns><c>true</c> if the application saved the file, <c>false</c> otherwise.</returns>
        public bool SaveGoods(string filepath, List<Good> items)
        {
            return base.SaveFile(filepath, items);
        }
    }
}