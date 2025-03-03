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
        //LevelList.Instance.PopulateList();  
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
            // see if we have that number in level list
            if(result <= Level.levels.Count)
                Levels_Generated = result;
            else
            {
                // adjust to show a message in the ui and not an error
                Debug.LogError("Level number out of range.");
            }
        }
    }

}
