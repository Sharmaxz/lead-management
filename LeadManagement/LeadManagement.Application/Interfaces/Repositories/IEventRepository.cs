using LeadManagement.Domain.Events;


namespace LeadManagement.Application.Interfaces.Repositories
{
	public interface IEventRepository
	{
		Task SaveEventAsync(BaseEvent eventData);
		Task<List<BaseEvent>> GetEventsByTypeAsync(string eventType);
	}
}
