using CakeShop.Data;
using CakeShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CakeShop.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _context;

    public HomeController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View("Login");
    }

    [HttpPost]
    public async Task<IActionResult> Login(string login, string password)
    {
        var user = await _context.Users.FirstOrDefaultAsync(x =>
            x.Login == login &&
            x.Password == password);

        if (user == null)
        {
            ViewBag.Error = "Неверный логин или пароль";
            return View("Login");
        }

        return RedirectToAction("Index", "Cakes");
    }
}