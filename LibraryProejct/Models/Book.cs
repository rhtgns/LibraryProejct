namespace LibraryProejct.Models
{
    public class Book
    {
        public int Id { get; set; } // kitap ııcn benzersiz bir kimlik 
        public string Title { get; set; } // kitap  baslıgı ekliyoruz
        public int AuthorId { get; set; }//yazarınn kimliği
        public string Genre { get; set; }//kitap türü
        public DateTime PublishDate { get; set; } // yayın tarihi
        public string ISBN { get; set; } // ISBN numarası
        public int CopiesAvailable { get; set; }//Mevcut kopya


        //author ile ilişkikendirme (navigasyon özelliği)
        public Author Author { get; set; }


    }
}
