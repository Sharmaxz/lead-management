using LeadManagement.Application.Features.Leads.Commands;
using LeadManagement.Application.Interfaces;
using LeadManagement.Application.Interfaces.Repositories;
using LeadManagement.Domain.Events;
using MediatR;
using System.Text.Json;

namespace LeadManagement.Application.Features.Leads.Handlers
{
	public class AcceptLeadHandler : IRequestHandler<AcceptLeadCommand, bool>
	{
		private readonly IEventRepository _eventRepository;
		private readonly ILeadRepository _repository;
		private readonly IEmailService _emailService;

		public AcceptLeadHandler(IEventRepository eventRepository, ILeadRepository repository, IEmailService emailService)
		{
			_eventRepository = eventRepository;
			_repository = repository;
			_emailService = emailService;
		}

		public async Task<bool> Handle(AcceptLeadCommand request, CancellationToken cancellationToken)
		{
			var lead = await _repository.GetLeadByIdAsync(request.LeadId);
			if (lead == null) return false;

			lead.Status = "Accepted";

			if (lead.Price > 500)
			{
				lead.Price *= 0.9m; // Aplica 10% de desconto
			}

			await _repository.UpdateLeadAsync(lead);

			await _eventRepository.SaveEventAsync(new BaseEvent(
				"LeadAccepted",
				 JsonSerializer.Serialize(new { lead.Id, lead.ContactFullName, lead.Status })
			));

			await _emailService.SendEmailAsync("vendas@test.com", "Lead Aceito", $"O lead {lead.ContactFullName} foi aceito. Preço final: {lead.Price}");

			return true;
		}
	}
}
