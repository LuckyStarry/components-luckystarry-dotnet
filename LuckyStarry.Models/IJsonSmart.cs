using System;

namespace LuckyStarry.Models
{
    public interface IJsonSmart
    {
        bool IsSuccessful { get; }
        string Message { get; }
    }

    public interface IJsonSmart<T> : IJsonSmart
    {
        T Entity { get; }
    }
}
