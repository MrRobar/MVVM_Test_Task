using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using Helpers;

namespace MVVM
{
    public class UserView : MonoBehaviour
    {
        [SerializeField] private TMP_InputField _nameInputField;
        [SerializeField] private Slider _ageSlider;
        [SerializeField] private Button _confirmButton;
        [SerializeField] private TMP_Text _greetingText;

        [Inject] private UserViewModel _vm;

        private CompositeDisposable _disposables;

        private void OnEnable()
        {
            _disposables = new CompositeDisposable();

            _nameInputField.BindTo(_vm.Name).AddTo(_disposables);
            _ageSlider.BindTo(_vm.Age).AddTo(_disposables);
            _vm.Greeting.BindTo(_greetingText).AddTo(_disposables);
            _vm.ConfirmCommand.BindTo(_confirmButton).AddTo(_disposables);
        }

        private void OnDisable()
        {
            _disposables.Dispose();
        }
    }
}