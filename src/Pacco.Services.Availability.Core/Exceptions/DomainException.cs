using System;
using System.Collections.Generic;
using System.Text;

namespace Pacco.Services.Availability.Core.Exceptions
{
    public class DomainException: Exception
    {
        public virtual string Code { get; }

        public DomainException(string message) : base(message)
        {
        }
    }
}
