using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Models
{
    public class Entity : IEntity
    {
        public long CreateTime { set; get; }
        public long CreateUser { set; get; }
        public long LastUpdateTime { set; get; }
        public long LastUpdateUser { set; get; }
        public bool LogicalDelete { set; get; }
    }

    public class Entity<TPrimary> : Entity, IEntity<TPrimary>
    {
        public TPrimary ID { set; get; }
    }
}
