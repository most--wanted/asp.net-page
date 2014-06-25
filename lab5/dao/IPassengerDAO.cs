using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using lab4.domain;

namespace lab4.dao
{
    public interface IPassengerDAO : IGenericDAO<Passenger>
    {
        Passenger getPassengerByCabinIdSurNameNameLastName(
        int key, string surName, string Name, string LastNAme);
    }
}
