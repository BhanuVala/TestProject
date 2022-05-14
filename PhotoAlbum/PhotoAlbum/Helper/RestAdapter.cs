using RestSharp;
using System;

namespace PhotoAlbum.Helper
{
    /// <summary>
    /// RestAdapter
    /// </summary>
    public class RestAdapter : IAdapter
    {
        /// <summary>
        /// RestAdapter constructor
        /// </summary>
        public RestAdapter()
        {
        }

        /// <summary>
        /// Execute
        /// </summary>
        /// <param name="completeUrl"></param>
        /// <param name="methodType"></param>
        /// <returns></returns>
        public IRestResponse Execute(string completeUrl, string methodType)
        {
            if (string.IsNullOrWhiteSpace(completeUrl))
            {
                throw new ArgumentNullException();

            }

            IRestResponse restResponse = null;
            try
            {               
                var client = new RestClient(completeUrl);
                IRestRequest request = new RestRequest(Method.GET);

                restResponse = client.Execute(request);

                if (restResponse.StatusCode == System.Net.HttpStatusCode.OK && restResponse.Content != null)
                {
                    return restResponse;
                }
            }
            catch (Exception ex)
            {
                throw ex;               
            }
            return restResponse;
        }
    }
}
