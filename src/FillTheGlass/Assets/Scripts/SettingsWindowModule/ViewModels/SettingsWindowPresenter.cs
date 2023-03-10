using System;
using MvvmModule;
using SettingsWindowModule.Contracts;
using SettingsWindowModule.View;
using UiModule;
using UnityEngine;

namespace SettingsWindowModule.ViewModels
{
    public sealed class SettingsWindowPresenter : IDisposable, ISettingsWindowPresenter
    {
        private const string PREFAB_NAME = "Settings_window";
        private readonly WindowsRootProvider _windowsRootProvider;
        private readonly IViewFactory _viewFactory;
        private readonly IViewModelFactory _viewModelFactory;
        private readonly SettingsWindowView _view;
        private SettingsWindowViewModel _viewModel;

        public SettingsWindowPresenter(WindowsRootProvider windowsRootProvider, IViewFactory viewFactory,
            IViewModelFactory viewModelFactory)
        {
            _viewFactory = viewFactory;
            _viewModelFactory = viewModelFactory;
            _windowsRootProvider = windowsRootProvider;
            _view = CreateView();
            _view.SetActive(false);
        }

        public void ShowWindow()
        {
            if (_viewModel != null)
                _viewModel.NeedClose -= HideWindow;

            _viewModel = _viewModelFactory.CreateEmptyViewModel<SettingsWindowViewModel>();
            _viewModel.NeedClose += HideWindow;
            _view.Initialize(_viewModel);
            _view.Hierarchy.transform.SetAsLastSibling();
            _view.SetActive(true);
        }

        public void HideWindow()
        {
            _viewModel.NeedClose -= HideWindow;
            _view.ClearViewModel();
            _view.SetActive(false);
        }

        public void Dispose()
        {
            if (_viewModel != null)
                _viewModel.NeedClose -= HideWindow;

            _view.Dispose();
        }

        private SettingsWindowView CreateView()
        {
            Transform root = _windowsRootProvider.GetWindowRoot();
            var view = _viewFactory.CreateView<SettingsWindowView, SettingsWindowHierarchy>(PREFAB_NAME, root);
            return view;
        }
    }
}