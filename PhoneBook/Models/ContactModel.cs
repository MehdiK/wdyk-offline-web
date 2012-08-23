using System.ComponentModel.DataAnnotations;

namespace PhoneBook.Models
{
    public class ContactModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string FullName { get; set; }
        [StringLength(50)]
        public string PhoneNumber { get; set; }
        [StringLength(100)]
        public string Address { get; set; }
    }
}