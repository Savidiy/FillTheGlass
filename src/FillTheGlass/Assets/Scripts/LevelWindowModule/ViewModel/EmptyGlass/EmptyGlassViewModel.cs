using System;
using System.Collections.Generic;
using LevelWindowModule.Contracts;
using LevelWindowModule.View;
using MvvmModule;
using UniRx;
using UnityEngine;

namespace LevelWindowModule
{
    public sealed class EmptyGlassViewModel : ViewModel<EmptyGlassArgs>, IEmptyGlassViewModel
    {
        private readonly GlassStaticDataProvider _glassStaticDataProvider;
        private readonly ReactiveProperty<bool> _hasGlass = new();
        private readonly ReactiveProperty<bool> _canClick = new();
        private readonly ReactiveProperty<Sprite> _glassSprite = new();
        private readonly EmptyGlassesModel _emptyGlassesModel;
        private readonly LevelModel _levelModel;

        public IReadOnlyReactiveProperty<bool> HasGlass => _hasGlass;
        public IReadOnlyReactiveProperty<bool> CanClick => _canClick;
        public IReadOnlyReactiveProperty<Sprite> GlassSprite => _glassSprite;

        public EmptyGlassViewModel(EmptyGlassArgs model, IViewModelFactory viewModelFactory, LevelHolder levelHolder,
            GlassStaticDataProvider glassStaticDataProvider) : base(model, viewModelFactory)
        {
            _glassStaticDataProvider = glassStaticDataProvider;
            _levelModel = levelHolder.LevelModel;
            _emptyGlassesModel = _levelModel.EmptyGlassesModel;
            _emptyGlassesModel.EmptyGlassesChanged += OnEmptyGlassesChanged;

            OnEmptyGlassesChanged();
        }

        private void OnEmptyGlassesChanged()
        {
            IReadOnlyList<EmptyGlassModel> emptyGlassModels = _emptyGlassesModel.EmptyGlassModels;
            int glassNumber = Model.GlassNumber;
            int glassesCount = emptyGlassModels.Count;
            if (glassNumber >= glassesCount)
                throw new Exception($"Empty glass number '{glassNumber}' greater than '{glassesCount}' glasses");

            _canClick.Value = _emptyGlassesModel.CanSelectGlass;

            EmptyGlassModel emptyGlassModel = emptyGlassModels[glassNumber];

            EGlassFormType glassFormType = emptyGlassModel.GlassFormType;
            bool hasGlass = glassFormType != EGlassFormType.None;
            _hasGlass.Value = hasGlass;

            if (hasGlass)
                _glassSprite.Value = _glassStaticDataProvider.GetSpriteByType(glassFormType);
        }

        public void GlassClickFromView()
        {
            _levelModel.SelectEmptyGlass(Model.GlassNumber);
        }

        public override void Dispose()
        {
            base.Dispose();
            _emptyGlassesModel.EmptyGlassesChanged -= OnEmptyGlassesChanged;
        }
    }
}