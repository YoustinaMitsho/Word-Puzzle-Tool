using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Referneces")]
    [SerializeField] private Image _levelImage;
    [SerializeField] private TextMeshProUGUI _levelName;
    [SerializeField] private Image _levelSlider;

    void Start()
    {
        MakeLevel();
        Invoke(nameof(LevelList.Instance.PopulateList), 0.1f);
    }

    private void MakeLevel()
    {
        for (int i = 0; i < MenuManager.Levels_Generated; i++)
        {
            _levelImage.sprite = Level.levels[i].images[0];
            _levelName.text = Level.levels[i].level_name;
            _levelSlider.fillAmount = i / (float)Level.levels[i].images.Count;
        }
    }
}
