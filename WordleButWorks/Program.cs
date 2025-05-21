using MySqlConnector;
using System.Runtime.Serialization.Formatters;

namespace WordleButWorks
{
    internal class Program
    {
        static MySqlConnection connection = new MySqlConnection("server=77.37.35.4;uid=u381396247_Harvie;pwd=U|TIL&a8|R;database=u381396247_Harvie");
        static void Main(string[] args)

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

            Console.WriteLine(Word);
            
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
                    Response = Console.ReadLine().ToUpper();

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
                    Console.Clear();
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
