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
		bool flag = true;
		public void userSignIn()
        {
			
            WriteLine("\nSign In");
            WriteLine("-------");

            flag = checkIfDBExists(flag);
            if (flag == false)
            {
                return;
            }

            checkIfEmailLoginExists(email);



            checkIfPassExists(password);

        }

        public bool checkIfDBExists(bool flag)
        {
            if (!File.Exists("userDB.txt"))
            {
                flag = false;                
                WriteLine("\nNo database .txt file, try signing up first\n");
                return flag;
            }
            return flag;
        }

        public void checkIfPassExists(string Pass)
        {
            while (true)
            {
                WriteLine("\nPlease enter your password");
                Write("> ");
                password = ReadLine();
                bool condition = false;
                string[] databaseFile = File.ReadAllLines("userDB.txt");


                for (int i = 0; i < databaseFile.Length; i++)
                {
                    if (databaseFile[i] == (password) && databaseFile[i - 1] == (email))
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
                break;
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
                    Write("> ");
                    Email = ReadLine();
                    string[] databaseFile = File.ReadAllLines("userDB.txt");
                    for (int i = 0; i < databaseFile.Length; i++)
                    {
                        if (databaseFile[i] == (Email))
                        {
                            if (!Email.Contains("@"))
                            {
                                break;
                            }
                            username = databaseFile[i - 1];
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





        }

    }
}
