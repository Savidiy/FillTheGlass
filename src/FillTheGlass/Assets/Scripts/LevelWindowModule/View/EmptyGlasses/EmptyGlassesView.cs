using System;
using System.Collections.Generic;
using MvvmModule;
using UnityEngine;

namespace LevelWindowModule.View
{
    public sealed class EmptyGlassesView : View<EmptyGlassesHierarchy, IEmptyGlassesViewModel>
    {
        private const string EMPTY_GLASS_PREFAB_NAME = "EmptyGlass";
        private readonly List<EmptyGlassView> _emptyGlassViews = new();

        // _view = _viewFactory.CreateView<EmptyGlassesView, EmptyGlassesHierarchy>(PREFAB_NAME, root);

        public EmptyGlassesView(EmptyGlassesHierarchy hierarchy, IViewFactory viewFactory) : base(hierarchy, viewFactory)
        {
        }

        protected override void UpdateViewModel(IEmptyGlassesViewModel viewModel)
        {
            UpdateViewCount(viewModel.EmptyGlassViewModels.Count);
            for (var index = 0; index < viewModel.EmptyGlassViewModels.Count; index++)
            {
                IEmptyGlassViewModel emptyGlassViewModel = viewModel.EmptyGlassViewModels[index];
                _emptyGlassViews[index].Initialize(emptyGlassViewModel);
            }
        }

        private Transform GetRoot(int index)
        {
            if (index >= Hierarchy.EmptyGlassPositions.Count)
                throw new Exception($"Too big index '{index}' for empty glass transforms");

            return Hierarchy.EmptyGlassPositions[index];
        }

        private void UpdateViewCount(int count)
        {
            for (int index = 0; index < _emptyGlassViews.Count; index++)
            {
                EmptyGlassView emptyGlassView = _emptyGlassViews[index];
                bool isActive = index < count;
                emptyGlassView.SetActive(isActive);
            }

            for (int index = _emptyGlassViews.Count; index < count; index++)
            {
                var view = CreateView<EmptyGlassView, EmptyGlassHierarchy>(EMPTY_GLASS_PREFAB_NAME, GetRoot(index));
                _emptyGlassViews.Add(view);
            }
        }
    }
}