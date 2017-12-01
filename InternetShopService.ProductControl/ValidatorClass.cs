using InternetShopService.ProductComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace InternetShopService.ProductControl
{
    /// <summary>
    /// Simple validator class.
    /// Allows to check data if it valid to store.
    /// Includes validation of strings (name or category), price, id, etc.
    /// </summary>
    public static class ValidatorClass
    {
        /// <summary>
        /// Checks if current id exists in the storage.
        /// </summary>
        /// <param name="id">Product's id.</param>
        /// <exception cref="KeyNotFoundException">Throws exception if id wasn't found in the storage.</exception>
        public static void CheckProductById(int id)
        {
            if (!Storage.products.ContainsKey(id))
                throw new KeyNotFoundException("The key wasn't found in the storage");
        }

        /// <summary>
        /// Checks if string is valid (string is longer than 3 or not null/empty)
        /// </summary>
        /// <param name="str">Product's name or category</param>
        /// <exception cref="ArgumentException">Throws exception if string length is less than the minimim value.</exception>
        public static void StringValidator(string str)
        {
            int minimumLength = 3;

            if (str.Length < minimumLength)
                throw new ArgumentException("Data length is too short.");
        }

        /// <summary>
        /// Checks if product's price value is positive.
        /// </summary>
        /// <param name="price">Product's price.</param>
        /// <exception cref="ValidationException">Throws exception if price is less than 0.</exception>
        public static void PriceValidator(decimal price)
        {
            if (price < 0)
                throw new ValidationException("Incorrect price.");
        }

        /// <summary>
        /// Checks if id is busy.
        /// </summary>
        /// <param name="id">Product's id.</param>
        /// <exception cref="ValidationException">Throws exception if key exists in the storage.</exception>
        public static void CheckIdInStorage(int id)
        {
            if (Storage.products.ContainsKey(id))
                throw new ValidationException("The key exists in the storage");
        }

        /// <summary>
        /// Checks the whole product.
        /// </summary>
        /// <param name="product">Product to check.</param>
        /// <exception cref="ArgumentNullException">Throws exception if the product is null.</exception>
        public static void ProductValidator(Product product)
        {
            if (product == null)
                throw new ArgumentNullException("Cannot use an empty product {0}");

            StringValidator(product.Name);
            StringValidator(product.Category);
            PriceValidator(product.Price);
        }
    }
}
