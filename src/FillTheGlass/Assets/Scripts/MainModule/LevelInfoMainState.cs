using LevelInfoWindowModule.Contracts;
using Savidiy.Utils.StateMachine;

namespace MainModule
{
    public sealed class LevelInfoMainState :  IState, IStateWithExit, IMainState
    {
        private readonly ILevelInfoWindowPresenter _levelInfoWindowPresenter;

        public LevelInfoMainState(ILevelInfoWindowPresenter levelInfoWindowPresenter)
        {
            _levelInfoWindowPresenter = levelInfoWindowPresenter;
        }
        
        public void Enter()
        {
            _levelInfoWindowPresenter.ShowWindow();
        }

        public void Exit()
        {
            _levelInfoWindowPresenter.HideWindow();
        }
    }
}