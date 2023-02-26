using MvvmModule;

namespace LevelInfoWindowModule.View
{
    public interface ILevelInfoWindowViewModel : IViewModel
    {
        ICalendarViewModel CalendarViewModel { get; }
        int LevelNumber { get; }
        int TargetMoneyCount { get; }
        int TotalMoneyCount { get; }
        void BackClickFromView();
        void StartClickFromView();
        void SettingsClickFromView();
    }
}