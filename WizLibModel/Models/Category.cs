using System.ComponentModel.DataAnnotations;

namespace WizLibModel.Models
{
    public class Category
    {
        [Key]
        public int Category_Id { get; set; }
        public string Name { get; set; }
    }
}
