using Entities;
using FluentNHibernate.Mapping;

namespace DataAccessLayer.Mappings
{
	public class CustomerMap : ClassMap<Customer>
	{
		public CustomerMap()
		{
			Id(x => x.Id);
			Map(x => x.Name);

			HasMany(x => x.Contacts).Cascade.All();
			HasMany(x => x.Projects).Cascade.All();
		}
	}
}