using LeadManagement.Application.Features.Leads.Commands;
using LeadManagement.Application.Interfaces.Repositories;
using LeadManagement.Domain.Events;
using MediatR;
using System.Text.Json;

namespace LeadManagement.Application.Features.Leads.Handlers
{
	public class DeclineLeadHandler : IRequestHandler<DeclineLeadCommand, bool>
	{
		private readonly IEventRepository _eventRepository;
		private readonly ILeadRepository _repository;

		public DeclineLeadHandler(IEventRepository eventRepository, ILeadRepository repository)
		{
			_eventRepository = eventRepository;
			_repository = repository;
		}

		public async Task<bool> Handle(DeclineLeadCommand request, CancellationToken cancellationToken)
		{
			var lead = await _repository.GetLeadByIdAsync(request.LeadId);
			if (lead == null) return false;

			lead.Status = "Declined";

			await _repository.UpdateLeadAsync(lead);

			await _eventRepository.SaveEventAsync(new BaseEvent(
				"LeadDeclined",
				JsonSerializer.Serialize(new { lead.Id, lead.ContactFullName, lead.Status })
			));

			return true;
		}
	}
}
