using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab4.domain
{
    public class Cabin : EntityBase
    {
        private IList<Passenger> passengerList = new List<Passenger>();
        public virtual int Number { get; set; }
        public virtual string Opisanie { get; set; }
        public virtual IList<Passenger> PassengerList
        {
            get { return passengerList; }
            set { passengerList = value; }
        }
    }
}
