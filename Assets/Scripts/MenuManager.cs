using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [Header("References:")]
    [SerializeField] TMP_InputField _levelNumber;

    public static int Levels_Generated { get; private set; }
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        _levelNumber.onEndEdit.AddListener(SetUserInput);
    }

    public void Start_Game()
    {
        SceneManager.LoadScene(Tags.Level_Scene);
    }

    private void SetUserInput(string value)
    {
        if (int.TryParse(value, out int result))
        {
            Levels_Generated = result;
        }
    }
}
