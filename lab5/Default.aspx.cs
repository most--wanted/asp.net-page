using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using lab4.domain;
using NHibernate;
using lab4.dao;

namespace lab5
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Page_Prerender(object sender, EventArgs e)
        {
            ISession session = (ISession)Session["hbmsession"];
            DAOFactory factory = new NHibernateDAOFactory(session);
            ICabinDAO cabinDAO = factory.getCabinDAO();
            List<Cabin> cabins = cabinDAO.GetAll();
            GridView1.DataSource = cabins;
            GridView1.DataBind();
        }

        protected void ibInsert_Click(object sender, EventArgs e)
        {
            //Получаем значения полей
            string s1 =
            ((TextBox)GridView1.FooterRow.FindControl("MyFooterTextBox1")).Text;
            string s2 =
            ((TextBox)GridView1.FooterRow.FindControl("MyFooterTextBox2")).Text;
            Cabin cabin = new Cabin();
            cabin.Number = Int32.Parse(s1);
            cabin.Opisanie = s2;
            ISession session = (ISession)Session["hbmsession"];
            DAOFactory factory = new NHibernateDAOFactory(session);
            ICabinDAO cabinDAO = factory.getCabinDAO();
            cabinDAO.SaveOrUpdate(cabin);
            Response.Redirect(HttpContext.Current.Request.Url.ToString());
        }

        protected void ibInsertInEmpty_Click(object sender, EventArgs e)
        {
            var parent = ((Control)sender).Parent;
            var groupNameTextBox = parent
            .FindControl("emptyGroupNameTextBox") as TextBox;
            var curatorNameTextBox = parent
            .FindControl("emptyCuratorNameTextBox") as TextBox;
            Cabin cabin = new Cabin();
            cabin.Number = Int32.Parse(groupNameTextBox.Text);
            cabin.Opisanie = curatorNameTextBox.Text;
            // cabin.HeadmanName = headmanNameTextBox.Text;
            ISession session = (ISession)Session["hbmsession"];
            DAOFactory factory = new NHibernateDAOFactory(session);
            ICabinDAO groupDAO = factory.getCabinDAO();
            groupDAO.SaveOrUpdate(cabin);
            Response.Redirect(HttpContext.Current.Request.Url.ToString());
        }

        protected void GridView1_RowDeleting(object sender,
GridViewDeleteEventArgs e)
        {
            //Получить индекс выделенной строки
            int index = e.RowIndex;
            GridViewRow row = GridView1.Rows[index];
            //Получить название группы
            string key = ((Label)(row.Cells[0].FindControl("myLabel1"))).Text;
            //Создание DAO группы
            ISession hbmSession = (ISession)Session["hbmsession"];
            DAOFactory factory = new NHibernateDAOFactory(hbmSession);
            ICabinDAO groupDAO = factory.getCabinDAO();
            //Получение группы по имени
            Cabin group = groupDAO.getCabinById(Convert.ToInt32(key));
            //Удаление группы
            if (group != null)
            {
                groupDAO.Delete(group);
            }
            Response.Redirect(HttpContext.Current.Request.Url.ToString());
        }



        //Перевести строку в режим редактирования
protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
{
//Получить индекс выделенной строки
int index = e.NewEditIndex;
GridViewRow row = GridView1.Rows[index];
//Получение старых значений полей в строке GridView
string oldGroupName = ((Label)(row.Cells[0].FindControl("myLabel1"))).Text;
//Сохранение названия группы в коллекции ViewState
ViewState["oldNumber"] = oldGroupName;
GridView1.EditIndex = index;
GridView1.ShowFooter = false;
GridView1.DataBind();
}
//Отмена редактирования записи
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
    int index = e.RowIndex;
    GridViewRow row = GridView1.Rows[index];
    string newGroupName =
    ((TextBox)(row.Cells[0].FindControl("myTextBox1"))).Text;
    string newCuratorName =
    ((TextBox)(row.Cells[1].FindControl("myTextBox2"))).Text;
    /*string newHeadmanName =
    ((TextBox)(row.Cells[2].FindControl("myTextBox3"))).Text;*/
    string oldGroupName = (string)ViewState["oldNumber"];
    //Создание DAO группы
    ISession hbmSession = (ISession)Session["hbmsession"];
    DAOFactory factory = new NHibernateDAOFactory(hbmSession);
    ICabinDAO groupDAO = factory.getCabinDAO();
    //Получение группы по имени
    Cabin group = groupDAO.getCabinById(Convert.ToInt32(oldGroupName));
    group.Number = Int32.Parse(newGroupName);
    group.Opisanie = newCuratorName;
    //group.HeadmanName = newHeadmanName;
    groupDAO.SaveOrUpdate(group);
    GridView1.EditIndex = -1;
    GridView1.ShowFooter = true;
    GridView1.DataBind();
}

protected void GridView1_RowCommand(object sender,
GridViewCommandEventArgs e)
{
    if (e.CommandName == "Select")
    {
        int index = Convert.ToInt32(e.CommandArgument);
        GridViewRow row = GridView1.Rows[index];
        string cabinNumber = ((Label)(row.Cells[0].FindControl("myLabel1"))).Text;
        Session["numberCabin"] = Int32.Parse(cabinNumber);
        Response.Redirect("Passenger.aspx");
    }
}

protected void GridView1_PageIndexChanging(object sender,
GridViewPageEventArgs e)
{
    GridView1.PageIndex = e.NewPageIndex;
    GridView1.EditIndex = -1;
    GridView1.ShowFooter = true;
    GridView1.DataBind();
}

    }
}
