using System;
using System.Collections.Generic;
using System.Text;
using PointOfSale.Terminal.Models;

namespace PointOfSale.Terminal.Interfaces
{
    public interface IProductsBuilder
    {
        void AddProduct(string productCode, decimal unitPrice);
        void AddProduct(string productCode, decimal unitPrice, int volumeSize, decimal volumePrice);
        IEnumerable<Product> GetAllProducts();

    }
}
