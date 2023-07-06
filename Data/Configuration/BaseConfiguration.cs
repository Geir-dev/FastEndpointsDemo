using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EndpointsDemo.Data.Configuration
{
    internal abstract class BaseConfiguration<TSample> : IEntityTypeConfiguration<TSample>
        where TSample : Student
    {
        public virtual void Configure(EntityTypeBuilder<TSample> builder)
        {
            builder.Property(stu => stu.Id).IsRequired();
            builder.Property(stu => stu.Email).IsRequired().HasDefaultValue("abc@online.com");
            builder.Property(stu => stu.Created).IsRequired().HasDefaultValueSql("GETDATE()");
        }
    }
}
