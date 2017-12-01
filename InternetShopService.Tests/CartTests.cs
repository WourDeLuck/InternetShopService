using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using InternetShopService.ProductComponents;
using InternetShopService.ProductControl;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace InternetShopService.Tests
{
    [TestClass]
    public class CartTests
    {
        ProductController pc = new ProductController();
        CartManager cm = new CartManager();

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
        public void AddToCart_Test()
        {
            var pr = pc.GetProductByID(3);
            cm.AddToCart(1, pr);

            Assert.IsNotNull(cm);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddToCart_NoProductTest()
        {
            SolidProduct pr = new SolidProduct("The Twisted Ones", "Book", 9.99m, 150);
            cm.AddToCart(1, pr);
        }

        [TestMethod]
        public void DeleteFromCart_Test()
        {
            Storage.cart = new Dictionary<int, Product>()
            {
                {1, new SolidProduct ("Foxy", "Toys & Collectibles", 12.99m, 200)},
                {2, new LiquidProduct("Pepsi", "Drinks", 0.99m, 200) }
            };

            cm.DeleteFromCart(2);

            Assert.IsFalse(Storage.cart.ContainsKey(2));
        }
    }
}
