using CashRegister.Library.Interfaces;
using CashRegister.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CashRegister.Library
{
    public class BasketManager
    {
        #region Common text
        public readonly string HistoryStart = "Open basket";
        public readonly string HistoryAddNew = "Add new item basket";
        public readonly string HistoryUpdate = "Update item basket";
        #endregion

        /// <summary>
        /// Gets or sets the basket list.
        /// </summary>
        /// <value>The basket list.</value>
        public BasketDetails BasketDetails { get; private set; }

        IGoodsManager goodsManager;

        /// <summary>
        /// Initializes a new instance of the <see cref="BasketManager"/> class.
        /// </summary>
        /// <param name="goodsManager">The goods manager.</param>
        public BasketManager(IGoodsManager goodsManager)
        {
            this.goodsManager = goodsManager;
            this.BasketDetails = new BasketDetails();
            AddHistory(HistoryStart);
        }

        /// <summary>
        /// Adds the history.
        /// </summary>
        /// <param name="operation">The operation.</param>
        /// <param name="itemName">Name of the item.</param>
        /// <param name="price">The price.</param>
        /// <param name="finalPrice">The final price.</param>
        /// <param name="applyDiscount">if set to <c>true</c> [apply discount].</param>
        public void AddHistory(string operation, string itemName = "", double price = 0, double finalPrice = 0, bool applyDiscount = false)
        {
            BasketDetails.BasketHistory.Add(new History(operation, itemName, price, finalPrice, applyDiscount));
        }

        /// <summary>
        /// Adds the new item.
        /// </summary>
        /// <param name="itemname">The itemname.</param>
        /// <param name="quantity">The quantity.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool AddNewItem(string itemname, int quantity)
        {
            if (!string.IsNullOrEmpty(itemname) && quantity > 0)
                return CalculateBasketItem(itemname, quantity);
            else
                return false;
        }

        /// <summary>
        /// Calculates the basket item.
        /// </summary>
        /// <param name="itemname">The itemname.</param>
        /// <param name="quantity">The quantity.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        public bool CalculateBasketItem(string itemname, int quantity)
        {
            bool rtn = false;

            Good good = goodsManager.SearchAGood(itemname);
            if (good != null)
            {
                var qry = BasketDetails.BasketList.SingleOrDefault(b => b.Item == itemname);
                if (qry != null)
                {
                    qry.Quantity += quantity;
                    qry.FinalPrice = CalculatePrice(good, qry.Quantity);

                    if (qry.FinalPrice > 0)
                    {
                        AddHistory(HistoryUpdate, itemname, qry.Price, qry.FinalPrice, (qry.Price * qry.Quantity) != qry.FinalPrice);
                        rtn = true;
                    }
                }
                else
                {
                    BasketItem bi = new BasketItem() { Item = good.Item, Price = good.Price, Quantity = quantity };
                    bi.FinalPrice = CalculatePrice(good, bi.Quantity);
                    BasketDetails.BasketList.Add(bi);

                    if (bi.FinalPrice > 0)
                    {
                        AddHistory(HistoryAddNew, itemname, bi.Price, bi.FinalPrice, (bi.Price * bi.Quantity) != bi.FinalPrice);
                        rtn = true;
                    }
                }
            }

            return rtn;
        }

        /// <summary>
        /// Calculates the price.
        /// </summary>
        /// <param name="good">The good.</param>
        /// <param name="quantity">The quantity.</param>
        /// <returns>System.Double.</returns>
        private double CalculatePrice(Good good, int quantity)
        {
            double rtn = 0;

            if (good != null)
                if (quantity >= good.OfferItemNumber && good.OfferItemNumber > 0)
                {
                    int qtyOffer = quantity / good.OfferItemNumber;
                    int qtyNoOffer = quantity % good.OfferItemNumber;
                    rtn = (qtyOffer * good.OfferPrice) + (qtyNoOffer * good.Price);
                    CreateTicket(good, qtyNoOffer, qtyOffer);
                }
                else
                {
                    rtn = quantity * good.Price;
                }
            else
                rtn = -1;

            return rtn;
        }

        /// <summary>
        /// Creates the ticket.
        /// </summary>
        /// <param name="good">The good.</param>
        /// <param name="qtyNoOffer">The qty no offer.</param>
        /// <param name="qtyOffer">The qty offer.</param>
        void CreateTicket(Good good, int qtyNoOffer, int qtyOffer)
        {
            BasketDetails.Ticket.RemoveAll(itm => itm.Item == good.Item);

            if (qtyNoOffer > 0)
                BasketDetails.Ticket.Add(new BasketItem() { Item = good.Item, Quantity = qtyNoOffer, Price = good.Price, FinalPrice = qtyNoOffer * good.Price });
            if (qtyOffer > 0)
                BasketDetails.Ticket.Add(new BasketItem() { Item = good.Item, Quantity = qtyOffer * good.OfferItemNumber, Price = good.Price, FinalPrice = qtyOffer * good.OfferPrice, IsOffer = true });
        }

        /// <summary>
        /// Gets the total basket.
        /// </summary>
        /// <returns>System.Double.</returns>
        public double GetTotalBasket()
        {
            return BasketDetails.BasketList.Sum(b => b.FinalPrice);
        }
    }
}