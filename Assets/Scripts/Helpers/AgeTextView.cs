using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class AgeTextView : MonoBehaviour
{
    [SerializeField] private TMP_Text _ageText;
    [SerializeField] private Slider _ageSlider;

    private void OnEnable()
    {
        _ageSlider.onValueChanged
            .AsObservable()
            .Select(v => (int)v)
            .Subscribe(val => _ageText.text = val.ToString())
            .AddTo(this);
    }
}