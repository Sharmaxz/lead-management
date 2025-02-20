using LeadManagement.Application.DTOs;
using MediatR;

namespace LeadManagement.Application.Features.Leads.Queries
{
	public class GetLeadByIdQuery : IRequest<LeadDto>
	{
		public int LeadId { get; set; }

		public GetLeadByIdQuery(int leadId)
		{
			LeadId = leadId;
		}
	}
}
