using System;

namespace WebAPI.Domain.Entities.Interfaces
{
    public interface IHistoryTrackingTableEnabled
    {
        DateTime ValidFrom { get; set; }
        DateTime ValidTo { get; set; }

        int UserId { get; set; }
        User User { get; set; }
    }
}
