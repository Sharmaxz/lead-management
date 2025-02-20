using LeadManagement.Application.Interfaces.Repositories;
using LeadManagement.Domain.Events;
using LeadManagement.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LeadManagement.Infrastructure.Repositories
{
	public class EventRepository : IEventRepository
	{
		private readonly LeadContext _context;

		public EventRepository(LeadContext context)
		{
			_context = context;
		}

		public async Task SaveEventAsync(BaseEvent eventData)
		{
			await _context.Set<BaseEvent>().AddAsync(eventData);
			await _context.SaveChangesAsync();
		}

		public async Task<List<BaseEvent>> GetEventsByTypeAsync(string eventType)
		{
			return await _context.Set<BaseEvent>()
				.Where(e => e.EventType == eventType)
				.OrderBy(e => e.Timestamp)
				.ToListAsync();
		}
	}
}
