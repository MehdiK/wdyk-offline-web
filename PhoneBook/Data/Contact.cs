using System.ComponentModel.DataAnnotations;

namespace PhoneBook.Data
{
    public class Contact
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string FullName { get; set; }
        [StringLength(20)]
        public string PhoneNumber { get; set; }
        [StringLength(100)]
        public string Address { get; set; }
        [Required]
        [StringLength(50)]
        public string UserName { get; set; }
    }
}