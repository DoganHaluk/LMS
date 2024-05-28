using LMSBase.Models.Dtos.Request;
using LMSBase.Models.Utilities;

namespace LMSBlazor.Pages
{
	public partial class Register
	{
		private CreateStudentDto NewStudent { get; set; }

		private List<InputError> Errors { get; set; }

		private bool isPasswordVisible = false;

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

		private void TogglePasswordVisibility()
		{
			isPasswordVisible = !isPasswordVisible;
		}

		public class NewStudentModel
		{
			public string Password { get; set; }
		}
	}
}
