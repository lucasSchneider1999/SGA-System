using System;
using SGA.Domain.Exceptions;

namespace SGA.Domain.Entities
{
    public class Product
    {
        public Guid Id { get; private set; }
        public string Nombre { get; private set; }
        public int PrecioCosto { get; private set; }
        public int PrecioVenta { get; private set; }
        public string Sku { get; private set; }
        public Guid ImpuestoId { get; private set; }
        public MeasureUnit UnidadMedida { get; private set; }

        public Product(string nombre, int precioCosto, int precioVenta, string sku, Guid impuestoId, MeasureUnit unidadMedida)
        {
            // Validación del nombre
            if (string.IsNullOrWhiteSpace(nombre))
            {
                throw new DomainException("El nombre del producto no puede estar vacío.");
            }

            // Validación del precio de costo
            if (precioCosto < 0)
            {
                throw new DomainException("El precio de costo no puede ser negativo.");
            }

            // Validación del precio de venta
            if (precioVenta < 0)
            {
                throw new DomainException("El precio de venta no puede ser negativo.");
            }

            // Validación de margen negativa
            if (precioVenta < precioCosto)
            {
                throw new DomainException("El precio de venta no puede ser menor que el precio de costo.");
            }

            // Validación del SKU
            if (string.IsNullOrWhiteSpace(sku))
            {
                throw new DomainException("El código SKU del producto no puede estar vacío.");
            }

            Id = Guid.NewGuid();
            Nombre = nombre;
            PrecioCosto = precioCosto;
            PrecioVenta = precioVenta;
            Sku = sku;
            ImpuestoId = impuestoId;
            UnidadMedida = unidadMedida;
        }
    }
}
