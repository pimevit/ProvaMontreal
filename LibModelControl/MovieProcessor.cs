using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LibModelControl
{
  public class MovieProcessor
  {
    public static async Task<MovieModel> LoadMovie(int pageNumber = 30)
    {
      /*
        var client = new RestClient("https://api.themoviedb.org/3/movie/30?language=en-US&api_key=c6b31d1cdad6a56a23f0c913e2482a31");
        var request = new RestRequest(Method.GET);
        request.AddParameter("undefined", "{}", ParameterType.RequestBody);
        IRestResponse response = client.Execute(request);
       * */
      string url = "";
      string apiKey = "api_key=api_key=c6b31d1cdad6a56a23f0c913e2482a31&language=en-US";

      if (pageNumber > 0)
      {
        url = $"https://api.themoviedb.org/3/movie/{pageNumber}?language=en-US&{apiKey}";
      }
      else
      {
        url = $"https://api.themoviedb.org/3/movie/30?language=en-US&{apiKey}";
      }

      using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
      {
        if (response.IsSuccessStatusCode)
        {
          MovieModel movie = await response.Content.ReadAsAsync<MovieModel>();

          return movie;
        }
        else
        {
          throw new Exception(response.ReasonPhrase);
        }
      }
    }

    public static async Task<MovieModel> LoadSunInformation()
    {
      string url = "https://api.themoviedb.org/3/movie/1?api_key=c6b31d1cdad6a56a23f0c913e2482a31&language=en-US";

      using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
      {

        if (response.IsSuccessStatusCode)
        {
          MovieResultModel result = await response.Content.ReadAsAsync<MovieResultModel>();


          return result.Results;
        }
        else
        {
          throw new Exception(response.ReasonPhrase);
        }
      }
    }
  }
}
