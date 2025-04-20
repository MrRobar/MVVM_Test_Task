using System;
using TMPro;
using UniRx;
using UnityEngine.UI;

namespace Helpers
{
    public static class BindExtensions
    {
        public static IDisposable BindTo(this TMP_InputField inputField, ReactiveProperty<string> property)
        {
            var d1 = inputField
                .onValueChanged
                .AsObservable()
                .Subscribe(value => property.Value = value);

            var d2 = property
                .Subscribe(value =>
                {
                    if (inputField.text != value)
                        inputField.text = value;
                });

            return new CompositeDisposable(d1, d2);
        }

        public static IDisposable BindTo(this Slider slider, ReactiveProperty<int> property)
        {
            var d1 = slider
                .onValueChanged
                .AsObservable()
                .Select(v => (int)v)
                .Subscribe(value => property.Value = value);

            var d2 = property
                .Subscribe(value =>
                {
                    if ((int)slider.value != value)
                        slider.value = value;
                });

            return new CompositeDisposable(d1, d2);
        }

        public static IDisposable BindTo(this ReactiveCommand cmd, Button button)
        {
            var d1 = cmd.CanExecute
                .Subscribe(can => button.interactable = can);

            var d2 = button.onClick
                .AsObservable()
                .Subscribe(_ => cmd.Execute());

            return new CompositeDisposable(d1, d2);
        }

        public static IDisposable BindTo(this IObservable<string> source, TMP_Text text) =>
            source.Subscribe(val => text.text = val);
    }
}