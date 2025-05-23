using System.ComponentModel.DataAnnotations;

namespace FinalExam.ViewModels.Account
{
    public class RegisterVM
    {
        [MinLength(4),MaxLength(30)]
        public string FullName {  get; set; }
        [MinLength(4), MaxLength(30)]
        public string UserName {  get; set; }
        [MinLength(4), MaxLength(30),DataType(DataType.EmailAddress)]
        public string Email {  get; set; }
        [MinLength(6), MaxLength(30), DataType(DataType.Password)]
        public string Password { get; set; }
        [MinLength(6), MaxLength(30), DataType(DataType.Password),Compare(nameof(Password))]
        public string ConfirmedPassword { get; set; }
    }
}
