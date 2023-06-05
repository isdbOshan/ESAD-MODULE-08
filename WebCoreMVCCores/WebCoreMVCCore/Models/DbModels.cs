using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WebCoreMVCCore.ViewModel;

namespace WebCoreMVCCore.Models
{
    public class Employee
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
    public class Experience
    {
        public int ExperienceId { get; set; }
        public string ExperienceName { get; set; } = default!;
        public string ExperienceDescription { get; set; } = default!;
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; } = default!;
    }
    public class EmployeeDBContext: DbContext
    {
        public EmployeeDBContext(DbContextOptions<EmployeeDBContext> option):base(option)
        {

        }
        public DbSet<Employee> Employees { get; set;}
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<WebCoreMVCCore.ViewModel.EmployeeInputModel> EmployeeInputModel { get; set; } = default!;
    }

}
