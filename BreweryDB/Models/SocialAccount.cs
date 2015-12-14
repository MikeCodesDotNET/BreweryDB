using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BreweryDB.Interfaces;

namespace BreweryDB.Models
{
    public class SocialAccount : ISocialAccount
    {

        public SocialAccount(SocialMedia socialMedia)
        {
            SocialMedia = socialMedia;
        }

        public string Id { get; set; }
        public string SocialMediaId { get; set; }
        public ISocialMedia SocialMedia { get; set; }
        public string Handle { get; set; }
        public string CreateDate { get; set; }
        public string Link { get; set; }
    }
}
