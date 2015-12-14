
using System;
using BreweryDB.Interfaces;

namespace BreweryDB.Models
{
    public class Category : ICategory
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string CreateDate { get; set; }
        public string Description { get; set; }
    }
}