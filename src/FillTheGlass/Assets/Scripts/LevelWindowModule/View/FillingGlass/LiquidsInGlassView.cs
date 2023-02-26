using MvvmModule;

namespace LevelWindowModule.View
{
    public sealed class LiquidsInGlassView : View<LiquidsInGlassHierarchy, ILiquidsInGlassViewModel>
    {
        public LiquidsInGlassView(LiquidsInGlassHierarchy hierarchy, IViewFactory viewFactory) : base(hierarchy, viewFactory)
        {
        }

        protected override void UpdateViewModel(ILiquidsInGlassViewModel viewModel)
        {
        }
    }
}