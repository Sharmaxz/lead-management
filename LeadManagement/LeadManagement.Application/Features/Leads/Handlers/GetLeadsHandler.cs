using LeadManagement.Application.Features.Leads.Queries;
using LeadManagement.Application.Interfaces.Repositories;
using LeadManagement.Domain.Entities;
using MediatR;

namespace LeadManagement.Application.Features.Leads.Handlers
{
    public class GetLeadsHandler : IRequestHandler<GetLeadsQuery, IEnumerable<Lead>>
	{
		private readonly ILeadRepository _repository;

		public GetLeadsHandler(ILeadRepository repository)
		{
			_repository = repository;
		}

		public async Task<IEnumerable<Lead>> Handle(GetLeadsQuery request, CancellationToken cancellationToken)
		{
			return await _repository.GetLeadsAsync();
		}
	}
}
