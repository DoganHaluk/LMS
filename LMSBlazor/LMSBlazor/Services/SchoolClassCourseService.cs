using System.Text.Json.Serialization;
using System.Text.Json;
using LMSBase.Models.Dtos.Request;
using System.Net.Http.Json;

namespace LMSBlazor.Services
{
	public class SchoolClassCourseService
	{
		private readonly HttpClient _httpClient;
		private readonly JsonSerializerOptions _serializerOptions;

		public SchoolClassCourseService(HttpClient httpClient)
		{
			_httpClient = httpClient;
			_serializerOptions = new JsonSerializerOptions()
			{
				PropertyNameCaseInsensitive = true,
				ReferenceHandler = ReferenceHandler.Preserve
			};
		}


		public async Task CreateSchoolClassCourses(CreateSchoolClassCourseDto createSchoolClassCourseDto)
		{
			var apiResponse = await _httpClient.PostAsJsonAsync("/api/SchoolClassCourse", createSchoolClassCourseDto);
			apiResponse.EnsureSuccessStatusCode();
		}

	}
}
