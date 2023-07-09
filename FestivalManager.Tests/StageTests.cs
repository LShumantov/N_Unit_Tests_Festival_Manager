namespace FestivalManager.Tests
{
    using System;
    using NUnit.Framework;
    using FestivalManager.Entities;

    [TestFixture]
    public class StageTests
    {
        private Stage stage;
        private Song defaultSong;
        private TimeSpan duration;
        private Performer performer;
        private readonly string songName = "Bqla Roza";       
        private readonly string defaultFirsName = "Lyubomir";
        private readonly string defaultLastName = " Shumantov";
        private readonly int defaultAge = 18;
        private readonly int lessAge = 8;             
        [SetUp]
        public void Setup()
        {
            this.stage = new Stage();
            this.defaultSong = new Song(songName, duration);
            this.duration = new TimeSpan(0, 05, 20);          
            this.performer = new Performer(defaultFirsName, defaultLastName, defaultAge);                    
        }      
        [Test]
        public void CheckStageConstructorWorksCorrectly()
        {
            Assert.That(this.stage.Performers, Is.Empty);
        }
        [Test]
        public void AddPerformerExceptionCanNotBeNullMessage()
        {
            var ArgumentNullException = string.Format("Can not be null.");
            Assert.Throws<ArgumentNullException>(() =>
            {
                this.stage.AddPerformer(null);
            }, ArgumentNullException
                );
        }
        [Test]
        public void AgeArgumentException()
        {
            var newPerformer = new Performer(defaultFirsName,defaultLastName,lessAge);           
            Assert.Throws<ArgumentException>(() =>
            {
               this.stage.AddPerformer(newPerformer);
            }, "You can only add performers that are at least 18.");
        }
        [Test]
        public void AddPerformer()
        {
            this.stage.AddPerformer(this.performer);
            Assert.That(this.stage.Performers.Count, Is.EqualTo(1));
            Assert.That(this.stage.Performers, Has.Member(this.performer));
        }
        [Test]
        public void AddSong()
        {
            try
            {
                this.stage.AddSong(this.defaultSong);
                Assert.IsTrue(true);
            }
            catch
            {
                Assert.IsTrue(false);
            }
        }
        [Test]
        public void AddSongExceptionCanNotBeNullMessage()
        {
            var ArgumentNullException = string.Format("Can not be null.");
            Assert.Throws<ArgumentNullException>(() =>
            {
                this.stage.AddSong(null);
            }, ArgumentNullException
                );
        }      
        [Test]
        public void DurationSongLessThanOneMinuteLongArgumentException()
        {
            var durationTestTotalMinutes = new TimeSpan(0, 00, 1);
            var newSong = new Song("Zaichenceto Bqlo", durationTestTotalMinutes);
            Assert.Throws<ArgumentException>(() =>
            {
                this.stage.AddSong(newSong);
            }, "You can only add songs that are longer than 1 minute.");
        }
        [Test]
        public void PerformerSongListAreDiferentFromNuul()
        {
            this.stage.AddPerformer(this.performer);
            this.performer.SongList.Add(defaultSong);
            Assert.That(this.performer.SongList.Count, Is.Not.EqualTo(null));            
            Assert.That(this.performer.SongList.Count, Is.EqualTo(1));
        }
        [Test]
        public void AddSongToPerformer()
        {          
            this.stage.AddPerformer(this.performer);          
            this.stage.AddSong(this.defaultSong);           
            var resultAddSongToPerformer = this.stage.AddSongToPerformer(this.defaultSong.Name, this.performer.FullName);         
            var resultFormat = string.Format("{0} will be performed by {1}", this.defaultSong, this.performer.FullName);
            Assert.That(resultAddSongToPerformer, Is.EqualTo(resultFormat));           
        }
        [Test]
        public void AddSongToPerformerExceptionCanNotBeNullMessageForSongName()
        {
            this.stage.AddPerformer(this.performer);
            this.stage.AddSong(this.defaultSong);
            var ArgumentNullException = string.Format("Can not be null.");
            Assert.Throws<ArgumentNullException>(() =>
            {
                this.stage.AddSongToPerformer(null, this.performer.FullName);

            }, ArgumentNullException
               );
        }
        [Test]
        public void AddSongToPerformerExceptionCanNotBeNullMessageForPerformerName()
        {           
            this.stage.AddPerformer(this.performer);
            this.stage.AddSong(this.defaultSong);
            var ArgumentNullException = string.Format("Can not be null.");
            Assert.Throws<ArgumentNullException>(() =>
            {
                this.stage.AddSongToPerformer(this.defaultSong.Name, null);

            }, ArgumentNullException
                );
        }
        [Test]
        public void AddSongToPerformerExceptionCanNotBeNullMessageForGetPerformer()
        {
            string defaultFirsNames = "Tosho";
            string defaultLastName = " Toshev";
            int age = 44;
            var diferentPerformer = new Performer(defaultFirsNames, defaultLastName, age);       
            this.stage.AddPerformer(diferentPerformer);
            this.stage.AddSong(this.defaultSong);
            this.stage.AddSongToPerformer(this.defaultSong.Name, diferentPerformer.FullName);
            Assert.Throws<ArgumentException>(() =>
            {
              
                this.stage.AddSongToPerformer(this.defaultSong.Name, this.performer.FullName);

            }, "There is no performer with this name.");
        }
        [Test]
        public void AddSongToPerformerExceptionCanNotBeNullMessageForGetSong()
         {      
            string name = "Mila moq mamo.";
            TimeSpan diferentTimeSpan =  new TimeSpan(0, 05, 20);
            var diferentSong = new Song(name,diferentTimeSpan);
            this.stage.AddPerformer(this.performer);
            this.stage.AddSong(diferentSong);
            this.stage.AddSongToPerformer(diferentSong.Name, this.performer.FullName);
            Assert.Throws<ArgumentException>(() =>
            {
                this.stage.AddSongToPerformer(this.defaultSong.Name, this.performer.FullName);

            }, "There is no songs with this name.");
         }       
        [Test]
        public void Play()
        {
            var durationTestTotalMinutes = new TimeSpan(0, 60, 1);
            var newSong = new Song("Zaichenceto Bqlo", durationTestTotalMinutes);
            this.stage.AddPerformer(this.performer);
            this.stage.AddSong(this.defaultSong);
            this.stage.AddSong(newSong);          
            this.stage.AddSongToPerformer(this.defaultSong.Name, this.performer.FullName);
            this.stage.AddSongToPerformer(newSong.Name, this.performer.FullName);
            var returnResultFromPlay = this.stage.Play();
            var performersCount = this.stage.Performers.Count;
            var performerSongListCount = this.performer.SongList.Count;
            var result = string.Format("{0} performers played {1} songs", performersCount, performerSongListCount);
            Assert.That(returnResultFromPlay, Is.EqualTo(result));
        }
    }
}