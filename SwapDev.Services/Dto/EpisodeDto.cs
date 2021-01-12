using System;

namespace SwapDev.Services.Dto
{
    public class EpisodeDto
    {
        public long Episode_Id { get; set; }
        public string Title { get; set; }
        public string Opening_Crawl { get; set; }
        public string Director { get; set; }
        public string Producer { get; set; }
        public DateTime Release_Date { get; set; }
        public double Rating { get; set; }
    }
}
