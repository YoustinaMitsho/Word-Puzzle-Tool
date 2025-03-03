using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceItem : MonoBehaviour
{
    TextMeshProUGUI _ChoiceAnswers;
    private Button _button;
    private Level _level;

    void Awake()
    {
        _ChoiceAnswers = GetComponent<TextMeshProUGUI>();
        _button = GetComponent<Button>();

        if (_button != null)
        {
            _button.onClick.AddListener(OnChoiceClicked);
        }
    }

    public void initialise(Level level, int index)
    {
        _ChoiceAnswers.text = level.no_of_choices_list[index];
        _level = level;
    }

    private void OnChoiceClicked()
    {
        if (_ChoiceAnswers.text == _level.RightChoice)
        {
            // play good anim
        }
        else
        {
            // play bad anim
        }
    }
}
