using System.ComponentModel.DataAnnotations;

namespace RemAcademy.WebApi.Models
{
    public class UpdateProductRequest
    {
        [Required]
        public string CourseName { get; set; }
        [Required]
        public string ClassGrade { get; set; }
    }
}
