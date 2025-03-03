using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level
{
    public static int levels_count = 0;
    public string level_name;
    public string level_creation_mode;
    public int level_parts;
    public List<Sprite> images;
    public int no_of_choices;
    public List<string> no_of_choices_list;
    public string RightChoice;
    public bool External_animation;
    public Sprite Good_Anim;
    public Sprite Bad_Anim;
    public bool Default_Anim;
    public static List<Level> levels = new List<Level>();

    public Level()
    {
        images = new List<Sprite>(new Sprite[level_parts]);
        no_of_choices_list = new List<string>(new string[no_of_choices]);

        if (External_animation)
        {
            Good_Anim = null;
            Bad_Anim = null;
        }
    }

}
