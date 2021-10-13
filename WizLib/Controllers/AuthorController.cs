using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WizLibDataAccess.Data;
using WizLibModel.Models;

namespace WizLib.Controllers
{
    public class AuthorController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public AuthorController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            List<Author> objList = _dbContext.Authors.ToList();
            return View(objList);
        }

        public IActionResult Upsert(int? id)
        {
            Author obj = new Author();
            if (id == null)
            {
                return View(obj);
            }
            //this for edit
            obj = _dbContext.Authors.FirstOrDefault(u => u.Author_Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Author obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Author_Id == 0)
                {
                    //this is create
                    _dbContext.Authors.Add(obj);
                }
                else
                {
                    //this is an update
                    _dbContext.Authors.Update(obj);
                }
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(obj);

        }

        public IActionResult Delete(int id)
        {
            var objFromDb = _dbContext.Authors.FirstOrDefault(u => u.Author_Id == id);
            _dbContext.Authors.Remove(objFromDb);
            _dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}