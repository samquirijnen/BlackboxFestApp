using Microsoft.AspNetCore.Http;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlackboxFest.Models
{
    public class Artist
    {
        public int Id { get; set; }
        [Column(TypeName = "nvarchar(100)")]
        [Required(ErrorMessage = "How can people now how is playing if you don't give up a name.")]
        public string Name { get; set; }
        [Column(TypeName = "nvarchar(150)")]
        [DisplayName("Short Description")]
        public string ArtistShortDescription { get; set; }
        [DisplayName("Long Description")]
        public string ArtistLongDescription { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [DisplayName("Genre")]
        public string MusicGenre { get; set; }

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
