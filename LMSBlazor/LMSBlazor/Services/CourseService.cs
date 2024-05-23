using LMSBase.Models.Dtos.Response;
using System.Net.Http.Json;
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

		public async Task EditCourseName(int courseId,CourseDto courseDto)
		{
			var apiResponse = await _httpClient.PutAsJsonAsync($"/api/courses/{courseId}", courseDto);
			apiResponse.EnsureSuccessStatusCode();
		}

		public async Task DeleteCourse(int courseId)
		{
			var apiResponse = await _httpClient.DeleteAsync($"/api/courses/{courseId}");
			apiResponse.EnsureSuccessStatusCode();
		}

		public async Task CreateCourse(CourseDto course)
		{
			var apiResponse = await _httpClient.PostAsJsonAsync("/api/courses",course);
			apiResponse.EnsureSuccessStatusCode();
		}
	}
}
