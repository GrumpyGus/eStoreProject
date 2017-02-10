using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Identity;
using eStore.Models;
using Microsoft.AspNet.Http;
using eStore.ViewModels;
using eStore.Utils;
using Microsoft.AspNet.Authorization;

namespace eStore.Controllers
{
    public class RegisterController : Controller
    {
        UserManager<ApplicationUser> _usrMgr;
        SignInManager<ApplicationUser> _signInMgr;
        public RegisterController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _usrMgr = userManager;
            _signInMgr = signInManager;
        }

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        // POST:/Register/Register
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Register/Register")]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            //if (ModelState.IsValid)
            //{
                ApplicationUser user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await _usrMgr.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _signInMgr.SignInAsync(user, isPersistent: false);
                    HttpContext.Session.SetString(SessionVars.LoginStatus, "logged on as " + model.Email);
                    HttpContext.Session.SetString(SessionVars.Message, "Registered, as " + model.Email);
                    HttpContext.Session.SetString(SessionVars.User, model.Email);
                }
                else
                {
                    //Registration failed - Index method is returned
                    ViewBag.Message = "registration failed - " + result.Errors.First().Description;
                    return View("Index");
                }
            //}
            //else
            //{
            //    ViewBag.Message = "Registration Failed";
            //}

           return Redirect("/Home");
        }
    }
}