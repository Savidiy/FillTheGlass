using MvvmModule;
using UniRx;
using UnityEngine;

namespace LevelWindowModule.View
{
    public interface IAccessoriesInGlassViewModel : IViewModel
    {
        IReadOnlyReactiveProperty<Vector3> IceLocalPosition { get; }
        IReadOnlyReactiveProperty<Vector3> CitrusLocalPosition { get; }
        IReadOnlyReactiveProperty<Vector3> StrawLocalPosition { get; }

        IReadOnlyReactiveProperty<bool> HasIce { get; }
        IReadOnlyReactiveProperty<bool> HasCitrus { get; }
        IReadOnlyReactiveProperty<bool> HasStraw { get; }
    }
}