using System;
using System.Collections.Generic;

namespace beerpong_api.Models
{
    public class Pool
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Team> Teams { get; set; }
        public List<Match> Matches { get; set; }
    }
}