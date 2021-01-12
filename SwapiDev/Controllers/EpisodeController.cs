using Microsoft.AspNetCore.Mvc;
using SwapDev.Services.Services.Episodes;

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
            var episodes = _episodeService.GetEpisodesList();

            return Ok(episodes);
        }

        [HttpGet("Episodes/{episodeId}")]
        public IActionResult GetEpisode(long episodeId)
        {
            var episode = _episodeService.GetEpisode(episodeId);

            return Ok(episode);
        }
    }
}
