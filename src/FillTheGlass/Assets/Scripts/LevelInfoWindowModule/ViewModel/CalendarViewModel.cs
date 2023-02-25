using LevelInfoWindowModule.View;
using MvvmModule;

namespace LevelInfoWindowModule.ViewModel
{
    public sealed class CalendarViewModel : EmptyViewModel, ICalendarViewModel
    {
        public CalendarViewModel(IViewModelFactory viewModelFactory) : base(viewModelFactory)
        {
        }
    }
}