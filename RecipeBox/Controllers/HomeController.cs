using Microsoft.AspNetCore.Mvc;
using RecipeBox.Models;

namespace RecipeBox.Controllers
{
  public class HomeController : Controller
  {

    // public IActionResult Index()
    // {
    //   var allRecipes = RecipeApi.GetRecipes(EnvironmentVariables.ApiKey);
    //   return View(allRecipes);
    // }

    [HttpGet("/")]
    public ActionResult Index()
    {
      return View();
    }
  }
}