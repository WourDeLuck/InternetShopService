using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternetShopService.ProductComponents;


namespace InternetShopService.ProductControl
{
    /// <summary>
    /// Allows to perform common manipulations with products (such as adding, deleting, renaming, etc.)
    /// </summary>
    public class ProductController : IProductController
    {
        /// <summary>
        /// Returns a product by its ID.
        /// </summary>
        /// <param name="id">Product id.</param>
        /// <returns>Product in storage.</returns>
        public Product GetProductByID(int id)
        {
            return Storage.products[id];
        }

        /// <summary>
        /// Adds product to the product storage.
        /// </summary>
        /// <param name="product">A product to register</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void AddProduct(Product product, int id)
        {
            if (product == null)
                throw new ArgumentNullException("Cannot add an empty product");

            ValidatorClass.CheckIdInStorage(id);
            ValidatorClass.ProductValidator(product);

            Storage.products.Add(id, product);
        }

        /// <summary>
        /// Deletes an item from the product storage.
        /// </summary>
        /// <param name="id">Product's key.</param>
        public void DeleteProduct(int id)
        {
            ValidatorClass.CheckProductById(id);

            Storage.products.Remove(id);                
        }

        /// <summary>
        /// Renames a product.
        /// </summary>
        /// <param name="id">Product's key.</param>
        /// <param name="newName">New name for a product.</param>
        public void RenameProduct(int id, string newName)
        {
            ValidatorClass.CheckProductById(id);
            ValidatorClass.StringValidator(newName);

            Storage.products[id].Name = newName;
        }

        /// <summary>
        /// Changes the price of a specific item in the product storage.
        /// </summary>
        /// <param name="id">Product's key.</param>
        /// <param name="price">Product's new price.</param>
        public void ChangePrice(int id, decimal newPrice)
        {
            ValidatorClass.CheckProductById(id);
            ValidatorClass.PriceValidator(newPrice);

            Storage.products[id].Price = newPrice;
        }

    }
}
