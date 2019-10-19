// I, Nigel Reimer, student number 000730702, certify that this material is my
// original work. No other person's work has been used without due
// acknowledgement and I have not made my work available to anyone else.

using Lab1A.Data;
using Lab1A.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Lab1ATest
{
    [TestClass]
    public class UnitTest1
    {
        private static DealershipMgr _dealershipMgr;

        [ClassInitialize]
        public static void Initialize(TestContext tc)
        {
            List<Dealership> dealerships = new List<Dealership> {
                new Dealership { Email = "dealer.one@website.com", Id = 1, Name = "Dealer One", PhoneNumber = "(111) 111-1111" },
                new Dealership { Email = "dealer.two@website.com", Id = 2, Name = "Dealer Two", PhoneNumber = "(222) 222-2222" }
            };

            _dealershipMgr = new DealershipMgr(dealerships);
        }

        [TestMethod]
        public void ValidGet()
        {
            // Arrange

            // Act
            Dealership dealership = _dealershipMgr.Get(1);

            // Assert
            Assert.AreEqual("dealer.one@website.com", dealership.Email);
            Assert.AreEqual(1, dealership.Id);
            Assert.AreEqual("Dealer One", dealership.Name);
            Assert.AreEqual("(111) 111-1111", dealership.PhoneNumber);
        }

        [TestMethod]
        public void InvalidGet()
        {
            // Arrange

            // Act
            Dealership dealership = _dealershipMgr.Get(3);

            // Assert
            Assert.IsNull(dealership);
        }

        [TestMethod]
        public void ValidPost()
        {
            // Arrange
            Dealership dealership = new Dealership { Email = "dealer.three@website.com", Id = 3, Name = "Dealer Three", PhoneNumber = "(333) 333-3333" };

            // Act
            _dealershipMgr.Post(dealership);

            // Assert
            Assert.AreEqual(3, _dealershipMgr.Get().Count);
        }


        [TestMethod]
        public void InvalidPost()
        {
            // Arrange
            Dealership dealership = null;

            // Act
            _dealershipMgr.Post(dealership);

            // Assert
            Assert.AreEqual(3, _dealershipMgr.Get().Count);
        }
    }
}
