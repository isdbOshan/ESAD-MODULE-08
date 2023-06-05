using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace WebApplicationSecond22.ViewModels
{
    public class PartsDataInputViewModel
    {
        public int PartsDetailId { get; set; }
        [Required, StringLength(50)]
        public string PartName { get; set; } = default!;
        [Required, Column(TypeName = "money")]
        public decimal PartsPrice { get; set; }
        public int CarDetailId { get; set; }
       
    }
}
