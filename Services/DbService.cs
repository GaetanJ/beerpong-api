using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using beerpong_api.Models;
using Microsoft.EntityFrameworkCore;

namespace beerpong_api.Services
{
    public interface IDbService
    {
        void CreateTournament(Tournament tournament);
        Task<Tournament> GetTournamentByIdAsync(int id);
        Tournament GetLastTournament();
        Pool GetPoolById(int id);
        List<Team> GetRoundByType(int type);
        void UpdateMatch(int id, Match match);
        void EditMatch(int id, Match match);
    }
    public class DbService : IDbService
    {

        public readonly TournamentContext _context;
        public readonly ITournamentService _tournamentService;

        public DbService(TournamentContext context, ITournamentService service)
        {
            _context = context;
            _tournamentService = service;
        }

        public void CreateTournament(Tournament tournament)
        {

            tournament.Pools = _tournamentService.GeneratePools(tournament.Teams);
            _context.Tournament.Add(tournament);
            _context.SaveChanges();
        }


        public async Task<Tournament> GetTournamentByIdAsync(int id)
        {
            var result = await _context.Tournament.Include(t => t.Pools).ThenInclude(pool => pool.Matches)
                                            .Include(t => t.Teams)
                                            .SingleOrDefaultAsync(t => t.ID == id);

            foreach (var pool in result.Pools)
            {
                pool.Matches = pool.Matches.OrderBy(m => m.Order).ToList();
            }

            return result;
        }

        public Tournament GetLastTournament()
        {
            var result = _context.Tournament.Include(t => t.Pools).ThenInclude(pool => pool.Matches)
                                            .Include(t => t.Teams)
                                            .OrderByDescending(t => t.ID)
                                            .FirstOrDefault();

            foreach (var pool in result.Pools)
            {
                pool.Matches = pool.Matches.OrderBy(m => m.Order).ToList();
            }

            return result;
        }

        public Pool GetPoolById(int id)
        {
            var result = _context.Pool.Include(pool => pool.Matches)
                                      .Include(pool => pool.Teams)
                                      .FirstOrDefault(pool => pool.ID == id);

            
            result.Matches = result.Matches.OrderBy(m => m.Order).ToList();
            
            return result;
        }


        public void UpdateMatch(int id, Match match)
        {
            var matchToUpdate = _context.Match.Include(m => m.Team1)
                                              .Include(m => m.Team2)
                                              .FirstOrDefault(m => m.ID == id);


            // Validate matchToUpdate is not null
            if (matchToUpdate != null)
            {
                // Make changes on matchToUpdate
                matchToUpdate.BeerFor1 = match.BeerFor1;
                matchToUpdate.BeerFor2 = match.BeerFor2;

                matchToUpdate.Team1.BeerFor += match.BeerFor1;
                matchToUpdate.Team1.BeerAgainst += match.BeerFor2;

                matchToUpdate.Team2.BeerFor += match.BeerFor2;
                matchToUpdate.Team2.BeerAgainst += match.BeerFor1;

                if(match.BeerFor1 > match.BeerFor2) {
                    matchToUpdate.Team1.Points += 3;
                }
                else if (match.BeerFor1 == match.BeerFor2) {
                    matchToUpdate.Team1.Points += 1;
                    matchToUpdate.Team2.Points += 1;
                }
                else {
                    matchToUpdate.Team2.Points += 3;
                }

                matchToUpdate.Played = true;

                // Update matchToUpdate in DbSet
                _context.Match.Update(matchToUpdate);

                // Save changes in database
                _context.SaveChanges();
            }
        }


        public void EditMatch(int id, Match match)
        {
            var matchToEdit = _context.Match.Include(m => m.Team1)
                                            .Include(m => m.Team2)
                                            .FirstOrDefault(m => m.ID == id);


            // Validate matchToEdit is not null
            if (matchToEdit != null)
            {
                matchToEdit.Team1.BeerFor = (matchToEdit.Team1.BeerFor - matchToEdit.BeerFor1) + match.BeerFor1;
                matchToEdit.Team1.BeerAgainst = (matchToEdit.Team1.BeerAgainst - matchToEdit.BeerFor2) + match.BeerFor2;

                matchToEdit.Team2.BeerFor = (matchToEdit.Team2.BeerFor - matchToEdit.BeerFor2) + match.BeerFor2;
                matchToEdit.Team2.BeerAgainst = (matchToEdit.Team2.BeerAgainst - matchToEdit.BeerFor1) + match.BeerFor1;

                // Remove old points
                if(matchToEdit.BeerFor1 > matchToEdit.BeerFor2) {
                    matchToEdit.Team1.Points -= 3;
                }
                else if (matchToEdit.BeerFor1 == matchToEdit.BeerFor2) {
                    matchToEdit.Team1.Points -= 1;
                    matchToEdit.Team2.Points -= 1;
                }
                else {
                    matchToEdit.Team2.Points -= 3;
                }


                // Add new points
                if(match.BeerFor1 > match.BeerFor2) {
                    matchToEdit.Team1.Points += 3;
                }
                else if (match.BeerFor1 == match.BeerFor2) {
                    matchToEdit.Team1.Points += 1;
                    matchToEdit.Team2.Points += 1;
                }
                else {
                    matchToEdit.Team2.Points += 3;
                }

                matchToEdit.BeerFor1 = match.BeerFor1;
                matchToEdit.BeerFor2 = match.BeerFor2;

                // Edit matchToEdit in DbSet
                _context.Match.Update(matchToEdit);

                // Save changes in database
                _context.SaveChanges();
            }
        }
    }
}