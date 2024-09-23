namespace LibraryProejct.Models
{
    public class Author
    {
        public int Id { get; set; }//yazar icin benzersinz bir kimlik oluşturdum
        public string FirstName { get; set; } //yazarın adı
        public string LastName { get; set; } // yazarın soy adı
        public DateTime DateOfBirth { get; set; }// yazarın dogum günü


        //burada yazarın kitaplarıyla ilişkilendirme yapıyoruz 
        public ICollection<Book> Books { get; set; }
                                             

    }
}
