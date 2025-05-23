using System.ComponentModel.DataAnnotations;

namespace FinalExam.ViewModels.Account
{
    public class LoginVM
    {
        [MinLength(4), MaxLength(30), DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [MinLength(6), MaxLength(30), DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
