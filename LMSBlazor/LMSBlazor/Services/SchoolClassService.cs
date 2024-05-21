using System.Text.Json.Serialization;
using System.Text.Json;
using LMSBase.Models.Dtos.Response;
using LMSBase.Models.Dtos.Request;
using System.Net.Http.Json;

namespace LMSBlazor.Services
{
	public class SchoolClassService
	{
		private readonly HttpClient _httpClient;
		private readonly JsonSerializerOptions _serializerOptions;

		public SchoolClassService(HttpClient httpClient)
		{
			_httpClient = httpClient;
			_serializerOptions = new JsonSerializerOptions()
			{
				PropertyNameCaseInsensitive = true,
				ReferenceHandler = ReferenceHandler.Preserve
			};
		}

		public async Task<List<SchoolClassSummaryDto>> GetAllSchoolClasses()
		{
			List<SchoolClassSummaryDto> schoolClasses = new List<SchoolClassSummaryDto>();
			var apiResponse = await _httpClient.GetStreamAsync("/api/SchoolClass/SchoolClasses");
			schoolClasses = JsonSerializer.Deserialize<List<SchoolClassSummaryDto>>(apiResponse, _serializerOptions);
			return schoolClasses;
		}

		public async Task<SchoolClassOverviewDto> GetSchoolClassOverview(int schoolClassId)
		{
			SchoolClassOverviewDto schoolclass = new SchoolClassOverviewDto();
			var apiResponse = await _httpClient.GetStreamAsync($"/api/SchoolClass/ClassOverview/{schoolClassId}");
			schoolclass = JsonSerializer.Deserialize<SchoolClassOverviewDto>(apiResponse, _serializerOptions);
			return schoolclass;
		}

		public async Task<SchoolClassSummaryDto> CreateSchoolClass(CreateSchoolClassDto createSchoolClassDto)
		{
			var apiResponse = await _httpClient.PostAsJsonAsync("/api/SchoolClass/SchoolcLass",createSchoolClassDto);
			SchoolClassSummaryDto newClass = JsonSerializer.Deserialize<SchoolClassSummaryDto>(apiResponse.Content.ReadAsStream(), _serializerOptions);
			return newClass;
		}
	}
}
