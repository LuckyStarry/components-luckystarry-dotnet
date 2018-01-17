using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Models
{
    public interface IUser
    {
        long ID { get; }
        string Name { get; }
    }
}
