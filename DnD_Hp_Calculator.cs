using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.Mathematics;
using Unity.Mathematics.Geometry;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class DnD_Hp_Calculator : MonoBehaviour
{
    public string Name;
    public int Level;
    public string Class;
    public int CON_Score;
    public string Race;
    public bool Tough;
    public bool Stout;
    

    private Dictionary<string, int> Classes = new Dictionary<string, int>()  //classes 
    {
        {"Artificer",8 },
        {"Barbarian", 12 },
        {"Bard", 8 },
        {"Cleric",8 },
        {"Druid",8 },
        {"Fighter",10 },
        {"Monk",8 },
        {"Ranger",10 },
        {"Rogue",8 },
        {"Paladin",10 },
        {"Sorcerer",6 },
        {"Wizard", 6 },
        {"Warlock",8 },

    };


    private List<string> Races = new List<string>()   //races
    {
        "Aasimar",
        "Dragonborn",
        "Dwarf",
        "Elf",
        "Gnome",
        "Goliath",
        "Halfling",
        "Human",
        "Orc",
        "Tiefling",

    };
    public struct ConRange
    {
        public int min;
        public int max;
        public int modifier;
    }

    private List<ConRange> ConScores = new List<ConRange>()    //con modifiers 
{
    new ConRange { min = 1, max = 1, modifier = -5 },
    new ConRange { min = 2, max = 3, modifier = -4 },
    new ConRange { min = 4, max = 5, modifier = -3 },
    new ConRange { min = 6, max = 7, modifier = -2 },
    new ConRange { min = 8, max = 9, modifier = -1 },
    new ConRange { min = 10, max = 11, modifier = 0 },
    new ConRange { min = 12, max = 13, modifier = 1 },
    new ConRange { min = 14, max = 15, modifier = 2 },
    new ConRange { min = 16, max = 17, modifier = 3 },
    new ConRange { min = 18, max = 19, modifier = 4 },
    new ConRange { min = 20, max = 21, modifier = 5 },
    new ConRange { min = 22, max = 23, modifier = 6 },
    new ConRange { min = 24, max = 25, modifier = 7 },
    new ConRange { min = 26, max = 27, modifier = 8 },
    new ConRange { min = 28, max = 29, modifier = 9 },
    new ConRange { min = 30, max = 30, modifier = 10 },
};


    void Start()
    {
        if (Level > 20)
        {
            Debug.LogError("Level can not exceed 20 points and any calculations are inaccurate");
        }

        if (CON_Score > 30)
        {
            Debug.LogError("CON Score can not exceed 30 points and any calculations are inaccurate");
            
        }
           
            int hitDie = Classes[Class];   //random roll
            int roll = Random.Range(1, hitDie + 1);
            int conMod = CON_Score;
            

        foreach (var range in ConScores)     //con mod addition to hp 
        {
            if (CON_Score >= range.min && CON_Score <= range.max)
            {
                conMod = range.modifier;
                break;
            }
        }
        
        float maxHp = roll + Level + conMod;    //maxhp calc
            
        if (Race == "Dwarf")        //race bonuses 
        {
            maxHp = maxHp + 2;      //
        }

        if (Race == "Orc")          //
        {
            maxHp = maxHp + 1;
        }

        if (Race == "Goliath")      //
        {
            maxHp = maxHp + 1;
        }

        if (Tough)             // trait bonuses 
        {
            maxHp = maxHp + 2;
        }

        if (Stout)          //  
        {
            maxHp = maxHp + 1;
        }

        string traits = "";         //debug setting for it to display only when true 

        if (Tough)
        {
            traits += " Tough";
        }

        if (Stout)
        {
            traits += " Stout";
        }

        if (traits != "")
        {
            traits = " and has the" + traits + " trait/s.";
        }

        Debug.Log("My character " + Name + "is a level " + Level +" "+ Class + " with a CON score of " + CON_Score + " and is of " + Race +" race " + traits );
        Debug.Log("They have a Max HP of " + maxHp);
    
    
    }
   

    

}
