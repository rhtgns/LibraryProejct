using LibraryProejct.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryProejct.Controllers
{
    public class BookController : Controller
    {
        private static List<Book> books = new List<Book>
        {
            new Book { Id = 1, Title = "Kitap 1", AuthorId = 1, Genre = "Roman", PublishDate = new DateTime(2020, 1, 1), ISBN = "123456789", CopiesAvailable = 5 },
            new Book { Id = 2, Title = "Kitap 2", AuthorId = 2, Genre = "Bilim Kurgu", PublishDate = new DateTime(2021, 2, 1), ISBN = "987654321", CopiesAvailable = 3 }
        };

        // Kitapların listesini gösterir
        public IActionResult List()
        {
            return View(books);
        }

        // Belirli bir kitabın detaylarını gösterir
        public IActionResult Details(int id)
        {
            var book = books.Find(b => b.Id == id); // Belirli kitabı bul
            if (book == null)
            {
                return NotFound(); // Kitap bulunamazsa 404 döner
            }
            return View(book);
        }

        // Yeni bir kitap eklemek için formu görüntüler
        public IActionResult Create()
        {
            return View();
        }

        // Yeni kitabı kaydetmek için POST isteği
        [HttpPost]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                book.Id = books.Count + 1; // Yeni ID oluştur
                books.Add(book); // Kitabı ekle
                return RedirectToAction("List"); // Listeye yönlendir
            }
            return View(book); // Hata varsa formu tekrar göster
        }

        // Var olan bir kitabı düzenler
        public IActionResult Edit(int id)
        {
            var book = books.Find(b => b.Id == id); // Belirli kitabı bul
            if (book == null)
            {
                return NotFound(); // Kitap bulunamazsa 404 döner
            }
            return View(book);
        }

        // Kitap güncelleme işlemi için POST isteği
        [HttpPost]
        public IActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                var existingBook = books.Find(b => b.Id == book.Id);
                if (existingBook != null)
                {
                    existingBook.Title = book.Title;
                    existingBook.AuthorId = book.AuthorId;
                    existingBook.Genre = book.Genre;
                    existingBook.PublishDate = book.PublishDate;
                    existingBook.ISBN = book.ISBN;
                    existingBook.CopiesAvailable = book.CopiesAvailable;
                    return RedirectToAction("List"); // Listeye yönlendir
                }
                return NotFound(); // Kitap bulunamazsa 404 döner
            }
            return View(book); // Hata varsa formu tekrar göster
        }

        // Kitabı silmek için bir onay sayfası sağlar
        public IActionResult Delete(int id)
        {
            var book = books.Find(b => b.Id == id); // Belirli kitabı bul
            if (book == null)
            {
                return NotFound(); // Kitap bulunamazsa 404 döner
            }
            return View(book);
        }

        // Kitap silme işlemi için POST isteği
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var book = books.Find(b => b.Id == id);
            if (book != null)
            {
                books.Remove(book); // Kitabı sil
                return RedirectToAction("List"); // Listeye yönlendir
            }
            return NotFound(); // Kitap bulunamazsa 404 döner
        }
    }
}
