using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using livepl.Models;
using livepl.DbContext;
using livepl.Entities;
// using cache
using Microsoft.AspNetCore.Mvc.Filters;

namespace livepl.Controllers;

public class UserController : Controller
{
    private readonly AppDbContext _context;
    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger, AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    // [ResponseCache(VaryByHeader = "User-Agent", Duration = 30)]
    public IActionResult Index()
    {
        // show list of users
        List<User> users = _context.Users.ToList();

        return View(users);
    }

    public IActionResult Details(int id)
    {
        if (id == 0)
        {
            return NotFound();
        }
        // show details of a user
        AppDbContext db = new AppDbContext();
        User user = db.Users.Find(id);

        return View(viewName: "Create", model: user);
    }

    public IActionResult Edit(int id)
    {
        // show edit form of a user
        AppDbContext db = new AppDbContext();
        User user = db.Users.Find(id);

        return View(user);
    }

    public IActionResult Create()
    {
        // show create form of a user
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(User user)
    {
        // create a user
        AppDbContext db = new AppDbContext();
        db.Users.Add(user);
        db.SaveChanges();

        return RedirectToAction("Index");
    }

    // delete a user
    public IActionResult Delete(int id)
    {
        AppDbContext db = new AppDbContext();
        User user = db.Users.Find(id);
        db.Users.Remove(user);
        db.SaveChanges();

        return RedirectToAction("Index");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
