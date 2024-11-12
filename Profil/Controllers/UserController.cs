using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Profil.Models.Foundations.Users;
using Profil.Services.Foundations.Users;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Profil.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly IWebHostEnvironment webHostEnvironment;

        public UserController(
            IUserService userService,
            IWebHostEnvironment webHostEnvironment)
        {
            this.userService = userService;
            this.webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(User user, IFormFile UserImage)
        {
            if (UserImage != null)
            {
                string uploadsFolder = Path.Combine(this.webHostEnvironment.WebRootPath, "uploads");
                string uniqueFileName = Guid.NewGuid().ToString() + "_" + UserImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                Directory.CreateDirectory(uploadsFolder); 

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await UserImage.CopyToAsync(fileStream);
                }

                user.UserImage = uniqueFileName;
            }

           this.userService.AddUserAsync(user);

            return RedirectToAction("Index");
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var users = await this.userService.RetrieveAllUsersAsync();
            return View(users);
        }
    }
}
