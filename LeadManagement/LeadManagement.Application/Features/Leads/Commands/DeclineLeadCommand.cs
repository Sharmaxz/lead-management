using MediatR;

namespace LeadManagement.Application.Features.Leads.Commands
{
	public class DeclineLeadCommand : IRequest<bool>
	{
		public int LeadId { get; set; }
	}
}
