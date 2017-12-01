using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetShopService.ProductComponents
{
    /// <summary>
    /// Native class for gas products (ex. gas balloon).
    /// </summary>
    public class GasProduct : Product
    {
        // Available volume of gas product stored in double.
        private double _volume;
        
        // Encapsulated field
        public double Volume { get => _volume; set => _volume = value; }

        // GasProduct constructor with a reference to base class' constructor.
        public GasProduct(string name, string category, decimal price, double volume)
            :base(name,category,price)
        {
            Volume = volume;
        }

        /// <summary>
        /// Method override for gas products.
        /// Add some volume to the common one.
        /// </summary>
        /// <param name="val">Value to add.</param>
        public override void AddQty(object val)
        {
            double vl = Convert.ToDouble(val);

            Volume = Volume + vl;
        }

        /// <summary>
        /// Method override for gas products.
        /// Substract some volume from the common one.
        /// </summary>
        /// <param name="val">Value to substract.</param>
        public override void SubstractQty(object val)
        {
            double vl = Convert.ToDouble(val);

            Volume = Volume - vl;
        }
    }
    
}
