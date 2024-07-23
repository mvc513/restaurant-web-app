using Microsoft.EntityFrameworkCore;
namespace restaurant_web_app.Models
{
    public class DB : DbContext
    {

        //1.Percaktimi i connection stringut
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlServer("Data Source=Lenovo\\SQLEXPRESS;Database=restaurantDB;User ID=sa;Password=sa;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
        //2. Percaktimi i modeleve qe do te jen tabela ne db
        public DbSet<Menu> Menu { get; set; }
        public DbSet<Item> Item { get; set; }
    }
}
 