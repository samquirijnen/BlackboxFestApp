using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlackboxFest.Models
{
    public class Country
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(150)")]
        [Required]
        public string Name { get; set; }
    }
}
