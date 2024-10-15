using Microsoft.EntityFrameworkCore;
namespace restaurant_web_app.Models
{
    public class DB : DbContext
    {
        public DB(DbContextOptions<DB> context) : base(context) 
        { 
        
        }
        //1.Percaktimi i connection stringut
        
        //2. Percaktimi i modeleve qe do te jen tabela ne db
        public DbSet<Menu> Menu { get; set; }
        public DbSet<Item> Item { get; set; }

        public DbSet<BookNow> BookNow { get; set; }
    }
}
 