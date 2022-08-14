using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace RecipeBox.Models
{
  public class RecipeBoxContetxtFactory : IDesignTimeDbContextFactory<RecipeBoxContetxt>
  {

    RecipeBoxContetxt IDesignTimeDbContextFactory<RecipeBoxContetxt>.CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();

      var builder = new DbContextOptionsBuilder<RecipeBoxContetxt>();

      builder.UseMySql(configuration["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(configuration["ConnectionStrings:DefaultConnection"]));

      return new RecipeBoxContetxt(builder.Options);
    }
  }
}