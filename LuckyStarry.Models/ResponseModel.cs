using System;
using System.Collections.Generic;
using System.Text;

namespace LuckyStarry.Models
{
    public class ResponseModel : IResponseModel
    {
        public bool Success { set; get; }
        public string Message { set; get; }
        public ResponseType Type { set; get; }
        public string Code { set; get; } = string.Empty;

        public static ResponseModel New() => new ResponseModel();
        public static ResponseModel<T> New<T>() => new ResponseModel<T>();

        public static ResponseModel Successful() => ResponseModel.New().IsSuccessful();
        public static ResponseModel Failed() => ResponseModel.New().IsFailed();

        public static ResponseModel Successful(string message) => ResponseModel.Successful().WithMessage(message);
        public static ResponseModel Failed(string message) => ResponseModel.Failed().WithMessage(message);

        public static ResponseModel<T> Successful<T>() => ResponseModel.New<T>().IsSuccessful();
        public static ResponseModel<T> Failed<T>() => ResponseModel.New<T>().IsFailed();

        public static ResponseModel<T> Successful<T>(string message) => ResponseModel.Successful<T>().WithMessage(message);
        public static ResponseModel<T> Failed<T>(string message) => ResponseModel.Failed<T>().WithMessage(message);

        public static ResponseModel<T> Successful<T>(T entity) => ResponseModel.Successful<T>().WithEntity(entity);
        public static ResponseModel<T> Failed<T>(T entity) => ResponseModel.Failed<T>().WithEntity(entity);

        public static ResponseModel<T> Successful<T>(T entity, string message) => ResponseModel.Successful<T>(message).WithEntity(entity);
        public static ResponseModel<T> Failed<T>(T entity, string message) => ResponseModel.Failed<T>(message).WithEntity(entity);
    }

    public class ResponseModel<T> : ResponseModel, IResponseModel<T>
    {
        public T Entity { set; get; }
    }
}
