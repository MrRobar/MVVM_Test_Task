using MVVM;
using UnityEngine;
using Zenject;

namespace DI
{
    public class UserModelInstaller : MonoInstaller
    {
        [SerializeField] private string _initialName = "Иван";
        [SerializeField] private int _initialAge = 25;
        public override void InstallBindings()
        {
            Container.Bind<UserModel>().AsSingle().OnInstantiated<UserModel>((_, model) =>
                {
                    model.SetName(_initialName);
                    model.SetAge(_initialAge);
                })
                .NonLazy();
        }
    }
}