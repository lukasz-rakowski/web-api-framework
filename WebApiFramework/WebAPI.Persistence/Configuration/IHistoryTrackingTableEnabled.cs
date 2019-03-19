using System;
using System.Collections.Generic;
using System.Text;
using WebAPI.Domain.Entities;

namespace WebAPI.Persistence.Configuration
{
    public interface IHistoryTrackingTableEnabled
    {
        DateTime ValidFrom { get; set; }
        DateTime ValidTo { get; set; }

        int UserId { get; set; }
        User User { get; set; }
    }
}
