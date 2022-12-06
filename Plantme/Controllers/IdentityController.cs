using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Plantme.Models;

namespace Plantme.Controllers
{
    public class IdentityController : Controller
    {

        private UserManager<IdentityUser> _userManager;
        private SignInManager<IdentityUser> _signInManager;

        public IdentityController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register(string? returnPage = null)
        {
            RegisterObject registerObject = new RegisterObject();
            registerObject.ReturnPage = returnPage;
            return View(registerObject.ReturnPage);
        }

        public IActionResult SignIn(string returnPage = null)
        {
            LogInObject logInObject = new LogInObject();
            logInObject.ReturnPage = returnPage;
            return View(logInObject.ReturnPage);
        }

        [HttpPost]
        public async Task<IActionResult> OnPostRegister(RegisterObject registerObject ,string? returnPage = null)
        {

            registerObject.ReturnPage = returnPage;
            //returnPage= returnPage ?? Url.Content("/Views/Identity/Register");
            
            if (ModelState.IsValid)
            {
                var user = new User {
                    UserName = registerObject.UserLoginName, Email = registerObject.UserEmail, 
                    PhoneNumber = registerObject.UserPhoneNo, Location = registerObject.Location, UserFirstName = registerObject.UserFirstName, 
                    UserSurname = registerObject.UserSurname,   Address = registerObject.Address
                };
                var result = await _userManager.CreateAsync(user, registerObject.Password);
                if (result.Succeeded)
                {

                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return RedirectToAction("Index", "Home");
                 
                }
            }
            return View("Register");

        }

        public async Task<IActionResult> SingIn(LogInObject logInObject, string returnPage = null)
        {
            


            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(logInObject.LogInEmail);
                //var password = await _userManager.CheckPasswordAsync(user, logInObject.LogInPassword);
                //if (password == false)
                //{
                //    return View("SignIn");
                //}
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, 
                // set lockoutOnFailure: true

                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index", "Home");



            }

            // If we got this far, something failed, redisplay form
            return LocalRedirect(returnPage);
        }


        public async Task<IActionResult> SignOut(string returnPage = null)
        {
            await _signInManager.SignOutAsync();

            //if (returnUrl != null)
            //{
            return LocalRedirect(returnPage);
            ////}
            ////else
            ////{
            //return RedirectToPage(returnurl);
            //}
            
        }
    }

}
