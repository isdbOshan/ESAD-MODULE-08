using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace R52_M8_Class_04_Work_01.Models
{
    public class Brand
    {
        public int BrandId { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; } = default!;
        [Required, StringLength(50)]
        public string CuntryOfOrigin { get; set; } = default!;
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
    public class Product
    {
        public int ProductId { get; set; }
        [Required, StringLength(50)]
        public string Name { get; set; } = default!;
        [Required, Column(TypeName ="money")]
        public decimal Price { get; set; }
        [Required, ForeignKey("Brand")]
        public int BrandId { get; set; }
        public virtual Brand Brand { get; set; } = default!;
    }
    public class BrandDbContext : DbContext
    {
        public BrandDbContext(DbContextOptions<BrandDbContext> options) : base(options) { }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }


    }
}
