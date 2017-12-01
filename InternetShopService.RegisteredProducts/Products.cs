using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InternetShopService.ProductComponents;


namespace InternetShopService.ProductComponents
{
    public static class Storage
    {
        // A simple storage for products.
        // Dictionary helps to enumerate every element that was added to this storage.
        public static Dictionary<int, Product> products = new Dictionary<int, Product>();

        // A simple storage for cart.
        public static Dictionary<int, Product> cart = new Dictionary<int, Product>();
    }
}
