using MainModule;
using Zenject;

namespace Bootstrap
{
    public sealed class Bootstrapper : IInitializable
    {
        private readonly MainStateMachine _mainStateMachine;

        public Bootstrapper(MainStateMachine mainStateMachine, StartMainState startMainState, LevelInfoMainState levelInfoMainState)
        {
            _mainStateMachine = mainStateMachine;
            
            _mainStateMachine.AddState(startMainState);
            _mainStateMachine.AddState(levelInfoMainState);
        }
    
        public void Initialize()
        {
            _mainStateMachine.EnterToState<StartMainState>();
        }
    }
}
