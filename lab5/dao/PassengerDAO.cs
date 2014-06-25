using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using lab4.domain;
using NHibernate;

namespace lab4.dao
{
public class PassengerDAO:GenericDAO<Passenger>, IPassengerDAO
{
public PassengerDAO(ISession session): base(session) { }
public Passenger getPassengerByCabinIdSurNameNameLastName(
        int key, string surName, string Name, string LastNAme)
{
var list = session.CreateSQLQuery(
"SELECT passenger.* FROM passenger JOIN cabins" +
" ON passenger.cabin = cabins.id" +
" WHERE cabins.number='" + Convert.ToString(key) + "'" +
" and passenger.surName='" + surName + "'" +
" and passenger.Name='" + Name + "' and passenger.LastName='"+LastNAme +"'")
.AddEntity("Passenger", typeof(Passenger))
.List<Passenger>();
Passenger passenger = list[0];
return passenger;
}
}
}
