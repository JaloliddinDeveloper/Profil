using Microsoft.AspNetCore.Mvc;

namespace Profil.Controllers
{
    public class HomeController:Controller
    {
        public IActionResult Index()=>
             View();  
    }
}
