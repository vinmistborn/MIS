using System.ComponentModel.DataAnnotations;

namespace MIS.Domain.Enums
{
    public enum Status
    {
        [Display(Name = "Active")]
        Active = 1,
        [Display(Name = "Finished")]
        Finished = 2
    }
}
