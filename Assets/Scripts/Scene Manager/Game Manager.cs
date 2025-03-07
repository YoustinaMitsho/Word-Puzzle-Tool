using System;
using System.Collections;
using System.Collections.Generic;
using EasyUI.Toast;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("Referneces")]
    [SerializeField] private Image _levelImage;
    [SerializeField] private TextMeshProUGUI _levelName;
    [SerializeField] private Image _levelSlider;

    public static bool _choice_clicked = false;
    int i;

    void Awake()
    {
        i = 0;
    }

    void Start()
    {
        if (MenuManager.CurrentLevel != -1)
        {
            i = MenuManager.CurrentLevel;
            MakeCertainLevel();
        }
        else if (MenuManager.Levels_Generated != -1)
        {
            i = 0;
            MakeLevels();
        }
    }

    void Update()
    {
        if (_choice_clicked)
        {
            _choice_clicked = false;
            i++;
            if (i >= MenuManager.Levels_Generated || i >= Level.levels.Count)
            {
                Exit();
            }
            else
            {
                MakeLevels();
            }
        }
/*
        if (i > MenuManager.CurrentLevel && MenuManager.Levels_Generated == -1 ||
            i >= Level.levels.Count && ChoiceItem.IsTrueAns)
        {
            MainMenu();
        }*/
    }

    public void MakeLevels()
    {
        if (i >= Level.levels.Count) return;

        _levelImage.sprite = Level.levels[i].level_image;
        _levelName.text = Level.levels[i].level_name;
        _levelSlider.fillAmount = 0;
        print("loop: " + i);
        ChoiceListing.instance.GenerateChoices(i);

    }

    public void MakeCertainLevel()
    {
        _levelImage.sprite = Level.levels[MenuManager.CurrentLevel].level_image;
        _levelName.text = Level.levels[MenuManager.CurrentLevel].level_name;
        _levelSlider.fillAmount = 0;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(Tags.Main_Menu_Scene);
    }

    private void Exit()
    {
        Toast.Show("Levels Ended", 2f);
        StartCoroutine(WaitForToast());
    }

    IEnumerator WaitForToast()
    {
        yield return new WaitForSeconds(2f);
        MainMenu();
    }
}
