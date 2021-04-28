using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlackboxFest.Models
{
    public class Adress
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        [Required]
        public string StreetName { get; set; }
        [Column(TypeName = "nvarchar(20)")]
        [Required]
        public string StreetNumber { get; set; }
        [Required]
        public int CityId { get; set; }
        [ForeignKey("CityId")]
        public virtual City City { get; set; }
        [Required]
        public string PersonId { get; set; }
        [ForeignKey("PersonId")]
        public virtual CustomUser CustomUser { get; set; }
    }
}
