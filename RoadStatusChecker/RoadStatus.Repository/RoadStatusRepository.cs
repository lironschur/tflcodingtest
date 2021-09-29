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
        private readonly RepositorySettings _settings;

        public RoadStatusRepository(RepositorySettings settings)
        {
            _settings = settings;
        }
        public async Task<IEnumerable<RoadCorridor>> GetRoadCorridorsAsync(string id)
        {
            var apiUrl = $"{_settings.BaseUrl}/Road/{id}";

            var url = new Url(new Uri(apiUrl));

            using var client = new HttpClient();
            if (!string.IsNullOrEmpty(_settings.ApiSubscriptionKey))
            {
                client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", _settings.ApiSubscriptionKey);
            }

            var response = await client.GetAsync(url.ToString());

            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<IEnumerable<RoadCorridor>>(jsonResponse);
                    return result;

                case HttpStatusCode.NotFound:
                    throw new NoResultsFoundException();

                default:
                    throw new Exception($"Status code returned: {response.StatusCode}");
            }
        }
    }
}
