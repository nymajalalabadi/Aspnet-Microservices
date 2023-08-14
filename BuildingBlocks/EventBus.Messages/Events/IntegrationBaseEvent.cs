using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Messages.Events
{
    public class IntegrationBaseEvent
    {
        public IntegrationBaseEvent()
        {
            Id = Guid.NewGuid();
            CreateTime = DateTime.UtcNow;
        }

        public IntegrationBaseEvent(Guid id, DateTime createTime)
        {
            Id = id;
            CreateTime = createTime;
        }

        public Guid Id { get; private set; }

        public DateTime CreateTime { get; private set; }
    }
}
