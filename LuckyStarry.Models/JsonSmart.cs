using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Models
{
    public class JsonSmart : IJsonSmart
    {
        public bool IsSuccessful { set; get; }
        public string Message { set; get; }

        public static JsonSmart New() => new JsonSmart();
        public static JsonSmart<T> New<T>() => new JsonSmart<T>();

        public static JsonSmart Successful() => JsonSmart.New().IsSuccessful();
        public static JsonSmart Failed() => JsonSmart.New().IsFailed();

        public static JsonSmart Successful(string message) => JsonSmart.Successful().WithMessage(message);
        public static JsonSmart Failed(string message) => JsonSmart.Failed().WithMessage(message);

        public static JsonSmart<T> Successful<T>() => JsonSmart.New<T>().IsSuccessful();
        public static JsonSmart<T> Failed<T>() => JsonSmart.New<T>().IsFailed();

        public static JsonSmart<T> Successful<T>(string message) => JsonSmart.Successful<T>().WithMessage(message);
        public static JsonSmart<T> Failed<T>(string message) => JsonSmart.Failed<T>().WithMessage(message);

        public static JsonSmart<T> Successful<T>(T entity) => JsonSmart.Successful<T>().WithEntity(entity);
        public static JsonSmart<T> Failed<T>(T entity) => JsonSmart.Failed<T>().WithEntity(entity);

        public static JsonSmart<T> Successful<T>(T entity, string message) => JsonSmart.Successful<T>(message).WithEntity(entity);
        public static JsonSmart<T> Failed<T>(T entity, string message) => JsonSmart.Failed<T>(message).WithEntity(entity);
    }

    public class JsonSmart<T> : JsonSmart, IJsonSmart<T>
    {
        public T Entity { set; get; }
    }
}
