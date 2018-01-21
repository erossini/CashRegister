using CashRegister.Library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashRegister.Repository
{
    public class BasketDetailsRepository : GenericRepository<BasketDetails>
    {
        /// <summary>
        /// Reads the details.
        /// </summary>
        /// <param name="filepath">The filepath.</param>
        /// <returns>List&lt;BasketDetails&gt;.</returns>
        public List<BasketDetails> ReadDetails(string filepath)
        {
            return base.ReadFile(filepath);
        }

        /// <summary>
        /// Saves the details.
        /// </summary>
        /// <param name="filepath">The filepath.</param>
        /// <param name="items">The items.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool SaveDetails(string filepath, BasketDetails items)
        {
            return base.SaveFile(filepath, items);
        }
    }
}
