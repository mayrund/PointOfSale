using PointOfSale.Terminal.Interfaces;

namespace PointOfSale.Terminal
{
    /// <summary>
    /// This class's purpose is to keep track of how many units from each product we have scanned.
    /// </summary>
    public class ProductUnitCounter
    {
        private readonly IPriceCalculator priceCalculator;
        private int itemsCount = 0;

        public ProductUnitCounter(IPriceCalculator priceCalculator)
        {
            this.priceCalculator = priceCalculator;
        }
        
        /// <summary>
        /// Increases the quantity for the product by one.
        /// </summary>
        public void AddItem()
        {
            this.itemsCount++;
        }

        /// <summary>
        /// Use the price calculator specified to get the total price.
        /// </summary>
        /// <returns></returns>
        public decimal GetTotalPrice()
        {
            return priceCalculator.CalculatePrice(itemsCount);
        }

        /// <summary>
        /// Resets count of items for the product to zero.
        /// </summary>
        public void ResetItemCount() { this.itemsCount = 0; }
    }
}
