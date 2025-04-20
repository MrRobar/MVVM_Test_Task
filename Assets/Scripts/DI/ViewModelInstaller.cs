using MVVM;
using Zenject;

namespace DI
{
    public class ViewModelInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<UserViewModel>().AsSingle().NonLazy();
        }
    }
}