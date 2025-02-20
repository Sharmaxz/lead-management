using LeadManagement.Application.Features.Leads.Commands;
using LeadManagement.Application.Interfaces.Repositories;
using LeadManagement.Domain.Entities;
using LeadManagement.Domain.Events;
using MediatR;
using System.Text.Json;

namespace LeadManagement.Application.Features.Leads.Handlers
{
	public class CreateLeadHandler : IRequestHandler<CreateLeadCommand, int>
	{
		private readonly IEventRepository _eventRepository;
		private readonly ILeadRepository _repository;

		public CreateLeadHandler(IEventRepository eventRepository, ILeadRepository repository)
		{
			_eventRepository = eventRepository;
			_repository = repository;
		}

		public async Task<int> Handle(CreateLeadCommand request, CancellationToken cancellationToken)
		{
			var lead = new Lead
			{
				ContactFirstName = request.Lead.ContactFirstName,
				ContactFullName = request.Lead.ContactFullName,
				ContactPhoneNumber = request.Lead.ContactPhoneNumber,
				ContactEmail = request.Lead.ContactEmail,
				DateCreated = DateTime.UtcNow,
				Suburb = request.Lead.Suburb,
				Category = request.Lead.Category,
				Description = request.Lead.Description,
				Price = request.Lead.Price,
				Status = "Invited"
			};

			await _repository.AddLeadAsync(lead);


			await _eventRepository.SaveEventAsync(new BaseEvent(
				 "LeadCreated",
				 JsonSerializer.Serialize(new { lead.Id, lead.ContactFullName, lead.Status })
			 ));

			return lead.Id;
		}
	}
}
