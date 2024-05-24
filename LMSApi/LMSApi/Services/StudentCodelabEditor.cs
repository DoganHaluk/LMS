using AutoMapper;
using LMSBase.Models.Domain;
using LMSBase.Models.Dtos.Response;
using Microsoft.EntityFrameworkCore;

namespace LMSApi.Services
{
	public class StudentCodelabEditor
	{
		private readonly StudentCodelabService _studentCodelabService;
		private readonly StudentService _studentService;
		private readonly IMapper _mapper;
		private readonly CodelabService _codelabService;

		public StudentCodelabEditor(StudentCodelabService studentCodelabService,StudentService studentService,IMapper mapper,CodelabService codelabService)
		{
			_studentCodelabService = studentCodelabService;
			_studentService = studentService;
			_mapper = mapper;
			_codelabService = codelabService;
		}


		public List<StudentCodelab> GetStudentCodelabs(int id)
		{
			return _studentCodelabService.GetStudentCodelabs(id);
		}

		public StudentCodelab CreateStudentCodelab(StudentCodelab studentCodelab)
		{
			return _studentCodelabService.CreateStudentCodelab(studentCodelab);
		}

		public StudentCodelab UpdateStatus(int id, StudentCodelab studentCodelab)
		{
			studentCodelab.CodelabId = id;
			return _studentCodelabService.UpdateStatus(studentCodelab);
		}

		public StudentCodelab UpdateComment(int id,StudentCodelab studentCodelab)
		{
			studentCodelab.CodelabId = id;
			return _studentCodelabService.UpdateComment(studentCodelab);
		}

		public List<Progression> GetProgressions(int schoolClassId,int moduleId)
		{
			List<Progression> progressions = new List<Progression>(); 
			//get list of students of the class
			List<StudentProgressionDto> students = _mapper.Map<List<StudentProgressionDto>>(_studentService.GetStudentsFromClass(schoolClassId));
			// get list of codelabsId from the module
			List<int> codelabs = _codelabService.GetCodelabIdsFromModule(moduleId);
			// For each student, see if there's a finished codelab.
			foreach(var student in students)
			{
				Progression progression = new Progression()
				{
					StudentName = student.UserName,
				};
				foreach(var codelabId in codelabs)
				{
					progression.TotalCodelabs += 1;
					var progress = _studentCodelabService.GetStudentCodelabWithDoneStatus(student.UserId, codelabId);
					if(progress != null)
					{
						progression.FinishedCodelabs += 1;
					}
				}
				progressions.Add(progression);
			}
			return progressions;
		}
	}
}
