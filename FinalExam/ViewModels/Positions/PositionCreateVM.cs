using System.ComponentModel.DataAnnotations;

namespace FinalExam.ViewModels.Positions
{
    public class PositionCreateVM
    {
        [MinLength(5), MaxLength(20)]
        public string Name { get; set; }
    }
}
