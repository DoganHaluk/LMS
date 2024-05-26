using LMSBase.Models.Dtos.Request;

namespace LMSBlazor.Pages
{
	public partial class Register
	{
		public CreateStudentDto NewStudent { get; set; }


		protected override async Task OnInitializedAsync()
		{
			NewStudent = new CreateStudentDto();
		}

		public async Task CreateStudent()
		{
			await _studentService.CreateStudent(NewStudent);
			_navigation.NavigateTo("/");
		}
	}
}
