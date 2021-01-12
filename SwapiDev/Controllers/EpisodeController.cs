using Microsoft.AspNetCore.Mvc;
using SwapDev.Services.Services.Episodes;
using SwapiDev.WebAPI.Models;
using System.Collections.Generic;
using WebApi.Helpers;

namespace SwapiDev.WebAPI.Controllers
{
    public class EpisodeController : Controller
    {
        private readonly IEpisodeService _episodeService;
        public EpisodeController(
            IEpisodeService episodeService)
        {
            _episodeService = episodeService;
        }

        [HttpGet("")]
        [HttpGet("Episodes")]
        public IActionResult GetEpisodes()
        {
            var result = new List<EpisodeModel>();
            var episodes = _episodeService.GetEpisodesList();

            foreach (var episode in episodes)
            {
                result.Add(new EpisodeModel
                {
                    EpisodeId = episode.Episode_Id,
                    Title = episode.Title,
                    Rating = episode.Rating
                });
            }

            var json = JsonHelper<List<EpisodeModel>>.JsonConverter(result);

            return Ok(json);
        }

        [HttpGet("Episodes/{episodeId}")]
        public IActionResult GetEpisode(long episodeId)
        {
            var episode = _episodeService.GetEpisode(episodeId);

            var model = new EpisodeModel
            {
                EpisodeId = episode.Episode_Id,
                Title = episode.Title,
                OpeningCrawl = episode.Opening_Crawl,
                Director = episode.Director,
                Producer = episode.Producer,
                ReleaseDate = episode.Release_Date,
                Rating = episode.Rating
            };

            var json = JsonHelper<EpisodeModel>.JsonConverter(model);

            return Ok(json);
        }
    }
}
