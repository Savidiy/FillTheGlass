using Savidiy.Utils;
using SettingsModule;

namespace LevelWindowModule
{
    public sealed class LevelModelFactory
    {
        private readonly TickInvoker _tickInvoker;

        public LevelModelFactory(TickInvoker tickInvoker)
        {
            _tickInvoker = tickInvoker;
        }

        public LevelModel Create(LevelData levelData)
        {
            var timerModel = new TimerModel(_tickInvoker, levelData.DurationInSeconds);
            var moneyModel = new MoneyModel(levelData.TargetMoneyCount);
            var emptyGlassesModel = new EmptyGlassesModel(levelData.StartEmptyGlasses);

            var levelModel = new LevelModel(timerModel, moneyModel, emptyGlassesModel);
            return levelModel;
        }
    }
}