using System.ComponentModel.DataAnnotations;

namespace FinalExam.Models
{
    public class Position:BaseEntity
    {
        [MinLength(5),MaxLength(20)]
        public string Name {  get; set; }
        public IEnumerable<Person>Persons { get; set; }
    }
}
