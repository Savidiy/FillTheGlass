using System;
using LevelWindowModule.Contracts;

namespace LevelWindowModule
{
    public sealed class GlassModel
    {
        public event Action ModelChanged;

        public EGlassFormType GlassFormType { get; private set; }
        public bool HasIce { get; private set; }
        public bool HasCitrus { get; private set; }
        public bool HasStraw { get; private set; }

        public void SetGlass(EGlassFormType glassFormType)
        {
            GlassFormType = glassFormType;
            OnModelChanged();
        }

        public void SetHasCitrus(bool hasCitrus)
        {
            HasCitrus = hasCitrus;
            OnModelChanged();
        }

        public void SetHasIce(bool hasIce)
        {
            HasIce = hasIce;
            OnModelChanged();
        }

        public void SetHasStraw(bool hasStraw)
        {
            HasStraw = hasStraw;
            OnModelChanged();
        }

        private void OnModelChanged() => ModelChanged?.Invoke();
    }
}