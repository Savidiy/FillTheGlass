using MvvmModule;
using UnityEngine;

namespace LevelInfoWindowModule.View
{
    public sealed class LevelInfoWindowView : View<LevelInfoWindowHierarchy, ILevelInfoWindowViewModel>
    {
        private readonly CalendarView _calendarView;

        // _view = _viewFactory.CreateView<LevelInfoWindowView, LevelInfoWindowHierarchy>(PREFAB_NAME, root);
        public LevelInfoWindowView(LevelInfoWindowHierarchy hierarchy, IViewFactory viewFactory) : base(hierarchy, viewFactory)
        {
            _calendarView = CreateView<CalendarView, CalendarHierarchy>(Hierarchy.CalendarHierarchy);
        }

        protected override void UpdateViewModel(ILevelInfoWindowViewModel viewModel)
        {
            _calendarView.Initialize(viewModel.CalendarViewModel);

            Hierarchy.LevelLabel.text = $"Level {viewModel.LevelNumber}";
            Hierarchy.TargetLabel.text = $"Target {viewModel.TargetMoneyCount}$";

            Hierarchy.BackButton.onClick.AddListener(OnBackButtonClick);
            Hierarchy.StartButton.onClick.AddListener(OnStartButtonClick);
            Hierarchy.SettingsButton.onClick.AddListener(OnSettingsButtonClick);
        }

        protected override void ReleaseViewModel()
        {
            base.ReleaseViewModel();

            Hierarchy.BackButton.onClick.RemoveListener(OnBackButtonClick);
            Hierarchy.StartButton.onClick.RemoveListener(OnStartButtonClick);
            Hierarchy.SettingsButton.onClick.RemoveListener(OnSettingsButtonClick);
        }

        private void OnSettingsButtonClick()
        {
            ViewModel.SettingsClickFromView();
        }

        private void OnStartButtonClick()
        {
            ViewModel.StartClickFromView();
        }

        private void OnBackButtonClick()
        {
            ViewModel.BackClickFromView();
        }
    }
}