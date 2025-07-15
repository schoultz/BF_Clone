using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

using Microsoft.Extensions.Configuration;
using System.IO;

namespace BostadStockholm.Data
{
    public static class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;

        public static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    InitializeSessionFactory();
                }
                return _sessionFactory;
            }
        }

        //        private static void InitializeSessionFactory()
        //        {
        //            _sessionFactory = Fluently.Configure()
        //                .Database(MsSqlConfiguration.MsSql2012
        //                    .ConnectionString(c => 
        //                        c.FromConnectionStringWithKey("DefaultConnection")))
        //                .Mappings(m => m.FluentMappings
        //                    .AddFromAssembly(Assembly.GetExecutingAssembly()))
        //                .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true))
        //                .BuildSessionFactory();
        //       }

        private static void InitializeSessionFactory()
        {
            // Load configuration from appsettings.json
            var configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            _sessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012
                    .ConnectionString(connectionString))
                .Mappings(m => m.FluentMappings
                    .AddFromAssembly(Assembly.GetExecutingAssembly()))
                .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true))
                .BuildSessionFactory();
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}