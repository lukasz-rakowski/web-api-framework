using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Domain.Entities.Interfaces;

namespace WebAPI.Domain.Entities.Base
{
    public class EntityBaseWithHistory: EntityBase, IHistoryTrackingTableEnabled
    {
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }

        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
