using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Models
{
    public interface IEntity
    {
        long CreateTime { set; get; }
        long CreateUser { set; get; }
        long LastUpdateTime { set; get; }
        long LastUpdateUser { set; get; }
        bool LogicalDelete { set; get; }
    }

    public interface IEntity<TPrimary> : IEntity
    {
        TPrimary ID { set; get; }
    }
}
