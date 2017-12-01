using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternetShopService.ProductComponents;

namespace InternetShopService.ProductControl
{
    /// <summary>
    /// Simple interface for product control.
    /// Includes adding, renaming, deleting, etc.
    /// </summary>
    public interface IProductController
    {
        /// <summary>
        /// Get product by its id.
        /// </summary>
        /// <param name="id">Id to find product by.</param>
        /// <returns>Product.</returns>
        Product GetProductByID(int id);

        /// <summary>
        /// Adds a product to storage.
        /// </summary>
        /// <param name="product">Product to add.</param>
        /// <param name="id">Product's id.</param>
        void AddProduct(Product product, int id);

        /// <summary>
        /// Deletes a product by its id.
        /// </summary>
        /// <param name="id">Product's id.</param>
        void DeleteProduct(int id);
        
        /// <summary>
        /// Renames a product by its id.
        /// </summary>
        /// <param name="id">Product's id.</param>
        /// <param name="newName">New name for the product.</param>
        void RenameProduct(int id, string newName);

        /// <summary>
        /// Changes price of the product.
        /// </summary>
        /// <param name="id">Product's id.</param>
        /// <param name="newPrice">New price of the product.</param>
        void ChangePrice(int id, decimal newPrice);
    }
}
