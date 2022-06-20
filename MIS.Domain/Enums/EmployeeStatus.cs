using System.ComponentModel.DataAnnotations;

namespace MIS.Domain.Enums
{
    public enum EmployeeStatus
    {
        [Display(Name = "Active")]
        Active = 1,
        [Display(Name = "On-Leave")]
        OnLeave = 2,
        [Display(Name = "Quit")]
        Quit = 3
    }
}
