using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelList : MonoBehaviour
{
    [SerializeField] private Transform _levelItemParent;
    [SerializeField] private LevelItem _levelItemPrefab;


    public void PopulateList()
    {
        try
        {
            foreach (Transform child in _levelItemParent)
            {
                Destroy(child.gameObject);
            }

            foreach (Level level in Level.levels)
            {
                LevelItem levelItem = Instantiate(_levelItemPrefab, _levelItemParent);
                levelItem.initialise(level);
            }
        }
        catch(Exception e)
        {
            Debug.LogError(e.Message);
        }
        
    }
}
