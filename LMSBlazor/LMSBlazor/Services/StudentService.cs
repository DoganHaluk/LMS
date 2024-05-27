using LMSBase.Models.Domain;
using LMSBase.Models.Dtos.Request;
using LMSBase.Models.Dtos.Response;
using LMSBase.Models.Utilities;
using System.Net.Http.Json;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net;

namespace LMSBlazor.Services
{
    public class StudentService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _serializerOptions;
        private readonly TokenService _tokenService;

        public StudentService(HttpClient httpClient,TokenService tokenService)
        {
            _httpClient = httpClient;
            _tokenService = tokenService;
            _serializerOptions = new JsonSerializerOptions()
            {
                PropertyNameCaseInsensitive = true,
                ReferenceHandler = ReferenceHandler.Preserve
            };
        }

        public async Task<List<StudentSummaryDto>> GetStudents()
        {
            List<StudentSummaryDto> students = new List<StudentSummaryDto>();
            var apiResponse = await _httpClient.GetStreamAsync("/api/student");
            students = JsonSerializer.Deserialize<List<StudentSummaryDto>>(apiResponse, _serializerOptions);
            return students;
        }


        public async Task<StudentSummaryDto> GetStudentProfile(int id)
        {
			await _tokenService.AddTokenAsync();
			StudentSummaryDto student = new StudentSummaryDto();
			var apiResponse = await _httpClient.GetStreamAsync($"/api/student/{id}");
			student = JsonSerializer.Deserialize<StudentSummaryDto>(apiResponse, _serializerOptions);
            return student;
		}


        public async Task<List<InputError>> EditStudentProfile(int id,EditStudentProfileDto editStudentProfileDto)
        {

            var apiResponse = await _httpClient.PostAsJsonAsync($"/api/student/{id}", editStudentProfileDto);
            if (apiResponse.StatusCode == HttpStatusCode.BadRequest)
            {
                var errors = JsonSerializer.Deserialize<List<InputError>>(apiResponse.Content.ReadAsStream(), _serializerOptions);
                return errors;
			}
            return null;
		}

        public async Task<List<InputError>> CreateStudent(CreateStudentDto createStudentDto)
        {
			var apiResponse = await _httpClient.PostAsJsonAsync($"/api/student", createStudentDto);
			if (apiResponse.StatusCode == HttpStatusCode.BadRequest)
			{
				var errors = JsonSerializer.Deserialize<List<InputError>>(apiResponse.Content.ReadAsStream(), _serializerOptions);
				return errors;
			}
			return null;
		}
    }
}
