using System.ComponentModel.DataAnnotations;

namespace FinalExam.ViewModels.Positions
{
    public class PositionGetVM
    {
        public int Id {  get; set; }
        [MinLength(5),MaxLength(20)]
        public string Name { get; set; }
    }
}
