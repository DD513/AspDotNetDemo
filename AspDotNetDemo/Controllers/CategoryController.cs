using AspDotNetDemo.DataAccess;
using AspDotNetDemo.DataAccess.Repository.IRepository;
using AspDotNetDemo.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspDotNetDemo.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _db;

        public CategoryController(ICategoryRepository db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.GetAll();
            return View(objCategoryList);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }
        
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            _db.Add(obj);
            _db.Save();
            return RedirectToAction("Index");
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            //var categoryFromDb = _db.Categories.Find(id);
            //本次修改部分
            var categoryFromDbFirst = _db.GetFirstOrDefault(u => u.Id == id);

            if (categoryFromDbFirst == null)
            {
                return NotFound();
            }

            return View(categoryFromDbFirst);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            _db.Update(obj);
            _db.Save();
            return RedirectToAction("Index");
        }

        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            // var categoryFromDb = _db.Categories.Find(id);
            var categoryFromDbFirst = _db.GetFirstOrDefault(u => u.Id == id);

            if (categoryFromDbFirst == null)
            {
                return NotFound();
            }

            return View(categoryFromDbFirst);
        }

        //POST
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var obj = _db.GetFirstOrDefault(u => u.Id == id);
            if(obj == null)
            {
                return NotFound();
            }
            _db.Remove(obj);
            _db.Save();
            return RedirectToAction("Index");
        }
    }
}
