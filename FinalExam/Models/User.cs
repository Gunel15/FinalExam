using Microsoft.AspNetCore.Identity;

namespace FinalExam.Models
{
    public class User:IdentityUser
    {
        public string FullName {  get; set; }
    }
}
