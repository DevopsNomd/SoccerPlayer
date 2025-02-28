using System.ComponentModel.DataAnnotations;

namespace SoccerPlayer.Models
{
    public  class Player
    {
        

        public int playerId { get; set; }
        public string? PlayerName { get; set; }
        public int? jerseyNumber { get; set; }
        public int? TeamId {  get; set; }
        public string TeamName { get; set; }
    }
}
