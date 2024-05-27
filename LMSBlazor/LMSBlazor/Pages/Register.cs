using LMSBase.Models.Dtos.Request;
using LMSBase.Models.Utilities;

namespace LMSBlazor.Pages
{
	public partial class Register
	{
		private CreateStudentDto NewStudent { get; set; }

		private List<InputError> Errors { get; set; }


		protected override async Task OnInitializedAsync()
		{
			NewStudent = new CreateStudentDto();
		}

		public async Task CreateStudent()
		{
			Errors = await _studentService.CreateStudent(NewStudent);
			if (Errors == null)
			{
				_navigation.NavigateTo("/");
			}			
		}
	}
}
