using LevelWindowModule.Contracts;

namespace LevelWindowModule
{
    public class EmptyGlassModel
    {
        public EGlassFormType GlassFormType { get; }

        public EmptyGlassModel(EGlassFormType glassFormType)
        {
            GlassFormType = glassFormType;
        }
    }
}