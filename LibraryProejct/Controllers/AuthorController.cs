using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace LibraryProejct.Controllers
{
    public class AuthorController : Controller
    {
        // Yazarları bellekte tutacak liste
        private static List<Author> _authors = new List<Author>
        {
            new Author { Id = 1, FirstName = "John", LastName = "Doe" },
            new Author { Id = 2, FirstName = "Jane", LastName = "Smith" }
        };

        // Yazarları listeleme metodu
        public IActionResult List()
        {
            return View(_authors); // Yazarları View'e gönder
        }

        // Yazar detaylarını gösterme metodu
        public IActionResult Details(int id)
        {
            var author = _authors.FirstOrDefault(a => a.Id == id); // Yazar ID ile bul
            if (author == null)
            {
                return NotFound(); // Yazar bulunamazsa 404 döndür
            }
            return View(author); // Yazar detaylarını View'e gönder
        }

        // Yeni yazar ekleme metodu (GET)
        public IActionResult Create()
        {
            return View(); // Boş formu döndür
        }

        // Yeni yazar ekleme metodu (POST)
        [HttpPost]
        public IActionResult Create(Author model)
        {
            if (ModelState.IsValid)
            {
                // Yeni yazar ekle
                model.Id = _authors.Max(a => a.Id) + 1; // ID'yi artırarak ekle
                _authors.Add(model);
                return RedirectToAction("List"); // Listeye yönlendir
            }
            return View(model); // Form geçersizse aynı sayfayı döndür
        }

        // Yazar düzenleme metodu (GET)
        public IActionResult Edit(int id)
        {
            var author = _authors.FirstOrDefault(a => a.Id == id); // Yazar ID ile bul
            if (author == null)
            {
                return NotFound(); // Yazar bulunamazsa 404 döndür
            }
            return View(author); // Düzenleme formunu döndür
        }

        // Yazar düzenleme metodu (POST)
        [HttpPost]
        public IActionResult Edit(Author model)
        {
            var author = _authors.FirstOrDefault(a => a.Id == model.Id);
            if (author == null)
            {
                return NotFound(); // Yazar bulunamazsa 404 döndür
            }

            if (ModelState.IsValid)
            {
                // Yazarın bilgilerini güncelle
                author.FirstName = model.FirstName;
                author.LastName = model.LastName;
                return RedirectToAction("List"); // Listeye yönlendir
            }

            return View(model); // Form geçersizse aynı sayfayı döndür
        }

        // Yazar silme metodu (GET)
        public IActionResult Delete(int id)
        {
            var author = _authors.FirstOrDefault(a => a.Id == id); // Yazar ID ile bul
            if (author == null)
            {
                return NotFound(); // Yazar bulunamazsa 404 döndür
            }
            return View(author); // Silme onay sayfasını döndür
        }

        // Yazar silme metodu (POST)
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var author = _authors.FirstOrDefault(a => a.Id == id); // Yazar ID ile bul
            if (author != null)
            {
                _authors.Remove(author); // Yazar listeden sil
            }
            return RedirectToAction("List"); // Listeye yönlendir
        }
    }

    // Yazar model sınıfı
    public class Author
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
