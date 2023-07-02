using AspNet_Core_Identity.Models.Dto;
using AspNet_Core_Identity.Repositories.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AspNet_Core_Identity.Controllers
{
    public class UserAuthenticationController : Controller
    {
        private readonly IUserAuthenticationservice _authService;
        public UserAuthenticationController(IUserAuthenticationservice authService)
        {
            this._authService = authService;
        }


        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var result = await _authService.LoginAsync(model);
            if (result.StatusCode == 1)
            {
                return RedirectToAction("Display", "Dashboard");
            }
            else
            {
                TempData["msg"] = result.Message;
                return RedirectToAction(nameof(Login));
            }
        }

        public IActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationModel model)
        {
            if (!ModelState.IsValid) { return View(model); }
            model.Role = "user";
            var result = await this._authService.RegisterAsync(model);
            TempData["msg"] = result.Message;
            return RedirectToAction(nameof(Registration));
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await this._authService.LogoutAsync();
            return RedirectToAction(nameof(Login));
        }


      //  public async Task<IActionResult> RegisterAdmin()
       // {
        //    var model = new RegistrationModel
          //  {
         //       Username = "admin",
         //       Email = "admin@gmail.com",
         //       FirstName = "John",
         //       LastName = "Doe",
         //       Password = "Admin@12345#",
         //       Role = "admin"
         //   };

         //   var result = await this._authService.RegisterAsync(model);

       //    return Ok(result);
      //  }



        [Authorize]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePassword model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var result = await _authService.ChangePassword(model, User.Identity.Name);
            TempData["msg"] = result.Message;
            return RedirectToAction(nameof(ChangePassword));
        }

    }
}
