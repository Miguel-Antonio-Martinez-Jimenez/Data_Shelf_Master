using DataShelfMaster.Context;
using DataShelfMaster.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataShelfMaster.Services
{
    public class BookService
    {
        #region Book
        public void CreateBooks(Book request)
        {
            try
            {
                using(var _context = new ApplicationDBContext())
                {
                    Book book = new Book()
                    {
                        ISBN = request.ISBN,
                        Title = request.Title,
                        Author = request.Author,
                        Edition = request.Edition,
                        Status = request.Status
                    };
                    _context.Books.Add(book);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Bug: ", ex);
            }
        }
        public List<Book> ReadBooks()
        {
			try
			{
				var _context = new ApplicationDBContext();
				var book = _context.Books.ToList();
				return book;
			}
			catch (Exception ex)
			{
				throw new Exception("Bug: ",ex);
			}
        }
		public void UpdateBooks(Book request)
		{
            try
            {
                using(var _context = new ApplicationDBContext())
                {
                    var book = _context.Books.Where(s => s.ISBN == request.ISBN).First<Book>();
                    book.ISBN = request.ISBN;
                    book.Title = request.Title;
                    book.Author = request.Author;
                    book.Edition = request.Edition;
                    book.Status = request.Status;
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Bug: ", ex);
            }
        }
        public void DeleteBooks(Book request)
        {
            try
            {
                using(var _context = new ApplicationDBContext())
                {
                    var book = _context.Books.FirstOrDefault(s => s.ISBN == request.ISBN);
                    _context.Books.Remove(book);
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Bug: ", ex);
            }
        }
        //- - - Adicional - - -//
        public List<Book> SearchBooks(string searchText)
        {
            try
            {
                var _context = new ApplicationDBContext();
                var books = _context.Books.Where(book =>
                    book.ISBN.Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
                    book.Title.Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
                    book.Author.Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
                    book.Edition.Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
                    book.Status.Contains(searchText, StringComparison.OrdinalIgnoreCase)
                ).ToList();

                return books;
            }
            catch (Exception ex)
            {
                throw new Exception("Bug: ", ex);
            }
        }
        public void UpdateBookStatus(Book request)
        {
            try
            {
                using (var _context = new ApplicationDBContext())
                {
                    var book = _context.Books.Where(s => s.ISBN == request.ISBN).First<Book>();
                    book.Status = request.Status;
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Bug: ", ex);
            }
        }

        public string ValidateBook(Book request)
        {
            try
            {
                var _context = new ApplicationDBContext();
                var validate = _context.Books.Where(s => s.ISBN == request.ISBN).ToList();
                return validate.Count.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("Bug: ", ex);
            }
        }
        #endregion
    }
}
