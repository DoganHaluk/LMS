using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSBase.Models.Dtos.Response
{
    public class SchoolClassDto
    {
        public int SchoolClassId { get; set; }
        public string SchoolClassName { get; set; }
        public List<CoachSchoolClassDto> CoachSchoolClasses { get; set; }
    }
}
