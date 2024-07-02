using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NoteKeeper.Web.Models.Domain.Account;
using NoteKeeper.Web.Models.DTO.AccountDTOs;

namespace NoteKeeper.Web.Controllers
{
    public class AccountController : Controller
    {
        private SignInManager<UserProfile> _signInManager;
        private UserManager<UserProfile> _userManager;

        public AccountController(SignInManager<UserProfile> signInManager, UserManager<UserProfile> userManager)
        {
            this._signInManager = signInManager;
            this._userManager = userManager;

        }


        public IActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction(nameof(NoteController.Index), "Note");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserProfileCreateDTO userProfileCreateDTO)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction(nameof(NoteController.Index), "Note");
            }

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Register", "Something is wrong");
                return View(userProfileCreateDTO);
            }
            UserProfile userProfile = new UserProfile()
            {
                UserName = userProfileCreateDTO.Email,
                Email = userProfileCreateDTO.Email
            };
            var result = await this._userManager.CreateAsync(userProfile, userProfileCreateDTO.Password);

            if (result.Succeeded)
            {
                await this._signInManager.SignInAsync(userProfile, isPersistent: true);
                return RedirectToAction(nameof(NoteController.Index), "Note");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("Register", error.Description);
                }
            }
            return View(userProfileCreateDTO);
        }

        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction(nameof(NoteController.Index), "Note");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            if (!ModelState.IsValid)
            {
                return View(loginDTO);
            }


            var result = await this._signInManager.PasswordSignInAsync(loginDTO.Email, loginDTO.Password, isPersistent: true, lockoutOnFailure: true);

            if (result.Succeeded)
            {
                return RedirectToAction(nameof(NoteController.Index), "Note");
            }

            return View(loginDTO);
        }

        public async Task<IActionResult> Logout()
        {
            await this._signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}
