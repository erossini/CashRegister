using System;
using System.Collections.Generic;
using System.Text;

namespace CashRegister.Library.Models
{
    /// <summary>
    /// Class History.
    /// </summary>
    public class History
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="History"/> class.
        /// </summary>
        /// <param name="operation">The operation.</param>
        /// <param name="itemName">Name of the item.</param>
        /// <param name="price">The price.</param>
        /// <param name="finalPrice">The final price.</param>
        /// <param name="applyDiscount">if set to <c>true</c> [apply discount].</param>
        public History(string operation, string itemName, double price, double finalPrice, bool applyDiscount)
        {
            Operation = operation;
            ItemName = itemName;
            Price = price;
            FinalPrice = finalPrice;
            ApplyDiscount = applyDiscount;
        }

        /// <summary>
        /// Gets or sets the operation.
        /// </summary>
        /// <value>The operation.</value>
        public string Operation { get; set; }

        /// <summary>
        /// Gets or sets the name of the item.
        /// </summary>
        /// <value>The name of the item.</value>
        public string ItemName { get; set; }

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
        /// Gets or sets a value indicating if a discount is applied.
        /// </summary>
        /// <value><c>true</c> if discount is applied; otherwise, <c>false</c>.</value>
        public bool ApplyDiscount { get; set; }
    }
}
