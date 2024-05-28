using LMSBase.Models.Dtos.Response;
using LMSBlazor.Services;
using Microsoft.AspNetCore.Components;

namespace LMSBlazor.Pages
{
    public partial class ClassOverview
    {
        [SupplyParameterFromQuery]
        private int UserId { get; set; }

        [SupplyParameterFromQuery]
        private int SchoolClassId { get; set; }

        private SchoolClassOverviewDto? SchoolClass { get; set; }

        private CurrentUser User { get; set; }

        protected override async Task OnInitializedAsync()
        {
            User = await _stateContainer.GetUserAsync();
            SchoolClass = new SchoolClassOverviewDto();
            SchoolClass = await _schoolClassService.GetSchoolClassOverview(SchoolClassId);
        }

        public async Task NavigateToAddCourses()
        {
            _navigation.NavigateTo($"/addcourses?UserId={UserId}&SchoolClassId={SchoolClassId}");
        }

        public async Task NavigateToStudent(int studentId)
        {
            _navigation.NavigateTo($"/studentprofile?UserId={studentId}");
        }

        public async Task NavigateToCoach(int coachId)
        {
            _navigation.NavigateTo($"/coachprofile?UserId={coachId}");
        }

        public async Task NavigateToCourse(int courseId)
        {
            _navigation.NavigateTo($"/courseoverview?UserId={UserId}&CourseId={courseId}&SchoolClassId={SchoolClassId}");
        }

    }
}
