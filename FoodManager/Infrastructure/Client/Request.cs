using System;
using System.Linq;
using System.Web;
using FoodManager.Infrastructure.Extensions;
using FoodManager.Infrastructure.Security;
using FoodManager.Infrastructure.Settings;
using FoodManager.Models.BaseResponses;
using RestSharp;

namespace FoodManager.Infrastructure.Client
{
    public class Request
    {
        public static void IsAlive(string uri)
        {
            var restRequest = new RestRequest(uri, Method.GET);
            ExcecuteRestClient<bool>(restRequest);
        }

        public static T Login<T>(string uri, Object objectBody)
        {
            var restRequest = new RestRequest(uri, Method.POST);

            if (objectBody.IsNotNull())
                restRequest.AddParameter("application/json", objectBody.Serialize(),
                    ParameterType.RequestBody);
            return ExcecuteRestClient<T>(restRequest);
        }

        public static SuccessResponse Logout(string uri)
        {
            var restRequest = new RestRequest(uri, Method.POST);
            var successResponse =  ExcecuteRestClient<SuccessResponse>(restRequest);
            SessionSettings.RemoveAllSessions();
            return successResponse;
        }

        public static TModelResponse Get<TModelResponse>(string uri)
        {
            var restRequest = new RestRequest(uri, Method.GET);
            return ExcecuteRestClient<TModelResponse>(restRequest);
        }

        public static TModelResponse Filter<TModelResponse>(string uri, Object request)
        {
            var restRequest = new RestRequest(uri, Method.GET);
            var dictionary = request.ConvertToDictionary();

            if (dictionary.IsNull())
                return ExcecuteRestClient<TModelResponse>(restRequest);

            foreach (var objectParameter in dictionary.Where(parameter => parameter.Value.IsNotNullOrEmpty()))
                restRequest.AddParameter(objectParameter.Key, objectParameter.Value);

            return ExcecuteRestClient<TModelResponse>(restRequest);
        }

        public static TModelResponse Filter<TModelResponse>(string uri)
        {
            var restRequest = new RestRequest(uri, Method.GET);
            return ExcecuteRestClient<TModelResponse>(restRequest);
        }

        public static CreationResponse Post(string uri, Object objectBody)
        {
            var restRequest = new RestRequest(uri, Method.POST);

            if (objectBody.IsNotNull())
                restRequest.AddParameter("application/json", objectBody.Serialize(),
                    ParameterType.RequestBody);
            var response = ExcecuteRestClient<CreationResponse>(restRequest);
            SessionSettings.AssignIdCreated(response.Id);
            return response;
        }

        public static CreationResponse Post(string uri)
        {
            return Post(uri, null);
        }

        public static SuccessResponse Put(string uri, Object objectBody)
        {
            var restRequest = new RestRequest(uri, Method.PUT);

            if (objectBody.IsNotNull())
                restRequest.AddParameter("application/json", objectBody.Serialize(),
                    ParameterType.RequestBody);
            return ExcecuteRestClient<SuccessResponse>(restRequest);
        }

        public static SuccessResponse Put(string uri)
        {
            var restRequest = new RestRequest(uri, Method.PUT);
            return ExcecuteRestClient<SuccessResponse>(restRequest);
        }

        public static SuccessResponse Delete(string uri)
        {
            var restRequest = new RestRequest(uri, Method.DELETE);
            return ExcecuteRestClient<SuccessResponse>(restRequest);
        }

        public static SuccessResponse Assign(string uri)
        {
            var restRequest = new RestRequest(uri, Method.POST);
            return ExcecuteRestClient<SuccessResponse>(restRequest);
        }

        public static SuccessResponse AssignMany(string uri, Object objectBody)
        {
            var restRequest = new RestRequest(uri, Method.PUT);
            if (objectBody.IsNotNull())
                restRequest.AddParameter("application/json", objectBody.Serialize(),
                    ParameterType.RequestBody);
            return ExcecuteRestClient<SuccessResponse>(restRequest);
        }

        public static SuccessResponse UnAssign(string uri)
        {
            var restRequest = new RestRequest(uri, Method.DELETE);
            return ExcecuteRestClient<SuccessResponse>(restRequest);
        }

        public static SuccessResponse UnAssignMany(string uri, Object objectBody)
        {
            var restRequest = new RestRequest(uri, Method.DELETE);
            if (objectBody.IsNotNull())
                restRequest.AddParameter("application/json", objectBody.Serialize(),
                    ParameterType.RequestBody);
            return ExcecuteRestClient<SuccessResponse>(restRequest);
        }

        public static FileResponse AddFile(string uri, HttpPostedFileBase file)
        {
            var restRequest = new RestRequest(uri, Method.POST);

            if (file.IsNotNull())
            {
                restRequest.AddFile("file", file.InputStream.CopyTo, file.FileName, "multipart/form-data");
                restRequest.Files.First().ContentLength = file.ContentLength;
            }

            return ExcecuteRestClient<FileResponse>(restRequest);
        }

        private static TModelResponse ExcecuteRestClient<TModelResponse>(IRestRequest restRequest)
        {
            SessionSettings.AssignTicks();
            var restClient = new RestClient {BaseUrl = new Uri(AppSettings.ServerApi)};

            restRequest.AddHeader("Content-Type", "application/json");
            restRequest.AddHeader("PrivateKey", Hmac.GeneratePrivateKey());
            restRequest.AddHeader("Timespan", SessionSettings.RetrieveTicks);
            restRequest.AddHeader("PublicKey", SessionSettings.RetrievePublicKey);
            restRequest.AddHeader("LoginType", SessionSettings.RetrieveLoginType.GetValue().ConvertToString());

            var response = restClient.Execute(restRequest);
            Response.ValidateStatus(response);

            var model = response.Content.Deserialize<TModelResponse>();
            return model;
        }
    }
}