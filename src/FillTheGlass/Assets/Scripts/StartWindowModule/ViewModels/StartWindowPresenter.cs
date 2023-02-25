using System;
using MvvmModule;
using StartWindowModule.Contracts;
using StartWindowModule.View;
using UiModule;
using UnityEngine;

namespace StartWindowModule.ViewModels
{
    public sealed class StartWindowPresenter : IDisposable, IStartWindowPresenter
    {
        private const string PREFAB_NAME = "Start_window";
        private readonly WindowsRootProvider _windowsRootProvider;
        private readonly IViewFactory _viewFactory;
        private readonly IViewModelFactory _viewModelFactory;
        private StartWindowView _view;

        public StartWindowPresenter(WindowsRootProvider windowsRootProvider, IViewFactory viewFactory,
            IViewModelFactory viewModelFactory)
        {
            _viewFactory = viewFactory;
            _viewModelFactory = viewModelFactory;
            _windowsRootProvider = windowsRootProvider;
            CreateView();
        }

        public void ShowWindow()
        {
            var viewModel = _viewModelFactory.CreateEmptyViewModel<StartWindowViewModel>();
            _view.Initialize(viewModel);
        }

        public void HideWindow()
        {
            _view.ClearViewModel();
        }

        public void Dispose()
        {
            _view.Dispose();
        }

        private void CreateView()
        {
            Transform root = _windowsRootProvider.GetWindowRoot();
            _view = _viewFactory.CreateView<StartWindowView, StartWindowHierarchy>(PREFAB_NAME, root);
        }
    }
}