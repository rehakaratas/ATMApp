using ATMApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMApp.Infrastructure.EntityTypeConfiguration
{
    public class UserProcessConfig : BaseEntityConfig<UserProcess>
    {
        public override void Configure(EntityTypeBuilder<UserProcess> builder)
        {
            builder.HasKey(x=> x.Id);
            builder.Property(x=>x.Id).IsRequired(true);

            builder.Property(x => x.TransactionNumber).HasAnnotation("SqlServer:Identity", "1000,1");
            builder.Property(x=>x.Process).IsRequired(true);

            builder.HasOne(x => x.User)
                .WithMany(x => x.UserProcesses)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            base.Configure(builder);
        }
    }
}
