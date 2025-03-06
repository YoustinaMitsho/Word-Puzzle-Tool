using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceItem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _ChoiceAnswers;
    [SerializeField] private AudioSource _audioSource;
    [SerializeField] private AudioClip _wrongAns;
    [SerializeField] private AudioClip _rightAns;

    private Button _button;
    public static string _rightChoice;
    public static bool IsTrueAns = false;

    void Awake()
    {
        _button = GetComponent<Button>();

        if (_button != null)
        {
            _button.onClick.AddListener(OnChoiceClicked);
        }
    }

    private void OnChoiceClicked()
    {
        print(_ChoiceAnswers.text);
        print("level: " + _rightChoice);
        if (_ChoiceAnswers.text == _rightChoice)
        {
            FindObjectOfType<WrongAnswerEffect>().SetEffectColor(Color.green);
            FindObjectOfType<WrongAnswerEffect>().TriggerEffect();
            _audioSource.PlayOneShot(_rightAns);
            IsTrueAns = true;
        }
        else
        {
            FindObjectOfType<WrongAnswerEffect>().SetEffectColor(Color.red);
            FindObjectOfType<WrongAnswerEffect>().TriggerEffect();
            _audioSource.PlayOneShot(_wrongAns);
            IsTrueAns = false;
        }
    }
}
