using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NHibernate;
using lab4.dao;
using lab4.domain;

namespace lab5
{
    public partial class Oloedit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_Prerender(object sender, EventArgs e)
        {
            int key = (int)Session["numberCabin"];
            textBox1.Text = Convert.ToString(key);
        }

        protected void button1_click(Object sender, EventArgs e)
        {
            int key = Int32.Parse(textBox1.Text);
            ISession hbmSession = (ISession)Session["hbmsession"];
            DAOFactory factory = new NHibernateDAOFactory(hbmSession);
            ICabinDAO cabinDAO = factory.getCabinDAO();
            IPassengerDAO passengerDAO = factory.getPassengerDAO();
            lab4.domain.Passenger passenger = (lab4.domain.Passenger)Session["editPassenger"];
            passenger.Cabin.PassengerList.Remove(passenger);
            Cabin cabin = cabinDAO.getCabinById(key);
            passenger.Cabin = cabin;
            cabin.PassengerList.Add(passenger);
            passengerDAO.SaveOrUpdate(passenger);
            Session["numberCabin"] = key;
            Response.Redirect("Passenger.aspx");
        }
    }
}
