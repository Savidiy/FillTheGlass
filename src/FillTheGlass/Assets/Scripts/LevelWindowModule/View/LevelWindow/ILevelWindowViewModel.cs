using MvvmModule;

namespace LevelWindowModule.View
{
    public interface ILevelWindowViewModel : IViewModel
    {
        IEmptyGlassesViewModel EmptyGlassesViewModel { get; }
        ICurrentGlassViewModel CurrentGlassViewModel { get; }
        void SettingsClickFromView();
    }
}