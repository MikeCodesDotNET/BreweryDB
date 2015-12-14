using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BreweryDB.Helpers;
using BreweryDB.Models;

namespace BreweryDB.Resources
{
    public class FeatureResource
    {
        private readonly BreweryDbClient client;

        public FeatureResource(BreweryDbClient breweryDbClient)
        {
            client = breweryDbClient;
        }

        async public Task<ResponseContainer<Feature>> ThisWeeks()
        {
            var url = $"{BreweryDbClient.BaseAddress}featured?key={BreweryDbClient.ApplicationKey}&format=json";
            return await JsonDownloader.DownloadSerializedJsonDataAsync<ResponseContainer<Feature>>(url);
        }

        async public Task<ResponseContainer<List<Feature>>> GetAll()
        {
            return await GetAll(1);
        }

        async public Task<ResponseContainer<List<Feature>>> GetAll(int pageNumber)
        {
            var url = $"{BreweryDbClient.BaseAddress}features?p={pageNumber}&key={BreweryDbClient.ApplicationKey}&format=json";
            return await JsonDownloader.DownloadSerializedJsonDataAsync<ResponseContainer<List<Feature>>>(url);
        }

        async public Task<ResponseContainer<Feature>> Get(DateTime date)
        {
            string week = date.Month.ToString();
            if(week.Length == 1)
            {
                week = $"0{week}";
            }

            var year = date.Year;

            var url = $"{BreweryDbClient.BaseAddress}feature/{year}-{week}?key={BreweryDbClient.ApplicationKey}&format=json";
            return await JsonDownloader.DownloadSerializedJsonDataAsync<ResponseContainer<Feature>>(url);
        }
    }
}

