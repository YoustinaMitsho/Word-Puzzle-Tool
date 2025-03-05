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
        if (MenuManager.CurrentLevel != -1) MakeCertainLevel();
        if (MenuManager.Levels_Generated != -1) MakeLevels();
    }

    void Update()
    {
        if (_choice_clicked)
        {
            i++;
            if (i == MenuManager.Levels_Generated)
            {
                Exit();
            }
            else
            {
                _choice_clicked = false;
                MakeLevels();
            }    
        }

        if( i >= MenuManager.CurrentLevel && MenuManager.Levels_Generated == -1)
        {
            MainMenu();
        }
    }

    public void MakeLevels()
    {
        _levelImage.sprite = Level.levels[i].level_image;
        _levelName.text = Level.levels[i].level_name;
        _levelSlider.fillAmount = 0;
        print("loop: " + i);
        ChoiceListing.instance.GenerateChoices(i);

        if (i == MenuManager.Levels_Generated) return;
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
