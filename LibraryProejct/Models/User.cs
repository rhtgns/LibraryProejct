namespace LibraryProejct.Models
{
    public class User
    {
        public int Id { get; set; } // kullanıcıın kimliği 
        public string FullName { get; set; } // kullanıcın tam  adı 
        public string Email { get; set; } // E posta adresi 
        public string Password { get; set; } // Giriş parolası 
        public string PhoneNumber { get; set; } // telefon numarası 
        public DateTime JoinDate { get; set; } // kayıt veya giriş tarihi 

        






    }
}
