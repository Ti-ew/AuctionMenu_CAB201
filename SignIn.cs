using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace AuctionMenu
{
    public class SignIn
    {
        public static string email;
        public static string password;
        public static string username;

        public void userSignIn()
        {
            WriteLine("\nSign In");
            WriteLine("-------");


            checkIfEmailLoginExists(email);

            WriteLine("\nPlease enter your password");
            checkIfPassExists(password);

        }

        public void checkIfPassExists(string Pass)
        {
            Pass = ReadLine();
            bool condition = false;
            string[] words = File.ReadAllLines("userDB.txt");


            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] == (Pass) && words[i - 1] == (email))
                {

                    condition = true;
                    break;
                }
                else
                {
                    condition = false;
                }
            }
            if (condition == true)
            {

                return;

            }
            if (condition == false)
            {
                WriteLine("\nIncorrect password for given email\n");

                checkIfPassExists(Pass);
            }

            //Some while loop that will print errors and re read user input until good password or username is found 
        }

        public void checkIfEmailLoginExists(string Email)
        {


            bool condition = false;
            if (File.Exists("userDB.txt"))
            {
                while (true)
                {
                    WriteLine("\nPlease enter your email address");
                    Email = ReadLine();
                    string[] words = File.ReadAllLines("userDB.txt");
                    for (int i = 0; i < words.Length; i++)
                    {
                        if (words[i] == (Email))
                        {
                            username = words[i - 1];
                            email = Email;
                            condition = true;
                            break;
                        }
                        else
                        {
                            condition = false;
                        }
                    }
                    if (condition == true)
                    {
                        break;
                    }
                    if (condition == false)
                    {
                        WriteLine("\tThe supplied value is not a valid email address.");


                    }

                }


                //Some while loop that will print errors and re read user input until good password or username is found 
            }

            else if (!File.Exists("userDB.txt"))
            {
                WriteLine("\nNo database .txt file, try signing up first");
                Thread.Sleep(1000);
                AuctionMainPage auction = new AuctionMainPage();//Includes the front menu
                auction.Start(@"+------------------------------+
| Welcome to the Auction House |
+------------------------------+
");//Includes registration menu 

            }



        }

    }
}
