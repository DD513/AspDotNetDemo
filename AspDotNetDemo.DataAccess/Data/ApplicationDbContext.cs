using AspDotNetDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace AspDotNetDemo.DataAccess
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }

        public DbSet<CoverType> CoverTypes { get; set; }

        //本次新增程式碼
        public DbSet<Product> Products { get; set; }
    }
}
