using LevelWindowModule.Contracts;
using LevelWindowModule.View;
using MvvmModule;
using UniRx;
using UnityEngine;

namespace LevelWindowModule
{
    public sealed class FillingGlassArgs
    {
        public GlassModel GlassModel { get; }

        public FillingGlassArgs(GlassModel glassModel)
        {
            GlassModel = glassModel;
        }
    }

    public sealed class FillingGlassViewModel : ViewModel<FillingGlassArgs>, IFillingGlassViewModel
    {
        private readonly GlassStaticDataProvider _glassStaticDataProvider;
        private readonly ReactiveProperty<Sprite> _glassSprite = new();
        private readonly ReactiveProperty<bool> _hasGlass = new();

        public ILiquidsInGlassViewModel LiquidsInGlassViewModel { get; }
        public IAccessoriesInGlassViewModel AccessoriesInGlassViewModel { get; }
        public IReadOnlyReactiveProperty<Sprite> GlassSprite => _glassSprite;
        public IReadOnlyReactiveProperty<bool> HasGlass => _hasGlass;

        public FillingGlassViewModel(FillingGlassArgs fillingGlassArgs, GlassStaticDataProvider glassStaticDataProvider,
            IViewModelFactory viewModelFactory) : base(fillingGlassArgs, viewModelFactory)
        {
            _glassStaticDataProvider = glassStaticDataProvider;
            var liquidsInGlassArgs = new LiquidsInGlassArgs(fillingGlassArgs.GlassModel);
            LiquidsInGlassViewModel = CreateViewModel<LiquidsInGlassViewModel, LiquidsInGlassArgs>(liquidsInGlassArgs);
            var accessoriesArgs = new AccessoriesInGlassArgs(fillingGlassArgs.GlassModel);
            AccessoriesInGlassViewModel = CreateViewModel<AccessoriesInGlassViewModel, AccessoriesInGlassArgs>(accessoriesArgs);

            Model.GlassModel.ModelChanged += OnModelChanged;
        }

        private void OnModelChanged()
        {
            GlassModel glassModel = Model.GlassModel;
            Sprite sprite = _glassStaticDataProvider.GetSpriteByType(glassModel.GlassFormType);
            _glassSprite.Value = sprite;
            _hasGlass.Value = glassModel.GlassFormType != EGlassFormType.None;
        }

        public override void Dispose()
        {
            base.Dispose();
            Model.GlassModel.ModelChanged -= OnModelChanged;
        }
    }
}