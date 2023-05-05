using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MyAppModels
{
    public class Category
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }
        [DisplayName("Display  Order")]
        public int DisplayOrder { get; set; }

        public DateTime Created_Date { get; set; } = DateTime.Now;

    }
}
