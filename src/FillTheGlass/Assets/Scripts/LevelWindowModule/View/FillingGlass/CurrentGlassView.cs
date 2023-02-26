using MvvmModule;

namespace LevelWindowModule.View
{
    public sealed class CurrentGlassView : View<CurrentGlassHierarchy, ICurrentGlassViewModel>
    {
        private readonly FillingGlassView _fillingGlassView;

        public CurrentGlassView(CurrentGlassHierarchy hierarchy, IViewFactory viewFactory) : base(hierarchy, viewFactory)
        {
            _fillingGlassView = CreateView<FillingGlassView, FillingGlassHierarchy>(Hierarchy.FillingGlassHierarchy);
        }

        protected override void UpdateViewModel(ICurrentGlassViewModel viewModel)
        {
            _fillingGlassView.Initialize(viewModel.FillingGlassViewModel);

            Bind(viewModel.CanSendGlass, OnCanSendChange);

            Bind(viewModel.CanToWash, UpdateButtons);
            Bind(viewModel.CanUnfill, UpdateButtons);
            Bind(viewModel.HasGlass, UpdateButtons);

            BindClick(Hierarchy.SendToCustomerButton, OnSendClick);
            BindClick(Hierarchy.CitrusButton, OnCitrusClick);
            BindClick(Hierarchy.StrawButton, OnStrawClick);
            BindClick(Hierarchy.IceButton, OnIceClick);
            BindClick(Hierarchy.ToWashButton, OnToWashClick);
            BindClick(Hierarchy.UnfillButton, OnUnfillClick);
        }

        private void UpdateButtons(bool _)
        {
            bool hasGlass = ViewModel.HasGlass.Value;

            Hierarchy.CitrusButton.interactable = hasGlass;
            Hierarchy.StrawButton.interactable = hasGlass;
            Hierarchy.IceButton.interactable = hasGlass;

            bool canToWash = ViewModel.CanToWash.Value;
            Hierarchy.ToWashButton.interactable = canToWash;

            bool canUnfill = ViewModel.CanUnfill.Value;
            Hierarchy.UnfillButton.interactable = canUnfill;
        }

        private void OnCanSendChange(bool obj) => Hierarchy.SendToCustomerButton.gameObject.SetActive(obj);

        private void OnSendClick() => ViewModel.SendClickFromView();
        private void OnCitrusClick() => ViewModel.OnCitrusClickFromView();
        private void OnStrawClick() => ViewModel.OnStrawClickFromView();
        private void OnIceClick() => ViewModel.OnIceClickFromView();
        private void OnToWashClick() => ViewModel.OnToWashClickFromView();
        private void OnUnfillClick() => ViewModel.OnUnfillClickFromView();
    }
}