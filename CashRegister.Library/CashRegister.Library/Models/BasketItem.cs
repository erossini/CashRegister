using System;
using System.Collections.Generic;
using System.Text;

namespace CashRegister.Library.Models
{
    /// <summary>
    /// Class BasketItem.
    /// </summary>
    public class BasketItem
    {
        /// <summary>
        /// Gets or sets the item.
        /// </summary>
        /// <value>The item.</value>
        public string Item { get; set; }

        /// <summary>
        /// Gets or sets the price.
        /// </summary>
        /// <value>The price.</value>
        public double Price { get; set; }

        /// <summary>
        /// Gets or sets the final price.
        /// </summary>
        /// <value>The final price.</value>
        public double FinalPrice { get; set; }

        /// <summary>
        /// Gets or sets the quantity.
        /// </summary>
        /// <value>The quantity.</value>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this instance is offer.
        /// </summary>
        /// <value><c>true</c> if this instance is offer; otherwise, <c>false</c>.</value>
        public bool IsOffer { get; set; }
    }
}
