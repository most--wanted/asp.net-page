using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;


namespace lab4.dao
{
    public class NHibernateDAOFactory : DAOFactory
    {
        /** NHibernate sessionFactory */
        protected ISession session = null;
        public NHibernateDAOFactory(ISession session)
        {
            this.session = session;
        }
        public override IPassengerDAO getPassengerDAO()
        {
            return new PassengerDAO(session);
        }
        public override ICabinDAO getCabinDAO()
        {
            return new CabinDAO(session);
        }
    }
}
