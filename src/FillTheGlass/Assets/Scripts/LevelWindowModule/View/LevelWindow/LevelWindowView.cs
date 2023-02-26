using MvvmModule;

namespace LevelWindowModule.View
{
    public sealed class LevelWindowView : View<LevelWindowHierarchy, ILevelWindowViewModel>
    {
        private readonly EmptyGlassesView _emptyGlassesView;
        private readonly CurrentGlassView _currentGlassView;

        public LevelWindowView(LevelWindowHierarchy hierarchy, IViewFactory viewFactory) : base(hierarchy, viewFactory)
        {
            _emptyGlassesView = CreateView<EmptyGlassesView, EmptyGlassesHierarchy>(Hierarchy.EmptyGlassesHierarchy);
            _currentGlassView = CreateView<CurrentGlassView, CurrentGlassHierarchy>(Hierarchy.CurrentGlassHierarchy);
        }

        protected override void UpdateViewModel(ILevelWindowViewModel viewModel)
        {
            _emptyGlassesView.Initialize(viewModel.EmptyGlassesViewModel);
            _currentGlassView.Initialize(viewModel.CurrentGlassViewModel);
            
            BindClick(Hierarchy.SettingsButton, OnSettingsClick);
        }

        private void OnSettingsClick()
        {
            ViewModel.SettingsClickFromView();
        }
    }
}