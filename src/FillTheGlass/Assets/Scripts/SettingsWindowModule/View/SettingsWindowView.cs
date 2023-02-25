using MvvmModule;
using UnityEngine;

namespace SettingsWindowModule.View
{
    public sealed class SettingsWindowView : View<SettingsWindowHierarchy, ISettingsWindowViewModel>
    {
        public SettingsWindowView(GameObject gameObject, IViewFactory viewFactory) : base(gameObject, viewFactory)
        {
            Hierarchy.gameObject.SetActive(false);
        }

        protected override void UpdateViewModel(ISettingsWindowViewModel viewModel)
        {
            Hierarchy.ResetButton.onClick.AddListener(OnResetButtonClick);
            Hierarchy.BackButton.onClick.AddListener(OnBackButtonClick);

            Hierarchy.gameObject.SetActive(true);
        }

        protected override void ReleaseViewModel()
        {
            base.ReleaseViewModel();
            Hierarchy.ResetButton.onClick.RemoveListener(OnResetButtonClick);
            Hierarchy.BackButton.onClick.RemoveListener(OnBackButtonClick);
            Hierarchy.gameObject.SetActive(false);
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