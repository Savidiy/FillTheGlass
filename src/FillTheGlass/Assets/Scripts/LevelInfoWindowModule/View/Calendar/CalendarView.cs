using MvvmModule;
using UnityEngine;

namespace LevelInfoWindowModule.View
{
    public sealed class CalendarView : View<CalendarHierarchy, ICalendarViewModel>
    {
        // _view = _viewFactory.CreateView<CalendarView, CalendarHierarchy>(PREFAB_NAME, root);
        public CalendarView(CalendarHierarchy hierarchy, IViewFactory viewFactory) : base(hierarchy, viewFactory)
        {
        }

        protected override void UpdateViewModel(ICalendarViewModel viewModel)
        {
        }
    }
}