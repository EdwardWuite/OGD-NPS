using System;
using System.Linq;
using System.Text;

namespace Entities
{
	public class Project
	{
		public virtual int Id { get; set; }
		public virtual string Name { get; set; }
		public virtual int Delayed { get; set; }
		public virtual bool Finished { get; set; }
		public virtual DateTime LastChanged { get; set; }
		public virtual DateTime FinishDate { get; set; }
		public virtual Contact Contact { get; set; }
		public virtual Customer Customer { get; set; }
		public virtual AccountManager AccountManager { get; set; }
	}
}
