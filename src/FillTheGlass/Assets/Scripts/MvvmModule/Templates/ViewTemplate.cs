using UnityEngine;

namespace MvvmModule.Templates
{
    public sealed class A123Hierarchy : MonoBehaviour
    {
    }

    public sealed class A123View : View<A123Hierarchy, IA123ViewModel>
    {
        // _view = _viewFactory.CreateView<A123View, A123Hierarchy>(PREFAB_NAME, root);
        public A123View(GameObject gameObject, IViewFactory viewFactory) : base(gameObject, viewFactory)
        {
        }

        protected override void UpdateViewModel(IA123ViewModel viewModel)
        {
        }
    }

    public interface IA123ViewModel : IViewModel
    {
    }

    public sealed class A123ViewModel : ViewModel<A123Args>, IA123ViewModel
    {
        // private readonly IViewModelFactory _viewModelFactory;
        // var viewModel = _viewModelFactory.CreateViewModel<A123ViewModel>();

        public A123ViewModel(A123Args model, IViewModelFactory viewModelFactory) : base(model, viewModelFactory)
        {
        }
    }

    public class A123Args
    {
    }
}