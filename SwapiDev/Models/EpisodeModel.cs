using System;

namespace SwapiDev.WebAPI.Models
{
    public class EpisodeModel
    {
        public long EpisodeId { get; set; }
        public string Title { get; set; }
        public string OpeningCrawl { get; set; }
        public string Director { get; set; }
        public string Producer { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public double Rating { get; set; }
    }
}
