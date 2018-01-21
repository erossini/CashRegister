using System;
using System.Collections.Generic;
using System.Text;

namespace CashRegister.Library.Models
{
    public class BasketDetails
    {
        /// <summary>
        /// Gets or sets the basket list.
        /// </summary>
        /// <value>The basket list.</value>
        public List<BasketItem> BasketList { get; private set; }

        /// <summary>
        /// Gets or sets the basket history.
        /// </summary>
        /// <value>The basket history.</value>
        public List<History> BasketHistory { get; private set; }

        /// <summary>
        /// Gets the ticket.
        /// </summary>
        /// <value>The ticket.</value>
        public List<BasketItem> Ticket { get; private set; }

        public BasketDetails()
        {
            BasketHistory = new List<History>();
            BasketList = new List<BasketItem>();
            Ticket = new List<BasketItem>();
        }
    }
}