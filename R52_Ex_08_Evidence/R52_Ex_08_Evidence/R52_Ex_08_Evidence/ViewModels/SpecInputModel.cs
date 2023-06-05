using R52_Ex_08_Evidence.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace R52_Ex_08_Evidence.ViewModels
{
    public class SpecInputModel
    {
        public int SpecId { get; set; }
        [Required, StringLength(30)]
        public string SpecName { get; set; } = default!;
        [Required, StringLength(50)]
        public string Value { get; set; } = default!;
       
        public int DeviceId { get; set; }
        
    }
}
