using LevelWindowModule.Contracts;
using LevelWindowModule.View;
using MvvmModule;
using UniRx;
using UnityEngine;

namespace LevelWindowModule
{
    public sealed class CurrentGlassViewModel : EmptyViewModel, ICurrentGlassViewModel
    {
        private readonly GlassModel _glassModel;

        private readonly ReactiveProperty<bool> _canToWash = new();
        private readonly ReactiveProperty<bool> _canUnfill = new();
        private readonly ReactiveProperty<bool> _hasGlass = new();
        private readonly LevelHolder _levelHolder;

        public IReadOnlyReactiveProperty<bool> CanSendGlass { get; }

        public IReadOnlyReactiveProperty<bool> CanToWash => _canToWash;
        public IReadOnlyReactiveProperty<bool> CanUnfill => _canUnfill;
        public IReadOnlyReactiveProperty<bool> HasGlass => _hasGlass;

        public IFillingGlassViewModel FillingGlassViewModel { get; }

        public CurrentGlassViewModel(IViewModelFactory viewModelFactory, LevelHolder levelHolder) : base(viewModelFactory)
        {
            _levelHolder = levelHolder;

            CurrentGlassModel currentGlassModel = levelHolder.LevelModel.CurrentGlassModel;
            _glassModel = currentGlassModel.GlassModel;
            _glassModel.ModelChanged += OnModelChanged;

            var args = new FillingGlassArgs(_glassModel);
            FillingGlassViewModel = CreateViewModel<FillingGlassViewModel, FillingGlassArgs>(args);
            CanSendGlass = currentGlassModel.CanSendGlass;

            OnModelChanged();
        }

        private void OnModelChanged()
        {
            bool hasGlass = _glassModel.GlassFormType != EGlassFormType.None;
            _hasGlass.Value = hasGlass;
            bool hasLiquid = false;
            _canUnfill.Value = hasGlass && hasLiquid;
            bool hasAnyAccessory = _glassModel.HasCitrus || _glassModel.HasIce || _glassModel.HasStraw;
            _canToWash.Value = hasGlass && !hasLiquid && !hasAnyAccessory;
        }

        public void SendClickFromView()
        {
            Debug.Log("SendClickFromView");
        }

        public void OnCitrusClickFromView() => _glassModel.SetHasCitrus(!_glassModel.HasCitrus);
        public void OnStrawClickFromView() => _glassModel.SetHasStraw(!_glassModel.HasStraw);
        public void OnIceClickFromView() => _glassModel.SetHasIce(!_glassModel.HasIce);

        public void OnToWashClickFromView() => _levelHolder.LevelModel.ToWashCurrentGlass();

        public void OnUnfillClickFromView()
        {
            Debug.Log("OnUnfillClickFromView");
        }
    }
}