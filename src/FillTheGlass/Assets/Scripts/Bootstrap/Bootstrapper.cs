using MainModule;
using Zenject;

namespace Bootstrap
{
    public sealed class Bootstrapper : IInitializable
    {
        private readonly MainStateMachine _mainStateMachine;

        public Bootstrapper(MainStateMachine mainStateMachine, StartMainState startMainState, SettingsMainState settingsMainState)
        {
            _mainStateMachine = mainStateMachine;
            
            _mainStateMachine.AddState(startMainState);
            _mainStateMachine.AddState(settingsMainState);
        }
    
        public void Initialize()
        {
            _mainStateMachine.EnterToState<StartMainState>();
        }
    }
}
