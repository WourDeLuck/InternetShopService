using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternetShopService.ProductComponents;
using InternetShopService.ProductControl;

namespace InternetShopService
{
    /// <summary>
    /// Quite simple cart manager class.
    /// Contains basic actions to perform on Cart.
    /// </summary>
    public class CartManager
    {
        /// <summary>
        /// Adds a product to the cart.
        /// </summary>
        /// <param name="product">Product to add.</param>
        /// <param name="count">Amount of product to add.</param>
        public void AddToCart<T>(int id, T value) where T: Product
        {
            if (Storage.products.ContainsValue(value))
                Storage.cart.Add(id, value);
            else
                throw new ArgumentException("Product wasn't found in the storage");
        }

        /// <summary>
        /// Deletes product from the cart.
        /// </summary>
        /// <param name="product">Product to delete.</param>
        public void DeleteFromCart(int id)
        {
            try
            {
                ValidatorClass.CheckProductById(id);
            }
            catch (KeyNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }

            Storage.cart.Remove(id);
        }
    }
}
