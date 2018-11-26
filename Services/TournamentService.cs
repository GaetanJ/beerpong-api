using System;
using System.Collections.Generic;
using beerpong_api.Models;

namespace beerpong_api.Services
{
    public interface ITournamentService
    {
        List<Pool> GeneratePools(List<Team> teams);

    }
    public class TournamentService : ITournamentService
    {

        public readonly TournamentContext _context;

        public TournamentService(TournamentContext context)
        {
            _context = context;
        }

        public List<Pool> GeneratePools(List<Team> teams)
        {
            var alphabet = new []{"A","B","C","D","E","F","G","H","I","J","K","L","M","N","O","P","Q","R","S","T","U","V","W","X","Y","Z"};
            List<Pool> pools = new List<Pool>();

            teams = Shuffle(teams);

            int limit = (teams.Count - 1) / 4 + 1;
            for (int i = 0; i < limit; i++)
            {
                var poolTmp = new Pool();
                poolTmp.Name = "Poule " + alphabet[i];
                poolTmp.Teams = teams.GetRange(i*4, 4);
                poolTmp.Matches = GenerateMatches(poolTmp.Teams);

                pools.Add(poolTmp);
            }

            return pools;
        }

        private List<Match> GenerateMatches(List<Team> teams) {
            List<Match> ret = new List<Match>();

            
            var match1  = new Match();
            match1.Team1 = teams[0];
            match1.Team2 = teams[3];
            match1.Order = 1;
            ret.Add(match1);

            var match2  = new Match();
            match2.Team1 = teams[1];
            match2.Team2 = teams[2];
            match2.Order = 2;
            ret.Add(match2);

            var match3  = new Match();
            match3.Team1 = teams[0];
            match3.Team2 = teams[2];
            match3.Order = 3;
            ret.Add(match3);

            var match4  = new Match();
            match4.Team1 = teams[1];
            match4.Team2 = teams[3];
            match4.Order = 4;
            ret.Add(match4);

            var match5  = new Match();
            match5.Team1 = teams[0];
            match5.Team2 = teams[1];
            match5.Order = 5;
            ret.Add(match5);

            var match6  = new Match();
            match6.Team1 = teams[2];
            match6.Team2 = teams[3];
            match6.Order = 6;
            ret.Add(match6);

            return ret;
        }

        public static List<T> Shuffle<T>(List<T> list)
        {
            var rng = new Random();

            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }

            return list;
        }



    }
}