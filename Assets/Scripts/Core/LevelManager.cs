using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private int levels_count;
    [SerializeField] private string level_name;
    [SerializeField] private string level_creation_mode;
    [SerializeField] private int level_parts;
    [SerializeField] private List<Sprite> images;
    [SerializeField] private int no_of_choices;
    [SerializeField] private List<string> no_of_choices_list;
    [SerializeField] private string RightChoice;
    [SerializeField] private bool External_animation;
    [SerializeField] private Sprite Good_Anim;
    [SerializeField] private Sprite Bad_Anim;
    [SerializeField] private bool Default_Anim;

    void Awake()
    {
        GenerateLevels();
    }

    void GenerateLevels()
    {
        //Level.levels.Clear();

        Level newLevel = new Level
        {
            level_name = this.level_name,
            level_creation_mode = this.level_creation_mode,
            level_parts = this.level_parts,
            no_of_choices = this.no_of_choices,
            no_of_choices_list = this.no_of_choices_list,
            RightChoice = this.RightChoice,
            External_animation = this.External_animation,
            Default_Anim = this.Default_Anim,
            images = this.images
        };

        if (this.External_animation)
        {
            newLevel.Good_Anim = this.Good_Anim;
            newLevel.Bad_Anim = this.Bad_Anim;
        }

        Level.levels.Add(newLevel);
    }
}
