using Savidiy.Utils.StateMachine;
using SettingsWindowModule.Contracts;

namespace MainModule
{
    public sealed class SettingsMainState :  IState, IStateWithExit, IMainState
    {
        private readonly ISettingsWindowPresenter _settingsWindowPresenter;

        public SettingsMainState(ISettingsWindowPresenter settingsWindowPresenter)
        {
            _settingsWindowPresenter = settingsWindowPresenter;
        }
        
        public void Enter()
        {
            _settingsWindowPresenter.ShowWindow();
        }

        public void Exit()
        {
            _settingsWindowPresenter.HideWindow();
        }
    }
}