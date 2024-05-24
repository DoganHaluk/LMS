using AutoMapper;
using LMSApi.Services;
using LMSBase.Models.Dtos.Request;
using LMSBase.Models.Dtos.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMSApi.Controllers
{
	[Route("api/statuses")]
	[ApiController]
	public class StatusController : ControllerBase
	{
		private readonly StatusService _statusService;
		private readonly IMapper _mapper;

		public StatusController(StatusService statusService, IMapper mapper)
		{
			_statusService = statusService;
			_mapper = mapper;
		}

		[HttpGet]
		public IActionResult GetAllStatuses()
		{
			List<UpdateStatusCodelabDto> codelabStatusDto = new List<UpdateStatusCodelabDto>();
			var statuses = _statusService.GetAllStatuses();
			foreach (var status in statuses)
			{
				codelabStatusDto.Add(_mapper.Map<UpdateStatusCodelabDto>(status));
			}
			return Ok(codelabStatusDto);
		}
	}
}
