using PointOfSale.Terminal.Interfaces;

namespace PointOfSale.Terminal.Calculators
{
    /// <summary>
    /// Price calculator for products bought in single units without volume pricing.
    /// </summary>
    public class SingleUnitPriceCalculator : IPriceCalculator
    {
        public readonly decimal unitPrice;
        public SingleUnitPriceCalculator(decimal unitPrice)
        {
            this.unitPrice = unitPrice;
        }

        public decimal CalculatePrice(int itemsCount)
        {
            return itemsCount * unitPrice;
        }
    }
}
