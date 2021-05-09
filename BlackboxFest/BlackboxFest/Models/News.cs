using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlackboxFest.Models
{
    public class News
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(150)")]
        [Required]
        public string Title { get; set; }
        [Column(TypeName = "nvarchar(500)")]
        [DisplayName("Short Description")]
        public string ShortDescription { get; set; }
        [DisplayName("Long Description")]
        public string LongDescription { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [Required]
        public  DateTime Date{ get; set; }
        [Column(TypeName = "nvarchar(100)")]
        [DisplayName("Image Name")]
        public string ImageName { get; set; }

        [NotMapped]
        public string NewImageName { get; set; }

        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ImageFile { get; set; }
    }
}
