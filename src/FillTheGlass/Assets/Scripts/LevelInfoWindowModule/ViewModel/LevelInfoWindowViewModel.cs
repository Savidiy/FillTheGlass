using LevelInfoWindowModule.View;
using MainModule;
using MvvmModule;
using Progress;
using SettingsModule;
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
        public int TotalMoneyCount { get; }

        public LevelInfoWindowViewModel(MainStateMachine mainStateMachine, ISettingsWindowPresenter settingsWindowPresenter,
            ProgressProvider progressProvider, IViewModelFactory viewModelFactory, GameSettings gameSettings) : base(viewModelFactory)
        {
            CalendarViewModel = CreateEmptyViewModel<CalendarViewModel>();

            int currentLevel = progressProvider.CurrentLevel;
            LevelNumber = currentLevel + 1;
            TotalMoneyCount = progressProvider.TotalEarnedMoney;
            TargetMoneyCount = gameSettings.GetLevelTargetMoney(currentLevel);

            _mainStateMachine = mainStateMachine;
            _settingsWindowPresenter = settingsWindowPresenter;
        }


        public void BackClickFromView()
        {
            _mainStateMachine.EnterToState<StartMainState>();
        }

        public void StartClickFromView()
        {
            _mainStateMachine.EnterToState<LevelPlayMainState>();
        }

        public void SettingsClickFromView()
        {
            _settingsWindowPresenter.ShowWindow();
        }
    }
}