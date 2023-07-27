using Adbeer.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Adbeer.Data.Constrains
{
    public class BusStudentsConstrains : IEntityTypeConfiguration<BusStudents>
    {
        public void Configure(EntityTypeBuilder<BusStudents> builder)
        {

            builder.HasOne(x => x._Stuednt)
                .WithMany(x => x._BusStudents)
                .HasForeignKey(x => x.StudentId);

            builder.HasOne(x => x._Bus)
                .WithMany(x => x._BusStudents)
                .HasForeignKey(x => x.BusId);
        }
    }
}
