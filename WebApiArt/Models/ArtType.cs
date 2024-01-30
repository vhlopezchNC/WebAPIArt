using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApiArt.Models
{
    public class ArtType
    {
        public ArtType()
        {
            this.Artworks = new HashSet<Artwork>();
        }
        public int ID { get; set; }

        [Display(Name = "Art Type")]
        [Required(ErrorMessage = "You cannot leave the art type name black.")]
        [StringLength(25, ErrorMessage = "Art type cannot be more than 25 characters long.")]
        public string Type { get; set; }

        [JsonIgnore]
        public ICollection<Artwork> Artworks { get; set; }
    }
}
