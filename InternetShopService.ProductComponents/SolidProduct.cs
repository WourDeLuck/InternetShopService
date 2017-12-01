using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetShopService.ProductComponents
{
    /// <summary>
    /// Native class for solid products (ex. books).
    /// </summary>
    public class SolidProduct : Product
    {
        // Common amount of solid products stored in uint.
        // Uint allows to store the qty of products using only positive values, so we couldn't get negative amount of product.
        private int _count;

        // Encapsulated field.
        public int Count { get => _count; set => _count = value; }
        

        // Solid product constructor
        public SolidProduct(string name, string category, decimal price, int count) 
            :base(name,category,price)
        {
            Count = count;
        }

        /// <summary>
        /// Method override for solid product.
        /// Adds some items to common amount of products.
        /// </summary>
        /// <param name="val">Value to add.</param>
        public override void AddQty(object val)
        {
            int ct = Convert.ToInt32(val);

            Count = Count + ct;
        }

        /// <summary>
        /// Method override for solid product.
        /// Substracts some items from common amount of products.
        /// </summary>
        /// <param name="val">Value to substract.</param>
        public override void SubstractQty(object val)
        {
            int ct = Convert.ToInt32(val);

            Count = Count - ct;
        }
    }
}
