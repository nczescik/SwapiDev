using Newtonsoft.Json;
using SwapDev.Services.Dto;
using SwapDev.Services.Helpers;
using SwapiDev.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using WebAPI.DAL.Interfaces;

namespace SwapDev.Services.Services.Episodes
{
    public class EpisodeService : IEpisodeService
    {
        private readonly IRepository<Episode> _episodeRepository;
        public EpisodeService(
            IRepository<Episode> episodeRepository)
        {
            _episodeRepository = episodeRepository;
        }

        public EpisodeDto GetEpisode(long episodeId)
        {
            //I wanted to be consistent with episode_id property, 
            //so that's why I am not fetching data by e.g. /films/1 
            //Value from URL does not fit with episode_id
            var results = WebClientHelper.GetValue("https://swapi.dev/api/films/", "results");

            List<EpisodeDto> episodes = JsonConvert.DeserializeObject<List<EpisodeDto>>(results);
            
            var episodeTitle = episodes
                .Where(e => e.Episode_Id == episodeId)
                .Select(e => e.Title)
                .FirstOrDefault();

            var episodeRating = _episodeRepository
                   .GetDbSet()
                   .Where(er => er.EpisodeId == episodeId)
                   .Select(er => er.Rating)
                   .DefaultIfEmpty()
                   .Average();

            var episodeDto = new EpisodeDto
            {
                Episode_Id = episodeId,
                Title = episodeTitle,
                Rating = episodeRating
            };

            return episodeDto;
        }

        public IList<EpisodeDto> GetEpisodesList()
        {
            var results = WebClientHelper.GetValue("https://swapi.dev/api/films/", "results");

            var episodes = JsonConvert.DeserializeObject<List<EpisodeDto>>(results);

            return episodes;
        }
    }
}
