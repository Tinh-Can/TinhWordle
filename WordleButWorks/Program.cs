using MySqlConnector;
using System.Runtime.Serialization.Formatters;
using System;

namespace WordleButWorks
{
    internal class Program
    {
        static MySqlConnection connection = new MySqlConnection("server=77.37.35.4;uid=u381396247_Harvie;pwd=U|TIL&a8|R;database=u381396247_Harvie");
        static void Main(string[] args)

        {
            void ClearConsoleLine(int line)
            {
                line = line - 1;
                int currentLineCursor = Console.CursorTop;
                Console.SetCursorPosition(0, line);
                Console.Write(new string(' ', Console.BufferWidth)); // Use BufferWidth, not WindowWidth
                Console.SetCursorPosition(0, currentLineCursor);
            }

            void DeleteLastConsoleLine()
            {
                if (Console.CursorTop == 0)
                {
                    return; // Don't go above line 0 or you'll summon a segmentation fault from the void
                }
                int previousLine = Console.CursorTop - 1;
                Console.SetCursorPosition(0, previousLine);
                Console.Write(new string(' ', Console.BufferWidth)); // Overwrite with spaces
                Console.SetCursorPosition(0, previousLine); // Move cursor to where the deleted line was
            }

            int won = 0;

            bool play = true;

            while (play == true)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;

                Random random = new Random();

                MySqlCommand wordCount = new MySqlCommand();
                string wordCountString = $"SELECT COUNT(*) FROM WordData";
                wordCount.Connection = connection;
                wordCount.CommandText = wordCountString;
                connection.Open();
                MySqlDataReader reader = wordCount.ExecuteReader();
                reader.Read();
                int count = reader.GetInt32(0);
                connection.Close();

                int RandomInt = random.Next(0, count);

                MySqlCommand getWords = new MySqlCommand();
                string getWordsString = $"SELECT `word` FROM WordData WHERE `wordID` = {RandomInt}";
                getWords.Connection = connection;
                getWords.CommandText = getWordsString;
                connection.Open();
                reader = getWords.ExecuteReader();
                reader.Read();
                string Word = reader.GetString(0);
                connection.Close();



                bool found = false;
                int i = 1;

                //Console.WriteLine(Word);

                //Word = "array";

                Console.Clear();
                Console.WriteLine("Welcome to Wordle! Please enter anything to continue.");
                Console.ReadLine();
                Console.Clear();

                int repeater = 1;

                while ((found == false) && (i <= 6))
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
                        Response = Console.ReadLine().ToUpper();
                        DeleteLastConsoleLine();
                        DeleteLastConsoleLine();


                        if (Response.Length == 5)
                        {
                            valid = true;
                        }
                        else
                        {
                            Console.WriteLine("Invalid Input. Please wait a few seconds.");
                            Thread.Sleep(1000);
                            DeleteLastConsoleLine();
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
                                }
                                else
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
                    }
                    //else
                    //{
                        
                        for (int l = 0; l < 5; l++)
                        {
                            if (Acorrect[l] == "G")
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write(Response[l]);
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                            }
                            else if (Aplace[l] == "G")
                            {
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                Console.Write(Response[l]);
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                Console.Write(Response[l]);
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                            }
                        }
                    //}

                    Console.WriteLine(" ");
                    i++;
                }

                if (found == true)
                {

                    Console.ForegroundColor = ConsoleColor.White;
                    //Console.Clear();
                    Console.WriteLine($"You win! The correct word was: {Word}");
                    won++;
                    Console.WriteLine($"You have won a total of {won} games.");
                    Console.WriteLine("Would you like to play again? Input 'Y' for yes, or type any other key for no.");
                    string PlayAgain = Console.ReadLine();
                    if (PlayAgain != "Y")
                    {
                        play = false;
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    //Console.Clear();
                    Console.WriteLine($"You have run out of guesses! The correct word was: {Word}");
                    Console.WriteLine($"You have won a total of {won} games.");
                    Console.WriteLine("Would you like to play again? Input 'Y' for yes, or type any other key for no.");
                    string PlayAgain = Console.ReadLine();
                    if (PlayAgain != "Y")
                    {
                        play = false;
                    }
                }
            }

        }
    }
}
