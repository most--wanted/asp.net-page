using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Npgsql;
using NHibernate;
using System.Reflection;
using FluentNHibernate;
using NHibernate.Cfg;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Tool.hbm2ddl;

namespace lab5
{
    public partial class Ship : System.Web.UI.MasterPage
    {

        private ISessionFactory factory;
        private ISession session;

        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            session = openSession("localhost", 5432,
            "ship", "postgres", "qwerty");
            Session["hbmsession"] = session;
        }


        private ISession openSession(String host, int port, String database,
String user, String passwd)
        {
            ISession session = null;
            //Получение ссылки на текущую сборку
            Assembly mappingsAssemly = Assembly.GetExecutingAssembly();
            if (factory == null)
            {
                //Конфигурирование фабрики сессий
                factory = Fluently.Configure()
                .Database(PostgreSQLConfiguration
                .PostgreSQL82.ConnectionString(c => c
                .Host(host)
                .Port(port)
                .Database(database)
                .Username(user)
                .Password(passwd)))
                .Mappings(m => m.FluentMappings
                .AddFromAssembly(mappingsAssemly))
                .ExposeConfiguration(BuildSchema)
                .BuildSessionFactory();
            }
            //Открытие сессии
            session = factory.OpenSession();
            return session;
        }
        //Метод для автоматического создания таблиц в базе данных
        private static void BuildSchema(Configuration config)
        {
            new SchemaExport(config).Create(false, false);
        }
    }
}
