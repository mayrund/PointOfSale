using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PointOfSale.Terminal.Calculators;
using PointOfSale.Terminal.Interfaces;
using PointOfSale.Terminal.Models;

namespace PointOfSale.Terminal.Builders
{
    /// <summary>
    /// This class is responsible for building a product list including unit prices and volume prices.
    /// </summary>
    public class ProductsBuilder : IProductsBuilder
    {
        private readonly List<Product> products = new List<Product>();

        /// <summary>
        /// This method adds a product with a unit price.
        /// </summary>
        /// <param name="productCode">Product code</param>
        /// <param name="unitPrice">Price per unit</param>
        public void AddProduct(string productCode, decimal unitPrice)
        {
            this.DoAddProduct(productCode, new SingleUnitPriceCalculator(unitPrice));
        }
        /// <summary>
        /// This method adds a product with a unit price and a volume price.
        /// </summary>
        /// <param name="productCode">Product code</param>
        /// <param name="unitPrice">Price per unit</param>
        /// <param name="volumeSize">Size of the volume</param>
        /// <param name="volumePrice">Price of volume</param>
        public void AddProduct(string productCode, decimal unitPrice, int volumeSize, decimal volumePrice)
        {
            this.DoAddProduct(productCode, new VolumePriceCalculator(unitPrice, volumeSize, volumePrice));
        }

        /// <summary>
        /// Retrieves all products added.
        /// </summary>
        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }

        private void DoAddProduct(string productCode, IPriceCalculator priceCalculator)
        {
            products.Add(new Product(productCode, priceCalculator));
        }
    }
}
