using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace lab4.domain
{
    public class Passenger : EntityBase
    {
        public virtual string SurName { get; set; }
        public virtual string Name { get; set; }
        public virtual string LastName { get; set; }
        public virtual int Year { get; set; }
        public virtual Cabin Cabin { get; set; }
    }
}
