using System.ComponentModel.DataAnnotations;

namespace CRUDCORE.Models
{
    public class ContactModel
    {
        public int IdContact { get; set; }

        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Telephone { get; set; }
        [Required]
        public string? Mail { get; set; }
    }
}
