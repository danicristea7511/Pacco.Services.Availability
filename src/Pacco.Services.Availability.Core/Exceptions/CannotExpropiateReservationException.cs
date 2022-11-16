using System;

namespace Pacco.Services.Availability.Core.Exceptions
{
    public class CannotExpropiateReservationException : DomainException
    {
        public Guid ResourceId { get; }
        public DateTime DateTime { get; }
        public CannotExpropiateReservationException(Guid resourceId, DateTime dateTime) : 
            base($"Cannot expropiate the  resource with ID: '{resourceId}' reservation at: {dateTime.Date}")
        {
            ResourceId = resourceId;
            DateTime = dateTime;
        }
    }
}
