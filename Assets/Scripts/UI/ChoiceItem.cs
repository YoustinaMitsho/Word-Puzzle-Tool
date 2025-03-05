using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceItem : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _ChoiceAnswers;
    private Button _button;
    public static string _rightChoice;
    [SerializeField] private GameObject _confetii;
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
            GameObject obj = Instantiate(_confetii, new Vector3(0,2,0), Quaternion.identity);
            //obj.GetComponent<ParticleSystem>().Play();
            IsTrueAns = true;
        }
        else
        {
            FindObjectOfType<WrongAnswerEffect>().TriggerEffect();
            IsTrueAns = false;
        }
    }
}
