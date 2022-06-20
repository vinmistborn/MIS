using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MIS.Domain.Enums
{
    public enum AttendanceStatus
    {
        [Display(Name = "P")]
        Present = 1,
        [Display(Name = "A")]
        Absent = 2     
    }
}
