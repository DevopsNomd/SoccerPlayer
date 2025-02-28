using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SoccerPlayer.Data.Interfaces;
using SoccerPlayer.Models;

namespace SoccerPlayer.Data.Repositories
{
    public class SPRepository: ISPRepository
    {
        public readonly SampleDatabaseContext _databaseContext;

        public SPRepository(SampleDatabaseContext dbContext)
        {
            _databaseContext = dbContext;
        }

        public async Task<int> CreatePlayer(int jerseyNumber, string PlayerName, int teamId)
        {
            var affectedRows = await _databaseContext.Database.ExecuteSqlInterpolatedAsync($"exec CreatePlayer @jerseyNumber={jerseyNumber},@PlayerName={PlayerName},@teamId={teamId}");
                return affectedRows;
                }

        public async Task<List<Player>> GetJoinedPlayerList()
        {
           // var playerspobjobj = await _databaseContext.Players.FromSqlInterpolated($"exec GetJoinedPlayerList").ToListAsync();
            var playerspobjobj = await _databaseContext.Players.FromSqlRaw(@"SELECT 
                                                                                        p.playerId,
                                                                                        p.playerName,
                                                                                  p.jerseyNumber,
                                                                                        t.teamId,
                                                                                        t.teamName
                                                                                    FROM
                                                                                        Player p
                                                                                    INNER JOIN
                                                                                        Team  t
                                                                                    ON
                                                                                        p.teamId = t.teamId").ToListAsync();
            return playerspobjobj;
        }

        public async Task<Player> GetPlayer(string PlayerName, int jerseyNumber)
        {
            var playerspobjobj = await _databaseContext.Players.FromSqlInterpolated($"exec GetPlayer @jerseyNumber={jerseyNumber},@PlayerName={PlayerName}").ToListAsync();
            return playerspobjobj.FirstOrDefault();
        }
        //public async Task<Player> GetPlayer(string PlayerName, int jerseyNumber)
        //{
            
        //        var query = "SELECT * FROM Player WHERE JerseyNumber = @jerseyNumber AND PlayerName = @PlayerName";
        //        var player = await _databaseContext.Players.FromSqlRaw(query,
        //                            new SqlParameter("@jerseyNumber", jerseyNumber),
        //                            new SqlParameter("@PlayerName", PlayerName))
        //                            .ToListAsync();
        //        return player.FirstOrDefault();
           
           
        //}


        public async Task<List<Player1>> GetPlayersList()
        {

             //var playerspobjobj = await _databaseContext.Players.FromSqlInterpolated($"exec GetPlayersList ").ToListAsync();           
                var playerspobjobj = await _databaseContext.Players1.FromSqlRaw($"select * from Player").ToListAsync();
                return playerspobjobj;          
        }

        public async Task<int> UpdatePlayer(int teamId, int playerId)
        {
            var affectedRows = await _databaseContext.Database.ExecuteSqlInterpolatedAsync($"exec UpdatePlayer @teamId={teamId},@playerId={playerId}");
            return affectedRows;
        }
    }
}
