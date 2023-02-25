using MvvmModule;

namespace LevelInfoWindowModule.View
{
    public interface ILevelInfoWindowViewModel : IViewModel
    {
        ICalendarViewModel CalendarViewModel { get; }
        int LevelNumber { get; }
        int TargetMoneyCount { get; }
        void BackClickFromView();
        void StartClickFromView();
        void SettingsClickFromView();
    }
}