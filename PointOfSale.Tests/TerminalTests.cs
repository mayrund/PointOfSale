using NUnit.Framework;
using System;
using System.Collections.Generic;
using PointOfSale.Terminal;
using PointOfSale.Terminal.Builders;
using PointOfSale.Terminal.Interfaces;
using PointOfSale.Terminal.Models;

namespace PointOfSale.Tests
{
    public class TerminalTests
    {
        private SimplePointOfSaleTerminal pointOfSaleTerminal;
        [SetUp]
        public void Setup()
        {
            pointOfSaleTerminal = new SimplePointOfSaleTerminal();
            pointOfSaleTerminal.SetPricing(SetupProducts().GetAllProducts());
        }

        /// <summary>
        /// -- A - $1.25 for each unit or $3.00 for 3 units
        /// -- B - $4.25 for each unit
        /// -- C - $1.00 for each unit or $5.00 for 6 units
        /// -- D - $0.75 for each unit
        /// </summary>
        private ProductsBuilder SetupProducts()
        {
            var productsBuilder = new ProductsBuilder();
            productsBuilder.AddProduct("A", 1.25m, 3, 3);
            productsBuilder.AddProduct("B", 4.25m);
            productsBuilder.AddProduct("C", 1.0m, 6, 5);
            productsBuilder.AddProduct("D", 0.75m);
            return productsBuilder;
        }

        [Test]
        public void ScanProducts_TestCorrectTotalValue()
        {
            // ABCDABA;
            pointOfSaleTerminal.Scan("A").Scan("B").Scan("C").Scan("D").Scan("A").Scan("B").Scan("A");
            Assert.AreEqual(13.25, pointOfSaleTerminal.CalculateTotal());

            // CCCCCCC;
            pointOfSaleTerminal.BeginNewTransaction();
            for (int i = 0; i < 7; i++)
            {
                pointOfSaleTerminal.Scan("C");
            }
            Assert.AreEqual(6.0, pointOfSaleTerminal.CalculateTotal());

            // ABCD
            pointOfSaleTerminal.BeginNewTransaction();
            pointOfSaleTerminal.Scan("A").Scan("B").Scan("C").Scan("D");
            Assert.AreEqual(7.25, pointOfSaleTerminal.CalculateTotal());

            // ADBDC
            pointOfSaleTerminal.BeginNewTransaction();
            pointOfSaleTerminal.Scan("A").Scan("D").Scan("B").Scan("D").Scan("C");
            Assert.AreEqual(8, pointOfSaleTerminal.CalculateTotal());

            // A x 3 ($3)
            // B x 1 ($4.25)
            // C x 6 ($5)
            // D x 1 ($0.75)
            pointOfSaleTerminal.BeginNewTransaction();
            pointOfSaleTerminal.Scan("A").Scan("B").Scan("A").Scan("A").Scan("C").Scan("C").Scan("C").Scan("C").Scan("C").Scan("D").Scan("C");
            Assert.AreEqual(13, pointOfSaleTerminal.CalculateTotal());

            // BDBA
            pointOfSaleTerminal.BeginNewTransaction();
            pointOfSaleTerminal.Scan("B").Scan("D").Scan("B").Scan("A");
            Assert.AreEqual(10.5, pointOfSaleTerminal.CalculateTotal());
        }
    }
}