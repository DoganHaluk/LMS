using LMSBase.Models.Dtos.Request;
using LMSBase.Models.Dtos.Response;
using LMSBlazor.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using System.Text.Json;

namespace LMSBlazor.Pages
{
	public partial class AddCourses
	{
		[SupplyParameterFromQuery]
		private int UserId { get; set; }

		[SupplyParameterFromQuery]
		private int SchoolClassId { get; set; }

		private List<CourseDto> Courses { get; set; }

		private SchoolClassSummaryDto SchoolClass { get; set; }

		private CreateSchoolClassCourseDto? CreateSchoolClassCourseDto { get; set; }

		//private string ModelJson { get; set; }

		//private string RequestJson { get; set; }

		//private EditContext EditContext { get; set; }


		protected override async Task OnInitializedAsync()
		{
			Courses = new List<CourseDto>();
			SchoolClass = new SchoolClassSummaryDto();
			Courses = await _courseService.GetCourses();
			SchoolClass = await _schoolClassService.GetSchoolClassSummary(SchoolClassId);
			var courseIds = await _schoolClassCourseService.CheckSchoolClassCourses(SchoolClassId);
			foreach (var course in Courses)
			{
				foreach (var id in  courseIds)
				{
					if (course.CourseId == id)
					{
						course.Selected = true;
					}
				}
			}
			//SetModelJson();
			//EditContext = new EditContext(Courses);
			//EditContext.OnFieldChanged += EditContext_OnFieldChanged;
		}

		//private void EditContext_OnFieldChanged(object? sender, FieldChangedEventArgs e)
		//{
		//	SetModelJson();
		//}

		public async Task CreateSchoolClassCourses()
		{
			//SetModelJson();
			await _schoolClassCourseService.CreateSchoolClassCourses(CreateDto());
			_navigation.NavigateTo($"/classoverview?UserId={UserId}&SchoolClassId={SchoolClassId}");
		}

		//public void SetModelJson()
		//{
		//	ModelJson = JsonSerializer.Serialize(Courses,new JsonSerializerOptions { WriteIndented = true });
		//}	
		
		public CreateSchoolClassCourseDto CreateDto()
		{
			CreateSchoolClassCourseDto = new CreateSchoolClassCourseDto()
			{
				SchoolClassId = SchoolClassId,
				CourseIds = Courses.Where(c => c.Selected == true).Select(c => c.CourseId).ToList()
			};
			//RequestJson = JsonSerializer.Serialize(CreateSchoolClassCourseDto, new JsonSerializerOptions { WriteIndented = true });
			return CreateSchoolClassCourseDto;
		}

		public void NavigateToCourseDashboard()
		{
			_navigation.NavigateTo($"/coursedashboard?UserId={UserId}");
		}
	}
}
