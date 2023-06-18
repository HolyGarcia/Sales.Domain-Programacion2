
using System;

namespace Sales.Infrastructure.Exceptions
{
    public class UsuarioException : Exception
    {
        public UsuarioException(string message) : base(message)
        {
            
        }
    }
}
