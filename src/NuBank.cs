using Newtonsoft.Json;
using RestSharp;
using System;
using System.Net;

namespace dotnetnubank
{
  public class NuBank
  {
    public dynamic SignInData { private get; set; }

    public string GetLoginToken(string login, string password)
    {
      var client = new RestClient("https://prod-s0-webapp-proxy.nubank.com.br");
      var request = new RestRequest("/api/proxy/AJxL5LBUC2Tx4PB-W6VD1SEIOd2xp14EDQ.aHR0cHM6Ly9wcm9kLWdsb2JhbC1hdXRoLm51YmFuay5jb20uYnIvYXBpL3Rva2Vu", Method.POST);
      SetDefaultHeader(request);

      // Body
      request.RequestFormat = DataFormat.Json;
      request.AddBody(new
      {
        password,
        login,
        grant_type = "password",
        client_id = "other.conta",
        client_secret = "yQPeLzoHuJzlMMSAjC-LgNUJdUecx8XO",
      });

      IRestResponse response = client.Execute(request);
      var content = response.Content; // raw content as string

      if (response.StatusCode == HttpStatusCode.OK)
      {
        SignInData = JsonConvert.DeserializeObject<dynamic>(content);
        return content;
      }
      else
      {
        return string.Empty;
      }
    }

    public string GetWholeFeed()
    {
      var client = new RestClient("https://prod-s0-webapp-proxy.nubank.com.br");
      Uri uri = new Uri((string)SignInData._links.events.href);
      var request = new RestRequest(uri.AbsolutePath, Method.GET);

      SetDefaultHeader(request);
      request.AddHeader("Authorization", $"Bearer {SignInData.access_token}");

      IRestResponse response = client.Execute(request);
      var content = response.Content;

      if (response.StatusCode == HttpStatusCode.OK)
      {
        return content;
      }
      else
      {
        return string.Empty;
      }
    }

    public IRestResponse Get(string access_token, string href)
    {
      var client = new RestClient("https://prod-s0-webapp-proxy.nubank.com.br");
      Uri uri = new Uri(href);
      var request = new RestRequest(uri.AbsolutePath, Method.GET);

      SetDefaultHeader(request);
      request.AddHeader("Authorization", $"Bearer {access_token}");

      return client.Execute(request);
    }

    private void SetDefaultHeader(RestRequest request)
    {
      request.AddHeader("Content-Type", "application/json");
      request.AddHeader("X-Correlation-Id", "WEB-APP.jO4x1");
      request.AddHeader("User-Agent", "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/53.0.2785.143 Safari/537.36");
      request.AddHeader("Origin", "https://conta.nubank.com.br");
      request.AddHeader("Referer", "https://conta.nubank.com.br/");
    }


  }
}
