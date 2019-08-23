using System;
using System.Collections.Generic;
using System.Linq;
using PointOfSale.Terminal.Extensions;
using PointOfSale.Terminal.Interfaces;
using PointOfSale.Terminal.Models;

namespace PointOfSale.Terminal
{
    public class SimplePointOfSaleTerminal : IPointOfSaleTerminal
    {
        private Dictionary<string, ProductUnitCounter> products;
        public SimplePointOfSaleTerminal()
        {
        }

        /// <summary>
        /// Calculate the total price for the items scanned.
        /// </summary>
        public decimal CalculateTotal()
        {
            return products.Aggregate(0.0M, (x, p) => x + p.Value.GetTotalPrice());
        }

        /// <summary>
        /// Scan a product. Please make sure the product is added using the product builder.
        /// </summary>
        /// <param name="productCode">Product code</param>
        public IPointOfSaleTerminal Scan(string productCode)
        {
            if (products.ContainsKey(productCode))
                products[productCode].AddItem();
            return this;
        }

        /// <summary>
        /// Sets the pricing for products.
        /// </summary>
        /// <param name="products">List of products</param>
        public void SetPricing(IEnumerable<Product> products)
        {
            this.products = products.ToDictionary(p => p.ProductCode, p => new ProductUnitCounter(p.PriceCalculator));
        }

        /// <summary>
        /// Starts a new transaction and reset the items count for the product list.
        /// </summary>
        public void BeginNewTransaction()
        {
            products.ForEach(p => p.Value.ResetItemCount());
        }
    }
}
