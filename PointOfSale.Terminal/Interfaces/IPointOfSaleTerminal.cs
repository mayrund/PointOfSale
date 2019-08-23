using System;
using System.Collections.Generic;
using System.Text;
using PointOfSale.Terminal.Models;

namespace PointOfSale.Terminal.Interfaces
{
    public interface IPointOfSaleTerminal
    {
        void BeginNewTransaction();
        void SetPricing(IEnumerable<Product> products);
        decimal CalculateTotal();
        IPointOfSaleTerminal Scan(string productCode);
    }
}
