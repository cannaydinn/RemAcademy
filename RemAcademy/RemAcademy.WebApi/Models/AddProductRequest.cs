using System.ComponentModel.DataAnnotations;

namespace RemAcademy.WebApi.Models
{
    public class AddProductRequest
    {
        [Required]
        [Length(5,10)]
        public string CourseName { get; set; }

        [Required]
        [MaxLength(5)]
        public string ClassGrade { get; set; }
    }
}
