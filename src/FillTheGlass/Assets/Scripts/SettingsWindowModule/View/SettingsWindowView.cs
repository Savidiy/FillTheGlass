using MvvmModule;

namespace SettingsWindowModule.View
{
    public sealed class SettingsWindowView : View<SettingsWindowHierarchy, ISettingsWindowViewModel>
    {
        public SettingsWindowView(SettingsWindowHierarchy hierarchy, IViewFactory viewFactory) : base(hierarchy, viewFactory)
        {
        }

        protected override void UpdateViewModel(ISettingsWindowViewModel viewModel)
        {
            Hierarchy.ResetButton.onClick.AddListener(OnResetButtonClick);
            Hierarchy.BackButton.onClick.AddListener(OnBackButtonClick);
        }

        protected override void ReleaseViewModel()
        {
            base.ReleaseViewModel();
            Hierarchy.ResetButton.onClick.RemoveListener(OnResetButtonClick);
            Hierarchy.BackButton.onClick.RemoveListener(OnBackButtonClick);
        }

        private void OnBackButtonClick()
        {
            ViewModel.BackClickFromView();
        }

        private void OnResetButtonClick()
        {
            ViewModel.ResetClickFromView();
        }
    }
}