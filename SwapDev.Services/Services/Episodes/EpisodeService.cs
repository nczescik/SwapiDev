using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SwapDev.Services.Dto;
using SwapiDev.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using WebAPI.DAL.Interfaces;

namespace SwapDev.Services.Services.Episodes
{
    public class EpisodeService : IEpisodeService
    {
        private readonly IRepository<EpisodeRating> _episodeRatingRepository;
        public EpisodeService(
            IRepository<EpisodeRating> episodeRepository)
        {
            _episodeRatingRepository = episodeRepository;
        }

        public EpisodeDto GetEpisode(long EpisodeId)
        {
            var episodeRating = _episodeRatingRepository
                   .GetDbSet()
                   .Where(er => er.EpisodeId == EpisodeId)
                   .Select(er => er.Rating)
                   .DefaultIfEmpty()
                   .Average();

            var episodeDto = new EpisodeDto
            {
                Episode_Id = EpisodeId,
                Rating = episodeRating
            };

            return episodeDto;
        }

        public IList<EpisodeDto> GetEpisodesList()
        {
            using var wc = new WebClient();
            var source = wc.DownloadString("https://swapi.dev/api/films/");

            dynamic data = JObject.Parse(source);
            var results = data["results"].ToString();

            var episodes = JsonConvert.DeserializeObject<List<EpisodeDto>>(results);

            return episodes;
        }
    }
}
