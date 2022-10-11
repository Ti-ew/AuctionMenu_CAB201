
using AuctionStartMenu;
using System.Text.RegularExpressions;
using static System.Console;


public class SignIn
{
    public static string email;
    string password;
    public static string username;

    public void userSignIn()
    {
        WriteLine("\nSign In");
        WriteLine("----------");

        WriteLine("\nPlease enter your email address.");
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

    public void checkIfEmailLoginExists(string Email)
    {
        Email = ReadLine();

        bool condition = false;
        if (File.Exists("userDB.txt"))
        {

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

            }
            if (condition == false)
            {
                WriteLine("\nNo email of that type was found");
                WriteLine("\nPlease enter your email address.");

                checkIfEmailLoginExists(Email);
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
    public static string Name;
    public static string userPass;
    public static string userEmail;


    //string curDir = Directory.GetCurrentDirectory();//Get current directory
    public void userSignUp()//User sign up method
    {

        //Create a .txt file named userDB. If the param is not set to true then the .txt file is overwritten each run



        WriteLine("\nRegistration");
        WriteLine("----------");
        WriteLine("\nPlease enter your name.");//Ask user for name
        Name = ReadLine();//Store in var 'Name'        
        WriteLine("\nPlease enter your email address.");
        checkIfEmailExists(userEmail);//Here will go conditional statements to check if email is already in use
        WriteLine("\nPlease enter your password.");
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
        string patternPass = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";
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
        }
        if (!IsValidEmail(Email))
        {

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
            Console.WriteLine("Email already in use");
            checkIfEmailExists(userEmail);
        }
        if (condition == false)
        {

            Console.WriteLine("\nValid Email");
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
    class FrontPage
    {
        string addy;
        string unitNum;


        static void lineChanger(string newText, string fileName, int line_to_edit)
        {
            string[] arrLine = File.ReadAllLines(fileName);
            arrLine[line_to_edit - 1] = newText;
            File.WriteAllLines(fileName, arrLine);
        }

        public void Start()
        {
            string[] words = File.ReadAllLines("userDB.txt");
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] == SignIn.email && words[i + 2] == "")
                {
                    WriteLine("\nPersonal Details for {0}({1}).", SignIn.username, SignIn.email);
                    WriteLine("------------------------------------\n");
                    WriteLine("Please provide your home address");
                    while (true)
                    {

                        Console.WriteLine("Unit number  (0 = none):");
                        var input = Console.ReadLine();


                        if (int.TryParse(input, out var value) && value > 0)
                        {
                            addy += input + " ";
                            break;
                        }
                        if (int.TryParse(input, out var bruh) && bruh == 0)
                        {

                            break;
                        }
                        else
                        {
                            Console.WriteLine("     Unit number must be a non-negative integer.\n");
                        }
                    }


                    while (true)
                    {

                        WriteLine("Street number:");
                        var streetNum = Console.ReadLine();

                        if (int.TryParse(streetNum, out var value) && 0 < value)
                        {
                            addy += streetNum + " ";
                            break;
                        }
                        else
                        {
                            Console.WriteLine("     Street number must be a positive integer.\n");
                        }
                    }

                    WriteLine("Street name:");
                    string streetName = Console.ReadLine();
                    addy += streetName + " ";

                    WriteLine("Street suffix:");
                    string streetSuffix = Console.ReadLine();


                    addy += streetSuffix + ", ";

                    WriteLine("City:");
                    string city = Console.ReadLine();
                    addy += city + " ";

                    string[] values = { "ACT", "act", "NSW", "nsw", "NT", "nt", "QLD", "qld", "SA", "sa", "TAS", "tas", "VIC", "vic", "WA", "wa" };
                    string emptyString = "";
                    string state;
                    while (true)
                    {
                        WriteLine("State (ACT, NSW, NT, QLD, SA, TAS, VIC, WA):");
                        state = Console.ReadLine();

                        if (values.Contains(state))
                        {
                            addy += state + " ";
                            break;
                        }
                        else
                        {
                            Console.WriteLine("     Select a state from the following\n");
                        }
                    }
                    while (true)
                    {

                        Console.WriteLine("Postcode  (1000 - 9999):");
                        var postcode = Console.ReadLine();


                        if (int.TryParse(postcode, out var value) && value >= 1000 && value <= 9999)
                        {
                            addy += postcode + " ";
                            break;
                        }
                        else
                        {
                            Console.WriteLine("     Invalid postcode.\n");
                        }
                    }
                    TextWriter add = new StreamWriter("userDB.txt", true);
                    //Write string variable to
                    add.Close();
                    lineChanger(addy, "userDB.txt", i + 3);


                    WriteLine("Address has been updated to {0}", addy);


                    break;
                }


            }
            //Goto user home page

            string[] options = { "{1} Advertise Product", "{2} View My Product List", "{3} Search For Advertised Products", "{4} View Bids On My Products", "{5} View My Purchased Items", "{6} Log Off" };
            string prompt = @"

  /$$$$$$  /$$ /$$                       /$$           /$$      /$$                              
 /$$__  $$| $$|__/                      | $$          | $$$    /$$$                              
| $$  \__/| $$ /$$  /$$$$$$  /$$$$$$$  /$$$$$$        | $$$$  /$$$$  /$$$$$$  /$$$$$$$  /$$   /$$
| $$      | $$| $$ /$$__  $$| $$__  $$|_  $$_/        | $$ $$/$$ $$ /$$__  $$| $$__  $$| $$  | $$
| $$      | $$| $$| $$$$$$$$| $$  \ $$  | $$          | $$  $$$| $$| $$$$$$$$| $$  \ $$| $$  | $$
| $$    $$| $$| $$| $$_____/| $$  | $$  | $$ /$$      | $$\  $ | $$| $$_____/| $$  | $$| $$  | $$
|  $$$$$$/| $$| $$|  $$$$$$$| $$  | $$  |  $$$$/      | $$ \/  | $$|  $$$$$$$| $$  | $$|  $$$$$$/
 \______/ |__/|__/ \_______/|__/  |__/   \___/        |__/     |__/ \_______/|__/  |__/ \______/ 
                                                                                                 
                                                                                                 
                                                                                                 

";
            Menu mainMenu = new Menu(prompt, options);
            string[] validValues = new string[] { "1", "2", "3", "4", "5", "6" };
            string myString = "";
            Auction auction = new Auction();
            mainMenu.Display();
            while (!validValues.Any(myString.Equals))
                myString = ReadLine();
            if (myString == validValues[0])
            {
                //Advertise class
            }
            if (myString == validValues[1])
            {

                //View Product class

            }
            if (myString == validValues[2])
            {

                //View bids on own product

            }
            if (myString == validValues[3])
            {

                //View Product class

            }
            if (myString == validValues[4])
            {

                //View Purchased items

            }
            if (myString == validValues[5])
            {
                auction.Start();
            }

        }
    }
}
namespace Program
{
    class Begin
    {
        static void Main(string[] args)
        {
            FrontPage frontPage = new FrontPage();
            Auction auction = new Auction();
            auction.Start();
            //Other page Start functions here
            frontPage.Start();

        }
    }
}