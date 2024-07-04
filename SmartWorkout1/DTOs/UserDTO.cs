using SmartWorkout1.Entities;
using System.ComponentModel.DataAnnotations;

namespace SmartWorkout1.DTOs
{
    public class UserDTO
    {
        public int? Id { get; set; }
        
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

        public bool Exist { get; set; } = true;


        public static UserDTO FromEntity(User user)
        {
            return new UserDTO
            {
                Birthday = user.Birthday,
                Gender = user.Gender,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
        }

    }
}
