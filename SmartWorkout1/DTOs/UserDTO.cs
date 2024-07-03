using System.ComponentModel.DataAnnotations;

namespace SmartWorkout1.DTOs
{
    public class UserDTO
    {

        [Required (ErrorMessage ="First Name is required!")]
        [StringLength (70, ErrorMessage ="First Name cannot be longer than 70 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required!")]
        [StringLength(70, ErrorMessage = "Last Name cannot be longer than 70 characters")]
        public string LastName { get; set; }

        [Required (ErrorMessage ="Birthday is Required!")]
        public DateTime Birthday { get; set; }

        [Required (ErrorMessage ="Gender is Required!")]
        public string Gender { get; set; }




    }
}
