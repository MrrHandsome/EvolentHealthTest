using System.ComponentModel.DataAnnotations;

namespace EvolentHealthTest.Models
{
    public class Contact
    {
        #region Public Property

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public bool Status { get; set; }

        #endregion
    }
}
