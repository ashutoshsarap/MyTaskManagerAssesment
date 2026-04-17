using Microsoft.AspNetCore.Mvc;
using MyTaskManager.Models.ViewModels;
using MyTaskManager.Repository.IRepository;

namespace MyTaskManager.Controllers
{
    public class CategoryController : Controller
    {

        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            var allCategory = _unitOfWork.Category.GetAll();
            var allCategoryVms = allCategory.Select(c => new CategoryVM
            {
                Id = c.Id,
                Name = c.Name
            });
            return View(allCategoryVms);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(CategoryVM categoryVM)
        {
            var categoryEntity = new Models.Entity.CategoryEntity
            {
                Name = categoryVM.Name
            };
            _unitOfWork.Category.Add(categoryEntity);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

        [ActionName("Delete")]
        public IActionResult Delete(int id)
        {
            _unitOfWork.Category.Delete(id);
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }
    }
}
