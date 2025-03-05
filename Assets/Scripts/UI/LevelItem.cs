using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelItem : MonoBehaviour
{
    [Header("References:")]
    [SerializeField] Image _levelImage;
    [SerializeField] TextMeshProUGUI _levelName;
    [SerializeField] TextMeshProUGUI _levelCreationMode;

    public void initialise(Level level)
    {
        _levelImage.sprite = level.level_image;
        _levelName.text = level.level_name;
        _levelCreationMode.text = level.level_creation_mode;
    }
    public void OpenLevel()
    {
        SceneManager.LoadScene(Tags.Level_Scene);
    }
}
