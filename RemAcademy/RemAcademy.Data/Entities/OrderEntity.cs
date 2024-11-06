using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemAcademy.Data.Entities
{
    public class OrderEntity : BaseEntity
    {
        private DateTime orderDate;
        private int teacherId;
        public decimal TotalAmount { get; set; }
        public UserEntity Teacher { get; set; }  

        // Relational Property
        public ICollection<OrderProductEntity> OrderProducts { get; set; } = new List<OrderProductEntity>();

        public DateTime OrderDate
        {
            get { return orderDate; }
            set { orderDate = value; }
        }

        public int TeacherId
        {
            get { return teacherId; }
            set { teacherId = value; }
        }


        

      

    }

    public class OrderConfiguration : BaseConfiguration<OrderEntity> 
    {
        public override void Configure(EntityTypeBuilder<OrderEntity> builder)
        {
            base.Configure(builder);
        }
    }
}
