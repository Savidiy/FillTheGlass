using Bootstrap;
using LevelInfoWindowModule.ViewModel;
using MainModule;
using MvvmModule;
using SettingsModule;
using SettingsWindowModule.ViewModels;
using StartWindowModule.ViewModels;
using UiModule;
using Zenject;

namespace Installers
{
    public class ProjectInstaller : MonoInstaller
    {
        public GameSettings GameSettings;
        
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<Bootstrapper>().AsSingle();

            Container.BindInterfacesTo<PrefabFactory>().AsSingle();
            Container.BindInterfacesTo<ViewFactory>().AsSingle();
            Container.BindInterfacesTo<ViewModelFactory>().AsSingle();

            Container.Bind<WindowsRootProvider>().AsSingle();
            Container.BindInterfacesTo<StartWindowPresenter>().AsSingle();
            Container.BindInterfacesTo<SettingsWindowPresenter>().AsSingle();
            Container.BindInterfacesTo<LevelInfoWindowPresenter>().AsSingle();
            
            Container.Bind<MainStateMachine>().AsSingle();
            Container.Bind<StartMainState>().AsSingle();
            Container.Bind<LevelInfoMainState>().AsSingle();
            
            Container.Bind<GameSettings>().FromInstance(GameSettings);
        }
    }
}