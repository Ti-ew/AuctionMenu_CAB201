using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
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
                WriteLine("Purchased items for {0}({1})", SignIn.username, SignIn.email);
                int tempUnderline = "Purchased items for {0}({1})".Length + SignIn.username.Length + SignIn.email.Length - 6;
                lineUnderliner(tempUnderline);
                // Stuff for the table, PIPE deez
                WriteLine("Item #\tSeller email\tProduct name\tDescription\tList price\tAmt paid\tDelivery Option");

                string[] ArrayOfWords = File.ReadAllLines("userDB.txt");
                for (int j = 0; j < ArrayOfWords.Length; j++)
                {

                    //Dont know how it is being formatted in text document, lets have a looky
                    //Here goes the stuff to check if it is a value or a "-"
                    if (ArrayOfWords[j] == "Purchased: " + SignIn.username)
                    {

                        for (int i = 0; i < 7; i++)
                        {
                            //Write string variable to the line under purchased so format it

                            if (ArrayOfWords[i + j] == "")
                            {
                                Console.Write("-\t");
                            }
                            else
                            {
                                Console.Write("{0}\t", ArrayOfWords[i + j]);
                            }

                            /*Purchased + {USERNAME} 
                                * Item num 
                                * Seller email 
                                * Product name
                                * Description
                                * List price
                                * Amt paid
                                * Delivery Option                             
                                * */

                        }

                    }

                }


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


                string verifiedProductPrice;
                while (true)
                {
                    WriteLine("\nProduct price ($d.cc)");
                    string productPrice = ReadLine();

                    char[] charArrproductPrice = productPrice.ToCharArray();
                    if (charArrproductPrice[0] == '$')
                    {
                        verifiedProductPrice = productPrice;
                        break;

                    }
                    WriteLine("\tA currency value is required, e.g. $54.95, $9.99, $2314.15\n");
                }

                WriteLine("\nSuccessfully added product {0}, {1}, {2}", productName, productDescription, verifiedProductPrice);
                TextWriter db = new StreamWriter("userDB.txt", true);
                db.WriteLine("For Sale:");
                db.WriteLine(SignIn.username);
                db.WriteLine("{0}", productName);//Write string variable to DB
                db.WriteLine("{0}", productDescription);//Write string variable to DB
                db.WriteLine("{0}", verifiedProductPrice);//Write string variable to DB
                db.WriteLine("");//For external bidder information
                db.WriteLine("");
                db.WriteLine("");
                db.WriteLine("");
                db.Close();
            }
            void viewProduct()
            {
                bool state = false;
                string[] CheckHimPC = File.ReadAllLines("userDB.txt");//Check is bro is broke and isnt advertising
                WriteLine("Product List for {0}({1})", SignIn.username, SignIn.email);
                string anotherUnderline = "Product List for {0}({1})";
                int lengthOfUnderline = anotherUnderline.Length + SignIn.email.Length + SignIn.username.Length - 6;
                lineUnderliner(lengthOfUnderline);
                WriteLine("\nItem #\tProduct name\tDescription\tList price\tBidder name\tBidder email\tBid amnt");
                int counter = 1;
                for (int i = 0; i < CheckHimPC.Length; i++)
                {

                    if (CheckHimPC[i] == "For Sale:" && CheckHimPC[i + 1] == SignIn.username)
                    {
                        Write(counter + "\t");
                        for (int j = 2; j < 7; j++)
                        {
                            Write(CheckHimPC[i + j] + "\t");
                        }
                        Write("\n");
                        counter++;
                    }

                }




            }
            void goShopping()
            {
                WriteLine("Product search for {0}({1})", SignIn.username, SignIn.email);
                string productSearch = "Product search for {0}({1)";
                int productSearchLen = productSearch.Length + SignIn.username.Length + SignIn.email.Length - 6;
                lineUnderliner(productSearchLen);


                string[] databaseFile = File.ReadAllLines("userDB.txt");

                while (true)
                {
                    WriteLine("\nPlease supply a search phrase (ALL to see all products)");
                    string shoppingSearch = ReadLine();
                    if (shoppingSearch == "ALL" || shoppingSearch == "all")
                    {
                        WriteLine("\nSearch results\n-------\n");
                        WriteLine("Item #\tProduct name\tDescription\tList price\tBidder name\tBidder email\tBid amnt");
                        int count = 0;

                        for (int i = 0; i < databaseFile.Length; i++)
                        {
                            if (databaseFile[i] == "For Sale:")
                            {
                                count++;
                                if (count != 0)
                                {
                                    Write(count + "\t");
                                }
                                for (int j = 2; j < 7; j++)
                                {
                                    if (databaseFile[i + j] != "")
                                    {
                                        Write("{0}\t", databaseFile[i + j]);
                                    }
                                    if (databaseFile[i + j] == "")
                                    {
                                        Write("-\t");
                                    }
                                    

                                }
                                Write("\n");
                                WriteLine("\nWould you like to place a bid on any of these items (yes or no)?");
                                string answer = ReadLine();
                                if (answer == "YES" || answer == "yes")
                                {
                                    WriteLine("Please enter a non-negative integer between 1 and {0}", count);
                                    string answer2 = ReadLine();
                                    string[] array = new string[count];
                                    for (int j = 0; j < count; j++)
                                    {
                                        array[j] = j.ToString();
                                    }
                                    if (array.Contains(answer2))
                                    {
                                        WriteLine("Bidding for {0} {1}");
                                        Write("\nHow much do you bid?");
                                        string answer3 = ReadLine();

                                        if (answer3.Contains("$"))
                                        {
                                            WriteLine("Your bid of {0} for {1} {2} is placed", answer3);
                                            WriteLine("Delivery Instructions\n-------------");
                                            WriteLine("(1) Click and collect");
                                            WriteLine("(2) Home Delivery");
                                            WriteLine("\nPlease select an option between 1 and 2");
                                            while (true)
                                            {
                                                string answer4 = ReadLine();
                                                if (answer4 == "1")
                                                {

                                                }
                                                if (answer4 == "2")
                                                {
                                                    string postalAddy = "";
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
                                                    //First barrier of correct input

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
                                                    //Second barrier of correct input

                                                    WriteLine("Street name:");
                                                    string streetName = Console.ReadLine();
                                                    postalAddy += streetName + " ";
                                                    Write("\n");
                                                    //No barrier needed

                                                    WriteLine("Street suffix:");
                                                    string streetSuffix = Console.ReadLine();
                                                    postalAddy += streetSuffix + ", ";
                                                    Write("\n");
                                                    //No barrier needed

                                                    WriteLine("City:");
                                                    string city = Console.ReadLine();
                                                    postalAddy += city + " ";
                                                    Write("\n");
                                                    //No barrier needed


                                                    string[] values = { "ACT", "act", "NSW", "nsw", "NT", "nt", "QLD", "qld", "SA", "sa", "TAS", "tas", "VIC", "vic", "WA", "wa" };
                                                    string state;
                                                    while (true)
                                                    {
                                                        WriteLine("State (ACT, NSW, NT, QLD, SA, TAS, VIC, WA):");
                                                        state = Console.ReadLine();

                                                        if (values.Contains(state))
                                                        {
                                                            postalAddy += state + " ";
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("     Select a state from the following\n");
                                                        }
                                                    }
                                                    Write("\n");
                                                    //Barrier for enetering a correct state type


                                                    while (true)
                                                    {

                                                        Console.WriteLine("Postcode  (1000 - 9999):");
                                                        var postcode = Console.ReadLine();


                                                        if (int.TryParse(postcode, out var value) && value >= 1000 && value <= 9999)
                                                        {
                                                            postalAddy += postcode + " ";
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("     Invalid postcode.\n");
                                                        }
                                                    }
                                                    Write("\n");
                                                    //Barrier for postcode

                                                    TextWriter add = new StreamWriter("userDB.txt", true);
                                                    add.Close();
                                                    lineChanger(postalAddy, "userDB.txt", i + 3);
                                                }
                                            }
                                        }


                                    }

                                }
                                else
                                {
                                    break;
                                }

                            }

                        }


                        break;
                    }
                    if (shoppingSearch == "something specific")
                    {

                    }
                }


            }
            void viewBids()
            {
                string[] checkForBid = File.ReadAllLines("userDB.txt");

            }

            string[] words = File.ReadAllLines("userDB.txt");
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i] == SignIn.email && words[i + 2] == "")//Ask for addy if not given
                {
                    //Whole bunch of while loops to continue to ask user until correct output is given

                    WriteLine("\nPersonal Details for {0}({1})", SignIn.username, SignIn.email);
                    string PersonalDetails = "Personal Details for {0}({1})";
                    int PersonalDetailsLength = (PersonalDetails.Length + SignIn.username.Length + SignIn.email.Length - 6);
                    lineUnderliner(PersonalDetailsLength);
                    WriteLine("\nPlease provide your home address.\n");
                    //Whole bunch of main menu printing logic

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
                    //First barrier of correct input

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
                    //Second barrier of correct input

                    WriteLine("Street name:");
                    string streetName = Console.ReadLine();
                    addy += streetName + " ";
                    Write("\n");
                    //No barrier needed

                    WriteLine("Street suffix:");
                    string streetSuffix = Console.ReadLine();
                    addy += streetSuffix + ", ";
                    Write("\n");
                    //No barrier needed

                    WriteLine("City:");
                    string city = Console.ReadLine();
                    addy += city + " ";
                    Write("\n");
                    //No barrier needed


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
                    //Barrier for enetering a correct state type


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
                    //Barrier for postcode

                    TextWriter add = new StreamWriter("userDB.txt", true);
                    add.Close();
                    lineChanger(addy, "userDB.txt", i + 3);
                    WriteLine("Address has been updated to {0}", addy);
                    //Updating .txt file


                    break;//break the for loop
                }
                //If no addy is needed

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

                    //Time to go shopping brah!
                    goShopping();

                }
                if (mystring == validvalues[3])
                {
                    //view bids on own product
                    viewBids();


                }
                if (mystring == validvalues[4])
                {

                    viewPurchased();

                }
                if (mystring == validvalues[5])
                {

                    AuctionMainPage auction = new AuctionMainPage();//Includes the front menu
                    auction.Start(@"");
                    //Includes registration menu (looped to send user back to front menu)
                    //Exit of this first menu is done by loggin in successfully
                }

            }
        }
    }
}
