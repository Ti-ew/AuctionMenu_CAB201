using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace AuctionMenu
{
    public class FrontPage
    {
        string addy;



        static void lineChanger(string newText, string fileName, int line_to_edit)
        {
            string[] arrLine = File.ReadAllLines(fileName);
            arrLine[line_to_edit - 1] = newText;
            File.WriteAllLines(fileName, arrLine);
        }

        static void lineUnderliner(int stringLength)
        {
            for (int i = 0; i < stringLength; i++)
            {
                Write("-");

            }
            Write("\n");
        }

        public void Start()
        {
            void viewPurchased()
            {

            }
            void advertiseProduct()
            {
                WriteLine("\nProduct Advertisement for {0}({1})", SignIn.username, SignIn.email);
                string productAdString = "Product Advertisement for {0}({1})";
                int LineLength = productAdString.Length + SignIn.username.Length + SignIn.email.Length - 6;
                lineUnderliner(LineLength);



                WriteLine("Product name");
                string productName = ReadLine();




                WriteLine("\nProduct description");
                string productDescription = ReadLine();


                string VerifiedProductPrice;
                while (true)
                {
                    WriteLine("\nProduct price ($d.cc)");
                    string productPrice = ReadLine();

                    char[] charArrproductPrice = productPrice.ToCharArray();
                    if (charArrproductPrice[0] == '$')
                    {
                        VerifiedProductPrice = productPrice;
                        break;

                    }
                    WriteLine("\tA currency value is required, e.g. $54.95, $9.99, $2314.15\n");
                }

                WriteLine("\nSuccessfully added product {0}, {1}, {2}", productName, productDescription, VerifiedProductPrice);
            }
            void viewProduct()
            {
                WriteLine("Stuff");
            }


            string[] words = File.ReadAllLines("userDB.txt");
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] == SignIn.email && words[i + 2] == "")
                {
                    WriteLine("\nPersonal Details for {0}({1})", SignIn.username, SignIn.email);
                    string PersonalDetails = "Personal Details for {0}({1})";
                    int PersonalDetailsLength = (PersonalDetails.Length + SignIn.username.Length + SignIn.email.Length - 6);
                    lineUnderliner(PersonalDetailsLength);
                    WriteLine("\nPlease provide your home address.\n");
                    while (true)
                    {

                        Console.WriteLine("Unit number  (0 = none):");
                        var input = Console.ReadLine();


                        if (int.TryParse(input, out var value) && value > 0)
                        {
                            addy += input + "/";
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
                    Write("\n");

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
                    Write("\n");
                    WriteLine("Street name:");
                    string streetName = Console.ReadLine();
                    addy += streetName + " ";
                    Write("\n");
                    WriteLine("Street suffix:");
                    string streetSuffix = Console.ReadLine();


                    addy += streetSuffix + ", ";
                    Write("\n");
                    WriteLine("City:");
                    string city = Console.ReadLine();
                    addy += city + " ";
                    Write("\n");
                    string[] values = { "ACT", "act", "NSW", "nsw", "NT", "nt", "QLD", "qld", "SA", "sa", "TAS", "tas", "VIC", "vic", "WA", "wa" };
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
                    Write("\n");
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
                    Write("\n");
                    TextWriter add = new StreamWriter("userDB.txt", true);
                    //Write string variable to
                    add.Close();
                    lineChanger(addy, "userDB.txt", i + 3);


                    WriteLine("Address has been updated to {0}", addy);


                    break;
                }


            }
            //goto user home page




            while (true)
            {
                string[] options = { "(1) Advertise product", "(2) View my product list", "(3) Search for advertised products", "(4) View bids on my products", "(5) View my purchased items", "(6) Log off" };
                WriteLine("\nClient Menu\r\n-----------");
                for (int i = 0; i < options.Length; i++)
                {
                    string currentOption = options[i];
                    WriteLine($"{currentOption}");
                }


                string[] validvalues = new string[] { "1", "2", "3", "4", "5", "6" };
                string mystring = "";
                mystring = ReadLine();
                if (mystring == validvalues[0])
                {
                    //advertise method
                    advertiseProduct();
                }
                if (mystring == validvalues[1])
                {

                    viewProduct();

                }
                if (mystring == validvalues[2])
                {

                    //view bids on own product

                }
                if (mystring == validvalues[3])
                {

                    //view product method

                }
                if (mystring == validvalues[4])
                {

                    viewPurchased();

                }
                if (mystring == validvalues[5])
                {
                    AuctionMainPage auction = new AuctionMainPage();//Includes the front menu
                    auction.Start(@"+------------------------------+
| Welcome to the Auction House |
+------------------------------+
");//Includes registration menu (looped to send user back to front menu)
   //Exit of this first menu is done by loggin in successfully
                }

            }
        }
    }
}
