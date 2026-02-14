using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using Random = UnityEngine.Random;


public class Dnd_Health_2 : MonoBehaviour
{
    public string Name;
    public int Level;
    public string Class;
    public int CON_Score;
    public string Race;
    public bool Tough;
    public bool Stout;
    
    abstract class Classes                  //classes die hit 
    {
        public abstract int DieRoll();
    }

    class Artificier : Classes
    {
        public override int DieRoll()
        {
            return Random.Range(1, 9);   // d8 
        }
    }

    class Barbarian : Classes
    {
        public override int DieRoll()
        {
            return Random.Range(1, 13);  // d12 
        }
    }

    class Bard : Classes
    {
        public override int DieRoll()
        {
            return Random.Range(1, 9);   // d8 
        }
    }
    class Cleric : Classes
    {
        public override int DieRoll()
        {
            return Random.Range(1, 9);     //d8
        }
    }
    class Druid : Classes
    {
        public override int DieRoll()
        {
            return Random.Range(1, 9);      //d8
        }
    }
    class Fighter : Classes
    {
        public override int DieRoll()
        {
            return Random.Range(1, 11);     //d10
        }
    }
    class Monk : Classes
    {
        public override int DieRoll()
        {
            return Random.Range(1, 9);      //d8
        }
    }
    class Ranger : Classes
    {
        public override int DieRoll()
        {
            return Random.Range(1, 11);     //d10
        }
    }
    class Rogue : Classes
    {
        public override int DieRoll()
        {
            return Random.Range(1, 9);      //d8
        }
    }
    class Paladin : Classes
    {
        public override int DieRoll()
        {
            return Random.Range(1, 11);     //d10
        }
    }
    class Sorcerer : Classes
    {
        public override int DieRoll()
        {
            return Random.Range(1, 7);      //d6
        }
    }
    class Wizard : Classes
    {
        public override int DieRoll()
        {
            return Random.Range(1, 7);      //d6
        }
    }
    class Warlock : Classes
    {
        public override int DieRoll()
        {
            return Random.Range(1, 9);      //d8
        }
    }


    public struct Con        //CON Score 
    {
        public int score;

        private static readonly (int min, int max, int mod)[] table =
        {
            (1, 1, -5),
            (2, 3, -4),
            (4, 5, -3),
            (6, 7, -2),
            (8, 9, -1),
            (10, 11, 0),
            (12, 13, 1),
            (14, 15, 2),
            (16, 17, 3),
            (18, 19, 4),
            (20, 21, 5),
            (22, 23, 6),
            (24, 25, 7),
            (26, 27, 8),
            (28, 29, 9),
            (30, 30, 10)
        };

        public int Modifier
        {
            get
            {
                foreach (var entry in table)
                {
                    if (score >= entry.min && score <= entry.max)
                        return entry.mod;
                }

                Debug.LogError("CON score must be between 1 and 30.");
                return 0;
            }
        }
     }


    abstract class Races                                //races 
    {
        public abstract int Bonus();
    }
    class Aasimar : Races
    {
        public override int Bonus()
        {
            return 0;
        }
    }
    class Dragonborn : Races
    {
        public override int Bonus()
        {
            return 0;
        }
    }
    class Dwarf : Races
    {
        public override int Bonus()
        {
            return 2;
        }
    }
    class Elf : Races
    {
        public override int Bonus()
        {
            return 0;
        }
    }
    class Gnome : Races
    {
        public override int Bonus()
        {
            return 0;
        }
    }
    class Goliath : Races
    {
        public override int Bonus()
        {
            return 1;
        }
    }
    class Halfling : Races
    {
        public override int Bonus()
        {
            return 0;
        }
    }
    class Human : Races
    {
        public override int Bonus()
        {
            return 0;
        }
    }
    class Orc : Races
    {
        public override int Bonus()
        {
            return 1;
        }
    }
    class Tiefling : Races
    {
        public override int Bonus()
        {
            return 0;
        }
    }
        
        private void Start()
    {
        Classes selectedClass = null;

        if (Class.ToLower() == "artificier")            //instantiate class upon typed in inspector 
        {
            selectedClass = new Artificier();
        }
        else if (Class.ToLower() == "barbarian")
        {
            selectedClass = new Barbarian();
        }
        else if (Class.ToLower() == "bard")
        {
            selectedClass = new Bard();
        }
        else if (Class.ToLower() == "cleric")
        {
            selectedClass = new Cleric();       
        }
        else if (Class.ToLower() == "druid")
        {
            selectedClass = new Druid();
        }
        else if (Class.ToLower() == "fighter")
        {
            selectedClass = new Fighter();
        }
        else if (Class.ToLower() == "monk")
        {
            selectedClass = new Monk();
        }
        else if (Class.ToLower() == "ranger")
        {
            selectedClass = new Ranger();
        }
        else if (Class.ToLower() == "rogue")
        {
            selectedClass = new Rogue ();
        }
        else if (Class.ToLower() == "paladin")
        {
            selectedClass = new Paladin();
        }
        else if (Class.ToLower() == "sorcerer")
        {
            selectedClass = new Sorcerer();
        }
        else if (Class.ToLower() == "wizard")
        {
            selectedClass = new Wizard();
        }
        else if (Class.ToLower() == "warlock")
        {
            selectedClass = new Warlock();
        }
        else 
        {
            Debug.LogError("Invalid class name.");
            return;
        }
        
        
        
        Races selectedRace = null;          //instantiate race upon called in inspector

        if (Race.ToLower() == "aasimar")
        {
            selectedRace = new Aasimar();
        }
        else if (Race.ToLower() == "dragonborn")
        {
            selectedRace = new Dragonborn();
        }
        else if (Race.ToLower() == "dwarf")
        {
            selectedRace = new Dwarf();
        }
        else if (Race.ToLower() == "elf")
        {
            selectedRace = new Elf();
        }
        else if (Race.ToLower() == "gnome")
        {
            selectedRace = new Gnome();
        }
        else if (Race.ToLower() == "goliath")
        {
            selectedRace = new Goliath();
        }
        else if (Race.ToLower() == "halfling")
        {
            selectedRace = new Halfling();
        }
        else if (Race.ToLower() == "human")
        {
            selectedRace = new Human();
        }
        else if (Race.ToLower() == "orc")
        {
            selectedRace = new Orc();
        }
        else if (Race.ToLower() == "tiefling")
        {
            selectedRace = new Tiefling();
        }
        else
        {
            Debug.LogError("Invalid Race selected");
            return;
        }


        int level = Level;
        int bonus = selectedRace.Bonus();
        int roll = selectedClass.DieRoll();

        Con con;
        con.score = CON_Score;
        int conMod = con.Modifier;
        
        int maxHp = level + bonus + roll + conMod;             //max hp method 
        
        if (Tough)                          //trait bonuses 
        {
            maxHp = maxHp + 2;
        }

        if (Stout)
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



        Debug.Log("My character "+ Name + "is a level "+ Level +" "+ Class +" with a CON score of "+ CON_Score + " and is of "+ Race +  traits);
        Debug.Log(Name + "has a max hp of " + maxHp);
    
    
    
    
    }
        
    














}
   

     




 