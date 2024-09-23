// bu sayfa kullanıcı kayıt gibi işlemleri yönetecek 

using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace LibraryProejct.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult SignUp() { return View(); /* Kayıt işlemi */ }
        public IActionResult Login() { return View(); /* Giriş işlemi */ }
        
        
    }


}
