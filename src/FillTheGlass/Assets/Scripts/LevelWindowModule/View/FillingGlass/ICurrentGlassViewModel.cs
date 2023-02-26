using MvvmModule;
using UniRx;

namespace LevelWindowModule.View
{
    public interface ICurrentGlassViewModel : IViewModel
    {
        IFillingGlassViewModel FillingGlassViewModel { get; }
        
        IReadOnlyReactiveProperty<bool> CanSendGlass { get; }
        IReadOnlyReactiveProperty<bool> CanToWash { get; }
        IReadOnlyReactiveProperty<bool> CanUnfill { get; }
        IReadOnlyReactiveProperty<bool> HasGlass { get; }

        void SendClickFromView();
        void OnCitrusClickFromView();
        void OnStrawClickFromView();
        void OnIceClickFromView();
        void OnToWashClickFromView();
        void OnUnfillClickFromView();
    }
}