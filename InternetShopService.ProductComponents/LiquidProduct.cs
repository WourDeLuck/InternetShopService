using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetShopService.ProductComponents
{
    /// <summary>
    /// Native class for Liquid products (ex. drinks).
    /// </summary>
    public class LiquidProduct : Product
    {
        // Available amount of weight of liquid product
        private double _weight;

        // Encapsulated field
        public double Weight { get => _weight; set => _weight = value; }

        // LiquidProduct constructor with a reference to base class' constructor.
        public LiquidProduct(string name, string category, decimal price, double weight)
            :base(name,category,price)
        {
            Weight = weight;
        }

        /// <summary>
        /// Method override for some 
        /// </summary>
        /// <param name="val">Value to add.</param>
        public override void AddQty(object val)
        {
            double wt = Convert.ToDouble(val);

            Weight = Weight + wt;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="val">Value to substract.</param>
        public override void SubstractQty(object val)
        {
            double wt = Convert.ToDouble(val);

            Weight = Weight - wt;
        }
    }
}
