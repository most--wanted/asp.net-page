using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Criterion;
using lab4.domain;

namespace lab4.dao
{
    public class CabinDAO : GenericDAO<Cabin>, ICabinDAO
    {
        public CabinDAO(ISession session) : base(session) { }
        public Cabin getCabinById(int key)
        {
            Cabin cabin = new Cabin();
            cabin.Number = key;
            ICriteria criteria = session.CreateCriteria(typeof(Cabin)).Add(Example.Create(cabin));
            IList<Cabin> list = criteria.List<Cabin>();
            cabin = list[0];
            return cabin;
        }
        public IList<Passenger> getAllPassengerOfCabin(int key)
        {
            var list = session.CreateSQLQuery(
            "SELECT passenger.* FROM passenger JOIN cabins" +
            " ON passenger.cabin = cabins.id" +
            " WHERE cabins.number='" + Convert.ToString(key) + "'")
            .AddEntity("Passenger", typeof(Passenger))
            .List<Passenger>();
            return list;
        }
        public void delCabinById(int key)
        {
            Cabin group = getCabinById(key);
            Delete(group);
        }
    }
}
