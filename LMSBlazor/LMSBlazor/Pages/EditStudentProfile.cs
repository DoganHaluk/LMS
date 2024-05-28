using LMSBase.Models.Dtos.Request;
using LMSBase.Models.Dtos.Response;
using LMSBase.Models.Utilities;
using LMSBlazor.Services;
using Microsoft.AspNetCore.Components;

namespace LMSBlazor.Pages
{
	public partial class EditStudentProfile
	{
		[Inject]
		StudentService _studentService { get; set; }
		[Inject]
		SchoolClassService _schoolClassService { get; set; }


		[SupplyParameterFromQuery]
		private int UserId { get; set; }
		private EditStudentProfileDto EditStudent { get; set; }

		private StudentSummaryDto Student { get; set; }

		private CoachSummaryDto Coach { get; set; }

		private List<SchoolClassSummaryDto> SchoolClasses { get; set; }

		private List<InputError> Errors { get; set; }

		private CurrentUser User { get; set; }


		protected override async Task OnInitializedAsync()
		{
			EditStudent = new EditStudentProfileDto();
			SchoolClasses = new List<SchoolClassSummaryDto>();
			SchoolClasses = await _schoolClassService.GetAllSchoolClasses();
			if (UserId > 0) 
			{
                Student = await _studentService.GetStudentProfile(UserId);
                EditStudent.UserName = Student.UserName;
				EditStudent.Email = Student.Email;
				if (Student.SchoolClass == null)
				{
					EditStudent.SchoolClassId = 1;
				}
				else
				{
					EditStudent.SchoolClassId = Student.SchoolClass.SchoolClassId;
				}				
            }
		}

		private void SelectClass(int id)
		{
			EditStudent.SchoolClassId = id;
		}

		private async Task UpdateProfile()
		{
			Errors = await _studentService.EditStudentProfile(UserId, EditStudent);
			if (Errors == null)
			{
				_navigation.NavigateTo($"/studentprofile?UserId={Student.UserId}");
			}
		}
			

        private void NavigateToProfile()
        {
            _navigation.NavigateTo($"/studentprofile?UserId={UserId}");
        }

    }
}
