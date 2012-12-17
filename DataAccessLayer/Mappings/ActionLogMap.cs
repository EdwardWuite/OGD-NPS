using Entities;
using FluentNHibernate.Mapping;

namespace DataAccessLayer.Mappings
{
	public class ActionLogMap : ClassMap<ActionLog>
	{
		public ActionLogMap()
		{
			Id(x => x.Id);
			Map(x => x.ActionDate);
			Map(x => x.AccountManagerName);
			Map(x => x.CustomerName);
			Map(x => x.ProjectName);
			Map(x => x.ContactName);
			Map(x => x.Finished);
		}
	}
}