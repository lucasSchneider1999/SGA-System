using System;

namespace SGA.Domain.Exceptions
{
    /// <summary>
    /// Excepción base para todas las violaciones de reglas de negocio en el dominio.
    /// </summary>
    public class DomainException : Exception
    {
        public DomainException(string message) : base(message)
        {
        }
    }
}
