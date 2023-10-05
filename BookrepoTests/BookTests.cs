using Microsoft.VisualStudio.TestTools.UnitTesting;
using Bookrepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookrepo.Tests
{
    [TestClass()]
    public class BookTests
    {

        [TestMethod()]
        public void ValidateTitleTest()
        {

            // Check if a book that dosent meet the requiremtns of containing null, throws an arguemnt
            Book bookNull = new() {Id = 1, Price = 2000 };
            Assert.ThrowsException<ArgumentNullException>(() => bookNull.ValidateTitle());

            // Check if a book that dosent meet the requiremtns of contaning atleast 3 characters throws an arguemnt
            Book bookAtleastThreeCharacters = new() { Id = 2, Title = "A", Price = 200 };
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => bookAtleastThreeCharacters.ValidateTitle());

        }

        [TestMethod()]
        public void ValidatePriceTest()
        {

            // Check if a book that dosent meet the requiremtns of a price must be greater than 0 throws an arguemnt
            Book bookPriceGreaterThanZero = new() { Id = 3, Title = "A", Price = 0 };
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => bookPriceGreaterThanZero.ValidatePrice());

            // Check if a book that dosent meet the requiremtns of a price must be lesser than 1200 or 1200 throws an arguemnt
            Book bookPriceLesserThanTwelveHundred = new() { Id = 4, Title = "A", Price = 1300 };
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => bookPriceLesserThanTwelveHundred.ValidatePrice());

        }

        [TestMethod()]
        public void ToStringTest()
        {

            // Check if the tostring method returns the same values as the test book created
            Book bookToString = new() { Id = 5, Title = "A", Price = 500 };
            string execptedResult = "id: 5 Title: A Price: 500";
            Assert.AreEqual(execptedResult, bookToString.ToString());

        }
    }
}