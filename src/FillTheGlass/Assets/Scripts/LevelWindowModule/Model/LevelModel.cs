using LevelWindowModule.Contracts;
using MvvmModule;
using UnityEngine;

namespace LevelWindowModule
{
    public sealed class LevelModel : DisposableCollector
    {
        public EmptyGlassesModel EmptyGlassesModel { get; }
        public TimerModel TimerModel { get; }
        public MoneyModel MoneyModel { get; }
        public CurrentGlassModel CurrentGlassModel { get; }

        public LevelModel(TimerModel timerModel, MoneyModel moneyModel, EmptyGlassesModel emptyGlassesModel,
            CurrentGlassModel currentGlassModel)
        {
            TimerModel = timerModel;
            MoneyModel = moneyModel;
            EmptyGlassesModel = emptyGlassesModel;
            CurrentGlassModel = currentGlassModel;

            AddDisposable(timerModel);
        }

        public void SelectEmptyGlass(int glassNumber)
        {
            Debug.Log($"Select empty glass '{glassNumber}'");
            
            EGlassFormType glassFormType = EmptyGlassesModel.EmptyGlassModels[glassNumber].GlassFormType;
            EmptyGlassesModel.SetCanSelectGlass(false);
            EmptyGlassesModel.RemoveGlass(glassNumber);
            EmptyGlassesModel.InvokeUpdate();
            
            CurrentGlassModel.GlassModel.SetGlass(glassFormType);
        }

        public void ToWashCurrentGlass()
        {
            EGlassFormType glassFormType = CurrentGlassModel.GlassModel.GlassFormType;
            CurrentGlassModel.GlassModel.SetGlass(EGlassFormType.None);
            
            foreach (EmptyGlassModel emptyGlassModel in EmptyGlassesModel.EmptyGlassModels)
            {
                if (emptyGlassModel.GlassFormType == EGlassFormType.None)
                {
                    emptyGlassModel.GlassFormType = glassFormType;
                    break;
                }
            }

            EmptyGlassesModel.SetCanSelectGlass(true);
            EmptyGlassesModel.InvokeUpdate();
        }
    }
}