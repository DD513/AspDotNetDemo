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
    }
}
