using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WizLibDataAccess.Data;
using WizLibModel.Models;

namespace WizLib.Controllers
{
    public class PublisherController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public PublisherController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            List<Publisher> objList = _dbContext.Publishers.ToList();
            return View(objList);
        }

        public IActionResult Upsert(int? id)
        {
            Publisher obj = new Publisher();
            if (id == null)
            {
                return View(obj);
            }
            //this for edit
            obj = _dbContext.Publishers.FirstOrDefault(u => u.Publisher_Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Publisher obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Publisher_Id == 0)
                {
                    //this is create
                    _dbContext.Publishers.Add(obj);
                }
                else
                {
                    //this is an update
                    _dbContext.Publishers.Update(obj);
                }
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(obj);

        }

        public IActionResult Delete(int id)
        {
            var objFromDb = _dbContext.Publishers.FirstOrDefault(u => u.Publisher_Id == id);
            _dbContext.Publishers.Remove(objFromDb);
            _dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}