namespace FestivalManager.Tests
{
    using NUnit.Framework;
    using FestivalManager.Entities;
    class PerformerTest
    {
        private Performer performer;     
        private readonly string defaultFirsName = "Lyubomir";
        private readonly string defaultLastName = " Shumantov";
        private readonly int defaultAge = 18;
        [SetUp]
        public void Setup()
        {
            this.performer = new Performer(defaultFirsName, defaultLastName, defaultAge);
        }
        [Test]
        public void CheckThePerformerConstructorWorksCorrectly()
        {
            Assert.AreEqual(this.defaultFirsName + " " + this.defaultLastName, this.performer.FullName);
            Assert.AreEqual(this.defaultAge, this.performer.Age);
            Assert.IsNotNull(this.performer.SongList);
        }
        [Test]
        public void CheckThePerformerToStringWorksCorrectly()
        {
            var resultToString = this.performer.ToString();
            string fullName = this.defaultFirsName + " " + this.defaultLastName;
            Assert.AreEqual(resultToString, fullName);
        }        
    }
}
