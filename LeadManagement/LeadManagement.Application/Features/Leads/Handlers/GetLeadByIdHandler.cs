using LeadManagement.Application.DTOs;
using LeadManagement.Application.Features.Leads.Queries;
using LeadManagement.Application.Interfaces.Repositories;
using MediatR;

namespace LeadManagement.Application.Features.Leads.Handlers
{
    public class GetLeadByIdHandler : IRequestHandler<GetLeadByIdQuery, LeadDto>
	{
		private readonly ILeadRepository _repository;

		public GetLeadByIdHandler(ILeadRepository repository)
		{
			_repository = repository;
		}

		public async Task<LeadDto> Handle(GetLeadByIdQuery request, CancellationToken cancellationToken)
		{
			var lead = await _repository.GetLeadByIdAsync(request.LeadId);
			if (lead == null) return null;

			return new LeadDto
			{
				ContactFirstName = lead.ContactFirstName,
				ContactFullName = lead.ContactFullName,
				ContactPhoneNumber = lead.ContactPhoneNumber,
				ContactEmail = lead.ContactEmail,
				Suburb = lead.Suburb,
				Category = lead.Category,
				Description = lead.Description,
				Price = lead.Price
			};
		}
	}
}
