using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entities;
using FluentNHibernate.Mapping;

namespace DataAccessLayer.Mappings
{
	public class ContactMap : ClassMap<Contact>
	{
		public ContactMap()
		{
			Id(x => x.Id);
			Map(x => x.Name);
			Map(x => x.EmailAddress);

			References(x => x.Customer);

			HasMany(x => x.Projects).Cascade.All();
		}
	}
}
