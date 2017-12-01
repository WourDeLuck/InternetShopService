using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InternetShopService.ProductComponents
{
    /// <summary>
    /// Common class for all products defined in the service.
    /// </summary>
    public abstract class Product
    {
        // Name of a product stored in string.
        private string _name;

        // Category of a product stored in string.
        // No need to make a list of categories.
        private string _category;

        // Price of a product stored in decimal.
        // Decimal allows to perform accurate calculations over financial deals.
        private decimal _price;

        // Encapsulated fields
        public string Name { get => _name; set => _name = value; }
        public string Category { get => _category; set => _category = value; }
        public decimal Price { get => _price; set => _price = value; }

        // Product constructor
        public Product(string name, string category, decimal price)
        {
            Name = name;
            Category = category;
            Price = price;
        }

        /// <summary>
        /// Abstract method for adding items to common amount.
        /// </summary>
        /// <param name="val">Value to add.</param>
        public abstract void AddQty(object val);

        /// <summary>
        /// Abstract method for substracting items from common amount.
        /// </summary>
        /// <param name="val">Value to substract.</param>
        public abstract void SubstractQty(object val);
    }
}
