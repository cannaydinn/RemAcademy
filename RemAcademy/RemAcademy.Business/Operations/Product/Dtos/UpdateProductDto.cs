using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemAcademy.Business.Operations.Product.Dtos
{
    public class UpdateProductDto
    {

        public int Id { get; set; }

        public string CourseName { get; set; }

        public string ClassGrade { get; set; }
    }
}
