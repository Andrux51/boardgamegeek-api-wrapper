using System.Web.Http;
using BoardGameApi.Models;
using RestSharp;

namespace BoardGameApi.Controllers
{
    public class ThingController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get(string query, int exact = 0)
        {
            var client = new RestClient("http://www.boardgamegeek.com/xmlapi2");

            var request = new RestRequest("search");

            request.AddParameter("query", query);
            request.AddParameter("exact", exact);

            var response = client.Execute<SearchResults>(request);

            return Ok(response.Data);
        }

        public IHttpActionResult Get(int id)
        {
            var client = new RestClient("http://www.boardgamegeek.com/xmlapi2");

            var request = new RestRequest("thing");

            request.AddParameter("id", id);

            var response = client.Execute<ThingDetail>(request);

            var thing = response.Data;

            thing.Image = $"http:{thing.Image}";

            return Ok(thing);
        }
    }
}