using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Task = WebApplication2.Models.Task;
namespace WebApplication2.Controllers
{
    public class TaskController : Controller
    {
        private static List<Task> tasks = new List<Task>();
        private static int nextId = 1;

        public IActionResult Index()
        {
            return View(tasks);
        }
        public IActionResult Details(int id)
        {
            var task = tasks.FirstOrDefault(x => x.Id == id);
            if (task == null) {
                return NotFound();
            }
            return View(task);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Task task)
        {
            if (ModelState.IsValid)
            {
                task.Id = nextId++;
                tasks.Add(task);
                return RedirectToAction(nameof(Index));
            }
            return View(task);
        }
    }
    
}