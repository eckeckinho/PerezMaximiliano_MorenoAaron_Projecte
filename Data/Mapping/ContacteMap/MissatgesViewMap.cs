using Entitats.ContacteClasses;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Mapping.ContacteClasses
{
    public class MissatgesViewMap : IEntityTypeConfiguration<MissatgesView>
    {
        public void Configure(EntityTypeBuilder<MissatgesView> builder)
        {
            builder.ToView("MissatgesView").HasKey(x => x.id);
        }
    }
}
