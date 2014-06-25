using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using lab4.domain;
using FluentNHibernate.Mapping;


namespace lab4.mapping
{
    public class CabinMap : ClassMap<Cabin>
    {
        public CabinMap()
        {
            Table("cabins");
            Id(x => x.Id).GeneratedBy.Native();
            Map(x => x.Number);
            Map(x => x.Opisanie);
            HasMany(x => x.PassengerList)
            .Inverse()
            .Cascade.All()
            .KeyColumn("cabin");
        }
    }
}
