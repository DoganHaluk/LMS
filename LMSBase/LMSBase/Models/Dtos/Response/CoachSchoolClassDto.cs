using LMSBase.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSBase.Models.Dtos.Response
{
    public class CoachSchoolClassDto
    {
        public SchoolClassSummaryDto SchoolClass { get; set; }
        public CoachSummaryDto Coach { get; set; }
    }
}
