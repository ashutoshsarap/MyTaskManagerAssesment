using Microsoft.AspNetCore.Mvc;
using MyTaskManager.Models.DTO;
using MyTaskManager.Models.ViewModels;
using MyTaskManager.Services.IService;

namespace MyTaskManager.Controllers
{
    public class TaskController : Controller
    {
        private readonly ITaskService taskService;

        public TaskController(ITaskService taskService)
        {
            this.taskService = taskService;
        }
        public IActionResult Index()
        {
            var allTask = taskService.GetAll(includeProperties: "Category");
            var allTaskVms = allTask.Select(t => new TaskVM
            {
                Id = t.Id,
                Title = t.Title,
                Description = t.Description,
                DueDate = t.DueDate,
                Priority = t.Priority,
                CategoryId = t.CategoryId
            });

            return View(allTaskVms);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(TaskVM taskVM)
        {
            if (ModelState.IsValid)
            {
                taskService.Add(new TaskDTO
                {
                    Id = taskVM.Id,
                    Title = taskVM.Title,
                    Description = taskVM.Description,
                    DueDate = taskVM.DueDate,
                    Priority = taskVM.Priority,
                    CategoryId = taskVM.CategoryId
                });
                return RedirectToAction("Index");
            }
            return View(taskVM);
        }

        [ActionName("Delete")]
        public IActionResult Delete(int id)
        {
            taskService.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            var taskItem = taskService.Get(t => t.Id == id);
            var taskVM = new TaskVM
            {
                Id = taskItem.Id,
                Title = taskItem.Title,
                Description = taskItem.Description,
                DueDate = taskItem.DueDate,
                Priority = taskItem.Priority,
                CategoryId = taskItem.CategoryId
            };
            return View(taskVM);
        }

        [HttpPost]
        public IActionResult Update(TaskVM taskVM)
        {
            if (ModelState.IsValid)
            {
                taskService.Update(new TaskDTO
                {
                    Id = taskVM.Id,
                    Title = taskVM.Title,
                    Description = taskVM.Description,
                    DueDate = taskVM.DueDate,
                    Priority = taskVM.Priority,
                    CategoryId = taskVM.CategoryId
                });
                return RedirectToAction("Index");
            }
            return View(taskVM);
        }
    }
}
