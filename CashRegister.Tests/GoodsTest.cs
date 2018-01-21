using CashRegister.Library;
using CashRegister.Library.Models;
using CashRegister.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Reflection;

namespace CashRegister.Tests
{
    [TestClass]
    public class GoodsTest
    {
        [TestMethod]
        public void AddNewGood_TryAddDuplicate()
        {
            GoodsManager gm = new GoodsManager();

            Good good1 = new Good("A", 5, 2, 7);
            Tuple<bool, string> rtn = gm.AddNewGood(good1);
            Good good2 = new Good("A", 5, 2, 7);
            Tuple<bool, string> rtn2 = gm.AddNewGood(good2);

            Assert.AreEqual(false, rtn2.Item1);
            Assert.AreEqual(gm.GoodAlreadyExists, rtn2.Item2);
        }

        [TestMethod]
        public void AddNewGood_NoValues()
        {
            GoodsManager gm = new GoodsManager();
            Good good = new Good();

            Tuple<bool, string> rtn = gm.AddNewGood(good);
            Assert.AreEqual(false, rtn.Item1);
            Assert.AreEqual(gm.GoodIsNotValid, rtn.Item2);
        }

        [TestMethod]
        public void AddNewGood_WithValues()
        {
            GoodsManager gm = new GoodsManager();
            Good good = new Good("A", 5);

            Tuple<bool, string> rtn = gm.AddNewGood(good);
            Assert.AreEqual(true, rtn.Item1);
            Assert.AreEqual("", rtn.Item2);
        }

        [TestMethod]
        public void AddNewGood_RightCount()
        {
            GoodsManager gm = new GoodsManager();
            Good good = new Good("A", 5);

            Tuple<bool, string> rtn = gm.AddNewGood(good);
            Assert.AreEqual(1, gm.GetNumberOfGoods());
            Assert.AreEqual(0, gm.GetNumberOfGoodsInOffer());
        }

        [TestMethod]
        public void AddNewGood_RightOfferCount()
        {
            GoodsManager gm = new GoodsManager();
            Good good = new Good("A", 5, 2, 7);

            Tuple<bool, string> rtn = gm.AddNewGood(good);
            Assert.AreEqual(1, gm.GetNumberOfGoods());
            Assert.AreEqual(1, gm.GetNumberOfGoodsInOffer());
        }

        [TestMethod]
        public void AddNewGood_Search()
        {
            GoodsManager gm = new GoodsManager();

            Good good1 = new Good("A", 5, 2, 7);
            Tuple<bool, string> rtn = gm.AddNewGood(good1);
            Good good2 = new Good("B", 5, 2, 7);
            Tuple<bool, string> rtn2 = gm.AddNewGood(good2);

            Assert.AreEqual(good1, gm.SearchAGood("A"));
        }

        [TestMethod]
        public void Good_SaveAndRead()
        {
            GoodsManager gm = new GoodsManager();

            Good good1 = new Good("A", 5, 2, 7);
            Tuple<bool, string> rtn = gm.AddNewGood(good1);
            Good good2 = new Good("B", 5, 2, 7);
            Tuple<bool, string> rtn2 = gm.AddNewGood(good2);

            string localPath = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string filename = Path.Combine(localPath, "Goods.json");

            GoodsRepository repo = new GoodsRepository();
            bool rtnSave = repo.SaveGoods(filename, gm.Goods);
            Assert.AreEqual(true, rtnSave);

            GoodsManager gm1 = new GoodsManager();
            gm1.Goods = repo.ReadGoods(filename);
            Assert.AreEqual(2, gm1.GetNumberOfGoods());

            Good g1 = gm1.SearchAGood("A");
            Assert.AreEqual(good1.Item, g1.Item);
            Assert.AreEqual(good1.OfferItemNumber, g1.OfferItemNumber);
            Assert.AreEqual(good1.OfferPrice, g1.OfferPrice);
            Assert.AreEqual(good1.Price, g1.Price);
        }
    }
}
