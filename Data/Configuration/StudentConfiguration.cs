
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FastEndpointsDemo.Data.Configuration
{
    internal class StudentConfiguration : BaseConfiguration<Student>
    {
        public override void Configure(EntityTypeBuilder<Student> builder) 
        {
            base.Configure(builder);

            builder.Property(stu => stu.Name).IsRequired().HasDefaultValue("name");
            builder.Property(stu => stu.LastName);
            builder.Property(stu => stu.Age);
            builder.Property(stu => stu.Phone);
        }
    }
}
