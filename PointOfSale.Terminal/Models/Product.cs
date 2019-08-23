using PointOfSale.Terminal.Interfaces;

namespace PointOfSale.Terminal.Models
{
    /// <summary>
    /// Represents a Product with a ProductCode and UnitPrice
    /// Each product can be configured differently.
    /// </summary>
    public class Product
    {
        public Product(string productCode, IPriceCalculator priceCalculator)
        {
            this.ProductCode = productCode;
            this.PriceCalculator = priceCalculator;
        }
        public IPriceCalculator PriceCalculator { get; private set; }
        public string ProductCode { get; private set; }

    }
}
