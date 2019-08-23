using System;
using System.Collections.Generic;
using System.Text;

namespace PointOfSale.Terminal.Interfaces
{
    public interface IPriceCalculator
    {
        decimal CalculatePrice(int itemsCount);
    }
}
