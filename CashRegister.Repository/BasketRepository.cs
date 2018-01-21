using CashRegister.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashRegister.Repository
{
    /// <summary>
    /// Class BasketRepository.
    /// </summary>
    /// <seealso cref="CashRegister.Repository.GenericRepository{CashRegister.Library.Models.BasketItem}" />
    public class BasketRepository : GenericRepository<BasketItem>
    {
        /// <summary>
        /// Reads the goods.
        /// </summary>
        /// <param name="filepath">The filepath.</param>
        /// <returns>List of BasketItem.</returns>
        public List<BasketItem> ReadGoods(string filepath)
        {
            return base.ReadFile(filepath);
        }

        /// <summary>
        /// Saves the goods.
        /// </summary>
        /// <param name="filepath">The filepath.</param>
        /// <param name="items">The items.</param>
        /// <returns><c>true</c> if the application saved the file, <c>false</c> otherwise.</returns>
        public bool SaveGoods(string filepath, List<BasketItem> items)
        {
            return base.SaveFile(filepath, items);
        }
    }
}
