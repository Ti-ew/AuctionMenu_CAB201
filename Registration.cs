using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Console;

namespace AuctionMenu
{
    public class Registration
    {
        public static string Name;
        public static string userPass;
        public static string userEmail;


        //string curDir = Directory.GetCurrentDirectory();//Get current directory
        public void userSignUp()//User sign up method
        {

            //Create a .txt file named userDB. If the param is not set to true then the .txt file is overwritten each run



            WriteLine("\nRegistration");
            WriteLine("------------");
            WriteLine("\nPlease enter your name");//Ask user for name
            Name = ReadLine();//Store in var 'Name'        
            WriteLine("\nPlease enter your email address");
            checkIfEmailExists(userEmail);//Here will go conditional statements to check if email is already in use
            WriteLine("\nPlease choose a password");
            checkPassParam(userPass);
            //Here will go conditional statments to tell user password doent fit criteria

            updateUserDatabase();
            WriteLine("\nClient {0}({1}) has successfully registered at the Auction House.", Name, userEmail);
            int milliseconds = 1000;
            Thread.Sleep(milliseconds);


        }

        public void updateUserDatabase()
        {
            TextWriter db = new StreamWriter("userDB.txt", true);
            db.WriteLine(Name);//Write string variable to
            db.Close();
            TextWriter SW = new StreamWriter("userDB.txt", true);
            SW.WriteLine(userEmail);
            SW.Close();

            TextWriter EZ = new StreamWriter("userDB.txt", true);
            EZ.WriteLine(userPass);
            EZ.WriteLine();
            EZ.Close();
        }

        public void checkPassParam(string password)
        {
            WriteLine("* At least 8 characters");
            WriteLine("* No whitespace characters");
            WriteLine("* At least one uppercase letter");
            WriteLine("* At least one lowercase letter");
            WriteLine("* At least one digit");
            WriteLine("* At least one special character");
            password = ReadLine();
            userPass = password;
            bool state;
            string patternPass = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!\]\[\(\):%*?&])[A-Za-z\d@$!\]\[\(\):%*?&]{8,}$";
            var regexPass = new Regex(patternPass, RegexOptions.IgnoreCase);
            state = regexPass.IsMatch(password);
            if (state == true)
            {
                return;
            }
            if (state == false)
            {
                WriteLine("      The supplied value is not a valid password");
                Thread.Sleep(1000);
                checkPassParam(password);
            }
        }

        public bool IsValidEmail(string email)
        {
            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
            var regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(email);

        }

        public void checkIfEmailExists(string Email)
        {

            Email = ReadLine();
            userEmail = Email;
            if (!IsValidEmail(Email))
            {

                WriteLine("Invalid Email");
                checkIfEmailExists(Email);
                return;
            }
            bool condition = false;
            string[] words = File.ReadAllLines("userDB.txt");
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Contains(Email) == true)
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
                Console.WriteLine("\n       Email already in use");
                checkIfEmailExists(userEmail);
                return;
            }
            if (condition == false)
            {


                return;

            }

            //Some while loop that will print errors and re read user input until good password or username is found 
        }



    }
}
