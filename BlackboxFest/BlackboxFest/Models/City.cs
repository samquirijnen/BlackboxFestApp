using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlackboxFest.Models
{
    public class City
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Required]
        public string Name { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        [Required]
        public string PostalCode { get; set; }
        [Required]
        public int CountryId { get; set; }
        [ForeignKey("CountyId")]
        public virtual Country Country { get; set; }

    }
}
