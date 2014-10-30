﻿using System;

namespace Xoqal.Core.Models
{
    /// <summary>
    /// Represents an Aggregate with standard GUID key.
    /// </summary>
    /// <remarks>
    /// Used to set the GUID key automatically.
    /// </remarks>
    public class GuidAggregate : IAggregate<Guid>
    {
        public GuidAggregate()
        {
            this.Id = Guid.NewGuid();
        }
        
        public virtual Guid Id { get; set; }
    }
}
