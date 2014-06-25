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
    public partial class Passenger : System.Web.UI.Page
    {

        protected void Page_Prerender(object sender, EventArgs e)
        {
            int key = (int)Session["numberCabin"];
            Label5.Text = Convert.ToString(key);
            ISession session = (ISession)Session["hbmsession"];
            DAOFactory factory = new NHibernateDAOFactory(session);
            ICabinDAO groupDAO = factory.getCabinDAO();
            IList<lab4.domain.Passenger> passengers = groupDAO.getAllPassengerOfCabin(key);
            GridView1.DataSource = passengers;
            GridView1.DataBind();
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ibInsert_Click(object sender, EventArgs e)
        {
            int key = (int)Session["numberCabin"];
            //Получаем значения полей
            string s1 =
            ((TextBox)GridView1.FooterRow.FindControl("MyFooterTextBox1")).Text;
            string s2 =
            ((TextBox)GridView1.FooterRow.FindControl("MyFooterTextBox2")).Text;
            string s3 =
            ((TextBox)GridView1.FooterRow.FindControl("MyFooterTextBox3")).Text;
            string s4 =
            ((TextBox)GridView1.FooterRow.FindControl("MyFooterTextBox4")).Text;
            //Создаем сессию
            ISession session = (ISession)Session["hbmsession"];
            DAOFactory factory = new NHibernateDAOFactory(session);
            ICabinDAO cabinDAO = factory.getCabinDAO();
            Cabin cabin = cabinDAO.getCabinById(key);
            IPassengerDAO passengerDAO = factory.getPassengerDAO();
            //Создаем объект студента и заполняем его поля
            lab4.domain.Passenger passenger = new lab4.domain.Passenger();
            passenger.SurName = s1;
            passenger.Name = s2;
            passenger.LastName = s3;
            passenger.Year = Convert.ToInt32(s4);
            passenger.Cabin = cabin;
            cabin.PassengerList.Add(passenger);
            //Сохраняем объект студента
            passengerDAO.SaveOrUpdate(passenger);
            Response.Redirect(HttpContext.Current.Request.Url.ToString());
        }

        protected void ibInsertInEmpty_Click(object sender, EventArgs e)
        {
            int keyGroup = (int)Session["numberCabin"];
            //Получаем значения полей ввода
            var parent = ((Control)sender).Parent;
            var firstNameTextBox = parent
            .FindControl("emptyFirstNameTextBox") as TextBox;
            var nameTextBox = parent
            .FindControl("emptyLastNameTextBox") as TextBox;
            var lastNameTextBox = parent.FindControl("emptySexTextBox") as TextBox;
            var yearTextBox = parent.FindControl("emptyYearTextBox") as TextBox;
            //Создаем сессию
            ISession session = (ISession)Session["hbmsession"];
            DAOFactory factory = new NHibernateDAOFactory(session);
            ICabinDAO cabinDAO = factory.getCabinDAO();
            Cabin cabin = cabinDAO.getCabinById(keyGroup);
            IPassengerDAO passengerDAO = factory.getPassengerDAO();
            //Создаем объект студента и заполняем его поля
            lab4.domain.Passenger student = new lab4.domain.Passenger();
            student.SurName = firstNameTextBox.Text;
            student.Name = nameTextBox.Text;
            student.LastName = lastNameTextBox.Text;
            student.Year = Convert.ToInt32(yearTextBox.Text);
            student.Cabin = cabin;
            cabin.PassengerList.Add(student);
            //Сохраняем объект студента
            passengerDAO.SaveOrUpdate(student);
            Response.Redirect(HttpContext.Current.Request.Url.ToString());
        }

        protected void GridView1_RowDeleting(object sender,
GridViewDeleteEventArgs e)
        {
            int keyGroup = (int)Session["numberCabin"];
            //Получить индекс выделенной строки
            int index = e.RowIndex;
            GridViewRow row = GridView1.Rows[index];
            //Получить имя студента
            string surName = ((Label)(row.Cells[0].FindControl("myLabel1"))).Text;
            string Name = ((Label)(row.Cells[1].FindControl("myLabel2"))).Text;
            string lastName = ((Label)(row.Cells[2].FindControl("myLabel3"))).Text;
            ISession hbmSession = (ISession)Session["hbmsession"];
            DAOFactory factory = new NHibernateDAOFactory(hbmSession);
            IPassengerDAO passengerDAO = factory.getPassengerDAO();
            lab4.domain.Passenger passsenger = passengerDAO.getPassengerByCabinIdSurNameNameLastName(keyGroup, surName, Name,lastName);
            //Удаление студента
            if (passsenger != null)
            {
                passsenger.Cabin.PassengerList.Remove(passsenger);
                passengerDAO.Delete(passsenger);
            }
            Response.Redirect(HttpContext.Current.Request.Url.ToString());
        }

        //Перевод строки в режим редактирования
        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //Получить индекс выделенной строки
            int index = e.NewEditIndex;
            GridViewRow row = GridView1.Rows[index];
            //Получение старых значений полей в строке GridView
            string oldFirstName = ((Label)(row.Cells[0].FindControl("myLabel1"))).Text;
            string oldName = ((Label)(row.Cells[1].FindControl("myLabel2"))).Text;
            string oldLastName = ((Label)(row.Cells[2].FindControl("myLabel3"))).Text;
            //Сохранение названия группы в коллекции ViewState
            ViewState["oldFirstName"] = oldFirstName;
            ViewState["oldName"] = oldName;
            ViewState["oldLastName"] = oldLastName;
            GridView1.EditIndex = index;
            GridView1.ShowFooter = false;
            GridView1.DataBind();
        }
        //Отмена редактирования строки
        protected void GridView1_RowCancelingEdit(object sender,
        GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            GridView1.ShowFooter = true;
            GridView1.DataBind();
        }
        //Редактирование строки
        protected void GridView1_RowUpdating(object sender,
        GridViewUpdateEventArgs e)
        {
            int keyGroup = (int)Session["numberCabin"];
            int index = e.RowIndex;
            GridViewRow row = GridView1.Rows[index];
            string newFirstName =
            ((TextBox)(row.Cells[0].FindControl("myTextBox1"))).Text;
            string newName =
            ((TextBox)(row.Cells[1].FindControl("myTextBox2"))).Text;
            string newLastName = ((TextBox)(row.Cells[2].FindControl("myTextBox3"))).Text;
            //string newSex = ((TextBox)(row.Cells[2].FindControl("myTextBox3"))).Text;
            string newYear = ((TextBox)(row.Cells[2].FindControl("myTextBox4"))).Text;
            string oldFirstName = (string)ViewState["oldFirstName"];
            string oldName = (string)ViewState["oldName"];
            string oldLastName = (string)ViewState["oldLastName"];
            //Создание DAO группы
            ISession hbmSession = (ISession)Session["hbmsession"];
            DAOFactory factory = new NHibernateDAOFactory(hbmSession);
            IPassengerDAO passengerDAO = factory.getPassengerDAO();
            //Получение группы по имени
            lab4.domain.Passenger passenger =
            passengerDAO.getPassengerByCabinIdSurNameNameLastName(keyGroup, oldFirstName, oldName,
            oldLastName);
            passenger.SurName = newFirstName;
            passenger.Name = newName;
            passenger.LastName = newLastName;
           // student.Sex = newSex[0];
            passenger.Year = Convert.ToInt32(newYear);
            passengerDAO.SaveOrUpdate(passenger);
            GridView1.EditIndex = -1;
            GridView1.ShowFooter = true;
            GridView1.DataBind();
        }

        protected void GridView1_PageIndexChanging(object sender,
GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            GridView1.EditIndex = -1;
            GridView1.ShowFooter = true;
            GridView1.DataBind();
        }

        protected void GridView1_RowCommand(object sender,
GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Mod")
            {
                int keyGroup = (int)Session["numberCabin"];
                GridViewRow row = (GridViewRow)((ImageButton)e.CommandSource).NamingContainer;
                string ne1wFirstName = ((Label)(row.Cells[0].FindControl("myLabel1"))).Text;
                string newName =((Label)(row.Cells[1].FindControl("myLabel2"))).Text;
                string newLastName = ((Label)(row.Cells[2].FindControl("myLabel3"))).Text;
                ISession hbmSession = (ISession)Session["hbmsession"];
                DAOFactory factory = new NHibernateDAOFactory(hbmSession);
                IPassengerDAO passengerDAO = factory.getPassengerDAO();
                lab4.domain.Passenger passenger =
                passengerDAO.getPassengerByCabinIdSurNameNameLastName(keyGroup, ne1wFirstName, newName,
                newLastName);
                Session["editPassenger"] = passenger;
                Response.Redirect("Oloedit.aspx");
            }
        }


    }
}
