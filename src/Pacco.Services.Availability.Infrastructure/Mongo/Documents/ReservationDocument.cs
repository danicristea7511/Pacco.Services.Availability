using System;

namespace Pacco.Services.Availability.Infrastructure.Mongo.Documents
{
    public sealed class ReservationDocument
    {
        public int TimeStamp { get; set; }
        public int Priority { get; set; }
    }
}
