using System.ComponentModel.DataAnnotations;

namespace JWTAuthentication
{
    public class CountryInfo
    {
        [Required]
        public string Email { get; set; }
        [Key]
        public int Id{ get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public string City { get; set; }

        public bool Isfavourite { get; set; }
    }
}