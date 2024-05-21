using LMSBase.Models.Dtos.Response;
using LMSBlazor.Services;
using Microsoft.AspNetCore.Components;

namespace LMSBlazor.Pages
{
    public partial class ClassOverview
    {
        [Inject]
        SchoolClassService _schoolClassService {  get; set; }

        [SupplyParameterFromQuery]
        private int UserId { get; set; }

        [SupplyParameterFromQuery]
        private int SchoolClassId { get; set; }

        SchoolClassOverviewDto SchoolClass { get; set; }


        protected override async Task OnInitializedAsync()
        {
            SchoolClass = new SchoolClassOverviewDto();
            SchoolClass = await _schoolClassService.GetSchoolClassOverview(SchoolClassId);
        }
    }
}
