using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemAcademy.Data.Entities
{
    public class OrderProductEntity : BaseEntity
    {
        private int orderId;
        private int productId;

        public int ProductId
        {
            get { return productId; }
            set { productId = value; }
        }

        public int OrderId
        {
            get { return orderId; }
            set { orderId = value; }
        }

        // Relational Property
        public OrderEntity Order { get; set; }
        public ProductEntity Product { get; set; }
    }

    public class OrderProductConfiguration : BaseConfiguration<OrderProductEntity> 
    {
        public override void Configure(EntityTypeBuilder<OrderProductEntity> builder)
        {
            builder.Ignore(x => x.Id);
            builder.HasKey("OrderId", "ProductId"); // Composite Key oluşturuldu, yeni bir primary key atandı
            base.Configure(builder);
        }
    }
}
