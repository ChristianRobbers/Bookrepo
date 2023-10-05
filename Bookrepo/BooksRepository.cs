using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookrepo
{
    public class BooksRepository
    {

        List<Book> books = new();

        public BooksRepository()
        {
            books.Add(new Book() { Id = 1, Title = "titleA", Price = 100 });
            books.Add(new Book() { Id = 2, Title = "titleB", Price = 200 });
            books.Add(new Book() { Id = 3, Title = "titleC", Price = 300 });
            books.Add(new Book() { Id = 4, Title = "titleD", Price = 400 });
            books.Add(new Book() { Id = 5, Title = "titleE", Price = 500 });
        }

        public List<Book> Get(string? orderBy = null, string? nameFilter = null, int? priceFilter = null  )
        {

            List<Book> result = new(books);

            // Logic to order books by Title and Price
            if(orderBy != null)
            {
                result = orderBy switch
                {
                    "Title" => result.OrderBy(book => book.Title).ToList(),
                    "Price" => result.OrderByDescending(book => book.Price).ToList(),
                    _ => throw new ArgumentException("Invalid Orderby Value")
                };
            }

            // Filters after the book Title
            if(nameFilter != null)
            {
                result.Where(book => book.Title != null && book.Title.Contains(nameFilter)).ToList();
            }

            // Filters after the price
            if(priceFilter != null)
            {
                result.Where(book => book.Price == priceFilter).ToList();
            }

            // Checks if there is books in the list and throws Exception if its empty
            if(result.Count() == 0)
            {
                throw new ArgumentException("There is no books in the list");
            }

            return result;

        }

        public Book? GetById(int id)
        {
           
            return books.FirstOrDefault(book => book.Id == id);
        
        }

        public Book Add(Book book) 
        {
         
            book.ValidatePrice();
            book.ValidateTitle();
            books.Add(book);
            return book;
            
        }

        public Book Delete(int id) 
        {

            Book? bookToRemove = GetById(id);

            if (bookToRemove != null)
            {
                books.Remove(bookToRemove);
            }
            else
            {
                throw new ArgumentException($"The book with the id: {id} dosent exist");
            }

            return bookToRemove;
        
        }

        public Book Update(int id, Book book) 
        { 
        
            Book? bookToUpdate = GetById(id);

            if (bookToUpdate != null)
            {
                bookToUpdate.Title = book.Title;
                bookToUpdate.Price = book.Price;
            }
            else
            {
                throw new ArgumentException($"The book with the id: {id} dosent exist");
            }

            return bookToUpdate;

        }

    }
}
