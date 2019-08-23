using PointOfSale.Terminal.Interfaces;
using PointOfSale.Terminal.Models;

namespace PointOfSale.Terminal.Calculators
{
    /// <summary>
    /// Price calculator for products ordered with volume pricing.
    /// </summary>
    public class VolumePriceCalculator : IPriceCalculator
    {
        private readonly IPriceCalculator singleUnitPriceCalculator;
        private readonly int volumeSize;
        private readonly decimal volumePrice;

        public VolumePriceCalculator(decimal unitPrice, int volumeSize, decimal volumePrice)
        {
            this.singleUnitPriceCalculator = new SingleUnitPriceCalculator(unitPrice);
            this.volumeSize = volumeSize;
            this.volumePrice = volumePrice;
        }

        public decimal CalculatePrice(int itemsCount)
        {
            return (itemsCount / volumeSize) * volumePrice + singleUnitPriceCalculator.CalculatePrice(itemsCount % volumeSize);
        }
    }
}
