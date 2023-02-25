using MvvmModule;
using UnityEngine;

namespace StartWindowModule.View
{
    public sealed class StartWindowView : View<StartWindowHierarchy, IStartWindowViewModel>
    {
        public StartWindowView(GameObject gameObject, IViewFactory viewFactory) : base(gameObject, viewFactory)
        {
            Hierarchy.gameObject.SetActive(false);
        }

        protected override void UpdateViewModel(IStartWindowViewModel viewModel)
        {
            Hierarchy.ContinueButton.gameObject.SetActive(viewModel.HasProgress);
            Hierarchy.StartButton.gameObject.SetActive(!viewModel.HasProgress);

            Hierarchy.StartButton.onClick.AddListener(OnStartButtonClick);
            Hierarchy.ContinueButton.onClick.AddListener(OnContinueButtonClick);
            Hierarchy.SettingsButton.onClick.AddListener(OnSettingsButtonClick);

            Hierarchy.gameObject.SetActive(true);
        }

        protected override void ReleaseViewModel()
        {
            base.ReleaseViewModel();
            Hierarchy.StartButton.onClick.RemoveListener(OnStartButtonClick);
            Hierarchy.ContinueButton.onClick.RemoveListener(OnContinueButtonClick);
            Hierarchy.SettingsButton.onClick.RemoveListener(OnSettingsButtonClick);
            Hierarchy.gameObject.SetActive(false);
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