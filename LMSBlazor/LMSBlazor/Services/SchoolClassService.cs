using System.Text.Json.Serialization;
using System.Text.Json;
using LMSBase.Models.Dtos.Response;
using LMSBase.Models.Dtos.Request;
using System.Net.Http.Json;
using LMSBase.Models.Domain;
using LMSBase.Models.Utilities;
using System.Net;

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

		public async Task<SchoolClassSummaryDto> GetSchoolClassSummary(int schoolClassId)
		{
			SchoolClassSummaryDto schoolclass = new SchoolClassSummaryDto();
			var apiResponse = await _httpClient.GetStreamAsync($"/api/SchoolClass/{schoolClassId}");
			schoolclass = JsonSerializer.Deserialize<SchoolClassSummaryDto>(apiResponse, _serializerOptions);
			return schoolclass;
		}

		public async Task<List<InputError>> CreateSchoolClass(CreateSchoolClassDto createSchoolClassDto)
		{
			var apiResponse = await _httpClient.PostAsJsonAsync("/api/SchoolClass/SchoolcLass",createSchoolClassDto);
			if (apiResponse.StatusCode == HttpStatusCode.BadRequest)
			{
				var errors = JsonSerializer.Deserialize<List<InputError>>(apiResponse.Content.ReadAsStream(), _serializerOptions);
				return errors;
			}
			return null;
		}
	}
}
