using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelList : MonoBehaviour
{
    [SerializeField] private Transform _levelItemParent;
    [SerializeField] private GameObject _ItemPrefab;

    GameObject prefabToInstantiate;

    public static LevelList Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PopulateList()
    {
        try
        {
            foreach (Transform child in _levelItemParent)
            {
                Destroy(child.gameObject);
            }

            if (_ItemPrefab.TryGetComponent<LevelItem>(out LevelItem item))
            {
                prefabToInstantiate = _ItemPrefab;
                foreach (Level level in Level.levels)
                {
                    LevelItem levelItem = Instantiate(prefabToInstantiate, _levelItemParent).GetComponent<LevelItem>();
                    if (levelItem != null)
                    {
                        levelItem.initialise(level);
                    }
                }
            }
            else if (_ItemPrefab.TryGetComponent<ChoiceItem>(out ChoiceItem choiceItemPrefab))
            {
                prefabToInstantiate = _ItemPrefab;
                int index = 0;
                foreach (Level level in Level.levels)
                {
                    ChoiceItem choiceItem = Instantiate(prefabToInstantiate, _levelItemParent).GetComponent<ChoiceItem>();
                    if (choiceItem != null)
                    {
                        choiceItem.initialise(level, index);
                    }
                    index++;
                }
            }
            else
            {
                Debug.LogError("The given _ItemPrefab does not have LevelItem or ChoiceItem component!");
            }
        }
        catch(Exception e)
        {
            Debug.LogError(e.Message);
        }
        
    }
}
