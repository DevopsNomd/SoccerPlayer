using SoccerPlayer.Models;

namespace SoccerPlayer.Data.Interfaces
{
    public interface ISPRepository
    {
        Task<Player> GetPlayer(string PlayerName, int jerseyNumber);
        Task<List<Player1>> GetPlayersList();
         Task<List<Player>> GetJoinedPlayerList();
       
        Task<int> UpdatePlayer(int teamId, int playerId);
        Task<int> CreatePlayer(int jerseyNumber, string playerName, int teamId);
    }
}
