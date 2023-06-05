using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using R52_Ex_08_Evidence.Models;

namespace R52_Ex_08_Evidence.ViewModels
{
    public class DeviceInputModel
    {
        public int DeviceId { get; set; }
        [Required, StringLength(50)]
        public string DeviceName { get; set; } = default!;
        [Required, Column(TypeName = "date")]
        public DateTime ReleaseDate { get; set; } = DateTime.Today;
        [Required, Column(TypeName = "money")]
        public decimal Price { get; set; }
        public bool OnSale { get; set; }
        [Required, StringLength(30)]
        public string Picture { get; set; } = default!;
        public List<SpecInputModel> Specs { get; set; } = new List<SpecInputModel>();
    }
}
