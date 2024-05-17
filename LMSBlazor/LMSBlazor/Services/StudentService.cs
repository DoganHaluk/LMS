using LMSBase.Models.Domain;
using LMSBase.Models.Dtos.Response;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LMSBlazor.Services
{
    public class StudentService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _serializerOptions;

        public StudentService(HttpClient httpClient)
        {
            _httpClient = httpClient;
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
            StudentSummaryDto student = new StudentSummaryDto();
			var apiResponse = await _httpClient.GetStreamAsync($"/api/student/{id}");
			student = JsonSerializer.Deserialize<StudentSummaryDto>(apiResponse, _serializerOptions);
            return student;
		}
    }
}
