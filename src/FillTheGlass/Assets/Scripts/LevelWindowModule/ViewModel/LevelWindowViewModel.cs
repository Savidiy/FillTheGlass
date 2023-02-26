using LevelWindowModule.View;
using MvvmModule;
using SettingsWindowModule.Contracts;

namespace LevelWindowModule
{
    public sealed class LevelWindowViewModel : EmptyViewModel, ILevelWindowViewModel
    {
        private readonly ISettingsWindowPresenter _settingsWindowPresenter;
        public IEmptyGlassesViewModel EmptyGlassesViewModel { get; }
        public ICurrentGlassViewModel CurrentGlassViewModel { get; }

        public LevelWindowViewModel(IViewModelFactory viewModelFactory, ISettingsWindowPresenter settingsWindowPresenter) : base(viewModelFactory)
        {
            _settingsWindowPresenter = settingsWindowPresenter;
            EmptyGlassesViewModel = CreateEmptyViewModel<EmptyGlassesViewModel>();
            CurrentGlassViewModel = CreateEmptyViewModel<CurrentGlassViewModel>();
        }

        public void SettingsClickFromView()
        {
            _settingsWindowPresenter.ShowWindow();
        }
    }
}