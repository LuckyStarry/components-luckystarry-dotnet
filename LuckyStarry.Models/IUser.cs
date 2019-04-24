using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Models
{
    public interface IUser
    {
        string UserID { get; }
        string UserName { get; }
        string[] Roles { get; }
    }
}
