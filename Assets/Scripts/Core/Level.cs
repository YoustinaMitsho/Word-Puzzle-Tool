using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level
{
    public string level_name;
    public string level_creation_mode;
    public int level_parts;
    public List<Image> images;
    public int no_of_choices;
    public List<string> no_of_choices_list;
    public bool External_animation;
    public Image Good_Anim;
    public Image Bad_Anim;
    public bool Default_Anim;
    public static List<Level> levels;
}
