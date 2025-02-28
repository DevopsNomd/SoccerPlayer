using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SoccerPlayer.Data.Interfaces;
using SoccerPlayer.Models;
using System.Reflection.Metadata.Ecma335;

namespace SoccerPlayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SPController : ControllerBase
    {
        private readonly ISPRepository _spRepository;
        public SPController(ISPRepository sPRepository)
        {
            _spRepository = sPRepository;
        }
        [HttpGet("GetPlayer")]
        public async Task<Player> GetPlayer(string PlayerName, int jerseyNumber)
        {
            var x = await _spRepository.GetPlayer(PlayerName, jerseyNumber);
            return x;
        }
        [HttpGet("GetPlayersList")]
        public async Task<List<Player1>> GetPlayersList()
        {
            var x = await _spRepository.GetPlayersList();
             return x;
        }
        [HttpPost("CreatePlayer")]
        public async Task<int>CreatePlayer(int jerseyNumber, string PlayerName, int teamId)
        {
            var x = await _spRepository.CreatePlayer(jerseyNumber, PlayerName, teamId);
            return x;
        }
        [HttpPut("UpdatePlayer")]
        public async Task<int> UpdatePlayer(int teamId, int playerId)
        {
            var x = await _spRepository.UpdatePlayer(teamId, playerId);
            return x;
        }
        [HttpGet("GetJoinedPlayerList")]
        public async Task<List<Player>> GetJoinedPlayerList()
        {
            var x = await _spRepository.GetJoinedPlayerList();
            return x;
        }
    }
}
