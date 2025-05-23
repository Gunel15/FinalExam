using System.ComponentModel.DataAnnotations;

namespace FinalExam.Models
{
    public class Person:BaseEntity
    {
        [MinLength(5),MaxLength(20)]
        public string Name {  get; set; }
        public int PositionId {  get; set; }
        public Position? Position { get; set; }
        public string ImageUrl {  get; set; }
    }
}
