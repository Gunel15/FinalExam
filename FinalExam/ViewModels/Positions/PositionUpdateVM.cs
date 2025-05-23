using System.ComponentModel.DataAnnotations;

namespace FinalExam.ViewModels.Positions
{
    public class PositionUpdateVM
    {
        public int Id {  get; set; }
        [MinLength(5), MaxLength(20)]
        public string Name { get; set; }
    }
}
