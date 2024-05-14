using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMSBase.Models.Dtos.Request
{
    public class CreateSchoolClassDto
    {
        public string SchoolClassName { get; set; }
        public int CoachId { get; set; }
    }
}
