using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level
{
    //public static int levels_count = 0;
    public string level_name;
    //public string level_creation_mode;
    //public int level_parts;
    public Sprite level_image;
    public int no_of_choices;
    public List<string> no_of_choices_list;
    public string RightChoice;
    /*public bool External_animation;
    public Sprite Good_Anim;
    public Sprite Bad_Anim;
    public bool Default_Anim;*/
    public static List<Level> levels = new List<Level>();

    public Level()
    {
        no_of_choices_list = new List<string>();
    }

    public Level(string name, int number_choices,
    Sprite imageSprites, string[] choices, int idx_of_right_choice)
    {
        level_name = name;
        //level_creation_mode = mode;
        //level_parts = parts;
        no_of_choices = number_choices;
        RightChoice = choices[idx_of_right_choice];
        //External_animation = externalAnim;
        //Default_Anim = defaultAnim;
        level_image = imageSprites;
        no_of_choices_list = new List<string>();

        for (int i = 0; i < choices.Length; i++)
        {
            no_of_choices_list.Add(choices[i]);
        }

        /*Good_Anim = goodAnim;
        Bad_Anim = badAnim;*/

        //levels_count++;
        //levels.Add(this);
    }


    static Level()
    {
        AddDefaultLevels();
    }

    private static void AddDefaultLevels()
    {
        levels.Add(new Level(
            "I am ill", 2, Resources.Load<Sprite>("Images/level1_img1"),
            new string[] { "Give Her Water", "Give Her Medicine" }, 1
        ));

        levels.Add(new Level(
            "I broke my Arm", 3, Resources.Load<Sprite>("Images/level2_img1"),
            new string[] { "Give Him Bandage", "Touch It", "Continue Playing" }, 0
        ));

        //levels_count = levels.Count;
    }

}
