namespace MyScore_ASP.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            Clients = new HashSet<Client>();
        }

        public int Id { get; set; }

        [StringLength(50)]
        public string NameProduct { get; set; }

        [Column(TypeName = "money")]
        public decimal? Price { get; set; }

        [Required]
        [StringLength(50)]
        public string Photo { get; set; }

        public int? IdCategory { get; set; }

        public int? IdManufacturer { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Client> Clients { get; set; }

        public virtual Table_Matufactur Table_Matufactur { get; set; }
    }
}
