using CashRegister.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashRegister.Repository
{
    /// <summary>
    /// Class BasketHistoryRepository.
    /// </summary>
    /// <seealso cref="CashRegister.Repository.GenericRepository{CashRegister.Library.Models.History}" />
    public class BasketHistoryRepository : GenericRepository<History>
    {
        /// <summary>
        /// Reads the goods.
        /// </summary>
        /// <param name="filepath">The filepath.</param>
        /// <returns>List&lt;History&gt;.</returns>
        public List<History> ReadGoods(string filepath)
        {
            return base.ReadFile(filepath);
        }

        /// <summary>
        /// Saves the goods.
        /// </summary>
        /// <param name="filepath">The filepath.</param>
        /// <param name="items">The items.</param>
        /// <returns><c>true</c> if the application saved the file, <c>false</c> otherwise.</returns>
        public bool SaveGoods(string filepath, List<History> items)
        {
            return base.SaveFile(filepath, items);
        }
    }
}
