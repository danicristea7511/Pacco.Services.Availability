using System;

namespace Pacco.Services.Availability.Core.Exceptions
{
    public class InvalidAgregateIdException : DomainException
    {
        public Guid Id { get; }

        public InvalidAgregateIdException(Guid id) : base($"Invalid agregate id: '{id}' ")
        {
            Id = id;
        }
        
    }
}
