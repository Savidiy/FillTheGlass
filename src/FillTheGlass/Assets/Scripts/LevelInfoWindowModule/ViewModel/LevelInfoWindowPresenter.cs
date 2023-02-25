﻿using System;
using LevelInfoWindowModule.Contracts;
using LevelInfoWindowModule.View;
using MvvmModule;
using UiModule;
using UnityEngine;

namespace LevelInfoWindowModule.ViewModel
{
    public sealed class LevelInfoWindowPresenter : IDisposable, ILevelInfoWindowPresenter
    {
        private const string PREFAB_NAME = "LevelInfo_window";
        private readonly WindowsRootProvider _windowsRootProvider;
        private readonly IViewFactory _viewFactory;
        private readonly IViewModelFactory _viewModelFactory;
        private readonly LevelInfoWindowView _view;

        public LevelInfoWindowPresenter(WindowsRootProvider windowsRootProvider, IViewFactory viewFactory,
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
            var viewModel = _viewModelFactory.CreateEmptyViewModel<LevelInfoWindowViewModel>();
            _view.Initialize(viewModel);
            _view.SetActive(true);
        }

        public void HideWindow()
        {
            _view.ClearViewModel();
            _view.SetActive(false);
        }

        public void Dispose()
        {
            _view.Dispose();
        }

        private LevelInfoWindowView CreateView()
        {
            Transform root = _windowsRootProvider.GetWindowRoot();
            var view = _viewFactory.CreateView<LevelInfoWindowView, LevelInfoWindowHierarchy>(PREFAB_NAME, root);
            return view;
        }
    }
}