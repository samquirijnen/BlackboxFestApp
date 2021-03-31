using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlackboxFest.Models
{
    public class City
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string PostalCode { get; set; }
        [Required]
        public int CountryId { get; set; }
        [ForeignKey("CountyId")]
        public virtual Country Country { get; set; }

    }
}
