using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Livepl.Models;
using Livepl.Entities;
using Livepl.DbContext;
using Microsoft.EntityFrameworkCore;

namespace Livepl.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /user
        public async Task<ViewResult> Index()
        {
            return View(await _context.User.ToListAsync());
        }

        // GET: /user/create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /user/create
        [HttpPost]
        public async Task<IActionResult> Create(User person)
        {
            person.IsActive = true;

            if (ModelState.IsValid)
            {
                _context.Add(person);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(person);
        }

        // GET: /user/detail/5
        public async Task<IActionResult> Details(int id)
        {
            var person = await _context.User.FindAsync(id);

            if (person == null)
            {
                return NotFound();
            }

            return View("Detail", person);
        }
    }
}