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
        public static string prompt = "";

        //string curDir = Directory.GetCurrentDirectory();//Get current directory
        public void userSignUp()//User sign up method
        {

            //Create a .txt file named userDB. If the param is not set to true then the .txt file is overwritten each run
            if (!File.Exists("userDB.txt"))
            {
                TextWriter newTextIfNone = new StreamWriter("userDB.txt", true);
                newTextIfNone.Close();
            }



            WriteLine("\nRegistration");
            WriteLine("------------");

            //Store in var 'Name'
            IsValidName();

            WriteLine("\nPlease enter your email address");
            checkIfEmailExists(userEmail);//Here will go conditional statements to check if email is already in use

            WriteLine("\nPlease choose a password");
            checkPassParam(userPass);
            //Here will go conditional statments to tell user password doent fit criteria

            updateUserDatabase();
            WriteLine("\nClient {0}({1}) has successfully registered at the Auction House.", Name, userEmail);

            AuctionMainPage auction = new AuctionMainPage();//Includes the front menu
            auction.Start(prompt);//Includes registration menu (looped to send user back to front menu)
                                  //Exit of this first menu is done by loggin in successfully


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
            EZ.WriteLine("");
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
            Write("> ");
            password = ReadLine();
            userPass = password;
            bool state;
            string patternPass = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!\]\[\|().=+\\?,_*~;`@;/""^\-'#<>}{:%*?&])[A-Za-z\d@$!\]\[\|().=+\\?,_*~;`@;/""^\-'#<>}{:%*?&]{8,}$";
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
        public void IsValidName()
        {

            while (true)
            {
                WriteLine("\nPlease enter your name");//Ask user for name
                Write("> ");
                Name = ReadLine();
                if (!Name.Contains("@"))
                {
                    break;
                }

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
            Write("> ");
            Email = ReadLine();
            userEmail = Email;
            if (!IsValidEmail(Email))
            {

                WriteLine("Invalid Email");
                checkIfEmailExists(Email);
                return;
            }
            bool condition = false;
            string[] databaseFile = File.ReadAllLines("userDB.txt");
            for (int i = 0; i < databaseFile.Length; i++)
            {
                if (databaseFile[i].Contains(Email) == true)
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
