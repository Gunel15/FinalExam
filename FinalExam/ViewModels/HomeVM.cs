using FinalExam.ViewModels.Persons;
using FinalExam.ViewModels.Positions;

namespace FinalExam.ViewModels
{
    public class HomeVM
    {
        public List<PersonGetVM> Persons{get; set;}
        public List<PositionGetVM> Positions { get; set;}
    }
}
