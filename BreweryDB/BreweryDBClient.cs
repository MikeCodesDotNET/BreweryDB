using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using BreweryDB.Helpers;

namespace BreweryDB
{
    public class BreweryDBClient
    {
        public static string ApplicationKey { get; private set; }

        public static void Initialize(string applicationKey, string applicationName, double cacheValidateForDayCount = 3)
        {
            BreweryDBClient.ApplicationKey = applicationKey;
            Akavache.BlobCache.ApplicationName = applicationName;
            CacheValidateForDayCount = cacheValidateForDayCount;
        }

        public static Double CacheValidateForDayCount {get; set;}
        public static bool UseCache {get; set;}
    }
}
