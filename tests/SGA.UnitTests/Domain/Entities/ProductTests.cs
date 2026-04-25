using Xunit;
using FluentAssertions;
using SGA.Domain.Entities;
using SGA.Domain.Exceptions;
using System;

namespace SGA.UnitTests.Domain.Entities
{
    public class ProductTests
    {
        [Fact]
        public void CreateProduct_WithEmptyName_ShouldThrowDomainException()
        {
            // Preparación
            string invalidName = "";
            int costo = 1000;
            int venta = 1500;
            string sku = "101";
            Guid impuestoId = Guid.NewGuid();

            // Acción
            Action act = () => new Product(invalidName, costo, venta, sku, impuestoId, MeasureUnit.Unit);

            // Verificación
            act.Should().Throw<DomainException>()
                .WithMessage("El nombre del producto no puede estar vacío.");
        }

        [Fact]
        public void CreateProduct_WithNegativeCost_ShouldThrowDomainException()
        {
            // Preparación
            string name = "Carne Molida";
            int invalidCosto = -10;
            int venta = 1500;
            string sku = "101";
            Guid impuestoId = Guid.NewGuid();

            // Acción
            Action act = () => new Product(name, invalidCosto, venta, sku, impuestoId, MeasureUnit.Unit);

            // Verificación
            act.Should().Throw<DomainException>()
                .WithMessage("El precio de costo no puede ser negativo.");
        }

        [Fact]
        public void CreateProduct_WithNegativeSalePrice_ShouldThrowDomainException()
        {
            // Preparación
            string name = "Carne Molida";
            int costo = 1000;
            int invalidVenta = -5;
            string sku = "101";
            Guid impuestoId = Guid.NewGuid();

            // Acción
            Action act = () => new Product(name, costo, invalidVenta, sku, impuestoId, MeasureUnit.Unit);

            // Verificación
            act.Should().Throw<DomainException>()
                .WithMessage("El precio de venta no puede ser negativo.");
        }

        [Fact]
        public void CreateProduct_WithSalePriceLowerThanCost_ShouldThrowDomainException()
        {
            // Preparación
            string name = "Carne Molida";
            int costo = 1000;
            int lowVenta = 800; // Menor que o custo
            string sku = "101";
            Guid impuestoId = Guid.NewGuid();

            // Acción
            Action act = () => new Product(name, costo, lowVenta, sku, impuestoId, MeasureUnit.Unit);

            // Verificación
            act.Should().Throw<DomainException>()
                .WithMessage("El precio de venta no puede ser menor que el precio de costo.");
        }

        [Fact]
        public void CreateProduct_WithEmptySku_ShouldThrowDomainException()
        {
            // Preparación
            string name = "Carne Molida";
            int costo = 1000;
            int venta = 1500;
            string invalidSku = "";
            Guid impuestoId = Guid.NewGuid();

            // Acción
            Action act = () => new Product(name, costo, venta, invalidSku, impuestoId, MeasureUnit.Unit);

            // Verificación
            act.Should().Throw<DomainException>()
                .WithMessage("El código SKU del producto no puede estar vacío.");
        }

        [Fact]
        public void CreateProduct_ShouldGenerateUniqueId()
        {
            // Preparación
            string name = "Carne Molida";
            int costo = 1000;
            int venta = 1500;
            string sku = "101";
            Guid impuestoId = Guid.NewGuid();

            // Acción
            var product = new Product(name, costo, venta, sku, impuestoId, MeasureUnit.Unit);

            // Verificación
            product.Id.Should().NotBeEmpty();
        }

        [Fact]
        public void CreateProduct_WithMeasureUnit_ShouldAssignCorrectly()
        {
            // Preparación
            string name = "Carne Molida";
            int costo = 1000;
            int venta = 1500;
            string sku = "101";
            Guid impuestoId = Guid.NewGuid();

            // Acción
            var productKilo = new Product(name, costo, venta, sku, impuestoId, MeasureUnit.Kilo);
            var productUnit = new Product(name, costo, venta, sku, impuestoId, MeasureUnit.Unit);

            // Verificación
            productKilo.UnidadMedida.Should().Be(MeasureUnit.Kilo);
            productUnit.UnidadMedida.Should().Be(MeasureUnit.Unit);
        }
    }
}
