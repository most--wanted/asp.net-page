using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab4.dao
{
    abstract public class DAOFactory
    {
        public abstract IPassengerDAO getPassengerDAO();
        public abstract ICabinDAO getCabinDAO();
    }
}
