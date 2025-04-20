using UniRx;
using Zenject;

namespace MVVM
{
    public class UserViewModel
    {
        [Inject] private UserModel _model;

        public ReactiveProperty<string> Name { get; } = new(string.Empty);
        public ReactiveProperty<int> Age { get; } = new(0);
        public ReactiveProperty<string> Greeting { get; }
        public ReactiveCommand ConfirmCommand { get; }

        public UserViewModel()
        {
            ConfirmCommand = Name
                .Select(n => !string.IsNullOrWhiteSpace(n))
                .ToReactiveCommand();

            Greeting = new ReactiveProperty<string>(string.Empty);

            ConfirmCommand
                .Subscribe(_ =>
                {
                    _model.SetName(Name.Value);
                    _model.SetAge(Age.Value);
                    Greeting.Value = $"Здравствуйте, {_model.Name}. Ваш возраст {_model.Age}!";
                });
        }
    }
}