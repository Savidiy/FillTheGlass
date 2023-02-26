using MvvmModule;
using UniRx;
using UnityEngine;

namespace LevelWindowModule.View
{
    public interface IEmptyGlassViewModel : IViewModel
    {
        IReadOnlyReactiveProperty<bool> HasGlass { get; }
        IReadOnlyReactiveProperty<bool> CanClick { get; }
        IReadOnlyReactiveProperty<Sprite> GlassSprite { get; }

        void GlassClickFromView();
    }
}