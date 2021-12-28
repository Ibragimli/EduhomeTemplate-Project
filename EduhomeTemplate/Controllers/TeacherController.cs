using EduhomeTemplate.Models;
using EduhomeTemplate.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduhomeTemplate.Controllers
{
    public class TeacherController : Controller
    {
        private readonly DataContext _context;

        public TeacherController(DataContext context)
        {
           _context = context;
        }
        public IActionResult Index()
        {
            TeacherViewModel teacherVM = new TeacherViewModel
            {
                teachers = _context.teachers.ToList(),
            };
            return View();
        }

        public IActionResult Detail(int id)
        {
            return View();
        }
    }
}
