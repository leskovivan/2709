using _2709.Data;
using _2709.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace _2709.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationContext _context;

        public IndexModel(ApplicationContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ToDoTask NewTask { get; set; }

        public IList<ToDoTask> Tasks { get; set; }

        public async Task OnGetAsync()
        {
            Tasks = await _context.Tasks.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                _context.Tasks.Add(NewTask);
                await _context.SaveChangesAsync();
                return RedirectToPage();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostToggleCompletionAsync(int taskId)
        {
            var task = await _context.Tasks.FindAsync(taskId);
            if (task != null)
            {
                task.IsCompleted = !task.IsCompleted;
                await _context.SaveChangesAsync();
            }
            return RedirectToPage();
        }

        public async Task<IActionResult> OnPostDeleteAsync(int taskId)
        {
            var task = await _context.Tasks.FindAsync(taskId);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage();
        }
    }

}
