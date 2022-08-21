// using System.Collections.Generic;
// using Newtonsoft.Json;
// using Newtonsoft.Json.Linq;

// namespace RecipeBox.Models
// {
//   public class RecipeApi
//   {
//     public string Diet { get; set; }
//     public string CuisineType { get; set; }
//     public string MealType { get; set; }
//     public string DishType { get; set;}

//     public static List<RecipeApi> GetRecipes(string apiKey)
//     {
//       var apiCallTask = ApiHelper.ApiCall(apiKey);
//       var result = apiCallTask.Result;

//       JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
//       List<RecipeApi> recipeApiList = JsonConvert.DeserializeObject<List<RecipeApi>>(jsonResponse["results"].ToString());

//       return recipeApiList;
//     }
//   }
// }