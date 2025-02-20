using LeadManagement.Application.DTOs;
using MediatR;

namespace LeadManagement.Application.Features.Leads.Commands
{
	public class CreateLeadCommand : IRequest<int>
	{
		public LeadDto Lead { get; set; }
	}
}
