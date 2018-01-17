using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Models
{
    public static class JsonSmartExtensions
    {
        public static T IsSuccessful<T>(this T model) where T : JsonSmart
        {
            model.IsSuccessful = true;
            return model;
        }

        public static T IsFailed<T>(this T model) where T : JsonSmart
        {
            model.IsSuccessful = false;
            return model;
        }

        public static T WithMessage<T>(this T model, string message) where T : JsonSmart
        {
            model.Message = message;
            return model;
        }

        public static T WithEntity<T, U>(this T model, U entity) where T : JsonSmart<U>
        {
            model.Entity = entity;
            return model;
        }
    }
}
