using EduhomeTemplate.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduhomeTemplate.Areas.Manage.Controllers
{
    [Area("manage")]
    //[Authorize(Roles = "SuperAdmin")]
    public class RoleController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly DataContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(UserManager<AppUser> userManager, DataContext context, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _context = context;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            var list = _context.Roles.ToList();
            return View(_context.Roles.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IdentityRole role)
        {
            IdentityRole existRole = await _context.Roles.FirstOrDefaultAsync(x => x.NormalizedName == role.Name.ToUpper());
            if (existRole != null)
            {
                ModelState.AddModelError("", "This role already exists in the database!");
                return View();
            }
            if (!ModelState.IsValid)
            {
                return View();
            }

            await _roleManager.CreateAsync(role);
            return RedirectToAction("index", "role");
        }
        public IActionResult Edit(string id)
        {
            IdentityRole existRole = _context.Roles.FirstOrDefault(x => x.Id == id);
            if (existRole == null)
            {
                return NotFound();
            }

            return View(existRole);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(IdentityRole role)
        {
            IdentityRole existRole = await _context.Roles.FirstOrDefaultAsync(x => x.Id == role.Id);
            if (existRole == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (role != null)
            {
                ModelState.AddModelError("", "This role already exists in the database!");
                return View();
            }

            existRole.Name = role.Name;
            _context.SaveChanges();

            return RedirectToAction("index", "role");
        }

        public async Task<ActionResult> Delete(string id)
        {
            IdentityRole existRole = _context.Roles.FirstOrDefault(x => x.Id == id);
            if (existRole == null)
            {
                return NotFound();
            }
            await _roleManager.DeleteAsync(existRole);

            return Ok();
        }

    }
}
