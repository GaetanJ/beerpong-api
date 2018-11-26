using System;

namespace beerpong_api.Models
{
    public class Match
    {
        public int ID { get; set; }
        public Team Team1 { get; set; }
        public Team Team2 { get; set; }
        public int Order { get; set; }
        public int BeerFor1 { get; set; }
        public int BeerFor2 { get; set; }
    }
}