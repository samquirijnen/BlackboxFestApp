using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlackboxFest.Models
{
    public class Artist
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "How can people now how is playing if you don't give up a name.")]
        public string Name { get; set; }
        [Required]
        public Byte[] Image { get; set; }
        public string ArtistShortDescription { get; set; }
        public string ArtistLongDescription { get; set; }
        public string MusicGenre { get; set; }
        [Required]
        public int BookingAgentId { get; set; }
        [ForeignKey("BookingAgentId")]
        public virtual BookingAgent BookingAgent { get; set; }
    }
}
