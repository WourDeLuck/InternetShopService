using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InternetShopService.ProductComponents;
using InternetShopService.ProductControl;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InternetShopService.Tests
{
    [TestClass]
    public class ValidatorClassTest
    {
        [TestInitialize]
        public void Initialize()
        {
            Storage.products = new Dictionary<int, Product>()
            {
                {1, new SolidProduct("Foxy", "Toys & Collectibles", 12.99m, 200)},
                {2, new LiquidProduct("Pepsi", "Drinks", 0.99m, 200) },
                {3, new GasProduct("Helium", "Other", 15.99m, 200) },
                {4, new SolidProduct("Pillows", "Home products", 4.99m, 350) }
            };
        }

        [TestMethod]
        [DataRow("d")]
        [DataRow("d4")]
        [DataRow("")]
        [ExpectedException(typeof(ArgumentException))]
        public void StringValidator_FailTest(string str)
        {
            ValidatorClass.StringValidator(str);
        }

        [TestMethod]
        [DataRow("GdshHHyen34")]
        [DataRow("Normal name 1")]
        [DataRow("Normal name 1 but longer")]
        public void StringValidator_Test(string str)
        {
            ValidatorClass.StringValidator(str);
        }

        [TestMethod]
        public void PriceValidator_Test()
        {
            ValidatorClass.PriceValidator(213.233m);
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void PriceValidator_FailTest()
        {
            ValidatorClass.PriceValidator(-2.99m);
        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(2)]
        [DataRow(3)]
        [DataRow(4)]
        public void CheckById_Test(int id)
        {
            ValidatorClass.CheckProductById(id);

            Assert.IsNotNull(Storage.products[id].Name);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void CheckById_FailTest()
        {
            ValidatorClass.CheckProductById(67);
        }

        [TestMethod]
        public void CheckId_Test()
        {
            ValidatorClass.CheckIdInStorage(5);
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void CheckId_FailTest()
        {
            ValidatorClass.CheckIdInStorage(1);
        }

        [TestMethod]
        public void CheckProduct_Test()
        {
            SolidProduct _pr = new SolidProduct("The Twisted Ones", "Book", 9.99m, 150);

            ValidatorClass.ProductValidator(_pr);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CheckProduct_FailTest()
        {
            LiquidProduct _pr = new LiquidProduct("0", "Smth", 10.99m, 1);

            ValidatorClass.ProductValidator(_pr);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CheckProduct_NullTest()
        {
            ValidatorClass.ProductValidator(null);
        }
    }
}
