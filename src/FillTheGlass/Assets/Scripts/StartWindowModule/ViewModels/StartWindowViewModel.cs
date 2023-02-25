using MainModule;
using MvvmModule;
using StartWindowModule.View;

namespace StartWindowModule.ViewModels
{
    public sealed class StartWindowViewModel : EmptyViewModel, IStartWindowViewModel
    {
        private readonly MainStateMachine _mainStateMachine;

        public bool HasProgress { get; }

        public StartWindowViewModel(IViewModelFactory viewModelFactory, MainStateMachine mainStateMachine) : base(viewModelFactory)
        {
            _mainStateMachine = mainStateMachine;
        }

        public void StartClickFromView()
        {
        }

        public void ContinueClickFromView()
        {
        }

        public void SettingsClickFromView()
        {
            _mainStateMachine.EnterToState<SettingsMainState>();
        }
    }
}