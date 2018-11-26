using System;
using System.Collections.Generic;

namespace beerpong_api.Models
{
    public class Tournament
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public  List<Team> Teams { get; set; }
        public List<Pool> Pools { get; set; }
    }
}