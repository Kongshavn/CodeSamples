using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ClientCredentials.Application.Models
{
    public class ClientAuthenticationRequestModel
    {

        public ClientAuthenticationRequestModel(string tokenEndpoint, string clientId, string clientSecret, List<string> scopes)
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
            Scopes = scopes;
            TokenEndpoint = tokenEndpoint;
        }

        private string ClientId { get; }
        private string ClientSecret { get; }
        private string TokenEndpoint { get; }
        private List<string> Scopes { get; }

        public HttpRequestMessage GetRequest()
        {
            var scopes = "";

            Scopes.ForEach(s => scopes += $"{s} ");

            var content = new StringContent($"grant_type=client_credentials&client_id={ClientId}&client_secret={HttpUtility.UrlEncode(ClientSecret)}&scope={scopes}",
                Encoding.UTF8, "application/x-www-form-urlencoded");

            return new HttpRequestMessage(HttpMethod.Post, TokenEndpoint)
            {
                Content = content
            };
        }
    }
}
