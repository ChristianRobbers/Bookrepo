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
    public class BooksRepositoryTests
    {

        BooksRepository repository = new();

        [TestMethod()]
        public void GetByIdTest()
        {
            
            // Check if the method returns null if a book doesnt exists and check if it returns "not null / some item" if there is a book with the id
            Assert.IsNotNull(repository.GetById(1));
            Assert.IsNull(repository.GetById(6));

        }

        [TestMethod()]
        public void AddTest()
        {

            // Check if the new book exists in the repository
            Book newBook = new() { Id = 11, Title = "abcd", Price = 400};
            repository.Add(newBook);
            Assert.AreEqual(newBook, repository.GetById(11));

        }

        [TestMethod()]
        public void DeleteTest()
        {

            // Check if the repository have 4 books after deleting one of the books
            repository.Delete(1);
            Assert.AreEqual(4, repository.Get().Count());

            // Check if a book with a Id that dosent exists i throws a arguemnt error
            Assert.ThrowsException<ArgumentException>(() => repository.Delete(10));
            
        }

    }
}