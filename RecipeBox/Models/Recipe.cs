using System.Collections.Generic;

namespace RecipeBox.Models
{
  public class Recipe
  {
    public Recipe()
    {
      this.JoinEntities = new HashSet<RecipeCategory>();
    }

    public int RecipeId { get; set; }
    public string Name { get; set; }
    public string Ingredients { get; set; }
    public string Instructions { get; set; }
    public string Rating { get; set; }

    public virtual ApplicationUser User { get; set; }

    public virtual ICollection<RecipeCategory> JoinEntities { get;}

    // public static IOrderedEnumerable<Recipe> OrderBy<Recipe, Rating>(this IEnumerable<Recipe> recipe, Func<Recipe, Rating> keySelector);
  }
}