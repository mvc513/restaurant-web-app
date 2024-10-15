using System.ComponentModel.DataAnnotations;

namespace restaurant_web_app.Models
{
    public class BookNow

    {
        [Key]
        public int Id { get; set; }
        public String NameSurname { get; set; }
        public String TableFor {  get; set; }
    }
}
