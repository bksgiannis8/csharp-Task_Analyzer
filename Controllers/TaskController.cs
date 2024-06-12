using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task_Analyzer.Data;
using Task_Analyzer.Models;

namespace Task_Analyzer.Controllers
{
    public class TaskController : Controller
    {
        private readonly ApplicationDBContext _db;

        public TaskController(ApplicationDBContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> UpdateStatus(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var task = await _db.Tasks.FindAsync(id);

            if (task == null)
            {
                return RedirectToAction("Index");
            }

            task.IsCompleted = true;
            _db.Update(task);
            await _db.SaveChangesAsync();

            return RedirectToAction("Index");
        }
    }
}
