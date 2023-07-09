namespace FestivalManager.Tests
{
    using System;
    using NUnit.Framework;
    using FestivalManager.Entities;
    class SongTest
    {
        private Song defaultSong;
        private TimeSpan duration;      
        private readonly string songName = "Bqla Roza";
        [SetUp]
        public void Setup()
        {
            this.duration = new TimeSpan(00, 05, 20);
            this.defaultSong = new Song(songName, duration);
        }
        [Test]
        public void CheckTheSongConstructorWorksCorrectly()
        {
            Assert.AreEqual(this.songName, this.defaultSong.Name);
            Assert.AreEqual(this.duration, this.defaultSong.Duration);
        }
        [Test]
        public void CheckSongToStringWorksCorrectly()
        {
            var resultToString = this.defaultSong.ToString();
            var durationFormat = string.Format("({0:mm\\:ss})", this.duration);
            string nameSongAndDurationFormat =this.songName +" "+ durationFormat;
            Assert.AreEqual(resultToString, nameSongAndDurationFormat);
        }      
    }
}
