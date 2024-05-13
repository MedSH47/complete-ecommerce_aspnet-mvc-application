using System.ComponentModel.DataAnnotations;

namespace eTickets.Models
{
    public class Actor
    {
        [Key]
        public int Id { get; set; } // Made public
        //named
        [Display(Name = "Profile Picture")]
        [Required(ErrorMessage ="profile picture is requird")]
        public string ProfilePictureURL { get; set; }
        //named
        [Display(Name = "Full Name ")]
        [Required(ErrorMessage = "Name is requird")]
        [StringLength(50,MinimumLength =3,ErrorMessage ="name must be between 3 and 50")]
        public string FullName { get; set; }
        //named
        [Display(Name = "Biography")]
        [Required(ErrorMessage = "Bio is requird")]
        public string Bio { get; set; }

        // Relationships
        public List<Actor_Movie> Actors_Movies { get; set; }
    }
}
