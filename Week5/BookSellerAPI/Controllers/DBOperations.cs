using DAL.Model;
using EFLibCore;
using System.Linq;
namespace BookSellerAPI.Controllers
{

    public class DBOperations
    {
        private BookContext _context = new BookContext();
        LoggerCls logger = new LoggerCls();

        #region USER FONKS..
        public bool AddBook(Book _book)
        {
            try
            {
                _context.Book.Add(_book);
                _context.SaveChanges();
                return true;
            }
            catch (Exception exc)
            {
                logger.CreateLog("HATA " + exc.Message);
                return false;
            }
        }

        /// <summary>
        ///  This function get booklist 
        /// </summary>
        /// <returns></returns>
        public List<Book> GetBooks()
        {
            List<Book> books = new List<Book>();
            books = _context.Book.ToList();
            return books;
        }

        /// <summary>
        ///  This function delete a book from booklist by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool DeleteBook(int Id)
        {
            try
            {
                _context.Book.Remove(FindBook("", "", Id));
                _context.SaveChanges();
                return true;
            }
            catch (Exception exc)
            {
                logger.CreateLog("HATA " + exc.Message);
                return false;
            }
        }
        /// <summary>
        ///  This function updates a book from list by Id
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="book"></param>
        /// <returns></returns>
        public bool UpdateBook(int Id, Book book)
        {
            var existBook = _context.Book.FirstOrDefault(w => w.Id == Id);
            if (existBook == null)
            {
                return false;
            }
            else
            {
                existBook.Title = book.Title;
                existBook.Author = book.Author;
                existBook.Price = book.Price;
                _context.SaveChanges();
                return true;
            }
        }
        /// <summary>
        /// This function finds a book from booklist by Title , Author , Id 
        /// </summary>
        /// <param name="Title"></param>
        /// <param name="Author"></param>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Book FindBook(string Title = "", string Author = "", int Id = 0)
        {
            Book? book = new Book();
            if (!string.IsNullOrEmpty(Title) && !string.IsNullOrEmpty(Author))
                book = _context.Book.FirstOrDefault(m => m.Title == Title && m.Author == Author);
            else if (Id > 0)
            {
                book = _context.Book.FirstOrDefault(m => m.Id == Id);
            }
            return book;
        }

        #endregion

        #region TOKEN FONKS..
        public void CreateLogin(APIAuthority loginUser)
        {
            _context.APIAuthority.Add(loginUser);
            _context.SaveChanges();
        }

        public APIAuthority GetLogin(APIAuthority loginUser)
        {
            APIAuthority? user = new APIAuthority();
            if (!string.IsNullOrEmpty(loginUser.UserName) && !string.IsNullOrEmpty(loginUser.Password))
            {
                user = _context.APIAuthority.FirstOrDefault(m => m.UserName == loginUser.UserName && m.Password == loginUser.Password);
            }

            return user;

        }
        #endregion


    }
}

