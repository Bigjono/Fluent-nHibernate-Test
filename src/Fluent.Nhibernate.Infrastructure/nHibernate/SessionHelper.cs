using System.Configuration;
using Fluent.Nhibernate.Test.Model;
using FluentNHibernate.Automapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using FluentNHibernateTEst.Infrastructure.Helpers.FluentConventions;
using NHibernate;

namespace Fluent.Nhibernate.Infrastructure.nHibernate
{
    public class SessionHelper
    {

        #region static factory helper
        private static ISessionFactory _sessionFactory;
        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null) InitializeSessionFactory();
                return _sessionFactory;
            }
        }
      

        private static void InitializeSessionFactory()
        {
            _sessionFactory = Fluently.
                      Configure()
                        .Database(MySQLConfiguration.Standard.ConnectionString(c => c.FromConnectionStringWithKey("ormtestconnection")))
                        .Mappings(m =>
                              m.AutoMappings.Add(AutoMap.AssemblyOf<Customer>()
                              .Conventions.Setup(c =>
                              {
                                  c.Add<PrimaryKeyConvention>();
                                  c.Add<DefaultStringLengthConvention>();
                                  c.Add<DefaultOneToManyConvention>();
                                  c.Add<DefaultReferencesConvention>();


                              }
                              )))
                      .BuildSessionFactory();
        }

        #endregion

 
        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }

    }
}
