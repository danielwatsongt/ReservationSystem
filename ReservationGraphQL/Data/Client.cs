using System.ComponentModel.DataAnnotations;

namespace ReservationGraphQL.Data
{
    public class Client
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
            
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(15)]
        public string? Phone { get; set; }
    }
}
