using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Models
{
    public static class ResponseModelExtensions
    {
        public static T IsSuccessful<T>(this T model) where T : ResponseModel
        {
            model.Success = true;
            return model;
        }

        public static T IsFailed<T>(this T model) where T : ResponseModel
        {
            model.Success = false;
            return model;
        }

        public static T WithMessage<T>(this T model, string message) where T : ResponseModel
        {
            model.Message = message;
            return model;
        }

        public static T WithEntity<T, U>(this T model, U entity) where T : ResponseModel<U>
        {
            model.Entity = entity;
            return model;
        }

        public static T WithType<T>(this T model, ResponseType type) where T : ResponseModel
        {
            return model.WithType(type, null);
        }

        public static T WithType<T>(this T model, ResponseType type, string code) where T : ResponseModel
        {
            model.Type = type;
            if (string.IsNullOrWhiteSpace(code))
            {
                code = $"{ (int)type }000";
            }
            model.Code = code.Trim();
            return model;
        }
    }
}
