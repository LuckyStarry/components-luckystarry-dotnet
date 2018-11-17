using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Models
{
    public class Entity : IEntity
    {
        public Entity() { }
        public Entity(IEntity entity)
        {
            this.CreateTime = entity.CreateTime;
            this.CreateUser = entity.CreateUser;
            this.CreateUserName = entity.CreateUserName;
            this.LastUpdateTime = entity.LastUpdateTime;
            this.LastUpdateUser = entity.LastUpdateUser;
            this.LastUpdateUserName = entity.LastUpdateUserName;
            this.LogicalDelete = entity.LogicalDelete;
        }

        public long CreateTime { set; get; }
        public string CreateUser { set; get; }
        public string CreateUserName { set; get; }
        public long LastUpdateTime { set; get; }
        public string LastUpdateUser { set; get; }
        public string LastUpdateUserName { set; get; }
        public bool LogicalDelete { set; get; }
    }

    public class Entity<TPrimary> : Entity, IEntity<TPrimary>
    {
        public Entity() { }
        public Entity(IEntity<TPrimary> entity) : base(entity)
        {
            this.ID = entity.ID;
        }

        public TPrimary ID { set; get; }
    }
}
