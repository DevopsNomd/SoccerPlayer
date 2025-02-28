namespace SoccerPlayer.Models
{
    public  class Team
    {
        public int TeamId { get; set; }
        public string? teamName { get; set; }

        public string? CountryName { get; set; }

        public int? ConfederationId { get; set; }

        public virtual Confederation? Confederation { get; set; }

        public virtual ICollection<Player> Players { get; } = new List<Player>();
    }
}