using System.ComponentModel.DataAnnotations;
using WebCoreMVCCore.Models;

namespace WebCoreMVCCore.ViewModel
{
    public class EmployeeInputModel
    {
        [Key]
        public int EmployeeId { get; set; }
        [Required, StringLength(50)]
        public string EmployeeName { get; set; } = default!;
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime JoinDate { get; set; }
        public bool WorkHome { get; set; }
        public decimal Salary { get; set; }
        public string Picture { get; set; } = default!;
        public virtual List<Experience> Experience { get; set; } = new List<Experience>();
    }
}
