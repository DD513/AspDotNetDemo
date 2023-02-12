using AspDotNetDemo.DataAccess;
using AspDotNetDemo.DataAccess.Repository.IRepository;
using AspDotNetDemo.Models;
using AspDotNetDemo.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspDotNetDemo.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller //本次修改程式碼
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment hostEnvironment) //本次修改程式碼
        {
            _unitOfWork = unitOfWork;
            _hostEnvironment = hostEnvironment;
        }

        public IActionResult Index()
        {
      
            return View();
        }

        //GET
        public IActionResult Upsert(int? id) 
        {
            ProductVM productVM = new() //本次修改部分
            {
                Product = new(),
                CategoryList = _unitOfWork.Category.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString(),
                })
            };
            if (id == null || id == 0)  //若產品Id為空值或0就建立新產品，若其不為0或空值，則更新產品。
            {
                // Create Product
                //ViewBag.CategoryList = CategoryList;
                //ViewData["CategoryList"] = CategoryList; //本次新增程式碼
                return View(productVM);
            }
            else
            {
                // Update Product
                productVM.Product = _unitOfWork.Product.GetFirstOrDefault(u => u.Id == id); //本次新增部分
                return View(productVM);
            }


            return View(productVM);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(ProductVM obj, IFormFile? file) //本次修改部分
        {
            
            if(ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath; //本次新增部分
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(wwwRootPath, @"images\products");

                    var extension = Path.GetExtension(file.FileName);

                    if (obj.Product.Image != null)//判斷是否有圖片上傳
                    {
                        var oldImagePath = Path.Combine(wwwRootPath, obj.Product.Image.TrimStart('\\'));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStreams = new FileStream(Path.Combine(uploads, fileName + extension), FileMode.Create))
                    {
                        file.CopyTo(fileStreams);
                    }
                    obj.Product.Image = @"\images\products\" + fileName + extension;
                }

                if (obj.Product.Id == 0)//判斷該筆資料是否是點擊edit按鍵 頁面須傳入ID <input asp-for="Product.Id" hidden/> //本次修改部分
                {
                    _unitOfWork.Product.Add(obj.Product);
                }
                else
                {
                    _unitOfWork.Product.Update(obj.Product);
                }

                _unitOfWork.Save();
                TempData["success"] = "Product createed successfully!";
                return RedirectToAction("Index");
            }
            return View(obj);
            
        }

        #region API CALLS 
        [HttpGet]
        public IActionResult GetAll()
        {
            var productList = _unitOfWork.Product.GetAll(includeProperties: "Category");
            return Json(new { data = productList });
        }

        //POST
        [HttpDelete]
        public IActionResult Delete(int? id)
        {
            var obj = _unitOfWork.Product.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            var oldImagePath = Path.Combine(_hostEnvironment.WebRootPath, obj.Image.TrimStart('\\'));
            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }

            _unitOfWork.Product.Remove(obj);
            _unitOfWork.Save();
            return Json(new { success = true, message = "Delete Successfully!!" });
        }

        #endregion
    }
}
