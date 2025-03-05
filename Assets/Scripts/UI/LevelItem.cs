using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelItem : MonoBehaviour
{
    public void OpenLevel()
    {
        SceneManager.LoadScene(Tags.Level_Scene);
    }
}
