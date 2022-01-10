using EduhomeTemplate.Models;
using EduhomeTemplate.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduhomeTemplate.Controllers
{
    public class OrderController : Controller
    {
        private readonly DataContext _context;
        private readonly UserManager<AppUser> _userManager;

        public OrderController(DataContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Buynow(int id)
        {

            Course course = _context.Courses.FirstOrDefault(x => x.Id == id);
            AppUser appUser = await _userManager.FindByNameAsync(User.Identity.Name);
            if (appUser == null)
            {
                return NotFound();
            }

            Order order = new Order()
            {
                Email = appUser.Email,
                AppUserId = appUser.Id,
                CourseName = course.Title,
                Price = course.Price,
                Language = course.Language,
                OrderTime = course.Time,
                Fullname = appUser.Fullname
            };
            _context.Orders.Add(order);
            _context.SaveChanges();
            return RedirectToAction("index", "home");
        }
    }
}
