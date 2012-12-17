using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer.Mappings;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace DataAccessLayer
{
	public class NHibernateHelper
	{
		private static ISessionFactory _sessionFactory;

		private static ISessionFactory SessionFactory
		{
			get 
			{ 
				if (_sessionFactory == null)
				{
					CreateSessionFactory();
				}
				return _sessionFactory;
			}
		}

		private static void CreateSessionFactory()
		{
			_sessionFactory = Fluently.Configure()
				.Database(MsSqlConfiguration.MsSql2008.ConnectionString(conn => conn.FromConnectionStringWithKey("NPSConnectionString")))
				.Mappings(m => m.FluentMappings.AddFromAssemblyOf<ActionLogMap>())
				.Mappings(m => m.FluentMappings.AddFromAssemblyOf<AccountManagerMap>())
				.Mappings(m => m.FluentMappings.AddFromAssemblyOf<CustomerMap>())
				.Mappings(m => m.FluentMappings.AddFromAssemblyOf<ContactMap>())
				.Mappings(m => m.FluentMappings.AddFromAssemblyOf<ProjectMap>())
				.BuildSessionFactory();
		}

		public static void InstallSessionFactory()
		{
			//TODO: this should be able to be done more efficiently re. CreateSessionFactory()
			_sessionFactory = Fluently.Configure()
				.Database(MsSqlConfiguration.MsSql2008.ConnectionString(conn => conn.FromConnectionStringWithKey("NPSConnectionString")))
				.Mappings(m => m.FluentMappings.AddFromAssemblyOf<ActionLogMap>())
				.Mappings(m => m.FluentMappings.AddFromAssemblyOf<AccountManagerMap>())
				.Mappings(m => m.FluentMappings.AddFromAssemblyOf<CustomerMap>())
				.Mappings(m => m.FluentMappings.AddFromAssemblyOf<ContactMap>())
				.Mappings(m => m.FluentMappings.AddFromAssemblyOf<ProjectMap>())
				//WARNING: this resets the complete database!
				.ExposeConfiguration(BuildSchema)
				.BuildSessionFactory();
		}

		private static void BuildSchema(Configuration config)
		{
			new SchemaExport(config).Create(true, true);
		}

		public static ISession OpenSession()
		{
			return SessionFactory.OpenSession();
		}
	}
}
