using LMSBase.Models.Dtos.Response;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LMSBlazor.Services
{
	public class CourseService
	{
		private readonly HttpClient _httpClient;
		private readonly JsonSerializerOptions _serializerOptions;

		public CourseService(HttpClient httpClient)
		{
			_httpClient = httpClient;
			_serializerOptions = new JsonSerializerOptions()
			{
				PropertyNameCaseInsensitive = true,
				ReferenceHandler = ReferenceHandler.Preserve
			};
		}

		public async Task<CourseOverviewDto> GetCourseOverview(int id)
		{
			CourseOverviewDto course = new CourseOverviewDto();
			var apiResponse = await _httpClient.GetStreamAsync($"/api/courses/{id}");
			course = JsonSerializer.Deserialize<CourseOverviewDto>(apiResponse, _serializerOptions);
			return course;
		}

		public async Task<List<CourseDto>> GetCourses()
		{
			List<CourseDto> courses = new List<CourseDto>();
			var apiResponse = await _httpClient.GetStreamAsync("/api/courses");
			courses = JsonSerializer.Deserialize<List<CourseDto>>(apiResponse, _serializerOptions);
			return courses;
		}
	}
}
