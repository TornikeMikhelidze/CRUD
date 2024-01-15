using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CRUD.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
		[MaxLength(50)]
		[DisplayName("First Name")]
		[RegularExpression(@"^[^\d]+$", ErrorMessage = "First Name should not contain digits.")]
		public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
		[RegularExpression(@"^[^\d]+$", ErrorMessage = "Last Name should not contain digits.")]
		[DisplayName("Last Name")]
		public string LastName { get; set; }
        [Required]
		[DisplayName("Display Order")]
        [Range(1, 50)]
		public int DisplayOrder {  get; set; }  
    }
}
