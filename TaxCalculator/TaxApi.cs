using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using TaxSerices.Entities;

namespace TaxSerices
{
    public class TaxApi
    {
        internal RestClient apiClient;
        public string apiToken { get; set; }
        public string apiUrl { get; set; }

        public TaxApi(string token)
        {
            apiToken = token;
            apiUrl = Constants.DefaultApiUrl + "/" + Constants.ApiVersion + "/";
            if (string.IsNullOrWhiteSpace(apiToken))
            {
                throw new ArgumentException("Please provide API key.", nameof(apiToken));
            }
            apiClient = new RestClient(apiUrl);            
        }

        protected virtual RestRequest CreateRequest(string action, Method method = Method.POST, object body = null)
        {
            var request = new RestRequest(action, method)
            {
                RequestFormat = DataFormat.Json
            };
            var includeBody = new[] { Method.POST, Method.PUT, Method.PATCH }.Contains(method);


            request.AddHeader("Authorization", "Bearer " + apiToken);


            if (body != null)
            {
                if (IsAnonymousType(body.GetType()))
                {
                    if (includeBody)
                    {
                        request.AddJsonBody(body);
                    }
                    else
                    {
                        foreach (var prop in body.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
                        {
                            request.AddQueryParameter(prop.Name, prop.GetValue(body).ToString());
                        }
                    }
                }
                else
                {
                    if (includeBody)
                    {
                        request.AddParameter("application/json", JsonConvert.SerializeObject(body), ParameterType.RequestBody);
                    }
                    else
                    {
                        body = JsonConvert.DeserializeObject(JsonConvert.SerializeObject(body));

                        foreach (var prop in JObject.FromObject(body).Properties())
                        {
                            request.AddQueryParameter(prop.Name, prop.Value.ToString());
                        }
                    }
                }
            }

            return request;
        }
        protected virtual bool IsAnonymousType(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException(nameof(type));
            }

            return Attribute.IsDefined(type, typeof(CompilerGeneratedAttribute), false)
                && type.IsGenericType && type.Name.Contains("AnonymousType")
                && (type.Name.StartsWith("<>") || type.Name.StartsWith("VB$"))
                && (type.Attributes & TypeAttributes.NotPublic) == TypeAttributes.NotPublic;
        }
        protected virtual T SendRequest<T>(string endpoint, object body = null, Method httpMethod = Method.POST) where T : new()
        {
            var request = CreateRequest(endpoint, httpMethod, body);
            var response = apiClient.Execute<T>(request);

            if ((int)response.StatusCode >= 400)
            {
                var taxjarError = JsonConvert.DeserializeObject<TaxError>(response.Content);
                var errorMessage = taxjarError.Error + " - " + taxjarError.Detail;
                throw new TaxException(response.StatusCode, taxjarError, errorMessage);
            }

            if (response.ErrorException != null)
            {
                throw new Exception(response.ErrorMessage, response.ErrorException);
            }

            return JsonConvert.DeserializeObject<T>(response.Content);
        }

        public virtual RateResponseAttributes Rates(string zip, object parameters = null)
        {
            var response = SendRequest<RateResponse>("rates/" + zip, parameters, Method.GET);
            return response.Rate;
        }

        public virtual TaxResponseAttributes TaxForOrder(object parameters)
        {
            var response = SendRequest<TaxResponse>("taxes", parameters, Method.POST);
            return response.Tax;
        }
    }
}
