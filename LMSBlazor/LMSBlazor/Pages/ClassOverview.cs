using LMSBase.Models.Dtos.Response;
using LMSBlazor.Services;
using Microsoft.AspNetCore.Components;

namespace LMSBlazor.Pages
{
    public partial class ClassOverview
    {
        [Inject]
        StateContainer _stateContainer {  get; set; }

        [Inject]
        SchoolClassService _schoolClassService {  get; set; }

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
    }
}
