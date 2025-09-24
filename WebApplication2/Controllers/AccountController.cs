using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.Services;

namespace WebApplication2.Controllers;

public class AccountController : Controller
{
    private readonly UserManager<ApplicationUser> _userManager;

    private readonly SignInManager<ApplicationUser> _singInManager;
    // GET
    public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> singInManager)
    {
        _userManager = userManager;
        _singInManager = singInManager;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel viewModel)
    {
        if (!ModelState.IsValid) return View(viewModel);
        var result = await _singInManager.PasswordSignInAsync(viewModel.Email, viewModel.Password, viewModel.RemenberMe,
            lockoutOnFailure: false);
        if (result.Succeeded)
            return Redirect("/");
        ModelState.AddModelError("", "Invalid login attemt");
        return View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (!ModelState.IsValid) return View(model);
        var user = new ApplicationUser
        {
            UserName = model.Email,
            Email = model.Email,
        };
        var result = await _userManager.CreateAsync(user, model.Password);
        if (result.Succeeded)
        {
            return Redirect("/");
        }

        foreach (var error in result.Errors)
        {
            ModelState.AddModelError("",error.Description);
        }

        return View(model);
    }
}