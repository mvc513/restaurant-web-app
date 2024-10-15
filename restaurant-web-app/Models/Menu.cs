using System.ComponentModel.DataAnnotations;

namespace restaurant_web_app.Models
{
    public class Menu
    {
        [Key]
        public int nrMenu { get; set; }
        public String titulli { get; set; } 


    }
}
