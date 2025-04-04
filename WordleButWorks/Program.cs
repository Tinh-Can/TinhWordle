using System.Runtime.Serialization.Formatters;

namespace WordleButWorks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            string[] Words = {"apple", "brave", "chair", "dream", "eagle", "frost", "grape", "happy", "ideal", "joker",
            "karma", "lunar", "magic", "noble", "ocean", "piano", "quiet", "raven", "solar", "tiger",
            "ultra", "vivid", "waste", "xenon", "yacht", "zebra", "beach", "cloud", "drink", "early",
            "fancy", "giant", "house", "input", "jolly", "kneel", "light", "mango", "novel", "orbit",
            "peace", "quick", "robot", "sandy", "table", "unity", "value", "watch", "xerox", "youth",
            "zesty", "amber", "brisk", "crisp", "dance", "eager", "flame", "glove", "honey", "icing",
            "jumbo", "knock", "lemon", "mirth", "nylon", "olive", "penny", "quirk", "roast", "spend",
            "tulip", "usage", "vowel", "wrist", "xylan", "yield", "zonal", "admin", "blend", "charm",
            "doubt", "event", "frost", "grasp", "honor", "image", "joint", "knees", "logic", "marry",
            "notch", "overt", "plumb", "quest", "relay", "shout", "truce", "umbra", "verge", "widen",
            "xenon", "young", "zebra", "acorn", "board", "crown", "dwell", "exalt", "flock", "gloom",
            "hatch", "ivory", "jumpy", "kneel", "leech", "motto", "nerdy", "onion", "plaza", "quirk",
            "risky", "scarf", "torso", "usher", "venue", "whale", "xenon", "yearn", "zonal", "amuse",
            "brisk", "chose", "drape", "elbow", "flick", "grind", "hover", "ingot", "jewel", "kiosk",
            "layer", "mirth", "nudge", "ounce", "pride", "quilt", "rover", "siren", "track", "upset",
            "vixen", "waver", "xylem", "youth", "zesty", "azure", "brass", "cider", "ditch", "error",
            "feast", "glory", "haste", "irony", "juice", "koala", "latch", "mango", "niece", "orbit",
            "plush", "quart", "rifle", "sloth", "torch", "umbra", "vivid", "witty", "xenon", "yeast",
            "zonal", "angel", "bloom", "crane", "dizzy", "equip", "flute", "gravy", "hound", "input",
            "jolly", "kneel", "lemon", "mirth", "nylon", "olive", "penny", "quirk", "roast", "spend",
            "tulip", "usage", "vowel", "wrist", "xylan", "yield", "zonal", "admin", "blend", "charm",
            "raven", "steed", "trust", "upend", "vigor", "wreak", "xeric", "yogic", "zebra", "brood",
            "chaos", "drown", "evade", "flint", "grasp", "harsh", "index", "joust", "knack", "leaky",
            "merit", "noble", "oasis", "prank", "quash", "risky", "slope", "truly", "ulcer", "vault",
            "wharf", "xenon", "yeast", "zonal", "afoul", "birch", "cloud", "dozen", "equip", "fjord",
            "giddy", "hence", "inlay", "jolly", "knurl", "lucid", "mirth", "north", "oxide", "proud",
            "quill", "rifle", "scorn", "tryst", "under", "vexed", "wryly", "xenon", "yacht", "zebra"};

            int RandomInt = random.Next(0, 99);
            bool found = false;
            string Word = Words[RandomInt];
            int i = 1;
            //Word = "array";
            

            Console.WriteLine("Welcome to Wordle! Please guess our random 5 letter word. If you guessed a letter correctly and it is in the right place, a 'G' will appear under it. If it is correct, but it is in the wrong place an 'A' will appear under it. Otherwise, there will be an X.");

            while ((found == false)&&(i<=6))
            {
                int place = 0;
                int correct = 0;
                string[] Aplace = { " ", " ", " ", " ", " " };
                string[] Acorrect = { " ", " ", " ", " ", " " };
                bool valid = false;
                string Response = "     ";

                while ((valid == false))
                {
                    Console.WriteLine($"Please enter guess number {i}");
                    Response = Console.ReadLine().ToLower();

                    if (Response.Length == 5)
                    {
                        valid = true;
                    } else
                    {
                        Console.WriteLine("Invalid Input. 5 Letters Please");
                    }
                }

                for (int j = 0; j < 5; j++)
                {
                    for (int k = 0; k < 5; k++)
                    {
                        if (Word[j] == Response[k])
                        {
                            if (j == k)
                            {
                                correct++;
                                Acorrect[k] = "G";
                            } else
                            {
                                place++;
                                Aplace[k] = "G";
                            }
                        }
                    }
                }

                if (correct == 5)
                {
                    found = true;
                } else
                {
                    //Console.WriteLine(" ");
                    for (int l = 0; l< 5; l++)
                    {
                        if (Acorrect[l] == "G")
                        {
                            Console.Write("G");
                        } else if (Aplace[l] == "G") 
                        {
                            Console.Write("A");
                        } else
                        {
                            Console.Write("X");
                        }
                    }
                }

                Console.WriteLine(" ");
                i++;
            }

            if (found == true)
            {
                Console.WriteLine($"You win! The correct word was: {Word}");
            }
            else
            {
                Console.WriteLine($"You have run out of guesses! The correct word was: {Word}");
            }

        }
    }
}
