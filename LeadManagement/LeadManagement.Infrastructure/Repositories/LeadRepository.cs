using LeadManagement.Application.Interfaces.Repositories;
using LeadManagement.Domain.Entities;
using LeadManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LeadManagement.Infrastructure.Repositories
{
	public class LeadRepository : ILeadRepository
	{
		private readonly LeadContext _context;

		public LeadRepository(LeadContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Lead>> GetLeadsAsync()
		{
			return await _context.Leads.ToListAsync();
		}

		public async Task<Lead> GetLeadByIdAsync(int id)
		{
			return await _context.Leads.FindAsync(id);
		}

		public async Task AddLeadAsync(Lead lead)
		{
			await _context.Leads.AddAsync(lead);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateLeadAsync(Lead lead)
		{
			_context.Leads.Update(lead);
			await _context.SaveChangesAsync();
		}
	}
}
