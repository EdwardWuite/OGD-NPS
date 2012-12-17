using System.Collections.Generic;

namespace Entities
{
	public class AccountManager
	{
		public virtual int Id { get; set; }
		public virtual string Name { get; set; }
		public virtual IList<Project> Projects { get; set; }

		public AccountManager()
		{
			Projects = new List<Project>();
		}
	}
}