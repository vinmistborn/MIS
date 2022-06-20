using System.ComponentModel.DataAnnotations;

namespace MIS.Domain.Enums
{
    public enum PaymentType
    {
        [Display(Name = "Cash")]
        Cash = 1,
        [Display(Name = "Click/Payme")]
        Online = 2,
        [Display(Name = "Bank Transaction")]
        BankTransaction = 3
    }
}
