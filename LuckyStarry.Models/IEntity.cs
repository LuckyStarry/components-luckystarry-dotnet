using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Models
{
    public interface IEntity
    {
        long CreateTime { set; get; }
        string CreateUser { set; get; }
        string CreateUserName { set; get; }
        long LastUpdateTime { set; get; }
        string LastUpdateUser { set; get; }
        string LastUpdateUserName { set; get; }
        bool LogicalDelete { set; get; }
    }

    public interface IEntity<TPrimary> : IEntity
    {
        TPrimary ID { set; get; }
    }
}
