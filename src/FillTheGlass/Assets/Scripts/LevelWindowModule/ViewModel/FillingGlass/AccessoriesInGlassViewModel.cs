using LevelWindowModule.View;
using MvvmModule;
using SettingsModule;
using UniRx;
using UnityEngine;

namespace LevelWindowModule
{
    public sealed class AccessoriesInGlassArgs
    {
        public GlassModel GlassModel { get; }

        public AccessoriesInGlassArgs(GlassModel glassModel)
        {
            GlassModel = glassModel;
        }
    }

    public sealed class AccessoriesInGlassViewModel : ViewModel<AccessoriesInGlassArgs>, IAccessoriesInGlassViewModel
    {
        private readonly GlassStaticDataProvider _glassStaticDataProvider;
        private readonly ReactiveProperty<bool> _hasIce = new();
        private readonly ReactiveProperty<bool> _hasCitrus = new();
        private readonly ReactiveProperty<bool> _hasStraw = new();

        private readonly ReactiveProperty<Vector3> _iceLocalPosition = new();
        private readonly ReactiveProperty<Vector3> _citrusLocalPosition = new();
        private readonly ReactiveProperty<Vector3> _strawLocalPosition = new();

        public IReadOnlyReactiveProperty<Vector3> IceLocalPosition => _iceLocalPosition;
        public IReadOnlyReactiveProperty<Vector3> CitrusLocalPosition => _citrusLocalPosition;
        public IReadOnlyReactiveProperty<Vector3> StrawLocalPosition => _strawLocalPosition;

        public IReadOnlyReactiveProperty<bool> HasIce => _hasIce;
        public IReadOnlyReactiveProperty<bool> HasCitrus => _hasCitrus;
        public IReadOnlyReactiveProperty<bool> HasStraw => _hasStraw;

        public AccessoriesInGlassViewModel(AccessoriesInGlassArgs accessoriesInGlassArgs,
            GlassStaticDataProvider glassStaticDataProvider,
            IViewModelFactory viewModelFactory) :
            base(accessoriesInGlassArgs, viewModelFactory)
        {
            _glassStaticDataProvider = glassStaticDataProvider;
            
            Model.GlassModel.ModelChanged += OnModelChanged;
            OnModelChanged();
        }

        private void OnModelChanged()
        {
            GlassModel glassModel = Model.GlassModel;

            _hasIce.Value = glassModel.HasIce;
            _hasStraw.Value = glassModel.HasStraw;
            _hasCitrus.Value = glassModel.HasCitrus;

            AccessoriesPositionData positionData = _glassStaticDataProvider.GetAccessoriesPositionByType(glassModel.GlassFormType);
            _iceLocalPosition.Value = positionData.IcePosition;
            _citrusLocalPosition.Value = positionData.CitrusPosition;
            _strawLocalPosition.Value = positionData.StrawPosition;
        }

        public override void Dispose()
        {
            base.Dispose();
            Model.GlassModel.ModelChanged -= OnModelChanged;
        }
    }
}