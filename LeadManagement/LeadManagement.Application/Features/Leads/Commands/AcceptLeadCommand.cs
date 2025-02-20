using MediatR;

namespace LeadManagement.Application.Features.Leads.Commands
{
	public class AcceptLeadCommand : IRequest<bool>
	{
		public int LeadId { get; set; }
	}
}
