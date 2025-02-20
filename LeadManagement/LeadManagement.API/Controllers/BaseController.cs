﻿using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LeadManagement.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public abstract class BaseController : ControllerBase
	{
		protected readonly IMediator _mediator;

		protected BaseController(IMediator mediator)
		{
			_mediator = mediator;
		}
	}
}
