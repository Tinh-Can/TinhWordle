using System.Runtime.Serialization.Formatters;

namespace WordleButWorks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            string[] Words = { };

            int RandomInt = random.Next(0, 99);
            bool found = false;
            //string Word = Words[RandomInt];
            int i = 1;
            string Word = "array";
            

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
