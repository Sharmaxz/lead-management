using LeadManagement.Application.DTOs;
using LeadManagement.Application.Features.Leads.Commands;
using LeadManagement.Application.Features.Leads.Queries;
using LeadManagement.Domain.Entities;
using LeadManagement.Domain.Events;
using LeadManagement.Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LeadManagement.API.Controllers
{
	public class LeadsController : BaseController
	{
		public LeadsController(IMediator mediator) : base(mediator)
		{
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Lead>>> GetAllLeads()
		{
			var query = new GetLeadsQuery();
			var result = await _mediator.Send(query);
			return Ok(result);
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Lead>> GetLeadById(int id)
		{
			var query = new GetLeadByIdQuery(id);
			var result = await _mediator.Send(query);
			if (result == null) return NotFound();
			return Ok(result);
		}

		[HttpPost]
		public async Task<ActionResult<int>> CreateLead([FromBody] LeadDto leadDto)
		{
			var command = new CreateLeadCommand { Lead = leadDto };
			var leadId = await _mediator.Send(command);
			return CreatedAtAction(nameof(GetLeadById), new { id = leadId }, leadId);
		}

		[HttpPut("{id}/accept")]
		public async Task<IActionResult> AcceptLead(int id)
		{
			var command = new AcceptLeadCommand { LeadId = id };
			var result = await _mediator.Send(command);
			if (!result) return NotFound();
			return NoContent();
		}

		[HttpPut("{id}/decline")]
		public async Task<IActionResult> DeclineLead(int id)
		{
			var command = new DeclineLeadCommand { LeadId = id };
			var result = await _mediator.Send(command);
			if (!result) return NotFound();
			return NoContent();
		}
	}
}
