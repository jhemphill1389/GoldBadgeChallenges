using System;
using System.Collections.Generic;
using _02_ClaimsRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace _02_ClaimsTest
{
    [TestClass]
    public class ClaimsTests
    {
        private Claims _item;
        private ClaimsRepo _repo;

        [TestInitialize]
        public void Arrange()
        {
            DateTime claimDate1 = new DateTime(2017, 08, 24);
            DateTime incidentDate1 = new DateTime(2017, 08, 25);
            _item = new Claims(1, ClaimType.Car, "Windshield cracked", 375m, incidentDate1, claimDate1);
            _repo = new ClaimsRepo();
            _repo.AddClaim(_item);
        }

        [TestMethod]
        public void AddClaim_ShouldBeTrue()
        {
            DateTime claimDate1 = new DateTime(2017, 08, 24);
            DateTime incidentDate1 = new DateTime(2017, 08, 25);
            _item = new Claims(1, ClaimType.Car, "Windshield cracked", 375m, incidentDate1, claimDate1);
            ClaimsRepo repo = new ClaimsRepo();
            bool addClaim = repo.AddClaim(_item);
            Assert.IsTrue(addClaim);
        }

        [TestMethod]
        public void GetAllClaims_ShouldReturnTrue()
        {
            List<Claims> claims = _repo.GetAllClaims();
            bool list = claims.Contains(_item);
            Assert.IsTrue(list);
        }

        [TestMethod]
        public void RemoveClaim_ShouldReturnTrue()
        {
            bool removed = _repo.RemoveClaim(_item);
            Assert.IsTrue(removed);
        }
    }
}