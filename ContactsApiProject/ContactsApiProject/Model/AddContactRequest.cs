using System.ComponentModel.DataAnnotations;

namespace ContactsApiProject.Model
{
    public class AddContactRequest
    {
        [Required]
        public string FullName { get; set; }
        public string Email { get; set; }
        
        [Required]
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
