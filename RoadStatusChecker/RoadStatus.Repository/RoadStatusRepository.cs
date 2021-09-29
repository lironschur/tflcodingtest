using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Flurl;
using Newtonsoft.Json;
using RoadStatus.Repository.Models;

namespace RoadStatus.Repository
{
    public class RoadStatusRepository : IRoadStatusRepository
    {
        public async Task<IEnumerable<RoadCorridor>> GetRoadCorridorsAsync(string id)
        {
            var apiUrl = $"https://api.tfl.gov.uk/Road/{id}"; //TestContext.Parameters["ApiUrl"];

            var url = new Url(new Uri(apiUrl));

            using var client = new HttpClient();
            var response = await client.GetAsync(url.ToString());

            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<IEnumerable<RoadCorridor>>(jsonResponse);
                    return result;

                case HttpStatusCode.NotFound:
                    return null;

                default:
                    throw new Exception($"Status code returned: {response.StatusCode}");
            }
        }
    }
}
