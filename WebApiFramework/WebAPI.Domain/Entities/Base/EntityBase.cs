﻿namespace WebAPI.Domain.Entities.Base
{
    public abstract class EntityBase
    {
        public int Id { get; set; }
        public byte[] Timestamp { get; set; }
        public bool IsDeleted { get; set; }
    }
}
