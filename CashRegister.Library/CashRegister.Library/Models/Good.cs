using System;
using System.Collections.Generic;
using System.Text;

namespace CashRegister.Library.Models
{
    /// <summary>
    /// Class Good.
    /// </summary>
    public class Good
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Good"/> class.
        /// </summary>
        public Good() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="Good"/> class.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="price">The price.</param>
        /// <param name="offerItemNumber">The offer item number.</param>
        /// <param name="offerPrice">The offer price.</param>
        public Good(string item, double price, int offerItemNumber = 0, double offerPrice = 0)
        {
            Item = item;
            Price = price;
            OfferItemNumber = offerItemNumber;
            OfferPrice = offerPrice;
        }

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
        /// Gets or sets the offer item number.
        /// </summary>
        /// <value>The offer item number.</value>
        public int OfferItemNumber { get; set; }

        /// <summary>
        /// Gets or sets the offer price.
        /// </summary>
        /// <value>The offer price.</value>
        public double OfferPrice { get; set; }
    }
}
