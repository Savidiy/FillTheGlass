using UniRx;

namespace LevelWindowModule
{
    public class CurrentGlassModel
    {
        private readonly ReactiveProperty<bool> _canSendGlass = new();

        public IReadOnlyReactiveProperty<bool> CanSendGlass => _canSendGlass;

        public GlassModel GlassModel { get; }

        public CurrentGlassModel(GlassModel glassModel)
        {
            GlassModel = glassModel;
        }
    }
}