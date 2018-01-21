using CashRegister.Library.Interfaces;
using CashRegister.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CashRegister.Library
{
    /// <summary>
    /// Class GoodsManager.
    /// </summary>
    public class GoodsManager : IGoodsManager
    {
        #region Common strings
        public readonly string GoodAlreadyExists = "Good already exists!";
        public readonly string GoodIsNotValid = "Good is not valid!";
        #endregion

        /// <summary>
        /// The goods
        /// </summary>
        public List<Good> Goods { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="GoodsManager"/> class.
        /// </summary>
        public GoodsManager()
        {
            Goods = new List<Good>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GoodsManager"/> class.
        /// </summary>
        /// <param name="good">The good.</param>
        public GoodsManager(Good good)
        {
            Goods = new List<Good>() { good };
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GoodsManager"/> class.
        /// </summary>
        /// <param name="goods">The goods.</param>
        public GoodsManager(List<Good> goods)
        {
            Goods = goods;
        }

        /// <summary>
        /// Adds the new good.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="price">The price.</param>
        /// <param name="itemOffer">The item offer.</param>
        /// <param name="itemOfferPrice">The item offer price.</param>
        public Tuple<bool, string> AddNewGood(string item, double price, int itemOffer = 0, double itemOfferPrice = 0)
        {
            return AddNewGood(new Good() { Item = item, OfferItemNumber = itemOffer, OfferPrice = itemOfferPrice, Price = price });
        }

        /// <summary>
        /// Adds the new good.
        /// </summary>
        /// <param name="good">The good.</param>
        public Tuple<bool, string> AddNewGood(Good good)
        {
            bool rtn = false;
            string rtnError = "";

            if (good != null && !string.IsNullOrEmpty(good.Item) && good.Price > 0)
            {
                if (SearchAGood(good.Item) == null)
                {
                    Goods.Add(good);
                    rtn = true;
                }
                else
                    rtnError = GoodAlreadyExists;
            }
            else
                rtnError = GoodIsNotValid;

            return new Tuple<bool, string>(rtn, rtnError);
        }

        /// <summary>
        /// Gets the number of goods.
        /// </summary>
        /// <returns>The number of goods.</returns>
        public int GetNumberOfGoods()
        {
            return Goods.Count;
        }

        /// <summary>
        /// Gets the number of goods in offer.
        /// </summary>
        /// <returns>The number of goods in offer.</returns>
        public int GetNumberOfGoodsInOffer()
        {
            return Goods.Where(g => g.OfferItemNumber > 0).Count();
        }

        /// <summary>
        /// Searches a good.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <returns>Good.</returns>
        public Good SearchAGood(string item)
        {
            return Goods.SingleOrDefault(g => g.Item == item);
        }
    }
}