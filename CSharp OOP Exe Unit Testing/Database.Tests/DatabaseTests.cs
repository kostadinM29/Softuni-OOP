using NUnit.Framework;
using System;
using System.Linq;

namespace Tests
{
    public class DatabaseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorShouldBeInitializedWith16Elements()
        {
            int[] nums = Enumerable.Range(1, 16).ToArray();

            Database database = new Database(nums);

            var expectedResult = 16;
            var actualResult = database.Count;

            Assert.AreEqual(actualResult, expectedResult);
        }
        [Test]
        public void ConstructorShouldThrowExceptionIfThereAreNot16Elements()
        {
            int[] nums = Enumerable.Range(1, 10).ToArray();

            Database database = new Database(nums);

            var expectedResult = 10;
            var actualResult = database.Count;

            Assert.AreEqual(actualResult, expectedResult);
        }
        [Test]
        public void AddOperationShouldAddElementAtNextFreeCell()
        {
            //arrange
            int[] nums = Enumerable.Range(1, 10).ToArray();

            Database database = new Database(nums);

            //act
            database.Add(5);

            var allElements = database.Fetch();

            //assert
            var expectedResult = 5;
            var actualResult = allElements[10];

            Assert.AreEqual(expectedResult, actualResult);
        }
        [Test]
        public void AddOperationShouldThrowExceptionIfElementsAreAbove16()
        {
            int[] nums = Enumerable.Range(1, 16).ToArray();

            Database database = new Database(nums);

            Assert.Throws<InvalidOperationException>(() => database.Add(10));
        }
        [Test]
        public void RemoveOperationShouldSupportOnlyRemovingAnElementAtTheLastIndex()
        {
            //arrange
            int[] nums = Enumerable.Range(1, 10).ToArray();

            Database database = new Database(nums);
            //act
            database.Remove();
            //assert
            var expectedResult = 9;
            var actualResult = database.Fetch()[8];

            var expectedCount = 9;
            var actualCount = database.Count;

            Assert.AreEqual(expectedResult, actualResult);
            Assert.AreEqual(expectedCount, actualCount);
        }
        [Test]
        public void RemoveOperationShouldThrowExceptionIfCountIsZero()
        {
            Database database = new Database();

            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }
        [Test]
        public void FetchShouldReturnAllElements()
        {
            int[] nums = Enumerable.Range(1, 5).ToArray();

            Database database = new Database(nums);

            var allElements = database.Fetch();

            int[] expectedResult = { 1, 2, 3, 4, 5 };
            CollectionAssert.AreEqual(expectedResult, allElements);
        }
    }
}