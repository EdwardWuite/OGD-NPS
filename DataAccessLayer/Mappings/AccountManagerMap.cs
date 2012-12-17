using Entities;
using FluentNHibernate.Mapping;

namespace DataAccessLayer.Mappings
{
	public class AccountManagerMap : ClassMap<AccountManager>
	{
		public AccountManagerMap()
		{
			Id(x => x.Id);
			Map(x => x.Name);

			HasMany(x=>x.Projects).Cascade.All();
		}
	}
}