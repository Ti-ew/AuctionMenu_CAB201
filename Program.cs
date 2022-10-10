﻿
using AuctionStartMenu;
using System;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text.RegularExpressions;
using static System.Console;
using System.ComponentModel.DataAnnotations;

public class SignIn
{
    string email;
    string password;
    bool emailConfirm = false;
    public void userSignIn()
    {
        WriteLine("\nSign In");
        WriteLine("----------");

        WriteLine("\nPlease enter your email address.");
        checkIfEmailExists(email);

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
            if (words[i] == ("Password: " + Pass) && words[i - 1] == ("Email: " + email))
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
            WriteLine("\n...Successful Login");
            int milliseconds = 1000;
            Thread.Sleep(milliseconds);

        }
        if (condition == false)
        {
            WriteLine("\nIncorrect password for given email\n");
            WriteLine("Please enter your password");
            checkIfPassExists(Pass);
        }

        //Some while loop that will print errors and re read user input until good password or username is found 
    }

    public void checkIfEmailExists(string Email)
    {
        Email = ReadLine();
        email = Email;
        bool condition = false;
        if (File.Exists("userDB.txt"))
        {

            string[] words = File.ReadAllLines("userDB.txt");
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] == ("Email: " + Email))
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
                emailConfirm = true;
            }
            if (condition == false)
            {
                WriteLine("\nNo email of that type was found");
                WriteLine("\nPlease enter your email address.");

                checkIfEmailExists(Email);
            }

            //Some while loop that will print errors and re read user input until good password or username is found 
        }

        else if (!File.Exists("userDB.txt"))
        {
            Console.WriteLine("\nNo database .txt file, try signing up first");
            Thread.Sleep(1000);
            Auction auction = new Auction();
            auction.Start();
        }



    }

}

public class Registration
{
    string Name;
    string userPass;
    string userEmail;


    //string curDir = Directory.GetCurrentDirectory();//Get current directory
    public void userSignUp()//User sign up method
    {
        using (TextWriter db = new StreamWriter("userDB.txt", true))
        //Create a .txt file named userDB. If the param is not set to true then the .txt file is overwritten each run
        {
            WriteLine("\nRegistration");
            WriteLine("----------");

            WriteLine("\nPlease enter your name.");//Ask user for name
            Name = ReadLine();//Store in var 'Name'
            db.WriteLine("Name: " + Name);//Write string variable to 
            db.Close();

            WriteLine("\nPlease enter your email address.");
            checkIfEmailExists(userEmail);//Here will go conditional statements to check if email is already in use


            WriteLine("\nPlease enter your password.");
            userPass = ReadLine();
            checkPassParam(userPass);//Here will go conditional statments to tell user password doent fit criteria
            TextWriter EZ = new StreamWriter("userDB.txt", true);
            EZ.WriteLine("Password: " + userPass);
            EZ.Close();

            TextWriter YO = new StreamWriter("userDB.txt", true);
            YO.WriteLine();
            YO.Close();
            WriteLine("\nRegistration Successful!");
            int milliseconds = 1000;
            Thread.Sleep(milliseconds);

        }
    }

    public void checkPassParam(string password)
    {

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
        if (!IsValidEmail(Email))
        {
            WriteLine("Invalid Email");
            checkIfEmailExists(Email);
        }
        bool condition = false;
        string[] words = File.ReadAllLines("userDB.txt");
        for (int i = 0; i < words.Length; i++)
        {
            if (words[i].Contains("Email: " + Email) == true)
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
            Console.WriteLine("Email already in use");
            checkIfEmailExists(userEmail);
        }
        if (condition == false)
        {
            TextWriter SW = new StreamWriter("userDB.txt", true);
            SW.WriteLine("Email: " + Email);
            SW.Close();
            Console.WriteLine("Valid Email");
            return;
        }

        //Some while loop that will print errors and re read user input until good password or username is found 
    }



}


namespace AuctionUserMenu
{





}

namespace AuctionStartMenu
{
    class Auction
    {
        public void Start()
        {
            string prompt = @"

 $$$$$$\                        $$\     $$\                           $$\      $$\                               
$$  __$$\                       $$ |    \__|                          $$$\    $$$ |                              
$$ /  $$ |$$\   $$\  $$$$$$$\ $$$$$$\   $$\  $$$$$$\  $$$$$$$\        $$$$\  $$$$ | $$$$$$\  $$$$$$$\  $$\   $$\ 
$$$$$$$$ |$$ |  $$ |$$  _____|\_$$  _|  $$ |$$  __$$\ $$  __$$\       $$\$$\$$ $$ |$$  __$$\ $$  __$$\ $$ |  $$ |
$$  __$$ |$$ |  $$ |$$ /        $$ |    $$ |$$ /  $$ |$$ |  $$ |      $$ \$$$  $$ |$$$$$$$$ |$$ |  $$ |$$ |  $$ |
$$ |  $$ |$$ |  $$ |$$ |        $$ |$$\ $$ |$$ |  $$ |$$ |  $$ |      $$ |\$  /$$ |$$   ____|$$ |  $$ |$$ |  $$ |
$$ |  $$ |\$$$$$$  |\$$$$$$$\   \$$$$  |$$ |\$$$$$$  |$$ |  $$ |      $$ | \_/ $$ |\$$$$$$$\ $$ |  $$ |\$$$$$$  |
\__|  \__| \______/  \_______|   \____/ \__| \______/ \__|  \__|      \__|     \__| \_______|\__|  \__| \______/ 
                                                                                                                 
                                                                                                                 
                                                                                                                 


Please select an option between 1 and 3";


            string[] options = { "{1} Register", "{2} Sign In", "{3} Exit" };
            Menu mainMenu = new Menu(prompt, options);
            Auction auction = new Auction();
            Registration registration = new Registration();
            SignIn signIn = new SignIn();
            mainMenu.Display();
            string[] validValues = new string[] { "1", "2", "3" };
            string myString = "";

            while (!validValues.Any(myString.Equals))
                myString = ReadLine();
            if (myString == validValues[0])
            {
                registration.userSignUp();
                auction.Start();
            }
            if (myString == validValues[1])
            {
                signIn.userSignIn();


            }
            if (myString == validValues[2])
            {
                System.Environment.Exit(1);
            }

        }
    }

    class Menu
    {
        public int SelectedIndex;
        public string[] Options;
        public string Prompt;

        public Menu(string prompt, string[] options)
        {
            Prompt = prompt;
            Options = options;
            SelectedIndex = 0;
        }

        public void Display()
        {
            WriteLine(Prompt);
            for (int i = 0; i < Options.Length; i++)
            {
                string currentOption = Options[i];
                WriteLine($"{currentOption}");
            }
        }
    }

    class Begin
    {
        static void Main(string[] args)
        {
            Auction auction = new Auction();
            auction.Start();
            //Other page Start functions here


        }
    }
}