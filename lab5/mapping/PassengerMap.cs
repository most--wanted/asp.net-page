using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using lab4.domain;
using FluentNHibernate.Mapping;

namespace lab4.mapping
{
    public class PassengerMap : ClassMap<Passenger>
    {
        public PassengerMap()
        {
            Table("passenger");
            Id(x => x.Id).GeneratedBy.Native();
            Map(x => x.SurName);
            Map(x => x.Name);
            Map(x => x.LastName);
            Map(x => x.Year);
            References(x => x.Cabin, "cabin");
        }
    }
}
