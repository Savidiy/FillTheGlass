using MvvmModule;
using UniRx;
using UnityEngine;

namespace LevelWindowModule.View
{
    public interface IFillingGlassViewModel : IViewModel
    {
        ILiquidsInGlassViewModel LiquidsInGlassViewModel { get; }
        IAccessoriesInGlassViewModel AccessoriesInGlassViewModel { get; }
        IReadOnlyReactiveProperty<Sprite> GlassSprite { get; }
        IReadOnlyReactiveProperty<bool> HasGlass { get; }
    }
}