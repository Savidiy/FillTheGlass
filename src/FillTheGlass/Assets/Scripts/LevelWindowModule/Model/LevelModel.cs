using MvvmModule;
using UnityEngine;

namespace LevelWindowModule
{
    public sealed class LevelModel : DisposableCollector
    {
        public EmptyGlassesModel EmptyGlassesModel { get; }
        public TimerModel TimerModel { get; }
        public MoneyModel MoneyModel { get; }

        public LevelModel(TimerModel timerModel, MoneyModel moneyModel, EmptyGlassesModel emptyGlassesModel)
        {
            TimerModel = timerModel;
            MoneyModel = moneyModel;
            EmptyGlassesModel = emptyGlassesModel;
            
            AddDisposable(timerModel);
        }

        public void SelectEmptyGlass(int glassNumber)
        {
            Debug.Log($"Select empty glass '{glassNumber}'");
        }
    }
}