using MvvmModule;
using UnityEngine;

namespace LevelInfoWindowModule.View
{
    public sealed class LevelInfoWindowView : View<LevelInfoWindowHierarchy, ILevelInfoWindowViewModel>
    {
        private readonly CalendarView _calendarView;

        public LevelInfoWindowView(LevelInfoWindowHierarchy hierarchy, IViewFactory viewFactory) : base(hierarchy, viewFactory)
        {
            _calendarView = CreateView<CalendarView, CalendarHierarchy>(Hierarchy.CalendarHierarchy);
        }

        protected override void UpdateViewModel(ILevelInfoWindowViewModel viewModel)
        {
            _calendarView.Initialize(viewModel.CalendarViewModel);

            Hierarchy.LevelLabel.text = $"Level {viewModel.LevelNumber}";
            Hierarchy.TargetMoneyLabel.text = $"Level target {viewModel.TargetMoneyCount}$";
            Hierarchy.TotalMoneyLabel.text = $"Total {viewModel.TotalMoneyCount}$";

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