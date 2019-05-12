using System;
using System.Net;
using FoodManager.Infrastructure.Dictionaries;
using FoodManager.Infrastructure.Exceptions.Client;
using FoodManager.Infrastructure.Extensions;
using FoodManager.Infrastructure.Settings;
using FoodManager.Models.BaseResponses;
using RestSharp;

namespace FoodManager.Infrastructure.Client
{
    public static class Response
    {
        public static void ValidateStatus(IRestResponse response)
        {
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    ChangePublicKey(response);
                    break;
                case HttpStatusCode.Accepted:
                    ChangePublicKey(response);
                    throw new AcceptedException(response.Content.Deserialize<ExceptionResponse>().Message);
                case HttpStatusCode.PreconditionFailed:
                    throw new PreconditionFailedException(response.Content.Deserialize<ExceptionResponse>().Message);
                case HttpStatusCode.NotAcceptable:
                    throw new NotAcceptableException(response.Content.Deserialize<ExceptionResponse>().Message);
                case HttpStatusCode.Conflict:
                    throw new ConflictException(response.Content.Deserialize<ExceptionResponse>().Message);
                case HttpStatusCode.Unauthorized:
                    throw new UnauthorizedAccessException(response.Content.Deserialize<ExceptionResponse>().Message);
                default:
                    var typeArgument = ExceptionDictionary.ExceptionTypeToStatusCode[response.StatusCode];
                    throw (Exception) Activator.CreateInstance(typeArgument);
            }
        }

        private static void ChangePublicKey(IRestResponse response)
        {
            var headerPublicKey = response.Headers[0].Value.ToString();
            SessionSettings.AssignPublicKey(headerPublicKey);
        }
    }
}