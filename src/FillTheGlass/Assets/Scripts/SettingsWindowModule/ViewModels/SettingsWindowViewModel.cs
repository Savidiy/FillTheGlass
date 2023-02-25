using System;
using MainModule;
using MvvmModule;
using SettingsWindowModule.View;

namespace SettingsWindowModule.ViewModels
{
    public sealed class SettingsWindowViewModel : EmptyViewModel, ISettingsWindowViewModel
    {
        private readonly MainStateMachine _mainStateMachine;

        private readonly Type _returnStateType;

        public bool HasProgress { get; }

        public SettingsWindowViewModel(IViewModelFactory viewModelFactory, MainStateMachine mainStateMachine) : base(
            viewModelFactory)
        {
            _mainStateMachine = mainStateMachine;
        }

        public void BackClickFromView()
        {
            _mainStateMachine.EnterToState<StartMainState>();
        }

        public void ResetClickFromView()
        {
        }
    }
}