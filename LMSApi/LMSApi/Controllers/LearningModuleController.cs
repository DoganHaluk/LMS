using LMSApi.Services;
using LMSBase.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace LMSApi.Controllers
{
	[Route("api/modules")]
	[ApiController]
	public class LearningModuleController : ControllerBase
	{
		private readonly LearningModuleEditor _learningModuleEditor;
		private readonly LearningModuleService _learningModuleService;

		public LearningModuleController(LearningModuleEditor learningModuleEditor, LearningModuleService learningModuleService)
		{
			_learningModuleEditor = learningModuleEditor;
			_learningModuleService = learningModuleService;
		}

		[HttpGet]
		public IActionResult GetLearningModules()
		{
			return Ok(_learningModuleService.GetLearningModules());
		}

		[HttpGet("{id}")]
		public IActionResult GetLearningModuleById(int id) 
		{
			return Ok(_learningModuleService.GetLearningModuleById(id));
		}

		[HttpPost]
		public IActionResult CreateLearningModule(LearningModuleDto learningModuleDto)
		{
			var newLearningModule = _learningModuleEditor.CreateLearningModule(learningModuleDto);
			return Created($"/api/modules/{newLearningModule.LearningModuleId}", newLearningModule);
		}

		[HttpPut("{id}")]
		public IActionResult UpdateLearningModule(int id, LearningModuleNameDto learningModuleNameDto)
		{
			var newLearningModule =_learningModuleEditor.UpdateLearningModuleName(id, learningModuleNameDto);
			return Created($"/api/modules/{newLearningModule.LearningModuleId}", newLearningModule);
		}
	}
}
