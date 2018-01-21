using CashRegister.Library;
using CashRegister.Library.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CashRegister.Tests
{
    [TestClass]
    public class BasketTest
    {
        GoodsManager gm;

        [TestInitialize]
        public void TestInitialize()
        {
            gm = new GoodsManager();
            Good good = new Good("A", 5, 3, 13);
            Tuple<bool, string> rtn = gm.AddNewGood(good);
            good = new Good("B", 3, 2, 4.5);
            rtn = gm.AddNewGood(good);
            good = new Good("C", 2);
            rtn = gm.AddNewGood(good);
            good = new Good("D", 1.5);
            rtn = gm.AddNewGood(good);
        }

        [TestMethod]
        public void AddItemToBasket()
        {
            BasketManager bm = new BasketManager(gm);

            bm.AddNewItem("B", 1);
            Assert.AreEqual(bm.GetTotalBasket(), 3);
        }

        [TestMethod]
        public void AddItemToBasket_Quantity()
        {
            BasketManager bm = new BasketManager(gm);

            bm.AddNewItem("C", 3);
            Assert.AreEqual(bm.GetTotalBasket(), 6);
        }

        [TestMethod]
        public void AddItemToBasket_QuantityOffer()
        {
            BasketManager bm = new BasketManager(gm);

            bm.AddNewItem("A", 3);
            Assert.AreEqual(bm.GetTotalBasket(), 13);
        }

        [TestMethod]
        public void AddItemToBasket_MultiQuantityOffer()
        {
            BasketManager bm = new BasketManager(gm);

            bm.AddNewItem("A", 6);
            Assert.AreEqual(bm.GetTotalBasket(), 26);
        }

        [TestMethod]
        public void AddItemToBasket_MultiQuantityOfferPlusOne()
        {
            BasketManager bm = new BasketManager(gm);

            bm.AddNewItem("A", 7);
            Assert.AreEqual(bm.GetTotalBasket(), 31);
        }

        [TestMethod]
        public void AddItemToBasket_VerifyOfferCalculator()
        {
            BasketManager bm = new BasketManager(gm);

            bm.AddNewItem("B", 1);
            Assert.AreEqual(bm.GetTotalBasket(), 3);

            bm.AddNewItem("A", 1);
            Assert.AreEqual(bm.GetTotalBasket(), 8);

            bm.AddNewItem("B", 1);
            Assert.AreEqual(bm.GetTotalBasket(), 9.5);
        }
    }
}
