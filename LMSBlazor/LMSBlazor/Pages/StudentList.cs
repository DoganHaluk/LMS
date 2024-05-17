using LMSBase.Models.Dtos.Response;
using LMSBlazor.Services;
using Microsoft.AspNetCore.Components;

namespace LMSBlazor.Pages
{
    public partial class StudentList
    {
        [Inject]

        private StudentService _studentService {  get; set; }

        public List<StudentSummaryDto> AllStudents { get; set; } = new List<StudentSummaryDto>();

        protected override async Task OnInitializedAsync()
        {
            AllStudents = await _studentService.GetStudents();
        }

    }
}
