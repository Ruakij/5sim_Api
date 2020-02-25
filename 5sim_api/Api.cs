using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using YoutubeBot._5sim.Exceptions;
using YoutubeBot._5sim.Objects;

namespace YoutubeBot._5sim
{
    public class Api
    {
        public const string endpoint = "https://5sim.net/v1/";
        private const string referral_key = null;

        string token;
        private RestClient client = new RestClient(endpoint);

        public Api(string token)
        {
            this.token = token;
        }

        /// <summary>
        /// Get a given service
        /// </summary>
        /// <param name="service_name">Name of service (e.g. 'google')</param>
        /// <param name="country">Country of service (Default is 'any')</param>
        /// <param name="carrier">Carrier of service (Default is 'any')</param>
        /// <returns></returns>
        public Service getService(string service_name, string country = "any", string carrier = "any")
        {
            String uri = $"guest/products/{country}/{carrier}";
            RestRequest request = new RestRequest(uri, Method.GET);

            IRestResponse response = client.Execute(request);

            // Client-error handling
            Exception ex = response.ErrorException;
            if (ex != null) throw ex;

            // Check for expected errors and throw the corresponding exception of necessary
            checkAndThrowException(response.StatusCode, response.Content);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                JObject services_json = (JObject)JsonConvert.DeserializeObject(response.Content);

                JObject service_json = (JObject)services_json[service_name];
                return service_json.ToObject<Service>();
            }
            else
                throw new InvalidOperationException($"Invalid response: {response.StatusCode}");
        }

        public Account getAccount()
        {
            String uri = "user/profile";
            RestRequest request = new RestRequest(uri, Method.GET);

            request.AddHeader("Authorization", $"Bearer {token}");

            IRestResponse response = client.Execute(request);

            // Client-error handling
            Exception ex = response.ErrorException;
            if (ex != null) throw ex;

            // Check for expected errors and throw the corresponding exception of necessary
            checkAndThrowException(response.StatusCode, response.Content);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                JObject account_json = (JObject)JsonConvert.DeserializeObject(response.Content);
                return account_json.ToObject<Account>();
            }
            else
                throw new InvalidOperationException($"Invalid response: {response.StatusCode}");
        }

        /// <summary>
        /// Buy a activation-number
        /// </summary>
        public Number buyActivationNumber(string service_name, string country = "any", string carrier = "any")
        {
            return buyNumber("activation", service_name, country, carrier);
        }
        /// <summary>
        /// Buy a hosting-number
        /// </summary>
        /// <param name="duration">One of: {3hours, 1day}</param>
        public Number buyHostingNumber(string duration, string country = "any", string carrier = "any")
        {
            return buyNumber("hosting", duration, country, carrier);
        }
        public Number buyNumber(string type, string product, string country = "any", string provider = "any")
        {
            String uri = $"user/buy/{type}/{country}/{provider}/{product}";
            RestRequest request = new RestRequest(uri, Method.GET);

            // Add referral_key if any
            if (!String.IsNullOrEmpty(referral_key)) request.AddQueryParameter("ref", referral_key);

            request.AddHeader("Authorization", $"Bearer {token}");

            IRestResponse response = client.Execute(request);

            // Client-error handling
            Exception ex = response.ErrorException;
            if (ex != null) throw ex;

            // Check for expected errors and throw the corresponding exception of necessary
            checkAndThrowException(response.StatusCode, response.Content);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                JObject activationNumber_json = (JObject)JsonConvert.DeserializeObject(response.Content);

                Number activationNumber = activationNumber_json.ToObject<Number>();
                activationNumber.carrier = (string)activationNumber_json["operator"];
                return activationNumber;
            }
            else
                throw new InvalidOperationException($"Invalid response: {response.StatusCode}");
        }

        public Number checkNumber(int id)
        {
            return actionNumber("check", id);
        }
        public Number finishNumber(int id)
        {
            return actionNumber("finish", id);
        }
        public Number cancelNumber(int id)
        {
            return actionNumber("cancel", id);
        }
        public Number banNumber(int id)
        {
            return actionNumber("ban", id);
        }

        private Number actionNumber(string type, int id)
        {
            String uri = $"user/{type}/{id}";
            RestRequest request = new RestRequest(uri, Method.GET);

            request.AddHeader("Authorization", $"Bearer {token}");

            IRestResponse response = client.Execute(request);

            // Client-error handling
            Exception ex = response.ErrorException;
            if (ex != null) throw ex;

            // Check for expected errors and throw the corresponding exception of necessary
            checkAndThrowException(response.StatusCode, response.Content);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                JObject activationNumber_json = (JObject)JsonConvert.DeserializeObject(response.Content);

                Number activationNumber = activationNumber_json.ToObject<Number>();
                activationNumber.carrier = (string)activationNumber_json["operator"];
                return activationNumber;
            }
            else
                throw new InvalidOperationException($"Invalid response: {response.StatusCode}");
        }


        // ----------

        private static void checkAndThrowException(HttpStatusCode statusCode, string content)
        {
            switch (statusCode)
            {
                case HttpStatusCode.OK:
                    switch (content)
                    {
                        case "no free phones":
                            throw new NoFreePhonesException();
                    }
                    break;

                case HttpStatusCode.BadRequest:
                    switch (content)
                    {
                        // Api had responded with 400 instead of 404
                        case "order not found":
                            throw new OrderNotFoundException();

                        case "not enough product qty":
                            throw new NotEnoughProductQuantityException();

                        case "not enough user balance":
                            throw new NotEnoughUserBalanceException();

                        case "not enough rating":
                            throw new NotEnoughRatingException();
                    }
                    break;

                case HttpStatusCode.NotFound:
                    switch (content)
                    {
                        case "order not found":
                            throw new OrderNotFoundException();

                        case "order expired":
                            throw new OrderExpiredException();

                        case "order has sms":
                            throw new OrderHasSmsException();

                        case "hosting order":
                            throw new HostingOrderException();
                    }
                    break;
            }
        }
    }
}
