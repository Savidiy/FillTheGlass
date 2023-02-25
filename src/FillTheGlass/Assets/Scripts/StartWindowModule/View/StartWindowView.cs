using MvvmModule;

namespace StartWindowModule.View
{
    public sealed class StartWindowView : View<StartWindowHierarchy, IStartWindowViewModel>
    {
        public StartWindowView(StartWindowHierarchy hierarchy, IViewFactory viewFactory) : base(hierarchy, viewFactory)
        {
        }

        protected override void UpdateViewModel(IStartWindowViewModel viewModel)
        {
            Hierarchy.ContinueButton.gameObject.SetActive(viewModel.HasProgress);
            Hierarchy.StartButton.gameObject.SetActive(!viewModel.HasProgress);

            Hierarchy.StartButton.onClick.AddListener(OnStartButtonClick);
            Hierarchy.ContinueButton.onClick.AddListener(OnContinueButtonClick);
            Hierarchy.SettingsButton.onClick.AddListener(OnSettingsButtonClick);
        }

        protected override void ReleaseViewModel()
        {
            base.ReleaseViewModel();
            Hierarchy.StartButton.onClick.RemoveListener(OnStartButtonClick);
            Hierarchy.ContinueButton.onClick.RemoveListener(OnContinueButtonClick);
            Hierarchy.SettingsButton.onClick.RemoveListener(OnSettingsButtonClick);
        }

        private void OnSettingsButtonClick()
        {
            ViewModel.SettingsClickFromView();
        }

        private void OnContinueButtonClick()
        {
            ViewModel.ContinueClickFromView();
        }

        private void OnStartButtonClick()
        {
            ViewModel.StartClickFromView();
        }
    }
}