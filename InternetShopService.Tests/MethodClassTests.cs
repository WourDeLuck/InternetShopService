using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InternetShopService.ProductComponents;
using InternetShopService.ProductControl;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InternetShopService.Tests
{
    [TestClass]
    public class MethodClassTests
    {
        SolidProduct _sp;
        GasProduct _gp;
        LiquidProduct _lp;

        [TestInitialize]
        public void Initialize()
        {
            _sp = new SolidProduct("The Twisted Ones", "Book", 9.99m, 150);
            _gp = new GasProduct("Helium", "Other", 15.99m, 200);
            _lp = new LiquidProduct("Pepsi", "Drinks", 0.99m, 200);
        }

        [TestMethod]
        public void SolidProduct_AddQtyTest()
        {
            _sp.AddQty(200);

            Assert.AreEqual(350, _sp.Count);
        }

        [TestMethod]
        public void SolidProduct_SubstractQtyTest()
        {
            _sp.SubstractQty(100);

            Assert.AreEqual(50, _sp.Count);
        }

        [TestMethod]
        public void GasProduct_AddQty()
        {
            _gp.AddQty(20.99);

            Assert.AreEqual(220.99, _gp.Volume);
        }

        [TestMethod]
        public void GasProduct_SubstractQty()
        {
            _gp.SubstractQty(12.566);

            Assert.AreEqual(187.434, _gp.Volume);
        }

        [TestMethod]
        public void LiquidProduct_AddQty()
        {
            _lp.AddQty(34.66);

            Assert.AreEqual(234.66, _lp.Weight);
        }

        [TestMethod]
        public void LiquidProduct_SubstractQty()
        {
            _lp.SubstractQty(123.44);

            Assert.AreEqual(76.56, _lp.Weight);
        }
    }
}
