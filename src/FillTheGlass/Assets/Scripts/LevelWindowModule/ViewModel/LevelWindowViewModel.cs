using LevelWindowModule.View;
using MvvmModule;

namespace LevelWindowModule
{
    public sealed class LevelWindowViewModel : EmptyViewModel, ILevelWindowViewModel
    {
        public IEmptyGlassesViewModel EmptyGlassesViewModel { get; }

        public LevelWindowViewModel(IViewModelFactory viewModelFactory) : base(viewModelFactory)
        {
            EmptyGlassesViewModel = CreateEmptyViewModel<EmptyGlassesViewModel>();
        }
    }
}