using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WizLibDataAccess.Data;
using WizLibModel.Models;
using WizLibModel.ViewModels;

namespace WizLib.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public BookController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            //List<Book> books = _dbContext.Books.ToList();
            //foreach (var book in books)
            //{
            //    //Least efficient: for each book query will be executed to load publisher
            //    book.Publisher = _dbContext.Publishers.FirstOrDefault(i => i.Publisher_Id == book.Publisher_Id);

            //    //More efficient: Explicit loading
            //    //will execute query for the distinct publishers only
            //    _dbContext.Entry(book).Reference(i => i.Publisher).Load();
            //}

            //Most efficient: Eager loading
            //everything will be combined in one single query using joins
            List<Book> books = _dbContext.Books.Include(i => i.Publisher).ToList();

            return View(books);
        }

        public IActionResult Upsert(int? id)
        {
            BookViewModel obj = new BookViewModel();
            //projection example
            obj.PublisherList = _dbContext.Publishers.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Publisher_Id.ToString()
            });
            if (id == null)
            {
                return View(obj);
            }
            //this for edit
            obj.Book = _dbContext.Books.FirstOrDefault(u => u.Book_Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(BookViewModel obj)
        {
            if (obj.Book.Book_Id == 0)
            {
                //this is create
                _dbContext.Books.Add(obj.Book);
            }
            else
            {
                //this is an update
                _dbContext.Books.Update(obj.Book);
            }
            _dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            BookViewModel obj = new BookViewModel();

            if (id == null)
            {
                return View(obj);
            }
            //this for edit
            //obj.Book = _dbContext.Books.FirstOrDefault(i => i.Book_Id == id);
            //obj.Book.BookDetail = _dbContext.BookDetails.FirstOrDefault(i => i.BookDetail_Id == obj.Book.BookDetail_Id);

            //efficient way: eager loading
            obj.Book = _dbContext.Books.Include(i => i.BookDetail).FirstOrDefault(i => i.Book_Id == id);

            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Details(BookViewModel obj)
        {
            if (obj.Book.BookDetail.BookDetail_Id == 0)
            {
                //this is create
                _dbContext.BookDetails.Add(obj.Book.BookDetail);
                _dbContext.SaveChanges();

                var BookFromDb = _dbContext.Books.FirstOrDefault(i => i.Book_Id == obj.Book.Book_Id);
                BookFromDb.BookDetail_Id = obj.Book.BookDetail.BookDetail_Id;
                _dbContext.SaveChanges();
            }
            else
            {
                //this is an update
                _dbContext.BookDetails.Update(obj.Book.BookDetail);
                _dbContext.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var objFromDb = _dbContext.Books.FirstOrDefault(u => u.Book_Id == id);
            _dbContext.Books.Remove(objFromDb);
            _dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult ManageAuthors(int id)
        {
            BookAuthorViewModel obj = new BookAuthorViewModel
            {
                BookAuthorList = _dbContext.BookAuthors.Include(u => u.Author).Include(u => u.Book)
                                    .Where(u => u.Book_Id == id).ToList(),
                BookAuthor = new BookAuthor()
                {
                    Book_Id = id
                },
                Book = _dbContext.Books.FirstOrDefault(u => u.Book_Id == id)
            };
            List<int> tempListOfAssignedAuthors = obj.BookAuthorList.Select(u => u.Author_Id).ToList();
            //NOT IN Clause in LINQ
            //get all the authors whos id is not in tempListOfAssignedAuthors
            var tempList = _dbContext.Authors.Where(u => !tempListOfAssignedAuthors.Contains(u.Author_Id)).ToList();

            obj.AuthorList = tempList.Select(i => new SelectListItem
            {
                Text = i.FullName,
                Value = i.Author_Id.ToString()
            });

            return View(obj);
        }

        [HttpPost]
        public IActionResult ManageAuthors(BookAuthorViewModel bookAuthorVM)
        {
            if (bookAuthorVM.BookAuthor.Book_Id != 0 && bookAuthorVM.BookAuthor.Author_Id != 0)
            {
                _dbContext.BookAuthors.Add(bookAuthorVM.BookAuthor);
                _dbContext.SaveChanges();
            }
            return RedirectToAction(nameof(ManageAuthors), new { @id = bookAuthorVM.BookAuthor.Book_Id });
        }

        [HttpPost]
        public IActionResult RemoveAuthors(int authorId, BookAuthorViewModel bookAuthorVM)
        {
            int bookId = bookAuthorVM.Book.Book_Id;
            BookAuthor bookAuthor = _dbContext.BookAuthors
                                        .FirstOrDefault(i => i.Author_Id == authorId && i.Book_Id == bookId);

            _dbContext.BookAuthors.Remove(bookAuthor);
            _dbContext.SaveChanges();
            return RedirectToAction(nameof(ManageAuthors), new { @id = bookId });
        }

        public IActionResult PlayGround()
        {
            //var bookTemp = _dbContext.Books.FirstOrDefault();
            //bookTemp.Price = 100;

            //var bookCollection = _dbContext.Books;
            //double totalPrice = 0;

            //foreach (var book in bookCollection)
            //{
            //    totalPrice += book.Price;
            //}

            //var bookList = _dbContext.Books.ToList();
            //foreach (var book in bookList)
            //{
            //    totalPrice += book.Price;
            //}

            //var bookCollection2 = _dbContext.Books;
            //var bookCount1 = bookCollection2.Count();

            //var bookCount2 = _dbContext.Books.Count();

            IEnumerable<Book> BookList1 = _dbContext.Books;
            var FilteredBook1 = BookList1.Where(b => b.Price > 500).ToList();

            IQueryable<Book> BookList2 = _dbContext.Books;
            var fileredBook2 = BookList2.Where(b => b.Price > 500).ToList();

            //var category = _dbContext.Categories.FirstOrDefault();
            //_dbContext.Entry(category).State = EntityState.Modified;
            //_dbContext.SaveChanges();

            //Updating Related Data
            //var bookTemp1 = _dbContext.Books.Include(b => b.BookDetail).FirstOrDefault(b => b.Book_Id == 4);
            //bookTemp1.BookDetail.NumberOfChapters = 2222;
            //bookTemp1.Price = 12345;
            //_dbContext.Books.Update(bookTemp1);
            //_dbContext.SaveChanges();

            //var bookTemp2 = _dbContext.Books.Include(b => b.BookDetail).FirstOrDefault(b => b.Book_Id == 4);
            //bookTemp2.BookDetail.Weight = 3333;
            //bookTemp2.Price = 123456;
            //_dbContext.Books.Attach(bookTemp2);
            //_dbContext.SaveChanges();

            //RAW SQL
            //var bookRaw = _dbContext.Books.FromSqlRaw("Select * from dbo.books").ToList();

            //SQL Injection attack prone
            //int id = 2;
            //var bookTemp1 = _dbContext.Books.FromSqlInterpolated($"Select * from dbo.books where Book_Id={id}").ToList();
            //var booksSproc = _dbContext.Books.FromSqlInterpolated($" EXEC dbo.getAllBookDetails {id}").ToList();

            //.NET 5 only
            //var BookFilter1 = _dbContext.Books.Include(e => e.BookAuthors.Where(p => p.Author_Id == 5)).ToList();
            //var BookFilter2 = _dbContext.Books.Include(e => e.BookAuthors.OrderByDescending(p => p.Author_Id).Take(2)).ToList();

            return RedirectToAction(nameof(Index));
        }
    }
}
