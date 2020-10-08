using System;
using System.Collections.Generic;
using _03_BadgesRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _03_BadgesTest
{
    [TestClass]
    public class BadgeTests
    {
        public Badges _badge;
        private BadgesRepository _repo;

        [TestInitialize]
        public void Arrange()
        {
            _repo = new BadgesRepository();
            List<string> doors = new List<string>() { "A7" };
            _badge = new Badges(12345, doors);
            _repo.AddBadge(_badge);
        }

        [TestMethod]
        public void AddBadge_ShouldBeTrue()
        {
            BadgesRepository repo = new BadgesRepository();
            List<string> doors = new List<string>() { "A7" };
            Badges badge = new Badges(12345, doors);
            bool addBadge = repo.AddBadge(badge);

            Assert.IsTrue(addBadge);
        }

        [TestMethod]
        public void AddBadgeDoor_ShouldBeTrue()
        {
            bool update = _repo.AddBadgeDoors(12345, "B2");
            Assert.IsTrue(update);
        }

        [TestMethod]
        public void RemoveBadgeDoor_ShouldBeTrue()
        {
            bool update = _repo.RemoveBadgeDoors(12345, "A5");
            Assert.IsTrue(update);
        }

        [TestMethod]
        public void GetAllBadges_ShouldBeTrue()
        {
            Dictionary<int, List<string>> badges = _repo.ShowAllBadges();
            bool containsKey = badges.ContainsKey(12345);
            Assert.IsTrue(containsKey);

            BadgesRepository repo = new BadgesRepository();
            List<string> doors = new List<string>() { "A7" };
            Badges badge = new Badges(12345, doors);
            bool addBadge = repo.AddBadge(badge);

            Dictionary<int, List<string>> valuePairs = repo.ShowAllBadges();
            bool contains = valuePairs.TryGetValue(12345, out doors);
            Assert.IsTrue(contains);
        }
    }
}