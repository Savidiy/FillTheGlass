using LevelWindowModule.View;
using MvvmModule;

namespace LevelWindowModule
{
    public sealed class LiquidsInGlassArgs
    {
        public GlassModel GlassModel { get; }

        public LiquidsInGlassArgs(GlassModel glassModel)
        {
            GlassModel = glassModel;
        }
    }

    public sealed class LiquidsInGlassViewModel : ViewModel<LiquidsInGlassArgs>, ILiquidsInGlassViewModel
    {
        public LiquidsInGlassViewModel(LiquidsInGlassArgs liquidsInGlassArgs, IViewModelFactory viewModelFactory) : base(
            liquidsInGlassArgs, viewModelFactory)
        {
        }
    }
}