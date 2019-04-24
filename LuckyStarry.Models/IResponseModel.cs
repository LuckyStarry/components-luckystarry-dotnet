using System;

namespace LuckyStarry.Models
{
    public interface IResponseModel
    {
        bool Success { get; }
        string Message { get; }
        ResponseType Type { get; }
        string Code { get; }
    }

    public interface IResponseModel<T> : IResponseModel
    {
        T Entity { get; }
    }
}
