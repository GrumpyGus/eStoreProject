using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eStore.Models
{
    public class OrderLineItems
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        
        [Required]
        public int OrderId { get; set; }

        [StringLength(15)]
        [Required]
        public string ProductId { get; set; }

        [Required]
        public int QtyBackOrdered { get; set; }

        [Required]
        public int QtyOrdered { get; set; }

        [Required]
        public int QtySold { get; set; }

        [Required]
        public decimal SellingPrice { get; set; }

        [Column(TypeName = "timestamp")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [MaxLength(8)]
        public byte[] Timer { get; set; }

    }
}
