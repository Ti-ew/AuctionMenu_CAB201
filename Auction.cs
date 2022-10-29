using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace AuctionMenu
{
    public class MainPage
    {
        public int count = 0;
        public void Start(string prompt)
        {
            WriteLine(prompt);

            string[] options = { "(1) Register", "(2) Sign In", "(3) Exit" };
            WriteLine("Main Menu\r\n---------");
            for (int i = 0; i < options.Length; i++)
            {
                string currentOption = options[i];
                WriteLine($"{currentOption}");
            }
            string[] validValues = new string[] { "1", "2", "3" };
            string myString = "";
            WriteLine("\nPlease select an option between 1 and 3");

            while (true)
            {
                Write("> ");
                myString = ReadLine();
                if (myString == validValues[0])
                {
                    Registration registration = new Registration();
                    registration.userSignUp();
                    break;


                }

                if (myString == validValues[1])
                {

                    SignIn signIn = new SignIn();
                    signIn.userSignIn();
                    break;

                }
                if (myString == validValues[2])
                {
                    WriteLine("+--------------------------------------------------+\r\n| Good bye, thank you for using the Auction House! |\r\n+--------------------------------------------------+");
                    System.Environment.Exit(1);
                }


            }
        }
    }
}