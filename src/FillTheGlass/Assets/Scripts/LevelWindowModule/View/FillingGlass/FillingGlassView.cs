using MvvmModule;
using UnityEngine;

namespace LevelWindowModule.View
{
    public sealed class FillingGlassView : View<FillingGlassHierarchy, IFillingGlassViewModel>
    {
        private readonly LiquidsInGlassView _liquidsInGlassView;
        private readonly AccessoriesInGlassView _accessoriesInGlassView;

        public FillingGlassView(FillingGlassHierarchy hierarchy, IViewFactory viewFactory) : base(hierarchy, viewFactory)
        {
            _liquidsInGlassView = CreateView<LiquidsInGlassView, LiquidsInGlassHierarchy>(Hierarchy.LiquidsInGlassHierarchy);
            _accessoriesInGlassView = CreateView<AccessoriesInGlassView, AccessoriesInGlassHierarchy>(Hierarchy.AccessoriesInGlassHierarchy);
        }

        protected override void UpdateViewModel(IFillingGlassViewModel viewModel)
        {
            Bind(viewModel.HasGlass, OnHasGlassChange);
            Bind(viewModel.GlassSprite, OnSpriteChange);

            _liquidsInGlassView.Initialize(viewModel.LiquidsInGlassViewModel);
            _accessoriesInGlassView.Initialize(viewModel.AccessoriesInGlassViewModel);
        }

        private void OnHasGlassChange(bool hasGlass)
        {
            SetActive(hasGlass);
        }

        private void OnSpriteChange(Sprite sprite)
        {
            Hierarchy.GlassImage.sprite = sprite;
        }
    }
}