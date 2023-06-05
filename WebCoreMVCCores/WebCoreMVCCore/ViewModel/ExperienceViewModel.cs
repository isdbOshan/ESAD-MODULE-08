using System.ComponentModel.DataAnnotations.Schema;
using WebCoreMVCCore.Models;

namespace WebCoreMVCCore.ViewModel
{
    public class ExperienceViewModel
    {
        public int ExperienceId { get; set; }
        public string ExperienceName { get; set; } = default!;
        public string ExperienceDescription { get; set; } = default!;
        public int EmployeeId { get; set; }
       
    }
}
