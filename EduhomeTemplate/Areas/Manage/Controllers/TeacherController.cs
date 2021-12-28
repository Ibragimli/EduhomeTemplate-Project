using EduhomeTemplate.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduhomeTemplate.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class TeacherController : Controller
    {
        private readonly DataContext _context;
        public TeacherController(DataContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.teachers.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Create(Teacher teacher )
        {
            _context.teachers.Add(teacher);
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Edit(int id)
        {
            Teacher teacher = _context.teachers.FirstOrDefault(x => x.Id == id);
            if (teacher == null)
            {
                return NotFound();
            }
            return View(teacher);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Teacher teacher)
        {
            Teacher teacherExist = _context.teachers.FirstOrDefault(x => x.Id == teacher.Id);
            if (teacherExist == null)
            {
                return NotFound();
            }
            teacherExist.Title = teacher.Title;
            teacherExist.Experience = teacher.Experience;
            teacherExist.Degree = teacher.Degree;
            teacherExist.Desc = teacher.Desc;
            teacherExist.Faculty = teacher.Faculty;
            teacherExist.Hobbies = teacher.Hobbies;
            teacherExist.Level = teacher.Level;
            teacherExist.DescLitlle = teacher.DescLitlle;
            _context.SaveChanges();
            return RedirectToAction("index");
        }

        public IActionResult Delete(int id)
        {
            Teacher teacher = _context.teachers.FirstOrDefault(x => x.Id == id);
            if (teacher == null)
            {
                return NotFound();
            }
            return View(teacher);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Teacher teacher)
        {
            Teacher teacherExist = _context.teachers.FirstOrDefault(x => x.Id == teacher.Id);
            if (teacherExist == null)
            {
                return NotFound();
            }

            _context.teachers.Remove(teacherExist);
            _context.SaveChanges();

            return RedirectToAction("index");

        }
    }
}
