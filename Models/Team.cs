using System;

namespace beerpong_api.Models
{
    public class Team
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Points { get; set; }
        public int BeerFor { get; set; }
        public int BeerAgainst { get; set; }
    }
}