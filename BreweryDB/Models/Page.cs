using System;
using System.Collections.Generic;

namespace BreweryDB.Models
{
    public class Page<T>
    {
        public int CurrentPage { get; set; }

        public int NumberOfPages { get; set; }

        public int TotalResults { get; set; }

        public List<T> Data { get; set; }
    }
}

