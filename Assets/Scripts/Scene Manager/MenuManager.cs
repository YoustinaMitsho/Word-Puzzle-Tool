using System.Collections;
using System.Collections.Generic;
using EasyUI.Toast;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [Header("References:")]
    [SerializeField] TMP_InputField _levelNumber;
    public static int CurrentLevel;
    public static int Levels_Generated;

    void Awake()
    {
        CurrentLevel = -1;
        Levels_Generated = -1;
    }

    void Start()
    {
        _levelNumber.onEndEdit.AddListener(SetUserInput);
    }


    public void Start_Game()
    {
        if (Levels_Generated > -1)
        {
            CurrentLevel = 0;
            SceneManager.LoadScene(Tags.Level_Scene);
        }
        if (_levelNumber.text == string.Empty)
            ShowEmptyWarning();
    }

    private void SetUserInput(string value)
    {
        if (int.TryParse(value, out int result))
        {
            if (result <= Level.levels.Count)
                Levels_Generated = result;
            else if (result > Level.levels.Count)
                ShowOutOfRangeWarning();
        }
    }

    public void ShowEmptyWarning()
    {
        Toast.Show("Please enter number of levels to be generated", 3f);
    }

    public void ShowOutOfRangeWarning()
    {
        Toast.Show("Number of levels you entered is more than what we have", 3f);
    }
}
