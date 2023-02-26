using System.Collections.Generic;
using MvvmModule;

namespace LevelWindowModule.View
{
    public interface IEmptyGlassesViewModel : IViewModel
    {
        IReadOnlyList<IEmptyGlassViewModel> EmptyGlassViewModels { get; }
    }
}