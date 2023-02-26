using System;
using System.Collections.Generic;
using LevelWindowModule.Contracts;

namespace LevelWindowModule
{
    public class EmptyGlassesModel
    {
        private readonly List<EmptyGlassModel> _emptyGlassModels = new();

        public event Action EmptyGlassesChanged;
        public bool CanSelectGlass { get; } = true;
        public IReadOnlyList<EmptyGlassModel> EmptyGlassModels => _emptyGlassModels;

        public EmptyGlassesModel(List<EGlassFormType> startEmptyGlasses)
        {
            foreach (EGlassFormType glassFormType in startEmptyGlasses)
            {
                var emptyGlassModel = new EmptyGlassModel(glassFormType);
                _emptyGlassModels.Add(emptyGlassModel);
            }
        }
    }
}