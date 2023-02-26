using System.Collections.Generic;
using LevelWindowModule.View;
using MvvmModule;

namespace LevelWindowModule
{
    public sealed class EmptyGlassesViewModel : EmptyViewModel, IEmptyGlassesViewModel
    {
        private readonly List<IEmptyGlassViewModel> _emptyGlassViewModels = new();

        public IReadOnlyList<IEmptyGlassViewModel> EmptyGlassViewModels => _emptyGlassViewModels;

        public EmptyGlassesViewModel(IViewModelFactory viewModelFactory, LevelHolder levelHolder) : base(viewModelFactory)
        {
            IReadOnlyList<EmptyGlassModel> emptyGlassModels = levelHolder.LevelModel.EmptyGlassesModel.EmptyGlassModels;
            for (var index = 0; index < emptyGlassModels.Count; index++)
            {
                var args = new EmptyGlassArgs(index);
                var viewModel = CreateViewModel<EmptyGlassViewModel, EmptyGlassArgs>(args);
                _emptyGlassViewModels.Add(viewModel);
            }
        }
    }
}