using Entities;
using FluentNHibernate.Mapping;

namespace DataAccessLayer.Mappings
{
	public class ProjectMap : ClassMap<Project>
	{
		public ProjectMap()
		{
			Id(x => x.Id);
			Map(x => x.Name);
			Map(x => x.FinishDate);
			Map(x => x.Finished);
			Map(x => x.Delayed);
			Map(x => x.LastChanged);

			References(x => x.Customer);
			References(x => x.Contact);
			References(x => x.AccountManager);
		}
	}
}