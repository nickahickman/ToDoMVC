using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoMVC.Models;
using System.Security.Claims;

namespace ToDoMVC.Controllers
{
    [Authorize]
    public class ToDoController : Controller
    {
        private readonly ToDoMVCContext _context;
        public ToDoController(ToDoMVCContext context)
        {
            _context = context;
        }
        public IActionResult ViewTasks()
        {
            string userKey = User.FindFirst(ClaimTypes.NameIdentifier).Value.ToString();
            List<Tasks> tasks = _context.Tasks.Where(x => x.OwnerId == userKey).ToList();
            ViewBag.UserKey = userKey;
            return View(tasks);
        }

        [HttpPost]
        public IActionResult AddTask(Tasks t)
        {
            if (ModelState.IsValid)
            {
                _context.Tasks.Add(t);
                _context.SaveChanges();
            }
            return RedirectToAction("ViewTasks");
        }

        public IActionResult MarkComplete(int Id)
        {
            Tasks t = _context.Tasks.Find(Id);
            t.IsComplete = !t.IsComplete;
            _context.Tasks.Update(t);
            _context.SaveChanges();
            return RedirectToAction("ViewTasks");
        }

        public IActionResult DeleteTask(int Id)
        {
            Tasks t = _context.Tasks.Find(Id);
            _context.Tasks.Remove(t);
            _context.SaveChanges();
            return RedirectToAction("ViewTasks");
        }
    }
}
