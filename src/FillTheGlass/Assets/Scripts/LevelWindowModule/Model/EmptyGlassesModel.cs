using System;
using System.Collections.Generic;
using LevelWindowModule.Contracts;

namespace LevelWindowModule
{
    public class EmptyGlassesModel
    {
        private readonly List<EmptyGlassModel> _emptyGlassModels = new();

        public event Action EmptyGlassesChanged;
        public bool CanSelectGlass { get; private set; } = true;
        public IReadOnlyList<EmptyGlassModel> EmptyGlassModels => _emptyGlassModels;

        public EmptyGlassesModel(List<EGlassFormType> startEmptyGlasses)
        {
            foreach (EGlassFormType glassFormType in startEmptyGlasses)
            {
                var emptyGlassModel = new EmptyGlassModel(glassFormType);
                _emptyGlassModels.Add(emptyGlassModel);
            }
        }

        internal void SetCanSelectGlass(bool canSelectGlass)
        {
            CanSelectGlass = canSelectGlass;
        }

        internal void RemoveGlass(int glassNumber)
        {
            _emptyGlassModels[glassNumber].GlassFormType = EGlassFormType.None;
        }

        internal void InvokeUpdate()
        {
            EmptyGlassesChanged?.Invoke();
        }
    }
}