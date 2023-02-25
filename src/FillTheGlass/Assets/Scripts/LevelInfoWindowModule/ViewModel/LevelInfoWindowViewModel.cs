using LevelInfoWindowModule.View;
using MainModule;
using MvvmModule;
using SettingsWindowModule.Contracts;

namespace LevelInfoWindowModule.ViewModel
{
    public sealed class LevelInfoWindowViewModel : EmptyViewModel, ILevelInfoWindowViewModel
    {
        private readonly MainStateMachine _mainStateMachine;
        private readonly ISettingsWindowPresenter _settingsWindowPresenter;
       
        public ICalendarViewModel CalendarViewModel { get; }
        public int LevelNumber { get; }
        public int TargetMoneyCount { get; }

        public LevelInfoWindowViewModel(MainStateMachine mainStateMachine, ISettingsWindowPresenter settingsWindowPresenter,
            IViewModelFactory viewModelFactory) : base(viewModelFactory)
        {
            CalendarViewModel = CreateEmptyViewModel<CalendarViewModel>();
            
            _mainStateMachine = mainStateMachine;
            _settingsWindowPresenter = settingsWindowPresenter;
        }


        public void BackClickFromView()
        {
            _mainStateMachine.EnterToState<StartMainState>();
        }

        public void StartClickFromView()
        {
        }

        public void SettingsClickFromView()
        {
            _settingsWindowPresenter.ShowWindow();
        }
    }
}