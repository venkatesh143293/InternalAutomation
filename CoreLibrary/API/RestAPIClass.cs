using WF.Test.AutomationFramework.ConfigParser;
using WF.Test.AutomationFramework.Helpers;
using RestSharp;

namespace WF.Test.AutomationFramework.CoreLibrary.API
{
    public class RestAPIClass
    {
        /// <summary>
        /// Get Response for Post Action on Rest call with ParameterBody
        /// </summary>
        public static string GetResponsePostActionParameterBody()
        {
            var client = new RestClient(APIConfigSettings.BaseURI);
            var request = new RestRequest(Method.POST);
            request.AddParameter(APIConfigSettings.ParameterName, APIConfigSettings.ParameterValue, ParameterType.RequestBody);
            var response = client.Post(request);
            return response.Content.ToString();
        }

        /// <summary>
        /// Get Response for Post Action on Rest call with ParameterBody
        /// </summary>
        public static string GetResponsePostActionParameterBody(string uri, string parameterName, string parameterValue)
        {
            Reporter.LogInfo("API endpoint: " + uri);
            var client = new RestClient(uri);
            var request = new RestRequest(Method.POST);
            request.AddHeader(APIConfigSettings.ParameterName, "");
            request.AddParameter(parameterName, parameterValue, ParameterType.RequestBody);
            var response = client.Post(request);
            if (response.StatusCode.Equals("200") || response.StatusCode.Equals("201"))
            {
                Reporter.LogPass("API called with status Code" + response.StatusCode);
                Reporter.LogPass("API response is" + response.Content.ToString());

            }
            else
            {
                Reporter.LogFail("Failed to call the API:" + response.StatusCode);

            }
            return response.Content.ToString();

        }

        /// <summary>
        /// Get Response for Get Action  on Rest call with AuthorizationToken
        /// </summary>
        public static string GetResponseGetActionAuthorizationToken(string accessToken, string requestResource)
        {

            var client = new RestClient(APIConfigSettings.SecondaryURI);
            client.AddDefaultHeader("Authorization", string.Format("Bearer {0}", accessToken));
            var request = new RestRequest(requestResource);
            var response = client.Get(request);
            return response.Content.ToString();
        }



        /// <summary>
        /// Get Response for Get Action  on Rest call with AuthorizationToken
        /// </summary>
        public static string GetResponseGetActionAuthorizationToken(string uri, string accessToken, string requestResource)
        {

            var client = new RestClient(uri);
            client.AddDefaultHeader("Authorization", string.Format("Bearer {0}", accessToken));
            var request = new RestRequest(requestResource);
            var response = client.Get(request);
            return response.Content.ToString();
        }



    }
}
