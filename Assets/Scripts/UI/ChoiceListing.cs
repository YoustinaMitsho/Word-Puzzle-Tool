using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceListing : MonoBehaviour
{
    public static ChoiceListing instance;

    void Awake()
    {
        MakeSingleton();
    }

    void Start()
    {
        GenerateChoices(-1);
    }

    void MakeSingleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void GenerateChoices(int index)
    {
        GameObject prefab = transform.GetChild(0).gameObject;
        GameObject obj;

        //print(MenuManager.CurrentLevel);

        if (index == -1 && MenuManager.CurrentLevel == -1) return;
        if (index == -1) index = MenuManager.CurrentLevel;

        print("Create level: " +  index);

        for (int i = 0; i < Level.levels[index].no_of_choices_list.Count; i++)
        {
            obj = Instantiate(prefab, transform);
            obj.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text =
                Level.levels[index].no_of_choices_list[i];

            obj.GetComponent<Button>().AddEventListener(i, ItemClicked);
        }

        Destroy(prefab);
    }

    void ItemClicked(int itemIndex)
    {
        GameManager._choice_clicked = true;
    }
}
