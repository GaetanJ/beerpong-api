using System;
using System.Collections.Generic;

namespace beerpong_api.Models
{
    public class Round
    {
        public int ID { get; set; }
        public int Type { get; set; }
        public List<Match> Matches { get; set; }
        public int TournamentID { get; set; }
    }
}