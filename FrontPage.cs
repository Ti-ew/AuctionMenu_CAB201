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
        string homeAddy;
        string productName;
        int secondCount = 0;
        string[] str = File.ReadAllLines("userDB.txt");

        string[] readDB(string DB)
        {
            string[] databaseFile = File.ReadAllLines(DB);
            return databaseFile;
        }
        void updateBid(string bid)
        {
            string[] databaseFile = readDB("userDB.txt");
            int lineForEditing = 0;

            for (int i = 0; i < databaseFile.Length; i++)
            {
                if (databaseFile[i] == productName)
                {
                    lineForEditing = i;
                }
            }
            lineChanger(SignIn.username, "userDB.txt", lineForEditing + 5);
            lineChanger(SignIn.email, "userDB.txt", lineForEditing + 6);
            lineChanger(bid, "userDB.txt", lineForEditing + 7);




        }
        void updateUserDBDelivery(string homeSddress)
        {
            string[] databaseFile = readDB("userDB.txt");
            for (int i = 0; i < databaseFile.Length; i++)
            {
                if (databaseFile[i] == "For Sale:" && databaseFile[i + 6] == SignIn.username && databaseFile[i + 7] == SignIn.email)
                {
                    lineChanger(homeAddy, "userDB.txt", i + 10);
                }
            }
        }

        static void lineChanger(string newText, string fileName, int line_to_edit)
        {
            string[] arrLine = File.ReadAllLines(fileName);
            arrLine[line_to_edit - 1] = newText;
            File.WriteAllLines(fileName, arrLine);
        }

        void beginSearch(string searchPhrase)
        {
            bool state = false;
            string[] databaseFile = readDB("userDB.txt");
            if (searchPhrase == "ALL" || searchPhrase == "all")
            {
                WriteLine("\nSearch results\n--------------\n");
                WriteLine("Item #\tProduct name\tDescription\tList price\tBidder name\tBidder email\tBid amnt");
                int count = 0;


                for (int i = 0; i < databaseFile.Length; i++)
                {
                    if (databaseFile[i] == "For Sale:")
                    {
                        if (!databaseFile[i + 1].Contains(SignIn.username))
                        {

                            count++;
                            if (count != 0)
                            {
                                Write(count + "\t");
                                str[secondCount] = count.ToString();

                            }


                            for (int j = 3; j < 9; j++)
                            {

                                if (databaseFile[i + j] != "")
                                {
                                    Write("{0}\t", databaseFile[i + j]);

                                    str[j - 1 + secondCount] = databaseFile[i + j];
                                }
                                if (databaseFile[i + j] == "")
                                {
                                    Write("-\t");
                                    str[j - 1 + secondCount] = "-";

                                }


                            }
                            secondCount += 8;
                            Write("\n");

                        }

                    }

                }
                if (count == 0)
                {
                    WriteLine("\nNothing for sale");
                    return;

                }

                WriteLine("\nWould you like to place a bid on any of these items (yes or no)?");
                string YesOrNoBid = ReadLine();
                if (YesOrNoBid == "yes" || YesOrNoBid == "YES")
                {
                    WriteLine("\nPlease enter a non-negative integer between 1 and {0}", count);
                    string answer4 = ReadLine();

                    for (int a = 0; a < databaseFile.Length; a++)
                    {
                        if (answer4 == str[a])
                        {
                            WriteLine("\nBidding for {0} (regular price {1}), current highest bid {2}", str[a + 1], str[a + 4], str[a + 6]);
                            WriteLine("\nHow much do you bid?");
                            string bidAmount = ReadLine();
                            productName = str[a + 1];
                            updateBid(bidAmount);
                            WriteLine("\nYour bid of {0} for {1} has been placed\n", bidAmount, productName);
                        }
                    }
                    WriteLine("\nDelivery Instructions\n---------------------");
                    Write("(1) Click and collect\n");
                    Write("(2) Home Delivery\n");

                    while (true)
                    {
                        string deliveryOption = ReadLine();
                        if (deliveryOption == "1")
                        {

                        }
                        if (deliveryOption == "2")
                        {
                            //Home delivery stuff
                            while (true)
                            {

                                Console.WriteLine("Unit number  (0 = none):");
                                var input = Console.ReadLine();


                                if (int.TryParse(input, out var value) && value > 0)
                                {
                                    homeAddy += input + "/";
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
                                    homeAddy += streetNum + " ";
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
                            homeAddy += streetName + " ";
                            Write("\n");
                            //No barrier needed

                            WriteLine("Street suffix:");
                            string streetSuffix = Console.ReadLine();
                            homeAddy += streetSuffix + ", ";
                            Write("\n");
                            //No barrier needed

                            WriteLine("City:");
                            string city = Console.ReadLine();
                            homeAddy += city + " ";
                            Write("\n");
                            //No barrier needed
                            string[] values = { "ACT", "act", "NSW", "nsw", "NT", "nt", "QLD", "qld", "SA", "sa", "TAS", "tas", "VIC", "vic", "WA", "wa" };
                            string deliveryState;
                            while (true)
                            {
                                WriteLine("State (ACT, NSW, NT, QLD, SA, TAS, VIC, WA):");
                                deliveryState = Console.ReadLine();

                                if (values.Contains(deliveryState))
                                {
                                    homeAddy += deliveryState + " ";
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
                                    homeAddy += postcode + " ";
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("     Invalid postcode.\n");
                                }
                            }
                            Write("\n");
                            //Barrier for postcode

                            WriteLine("Thank you for your bid. If successful, the item will be provided via delivery to {0}", homeAddy);
                            //update userDB with delivery address
                            updateUserDBDelivery(homeAddy);
                            break;
                        }
                    }


                }

            }
            for (int i = 0; i < databaseFile.Length; i++)
            {

                if (databaseFile[i] == "For Sale:")
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (databaseFile[j + i].Contains(searchPhrase))
                        {
                            state = true;
                            break;
                        }
                        else
                        {
                            state = false;
                        }
                    }
                    if (state == true)
                    {
                        WriteLine("\nSearch results\n--------------\n");
                        WriteLine("Item #\tProduct name\tDescription\tList price\tBidder name\tBidder email\tBid amnt");
                        int count = 0;


                        for (int b = 0; b < databaseFile.Length; b++)
                        {
                            if (databaseFile[i] == "For Sale:")
                            {
                                if (!databaseFile[i + 1].Contains(SignIn.username))
                                {

                                    count++;
                                    if (count != 0)
                                    {
                                        Write(count + "\t");
                                        str[secondCount] = count.ToString();

                                    }


                                    for (int j = 3; j < 9; j++)
                                    {

                                        if (databaseFile[i + j] != "")
                                        {
                                            Write("{0}\t", databaseFile[i + j]);

                                            str[j - 1 + secondCount] = databaseFile[i + j];
                                        }
                                        if (databaseFile[i + j] == "")
                                        {
                                            Write("-\t");
                                            str[j - 1 + secondCount] = "-";

                                        }


                                    }
                                    secondCount += 8;
                                    Write("\n");

                                    break;
                                }

                            }

                        }
                        if (count == 0)
                        {
                            WriteLine("\nNothing for sale");
                            break;
                        }

                        WriteLine("\nWould you like to place a bid on any of these items (yes or no)?");
                        string YesOrNoBid = ReadLine();
                        if (YesOrNoBid == "yes" || YesOrNoBid == "YES")
                        {
                            WriteLine("\nPlease enter a non-negative integer between 1 and {0}", count);
                            string answer4 = ReadLine();

                            for (int a = 0; a < databaseFile.Length; a++)
                            {
                                if (answer4 == str[a])
                                {
                                    WriteLine("\nBidding for {0} (regular price {1}), current highest bid {2}", str[a + 2], str[a + 4], str[a + 5]);
                                    WriteLine("\nHow much do you bid?");
                                    string bidAmount = ReadLine();
                                    productName = str[a + 1];
                                    updateBid(bidAmount);
                                    WriteLine("\nYour bid of {0} for {1} has been placed\n", bidAmount, productName);
                                    break;
                                }
                            }
                            WriteLine("Delivery Instructions\n---------------------");
                            Write("(1) Click and collect\n");
                            Write("(2) Home Delivery\n");
                            while (true)
                            {
                                string deliveryOption = ReadLine();
                                if (deliveryOption == "1")
                                {

                                }
                                if (deliveryOption == "2")
                                {
                                    //Home delivery stuff
                                    while (true)
                                    {

                                        Console.WriteLine("\nUnit number  (0 = none):");
                                        var input = Console.ReadLine();


                                        if (int.TryParse(input, out var value) && value > 0)
                                        {
                                            homeAddy += input + "/";
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
                                            homeAddy += streetNum + " ";
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
                                    homeAddy += streetName + " ";
                                    Write("\n");
                                    //No barrier needed

                                    WriteLine("Street suffix:");
                                    string streetSuffix = Console.ReadLine();
                                    homeAddy += streetSuffix + ", ";
                                    Write("\n");
                                    //No barrier needed

                                    WriteLine("City:");
                                    string city = Console.ReadLine();
                                    homeAddy += city + " ";
                                    Write("\n");
                                    //No barrier needed
                                    string[] values = { "ACT", "act", "NSW", "nsw", "NT", "nt", "QLD", "qld", "SA", "sa", "TAS", "tas", "VIC", "vic", "WA", "wa" };
                                    string deliveryState;
                                    while (true)
                                    {
                                        WriteLine("State (ACT, NSW, NT, QLD, SA, TAS, VIC, WA):");
                                        deliveryState = Console.ReadLine();

                                        if (values.Contains(deliveryState))
                                        {
                                            homeAddy += deliveryState + " ";
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
                                            homeAddy += postcode + " ";
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("     Invalid postcode.\n");
                                        }
                                    }
                                    Write("\n");
                                    //Barrier for postcode

                                    WriteLine("Thank you for your bid. If successful, the item will be provided via delivery to {0}", homeAddy);
                                    //update userDB with delivery address
                                    updateUserDBDelivery(homeAddy);
                                    break;

                                }
                            }
                        }
                        break;
                    }

                }

            }
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
                string[] databaseFile = readDB("userDB.txt");

                for (int j = 0; j < databaseFile.Length; j++)
                {

                    //Dont know how it is being formatted in text document, lets have a looky
                    //Here goes the stuff to check if it is a value or a "-"
                    if (databaseFile[j] == "Sold:" && databaseFile[j + 6] == SignIn.username)
                    {
                        int itemNum = 1;

                        Write(itemNum.ToString() + "\t");
                        Write(databaseFile[j + 2] + "\t");
                        Write(databaseFile[j + 3] + "\t");
                        Write(databaseFile[j + 4] + "\t");
                        Write(databaseFile[j + 5] + "\t");
                        Write(databaseFile[j + 8] + "\t");
                        Write("Deliver to {0}", databaseFile[j + 9]);
                        itemNum++;
                        Write("\n");
                    }

                }


            }
            void advertiseProduct()
            {
                WriteLine("\nProduct Advertisement for {0}({1})", SignIn.username, SignIn.email);
                string productAdString = "Product Advertisement for {0}({1})";
                int LineLength = productAdString.Length + SignIn.username.Length + SignIn.email.Length - 6;
                lineUnderliner(LineLength);



                WriteLine("\nProduct name");
                string productName = ReadLine();




                WriteLine("\nProduct description");
                string productDescription = ReadLine();


                string verifiedProductPrice;
                while (true)
                {
                    WriteLine("\nProduct price ($d.cc)");
                    string productPrice = ReadLine();

                    char[] charArrproductPrice = productPrice.ToCharArray();
                    if (charArrproductPrice.Length > 0)
                    {
                        if (charArrproductPrice[0] == '$')
                        {
                            verifiedProductPrice = productPrice;
                            break;

                        }
                    }
                    WriteLine("\tA currency value is required, e.g. $54.95, $9.99, $2314.15\n");
                }

                WriteLine("\nSuccessfully added product {0}, {1}, {2}", productName, productDescription, verifiedProductPrice);
                TextWriter db = new StreamWriter("userDB.txt", true);
                db.WriteLine("For Sale:");
                db.WriteLine(SignIn.username);
                db.WriteLine(SignIn.email);
                db.WriteLine("{0}", productName);//Write string variable to DB
                db.WriteLine("{0}", productDescription);//Write string variable to DB
                db.WriteLine("{0}", verifiedProductPrice);//Write string variable to DB
                db.WriteLine("");//Bidder name will go here
                db.WriteLine("");//Bidder Email will go here
                db.WriteLine("");//Bidder amount
                db.WriteLine("");//Bidder delivery address
                db.WriteLine("");//Empty line
                db.Close();
            }
            void viewProduct()
            {

                //Check iF bro is broke and isnt advertising
                WriteLine("Product List for {0}({1})", SignIn.username, SignIn.email);
                string anotherUnderline = "Product List for {0}({1})";
                int lengthOfUnderline = anotherUnderline.Length + SignIn.email.Length + SignIn.username.Length - 6;
                lineUnderliner(lengthOfUnderline);
                WriteLine("\nItem #\tProduct name\tDescription\tList price\tBidder name\tBidder email\tBid amnt");
                int counter = 1;
                string[] databaseFile = readDB("userDB.txt");
                for (int i = 0; i < databaseFile.Length; i++)
                {

                    if (databaseFile[i] == "For Sale:" && databaseFile[i + 1] == SignIn.username)
                    {

                        if (databaseFile[i + 6] == "")
                        {
                            Write(counter + "\t");
                            for (int j = 3; j < 9; j++)
                            {
                                if (databaseFile[i + j] == "")
                                {
                                    Write("-\t");
                                }
                                Write(databaseFile[i + j] + "\t");
                            }
                            Write("\n");
                            counter++;
                        }


                    }

                }
            }
            void goShopping()
            {
                WriteLine("\nProduct search for {0}({1})", SignIn.username, SignIn.email);
                string productSearch = "Product search for {0}({1)";
                int productSearchLen = productSearch.Length + SignIn.username.Length + SignIn.email.Length - 6;
                lineUnderliner(productSearchLen);
                while (true)
                {

                    string[] databaseFile = readDB("userDB.txt");
                    WriteLine("\nPlease supply a search phrase (ALL to see all products)");
                    string shoppingSearch = ReadLine();
                    beginSearch(shoppingSearch);
                    break;
                }
            }
            void viewBids()
            {

                //Check iF bro is broke and isnt advertising
                WriteLine("Product List for {0}({1})", SignIn.username, SignIn.email);
                string anotherUnderline = "Product List for {0}({1})";
                int lengthOfUnderline = anotherUnderline.Length + SignIn.email.Length + SignIn.username.Length - 6;
                lineUnderliner(lengthOfUnderline);
                WriteLine("\nItem #\tProduct name\tDescription\tList price\tBidder name\tBidder email\tBid amnt");
                int counter = 0;

                int tempArrCount = 0;
                string[] databaseFile = readDB("userDB.txt");
                string[] tempArr = new string[databaseFile.Length];
                for (int i = 0; i < databaseFile.Length; i++)
                {

                    if (databaseFile[i] == "For Sale:" && databaseFile[i + 1] == SignIn.username && databaseFile[i + 11] != "")
                    {

                        if (databaseFile[i + 5] != "")
                        {
                            counter++;
                            Write(counter + "\t");
                            tempArr[tempArrCount] = counter.ToString();
                            tempArrCount++;
                            for (int j = 3; j < 9; j++)
                            {
                                if (databaseFile[i + j] == "")
                                {
                                    tempArr[tempArrCount] = "-";
                                    Write("-\t");
                                    tempArrCount++;
                                }
                                Write(databaseFile[i + j] + "\t");
                                tempArr[tempArrCount] = databaseFile[i + j];
                                tempArrCount++;

                            }
                            Write("\n");
                        }
                        if (counter > 0)
                        {
                            Write("\nWould you like to sell something (yes or no)?\n");
                            string yesOrNo = ReadLine();
                            if (yesOrNo == "yes" || yesOrNo == "YES")
                            {
                                Write("\nPlease enter an integer between 1 and {0}\n", counter);
                                string productIndex = ReadLine();
                                for (int a = 0; a < databaseFile.Length; i++)
                                {
                                    if (tempArr[a] == productIndex)
                                    {
                                        for (int b = 0; b < databaseFile[i].Length; b++)
                                        {
                                            if (databaseFile[b] == "For Sale:" && databaseFile[b + 1] == SignIn.username && databaseFile[b + 3] == tempArr[a + 1])
                                            {
                                                lineChanger("Sold:", "userDB.txt", b + 1);
                                                WriteLine("\nYou have sold {0} to {1} for {2}", databaseFile[b + 1], databaseFile[b + 3], databaseFile[b + 5]);

                                                break;
                                            }

                                        }
                                        break;

                                    }

                                }
                            }
                        }
                        //Print no bids on your items brooke boi

                    }

                }







            }
            while (File.Exists("userDB.txt"))
            {
                string[] databaseFile = readDB("userDB.txt");
                for (int i = 0; i < databaseFile.Length; i++)
                {
                    if (databaseFile[i] == SignIn.username && databaseFile[i + 3] == "" && databaseFile[i + 2] == SignIn.password)//Ask for addy if not given
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

                            Console.WriteLine("\nUnit number  (0 = none):");
                            var input = Console.ReadLine();


                            if (int.TryParse(input, out var value) && value > 0)
                            {
                                homeAddy += input + "/";
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


                        string[] values = { "ACT", "act", "Act", "NSW", "nsw", "Nsw", "NT", "nt", "Nt", "QLD", "qld", "Qld", "SA", "sa", "Sa", "TAS", "tas", "Tas", "VIC", "vic", "Vic", "WA", "wa", "Wa" };
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
                        add.WriteLine("");
                        add.Close();
                        lineChanger(addy, "userDB.txt", i + 4);
                        WriteLine("Address has been updated to {0}", addy);
                        //Updating .txt file


                        break;//break the for loop
                    }
                    //If no addy is needed

                }
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

                        break;

                    }

                }
                break;
            }
            //goto user home page
        }


    }
}
