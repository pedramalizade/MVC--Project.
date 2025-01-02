using App.Domain.Core.Core_App.CardAggrigate.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using App.Domain.Core.Core_App.UserAggrigate.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Infra.DataBase.SqlServer
{
    public class CardConfig : IEntityTypeConfiguration<Card>
    {
        public void Configure(EntityTypeBuilder<Card> builder)
        {
            builder.HasKey(c => c.CardNumber);

            builder.HasOne(a => a.User)
                .WithMany(x => x.Cards)
                .HasForeignKey(x => x.UserId);
        } 
    }
}
