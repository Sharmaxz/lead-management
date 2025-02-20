using LeadManagement.Domain.Entities;
using MediatR;

namespace LeadManagement.Application.Features.Leads.Queries
{
	public class GetLeadsQuery : IRequest<IEnumerable<Lead>> { }
}

