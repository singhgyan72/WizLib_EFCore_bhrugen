using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WizLibDataAccess.Data;
using WizLibModel.Models;

namespace WizLib.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public CategoryController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            List<Category> categories = _dbContext.Categories.ToList();

            return View(categories);
        }

        [HttpGet]
        public IActionResult Upsert(int? id)
        {
            Category category = new Category();
            if (id == null)
            {
                return View(category);
            }
            else
            {
                category = _dbContext.Categories.FirstOrDefault(i => i.Category_Id == id);
                if (category == null)
                    return NotFound();

                return View(category);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Category category)
        {
            if (ModelState.IsValid)
            {
                if (category.Category_Id == 0)
                {
                    _dbContext.Categories.Add(category);
                }
                else
                {
                    _dbContext.Categories.Update(category);
                }
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        public IActionResult Delete(int id)
        {
            var category = _dbContext.Categories.FirstOrDefault(i => i.Category_Id == id);

            if (category != null)
                _dbContext.Categories.Remove(category);

            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateMultiple2()
        {
            //No bulk operation for less than 4 operations
            List<Category> categories = new List<Category>();
            for (int i = 0; i < 2; i++)
            {
                categories.Add(new Category { Name = Guid.NewGuid().ToString() });
                //_dbContext.Categories.Add(new Category { Name = Guid.NewGuid().ToString() });
            }
            _dbContext.Categories.AddRange(categories);
            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult CreateMultiple5()
        {
            //Bulk insertion will be 4 or more operations
            List<Category> categories = new List<Category>();
            for (int i = 0; i < 5; i++)
            {
                categories.Add(new Category { Name = Guid.NewGuid().ToString() });
                //_dbContext.Categories.Add(new Category { Name = Guid.NewGuid().ToString() });
            }
            _dbContext.Categories.AddRange(categories);
            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult RemoveMultiple2()
        {
            //No bulk operation for less than 4 operations
            IEnumerable<Category> categories = _dbContext.Categories.OrderByDescending(i => i.Category_Id)
                                                            .Take(2).ToList();

            _dbContext.Categories.RemoveRange(categories);
            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult RemoveMultiple5()
        {
            //Bulk deletion will be 4 or more operations
            IEnumerable<Category> categories = _dbContext.Categories.OrderByDescending(i => i.Category_Id)
                                                            .Take(5).ToList();

            _dbContext.Categories.RemoveRange(categories);
            _dbContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
