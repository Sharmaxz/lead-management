using LeadManagement.Domain.Entities;

namespace LeadManagement.Application.Interfaces.Repositories
{
	public interface ILeadRepository
    {
        Task<IEnumerable<Lead>> GetLeadsAsync();
        Task<Lead> GetLeadByIdAsync(int id);
        Task AddLeadAsync(Lead lead);
        Task UpdateLeadAsync(Lead lead);
    }
}
