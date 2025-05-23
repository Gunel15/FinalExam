using System.ComponentModel.DataAnnotations;

namespace FinalExam.ViewModels.Persons
{
    public class PersonGetVM
    {
        public int Id { get; set; }
        [MinLength(5), MaxLength(20)]
        public string Name { get; set; }
        public string PositionName { get; set; }
        public string ImageUrl { get; set; }
    }
}
