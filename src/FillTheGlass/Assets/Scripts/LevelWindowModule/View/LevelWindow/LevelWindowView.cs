using MvvmModule;

namespace LevelWindowModule.View
{
    public sealed class LevelWindowView : View<LevelWindowHierarchy, ILevelWindowViewModel>
    {
        private readonly EmptyGlassesView _emptyGlassesView;

        // _view = _viewFactory.CreateView<LevelWindowView, LevelWindowHierarchy>(PREFAB_NAME, root);
        public LevelWindowView(LevelWindowHierarchy hierarchy, IViewFactory viewFactory) : base(hierarchy, viewFactory)
        {
            _emptyGlassesView = CreateView<EmptyGlassesView, EmptyGlassesHierarchy>(Hierarchy.EmptyGlassesHierarchy);
        }

        protected override void UpdateViewModel(ILevelWindowViewModel viewModel)
        {
            _emptyGlassesView.Initialize(viewModel.EmptyGlassesViewModel);
        }
    }
}