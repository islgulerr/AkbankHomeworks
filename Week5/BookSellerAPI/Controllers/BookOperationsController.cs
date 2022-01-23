using DAL.Model;
using Microsoft.AspNetCore.Mvc;

namespace BookSellerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookOperationsController : ControllerBase
    {
        Result resultMessage = new Result();
        DBOperations dbOperation = new DBOperations();

        /// <summary>
        /// Eklenen kitapların tamamını fiyata göre sıralayarak getirir.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Book> GetBook()
        {
            return dbOperation.GetBooks();
        }

        /// <summary>
        /// id'ye göre kitabı getirir.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Book GetBookById(int id)
        {  
            Book resultObject = dbOperation.FindBook("", "", id);
            return resultObject;
        }


        /// <summary>
        /// Yeni kitap eklenir.
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpPost]
        public Result PostBook(Book book)
        {
           
            Book? rBook = dbOperation.FindBook(book.Title, book.Author, book.Id);
            bool bookCheck = (rBook != null) ? true : false;
            if (bookCheck == false)
            {
                if (dbOperation.AddBook(book) == true)
                {
                    resultMessage.Status = 1;
                    resultMessage.Message = "Yeni kitap listeye eklendi.";
                }
                else
                {
                    resultMessage.Status = 0;
                    resultMessage.Message = "Kitap listeye eklenemedi.";
                }
            }
            else
            {
                resultMessage.Status = 0;
                resultMessage.Message = "Bu kitap listede zaten var.";
            }
            return resultMessage;
        }



        /// <summary>
        /// Girilen id'ye ait kitap bilgileri güncellenir.
        /// </summary>
        /// <param name="bookId"></param>
        /// <param name="newBook"></param>
        /// <returns></returns>
        [HttpPut("{bookId}")]
        public Result UpdateBook(int bookId, Book newBook)
        {
            bool book = dbOperation.UpdateBook(Id: bookId, book: newBook);
            
            if (book != null)
            {
                resultMessage.Status = 1;
                resultMessage.Message = "Kitap bilgileri basariyla guncellendi.";
            }
            else
            {
                resultMessage.Status = 0;
                resultMessage.Message = "Kitap sistemde kayitli degil.";
            }

            return resultMessage;
        }

        /// <summary>
        /// Id bilgisi girilen kitap listeden silinir.
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        [HttpDelete("{bookId}")]
        public Result DeleteBook(int bookId)
        {

                if (dbOperation.DeleteBook(bookId))
                {
                    resultMessage.Status = 1;
                    resultMessage.Message = "Kitap basariyla silindi.";
                }
                else
                {
                    resultMessage.Status = 0;
                    resultMessage.Message = "Kitap sistemde kayitli degil.";
                }

            return resultMessage;

        }

    }
}
