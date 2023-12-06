﻿using Freecourse.Web.Models;
using Freecourse.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Freecourse.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IIdentityService _identityService;

        public AuthController(IIdentityService identityService)
        {
            _identityService = identityService;
        }

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInInput signInInput)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var response = await _identityService.SignIn(signInInput);

            if (!response.IsSuccessfull)
            {
                response.Errors.ForEach(error =>
                {
                    ModelState.AddModelError(string.Empty, error);
                });
            }

            return RedirectToAction(nameof(Index), "Home");
        }
    }
}
