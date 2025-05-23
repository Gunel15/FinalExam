using System.ComponentModel.DataAnnotations;

namespace FinalExam.ViewModels.Persons
{
    public class PersonUpdateVM
    {
        public int Id { get; set; }
        [MinLength(5), MaxLength(20)]
        public string Name { get; set; }
        public int PositionId { get; set; }
        public IFormFile? ImageFile { get; set; }
    }
}
