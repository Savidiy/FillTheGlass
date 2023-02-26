using MainModule;
using Zenject;

namespace Bootstrap
{
    public sealed class Bootstrapper : IInitializable
    {
        private readonly MainStateMachine _mainStateMachine;

        public Bootstrapper(MainStateMachine mainStateMachine, StartMainState startMainState,
            LevelInfoMainState levelInfoMainState, LevelPlayMainState levelPlayMainState)
        {
            _mainStateMachine = mainStateMachine;

            _mainStateMachine.AddState(startMainState);
            _mainStateMachine.AddState(levelInfoMainState);
            _mainStateMachine.AddState(levelPlayMainState);
        }

        public void Initialize()
        {
            _mainStateMachine.EnterToState<StartMainState>();
        }
    }
}