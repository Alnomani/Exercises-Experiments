using numStoreLocations;

namespace numStoreLocations.UnitTests
{
    public class CandidateLocationsFinderTests
    {
        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void FindNumberOfValidLocations_SmallField1_ReturnTwo()
        {
            int[,] field =
            {
                { 0, 0, 0, 0 },
                { 0, 0, 1, 0 },
                { 1, 0, 0, 1 }
            };
            CandidateLocationsFinder game = new CandidateLocationsFinder(2, field);
            int result = game.FindNumberOfValidLocations();
            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void FindNumberOfValidLocations_MidField1_ReturnEight()
        {
            int[,] field =
            {
                { 0, 0, 0, 1 },
                { 0, 1, 0, 0 },
                { 0, 0, 1, 0 },
                { 1, 0, 0, 0 },
                { 0, 0, 0, 0 }
            };

            CandidateLocationsFinder game = new CandidateLocationsFinder(4, field);
            int result = game.FindNumberOfValidLocations();
            Assert.That(result, Is.EqualTo(8));
        }

        [Test]
        public void FindNumberOfValidLocations_MidLargeField1_ReturnOne()
        {
            int[,] field =
            {
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 1, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 1, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 1, 0, 0, 0, 0, 0, 0, 0 },
                { 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            };

            CandidateLocationsFinder game = new CandidateLocationsFinder(3, field);
            int result = game.FindNumberOfValidLocations();
            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void FindNumberOfValidLocations_OneHouse_ReturnOne()
        {
            int[,] field =
            {
                { 0, 0, 0, 0},
                { 0, 0, 1, 0}
            };
            CandidateLocationsFinder game = new CandidateLocationsFinder(1, field);
            int result = game.FindNumberOfValidLocations();
            Assert.That(result, Is.EqualTo(3));
        }
    }
}