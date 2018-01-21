using System;
using System.Collections.Generic;
using CashRegister.Library.Models;

namespace CashRegister.Library.Interfaces
{
    /// <summary>
    /// Interface IGoodsManager
    /// </summary>
    public interface IGoodsManager
    {
        List<Good> Goods { get; set; }

        int GetNumberOfGoods();

        int GetNumberOfGoodsInOffer();
        Tuple<bool, string> AddNewGood(Good good);
        Tuple<bool, string> AddNewGood(string item, double price, int itemOffer = 0, double itemOfferPrice = 0);
        Good SearchAGood(string item);
    }
}