namespace SwapiDev.DAL.Entities
{
    public class EpisodeRating : Entity
    {
        public long EpisodeId { get; set; }
        public int Rating { get; set; }
    }
}
