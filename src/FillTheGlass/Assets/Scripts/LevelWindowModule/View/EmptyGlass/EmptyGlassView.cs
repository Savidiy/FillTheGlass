﻿using MvvmModule;
using UnityEngine;

namespace LevelWindowModule.View
{
    public sealed class EmptyGlassView : View<EmptyGlassHierarchy, IEmptyGlassViewModel>
    {
        public EmptyGlassView(EmptyGlassHierarchy hierarchy, IViewFactory viewFactory) : base(hierarchy, viewFactory)
        {
        }

        protected override void UpdateViewModel(IEmptyGlassViewModel viewModel)
        {
            Bind(viewModel.HasGlass, OnHasGlassChange);
            Bind(viewModel.CanClick, OnCanClickChange);
            Bind(viewModel.GlassSprite, OnGlassSpriteChange);

            Hierarchy.GlassButton.onClick.AddListener(OnGlassClick);
        }

        private void OnCanClickChange(bool canClick)
        {
            Hierarchy.GlassButton.interactable = canClick;
        }

        protected override void ReleaseViewModel()
        {
            base.ReleaseViewModel();
            Hierarchy.GlassButton.onClick.RemoveListener(OnGlassClick);
        }

        private void OnGlassSpriteChange(Sprite sprite)
        {
            Hierarchy.GlassImage.sprite = sprite;
        }

        private void OnHasGlassChange(bool hasGlass)
        {
            Hierarchy.GlassImage.enabled = hasGlass;
        }

        private void OnGlassClick()
        {
            ViewModel.GlassClickFromView();
        }

        public override void Dispose()
        {
            base.Dispose();
            if (Hierarchy.gameObject != null)
                Object.Destroy(Hierarchy.gameObject);
        }
    }
}