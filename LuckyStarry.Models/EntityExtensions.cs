using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Models
{
    public static class EntityExtensions
    {
        public static T WithCreateUser<T>(this T entity, IUser user) where T : IEntity
        {
            entity.CreateUser = user.UserID;
            entity.CreateUserName = user.UserName;
            entity.CreateTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

            entity.LastUpdateUser = entity.CreateUser;
            entity.LastUpdateUserName = entity.CreateUserName;
            entity.LastUpdateTime = entity.CreateTime;

            return entity;
        }

        public static T WithLastUpdateUser<T>(this T entity, IUser user) where T : IEntity
        {
            entity.LastUpdateUser = user.UserID;
            entity.LastUpdateUserName = user.UserName;
            entity.LastUpdateTime = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

            return entity;
        }

        public static T WithCreateUser<T, U>(this T entity, U other) where T : IEntity where U : IEntity
        {
            entity.CreateUser = other.LastUpdateUser;
            entity.CreateUserName = other.LastUpdateUserName;
            entity.CreateTime = other.LastUpdateTime;

            entity.LastUpdateUser = entity.CreateUser;
            entity.LastUpdateUserName = entity.CreateUserName;
            entity.LastUpdateTime = entity.CreateTime;

            return entity;
        }

        public static T WithLastUpdateUser<T, U>(this T entity, U other) where T : IEntity where U : IEntity
        {
            entity.LastUpdateUser = other.LastUpdateUser;
            entity.LastUpdateUserName = other.LastUpdateUserName;
            entity.LastUpdateTime = other.LastUpdateTime;

            return entity;
        }
    }
}
