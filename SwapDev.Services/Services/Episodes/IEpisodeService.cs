using SwapDev.Services.Dto;
using System.Collections.Generic;

namespace SwapDev.Services.Services.Episodes
{
    public interface IEpisodeService
    {
        EpisodeDto GetEpisode(long EpisodeId);
        IList<EpisodeDto> GetEpisodesList();
    }
}
