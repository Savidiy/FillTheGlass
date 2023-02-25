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
        private SettingsWindowView _view;

        public SettingsWindowPresenter(WindowsRootProvider windowsRootProvider, IViewFactory viewFactory,
            IViewModelFactory viewModelFactory)
        {
            _viewFactory = viewFactory;
            _viewModelFactory = viewModelFactory;
            _windowsRootProvider = windowsRootProvider;
            CreateView();
        }

        public void ShowWindow()
        {
            var viewModel = _viewModelFactory.CreateEmptyViewModel<SettingsWindowViewModel>();
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
            _view = _viewFactory.CreateView<SettingsWindowView, SettingsWindowHierarchy>(PREFAB_NAME, root);
        }
    }
}