using System.ComponentModel.DataAnnotations;

namespace UniqueColumn.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required, StringLength(255)]
        public string Name { get; set; }

        [Required, StringLength(255), Display(Name = "Phone No")]
        public string PhoneNo { get; set; }

        [Required, StringLength(255), EmailAddress]
        public string Email { get; set; }
    }
}
