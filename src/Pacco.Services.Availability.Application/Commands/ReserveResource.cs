using Convey.CQRS.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pacco.Services.Availability.Application.Commands
{
    public class ReserveResource: ICommand
    {
        public Guid ResourceId { get;}
        public DateTime DateTime { get;}
        public int Priority { get; set; }

        public ReserveResource(Guid resourceId, DateTime dateTime, int priority)
        {
            ResourceId = resourceId;
            DateTime = dateTime;
            Priority = priority;
        }
    }
}
