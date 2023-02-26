using LevelWindowModule.Contracts;

namespace LevelWindowModule
{
    public class EmptyGlassModel
    {
        public EGlassFormType GlassFormType { get; internal set; }

        public EmptyGlassModel(EGlassFormType glassFormType)
        {
            GlassFormType = glassFormType;
        }
    }
}