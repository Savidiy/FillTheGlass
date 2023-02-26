using MvvmModule;
using UnityEngine;

namespace LevelWindowModule.View
{
    public sealed class AccessoriesInGlassView : View<AccessoriesInGlassHierarchy, IAccessoriesInGlassViewModel>
    {
        public AccessoriesInGlassView(AccessoriesInGlassHierarchy hierarchy, IViewFactory viewFactory) : base(hierarchy,
            viewFactory)
        {
        }

        protected override void UpdateViewModel(IAccessoriesInGlassViewModel viewModel)
        {
            Bind(viewModel.HasIce, OnHasIceChange);
            Bind(viewModel.HasStraw, OnHasStrawChange);
            Bind(viewModel.HasCitrus, OnHasCitrusChange);
            Bind(viewModel.IceLocalPosition, OnIceLocalPositionChange);
            Bind(viewModel.CitrusLocalPosition, OnCitrusLocalPositionChange);
            Bind(viewModel.StrawLocalPosition, OnStrawLocalPositionChange);
        }

        private void OnHasIceChange(bool has) => Hierarchy.IceImage.enabled = has;
        private void OnHasStrawChange(bool has) => Hierarchy.StrawImage.enabled = has;
        private void OnHasCitrusChange(bool has) => Hierarchy.CitrusImage.enabled = has;
        private void OnIceLocalPositionChange(Vector3 pos) => Hierarchy.IceImage.transform.localPosition = pos;
        private void OnCitrusLocalPositionChange(Vector3 pos) => Hierarchy.CitrusImage.transform.localPosition = pos;
        private void OnStrawLocalPositionChange(Vector3 pos) => Hierarchy.StrawImage.transform.localPosition = pos;
    }
}