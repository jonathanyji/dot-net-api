using Microsoft.EntityFrameworkCore;
using MySampleAPI.Models;


namespace MySampleAPI.Data
{
    public class ApiContext : DbContext
    {
        public DbSet<Car> cars {  get; set; }
        public ApiContext(DbContextOptions<ApiContext> options) :base(options)
        {
           
        }
    }
}
