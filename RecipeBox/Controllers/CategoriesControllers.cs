using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using RecipeBox.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace RecipeBox.Controllers
 {
 public class CategoriesController : Controller
 {
    private readonly RecipeBoxContext _db;

    public CategoriesController(RecipeBoxContext db)
    {
      _db = db;
     }

     public ActionResult Index()
     {
       List<Category> model = _db.Categories.ToList();
       return View(model);
     }

   public ActionResult Create()
    {
       return View();
    }

     [HttpPost]
     public ActionResult Create(Category category)
     {
       _db.Categories.Add(category);
       _db.SaveChanges();
      return RedirectToAction("Index");
     }

     public ActionResult Details(int id)
     {
       var thisCategory = _db.Categories
           .Include(category => category.JoinEntities)
           .ThenInclude(join => join.Recipe)
           .FirstOrDefault(category => category.CategoryId == id);
       return View(thisCategory);
     }
     public ActionResult Edit(int id)
     {
       var thisCategory = _db.Categories.FirstOrDefault(category => category.CategoryId == id);
       return View(thisCategory);
     }

     [HttpPost]
     public ActionResult Edit(Category category)
     {
       _db.Entry(category).State = EntityState.Modified;
       _db.SaveChanges();
       return RedirectToAction("Index");
    }
    
    [HttpPost]
    public ActionResult AddRecipe(Category category)
    {
      _db.Entry(category).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index", "Home");
    }
    public ActionResult AddRecipe(int id)
    {
      var thisCategory = _db.Categories.FirstOrDefault(category => category.CategoryId == id);
      ViewBag.RecipeId = new SelectList(_db.Recipes, "RecipeId", "Model");
      return View(thisCategory);
    }
    [HttpPost]
    public ActionResult AddRecipe(Category category, int RecipeId)
    {
      if (RecipeId != 0)
      {
        _db.RecipeCategory.Add(new RecipeCategory(){ RecipeId = RecipeId, CategoryId = category.CategoryId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index", "Home");
    }

     public ActionResult Delete(int id)
     {
       var thisCategory = _db.Categories.FirstOrDefault(category => category.CategoryId == id);
       return View(thisCategory);
     }

     [HttpPost, ActionName("Delete")]
     public ActionResult DeleteConfirmed(int id)
     {
       var thisCategory = _db.Categories.FirstOrDefault(category => category.CategoryId == id);
       _db.Categories.Remove(thisCategory);
       _db.SaveChanges();
       return RedirectToAction("Index");
     }
   }
 }