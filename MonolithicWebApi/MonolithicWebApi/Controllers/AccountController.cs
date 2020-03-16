using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common.Interfaces.Services;
using Core.DTO;
using Core.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MonolithicWebApi.Models;
using Persistence.DAL;

namespace MonolithicWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ILibraryService _libraryService;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, ILibraryService libraryService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _libraryService = libraryService;
            //_userManager.UserValidators = UserValidator<User>(UserManager<User>) { AllowOnlyAlphanumericUserNames = false };
            //_userManager.UserValidators   = new UserValidator<User>() { AllowOnlyAlphanumericUserNames = false };

            _userManager.UserValidators.Clear();
            //_userManager.UserValidators.Add(new UserValidator<User>() { AllowOnlyAlphanumericUserNames = false };)
        
        //var ee = new UserValidator<User>(_userManager) { AllowOnlyAlphanumericUserNames = false };
        }


        [HttpPost]
        public async Task<IActionResult> Register([FromBody]UserAccountModel account)
        {
            //var newUser = new IdentityUser(account.Email)
            //{
            //    Email = account.Email
            //};

            var newUser = new User()
            {
                Email = account.Email
            };

            //TODO create Library

            var libraryId = _libraryService.Add(new LibraryDTO()
            {
                Name = newUser.Email + "_Library"
            });


            newUser.LibraryId = libraryId;

            newUser.YearOfBirth = 1997;
            //newUser.SecurityStamp = Guid.NewGuid().ToString();


            var creationResult = await _userManager.CreateAsync(newUser, account.Password);

            if (!creationResult.Succeeded)
            {
                return BadRequest(creationResult.Errors.Select(error => error.Description).Aggregate((errorDescriptions, identityError) => errorDescriptions + $", {identityError}"));
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<bool> Login([FromBody]UserAccountModel account)
        {
            var user = await _userManager.FindByEmailAsync(account.Email);
            if (user == null)
                return false;

            var signInResult = await _signInManager.PasswordSignInAsync(user, account.Password, isPersistent: true, lockoutOnFailure: false); //lockout on failure is off because this is a demo

            if (!signInResult.Succeeded)
                return false;

            return true;
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return NoContent();
        }



        //[HttpPost]

        //public bool Login([FromBody] UserAccountModel account)
        //{
        //    var ee = account;
        //    return true;
            
        //}
    }
}