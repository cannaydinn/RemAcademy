using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemAcademy.Data.Entities
{
    public class ProductEntity : BaseEntity
    {
        private string courseName;
        private string classGrade;


        public string CourseName
        {
            get { return courseName; }
            set { courseName = value; }
        }

        public string ClassGrade
        {
            get { return classGrade; }
            set { classGrade = value; }
        }

        // Relational Property
        public ICollection<OrderProductEntity> OrderProducts {  get; set; } 

    }

    public class ProductConfiguration : BaseConfiguration<ProductEntity> 
    {
        public override void Configure(EntityTypeBuilder<ProductEntity> builder)
        {
            builder.Property(x => x.CourseName)
                .IsRequired();
            builder.Property(x => x.ClassGrade)
                .IsRequired();
            base.Configure(builder);
        }
    }
}
