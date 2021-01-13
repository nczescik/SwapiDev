using Moq;
using NUnit.Framework;
using SwapDev.Services.Services.Episodes;
using System;
using System.Linq;
using WebAPI.DAL.Interfaces;

namespace SwapiDev.Tests.Episode
{
    public class EpisodeTest
    {
        private IRepository<DAL.Entities.EpisodeRating> episodeRatingRepository;

        [SetUp]
        public void Setup()
        {
            episodeRatingRepository = new Mock<IRepository<DAL.Entities.EpisodeRating>>().Object;
        }

        [Test]
        public void GetEpisodes_ReturnsProperEpisodesCount()
        {
            //arrange
            var _episodeService = new EpisodeService(episodeRatingRepository);

            //act
            var episodes = _episodeService.GetEpisodesList();

            //assert
            Assert.AreEqual(6, episodes.Count());
        }

        [TestCase(1, "The Phantom Menace")]
        [TestCase(2, "Attack of the Clones")]
        [TestCase(3, "Revenge of the Sith")]
        [TestCase(4, "A New Hope")]
        [TestCase(5, "The Empire Strikes Back")]
        [TestCase(6, "Return of the Jedi")]
        public void GetEpisode_ReturnsEpisodeDetails(long episodeId, string title)
        {
            //arrange
            var _episodeService = new EpisodeService(episodeRatingRepository);

            //act
            var episodes = _episodeService.GetEpisode(episodeId);

            //assert
            Assert.AreEqual(title, episodes.Title);
        }

        [TestCase(0)]
        public void GetEpisode_ReturnsEpisodeDoesntExistMessageException(long episodeId)
        {
            //arrange
            var _episodeService = new EpisodeService(episodeRatingRepository);

            //assert
            Assert.Throws(Is.TypeOf<Exception>()
                .And.Message.EqualTo("Episode doesn't exist"),
              () => _episodeService.GetEpisode(episodeId));
        }
    }
}
