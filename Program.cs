using AuctionMenu;
using System;
using System.IO;
using System.Linq;
using static System.Console;

public class SignIn
{
    public void userSignIn()
    {
        WriteLine("\nSign In");
        WriteLine("----------");

        WriteLine("\nPlease enter your email address");
        ReadLine();

        WriteLine("\nPlease enter your password");
        ReadLine();

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

    public void checkEmailValid(string Email)
    {

    }

    public void checkIfEmailExists(string Email)
    {
        Email = ReadLine();
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
        }

        //Some while loop that will print errors and re read user input until good password or username is found 
    }



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


        }
    }
}