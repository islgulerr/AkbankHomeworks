using BookSellerAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace BookSellerAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookOperationsController : ControllerBase
    {
        List<Book> bookList = new List<Book>();
        Result resultMessage = new Result();

        /// <summary>
        /// Eklenen kitapların tamamını fiyata göre sıralayarak getirir.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public List<Book> GetBook()
        {
            bookList = AddBook().OrderByDescending(x => x.Price).ToList();
            return bookList;
        }

        /// <summary>
        /// id'ye göre kitabı getirir.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public Book GetBook(int id)
        {
            List<Book> bookList = new List<Book>();
            bookList = AddBook();

            Book resultObject = new Book();
            //listenin içindeki tek bir elemani aliyor.
            resultObject = bookList.FirstOrDefault(x => x.Id == id);
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
            //liste dolduruluyor.
            bookList = AddBook();

            //Yeni eleman listede var mi?
            bool bookCheck = bookList.Select(x => x.Id == book.Id || x.Title == book.Title).FirstOrDefault();
            if (bookCheck == false)
            {
                bookList.Add(book);
                resultMessage.Status = 1;
                resultMessage.Message = "Yeni kitap listeye eklendi.";
            }
            else
            {
                resultMessage.Status = 0;
                resultMessage.Message = "Bu kitap listede var.";
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
            //liste dolduruluyor.
            bookList = AddBook();

            //null da olabilir.
            Book? oldBook = bookList.Find(o => o.Id == bookId);
            if (oldBook != null)
            {
                bookList.Add(newBook);
                bookList.Remove(oldBook);

                resultMessage.Status = 1;
                resultMessage.Message = "Kitap bilgileri basariyla guncellendi.";
                resultMessage.BookList = bookList;
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

                //liste dolduruluyor.
                bookList = AddBook();

                //null da olabilir.
                Book? oldBook = bookList.Find(o => o.Id == bookId);
                if (oldBook != null)
                {
                    bookList.Remove(oldBook);
                    resultMessage.Status = 1;
                    resultMessage.Message = "Kitap basariyla silindi.";
                    resultMessage.BookList = bookList;
                }
                else
                {
                    resultMessage.Status = 0;
                    resultMessage.Message = "Kitap sistemde kayitli degil.";
                }
            

            return resultMessage;

        }




        public List<Book> AddBook()
        {
            List<Book> bookList = new List<Book>();
            bookList.Add(new Book { Price = 33.80, Title = "Gece Yarısı Kütüphanesi", Author = "Matt Haig", Id = 1 });
            bookList.Add(new Book { Price = 31.20, Title = "Körlük", Author = "Jose Saramago", Id = 2 });
            bookList.Add(new Book { Price = 31.85, Title = "Seyir", Author = "Piraye", Id = 3 });
            bookList.Add(new Book { Price = 24.40, Title = "Şeker Portakalı", Author = "Jose Mauro De Vasconcelos", Id = 4 });
            bookList.Add(new Book { Price = 32.10, Title = "Harry Potter ve Felsefe Taşı", Author = "J. K. Rowling", Id = 5 });
            return bookList;
        }


    }
}
