using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public static class ButtonExtension
{
    public static void AddEventListener<T>(this Button button, T param, Action<T> OnClick)
    {
        button.onClick.AddListener(delegate () {
            OnClick(param);
        });
    }
}

public class LevelListing : MonoBehaviour
{
    private void Start()
    {
        GameObject prefab = transform.GetChild(0).gameObject;
        GameObject obj;
        //print(Level.levels.Count);
        for(int i = 0; i < Level.levels.Count; i++)
        {
            obj = Instantiate(prefab, transform);
            obj.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = Level.levels[i].level_name;
            obj.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = Level.levels[i].level_creation_mode;
            obj.transform.GetChild(0).GetComponent<Image>().sprite = Level.levels[i].level_image;

            obj.GetComponent<Button>().AddEventListener(i, ItemClicked);
        }

        Destroy(prefab);
    }

    void ItemClicked(int itemIndex)
    {
        //print("level listing index: "   + itemIndex);
        MenuManager.CurrentLevel = itemIndex;
    }
}
