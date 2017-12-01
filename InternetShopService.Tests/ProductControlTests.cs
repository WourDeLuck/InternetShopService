using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InternetShopService.ProductComponents;
using InternetShopService.ProductControl;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InternetShopService.Tests
{
    [TestClass]
    public class ProductControlTests
    {
        SolidProduct _pr;
        ProductController _contr = new ProductController();

        [TestInitialize]
        public void Initialize()
        {
            _pr = new SolidProduct("The Twisted Ones", "Book", 9.99m, 150);

            Storage.products = new Dictionary<int, Product>()
            {
                {1, new SolidProduct("Foxy", "Toys & Collectibles", 12.99m, 200)},
                {2, new LiquidProduct("Pepsi", "Drinks", 0.99m, 200) },
                {3, new GasProduct("Helium", "Other", 15.99m, 200) },
                {4, new SolidProduct("Pillows", "Home products", 4.99m, 350) }
            };
        }

        [TestMethod]
        public void Add_Test()
        {
            _contr.AddProduct(_pr, 5);

            Assert.IsTrue(Storage.products.ContainsKey(5));
            Assert.AreEqual(Storage.products[5].Name, "The Twisted Ones");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Add_NullTest()
        {
            _contr.AddProduct(null, 5);
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void Add_ExistingKeyTest()
        {
            _contr.AddProduct(_pr, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void Delete_KeyNotFoundTest()
        {
            _contr.DeleteProduct(5);
        }

        [TestMethod]
        public void Delete_Test()
        {
            _contr.DeleteProduct(3);

            Assert.IsFalse(Storage.products.ContainsKey(3));
        }

        [TestMethod]
        public void Rename_Test()
        {
            _contr.RenameProduct(1, "Foxy Plush");

            Assert.IsNotNull(Storage.products[1].Name);
            Assert.AreNotEqual("Foxy", Storage.products[1].Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Rename_IncorrectStringTest()
        {
            _contr.RenameProduct(1, "");
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void Rename_KeyNotFoundTest()
        {
            _contr.RenameProduct(356, "Sheep");
        }

        [TestMethod]
        public void ChangePrice_Test()
        {
            _contr.ChangePrice(2, 2.99m);

            Assert.IsNotNull(Storage.products[2].Price);
            Assert.AreEqual(2.99m, Storage.products[2].Price);
        }

        [TestMethod]
        [ExpectedException(typeof(ValidationException))]
        public void ChangePrice_IncorrectPrice()
        {
            _contr.ChangePrice(2, -6.99m);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void ChangePrice_KeyNotFoundTest()
        {
            _contr.ChangePrice(50, 5.99m);
        }
    }
}
