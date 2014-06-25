using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using lab4.domain;

namespace lab4.dao
{
    public interface ICabinDAO : IGenericDAO<Cabin>
    {
        Cabin getCabinById(int key);
        IList<Passenger> getAllPassengerOfCabin(int key);
        void delCabinById(int key);
    }
}
