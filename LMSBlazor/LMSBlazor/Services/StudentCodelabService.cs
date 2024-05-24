using System.Text.Json.Serialization;
using System.Text.Json;
using LMSBase.Models.Dtos.Response;
using LMSBase.Models.Dtos.Request;
using System.Net.Http.Json;

namespace LMSBlazor.Services
{
	public class StudentCodelabService
	{
		private readonly HttpClient _httpClient;
		private readonly JsonSerializerOptions _serializerOptions;

		public StudentCodelabService(HttpClient httpClient)
		{
			_httpClient = httpClient;
			_serializerOptions = new JsonSerializerOptions()
			{
				PropertyNameCaseInsensitive = true,
				ReferenceHandler = ReferenceHandler.Preserve
			};
		}

		public async Task<StudentCodelabSummaryDto> CreateStudentCodelab(CreateStudentCodelabDto createStudentCodelabDto)
		{
			StudentCodelabSummaryDto studentCodelab = new StudentCodelabSummaryDto();
			var apiResponse = await _httpClient.PostAsJsonAsync("/api/studentcodelabs", createStudentCodelabDto);
			studentCodelab = JsonSerializer.Deserialize<StudentCodelabSummaryDto>(apiResponse.Content.ReadAsStream(), _serializerOptions);
			return studentCodelab;
		}

		public async Task<List<UpdateStatusCodelabDto>> GetStatuses()
		{
			List<UpdateStatusCodelabDto> statuses = new List<UpdateStatusCodelabDto>();
			var apiResponse = await _httpClient.GetStreamAsync("/api/studentcodelabs/statuses");
			statuses = JsonSerializer.Deserialize<List<UpdateStatusCodelabDto>>(apiResponse, _serializerOptions);
			return statuses;
		}


	}
}
