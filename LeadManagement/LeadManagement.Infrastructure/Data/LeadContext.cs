using LeadManagement.Domain.Entities;
using LeadManagement.Domain.Events;
using Microsoft.EntityFrameworkCore;

namespace LeadManagement.Infrastructure.Data
{
	public class LeadContext : DbContext
	{
		public LeadContext(DbContextOptions<LeadContext> options) : base(options) { }

		public DbSet<BaseEvent> Events { get; set; }

		public DbSet<Lead> Leads { get; set; }

	}
}