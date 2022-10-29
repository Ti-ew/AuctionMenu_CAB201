using static System.Console;
using System.Globalization;
using System.Collections.Generic;

namespace AuctionMenu
{
    public class FrontPage
    {
        string addy;
        string homeAddy;
        string productName;

		public string[] RemoveDuplicates(string[] myList)
		{
			System.Collections.ArrayList newList = new System.Collections.ArrayList();

			foreach (string str in myList)
				if (!newList.Contains(str))
					newList.Add(str);
			return (string[])newList.ToArray(typeof(string));
		}
		string convert24to12(string time, string minutes)
        {

			//if the strings first letter is a 0, delete it
			char[] charArr = time.ToCharArray();
            if (charArr[0] == '0' && charArr[1] == '0')
            {
				time = time.Replace('0', ' ');				
				time = time.Replace(' ', '1');
				time = time.Remove(1,1);
				time = time + " AM";
			}
			if (charArr[0] == '0')
            {
				//remove the 0
				time = time.Remove(0, 1);
                time = time + ":" + minutes + " AM";
			}
            if (charArr[0] == '1' && charArr[1] == '0')
            {				
				time = time + ":" + minutes + " AM";
			}
            if (charArr[0] == '1' && charArr[1] == '1')
            {
				time = time + ":" + minutes + " AM";
			}
			if (charArr[0] == '1' && charArr[1] == '2')
			{				
				time = time + ":" + minutes + " PM";
			}
			if (charArr[0] == '1' && charArr[1] == '3')
			{
                //remove the 1
                time = time.Remove(1, 1);
				time = time + ":" + minutes + " PM";
			}
			if (charArr[0] == '1' && charArr[1] == '4')
			{
                time = time.Replace('1', '2');
                time = time.Remove(1, 1);
				time = time + ":" + minutes + " PM";
			}
			if (charArr[0] == '1' && charArr[1] == '5')
			{
				time = time.Replace('1', '3');
				time = time.Remove(1, 1);
				time = time + ":" + minutes + " PM";
			}
			if (charArr[0] == '1' && charArr[1] == '6')
			{
				time = time.Replace('1', '4');
				time = time.Remove(1, 1);
				time = time + ":" + minutes + " PM";
			}
            if (charArr[0] == '1' && charArr[1] == '7')
            {
                time = time.Replace('1', '5');
                time = time.Remove(1, 1);
                time = time + ":" + minutes + " PM";
            }			
			if (charArr[0] == '1' && charArr[1] == '8')
			{
				time = time.Replace('1', '6');
				time = time.Remove(1, 1);
				time = time + ":" + minutes + " PM";
			}
			if (charArr[0] == '1' && charArr[1] == '9')
			{
				time = time.Replace('1', '7');
				time = time.Remove(1, 1);
				time = time + ":" + minutes + " PM";
			}
			if (charArr[0] == '2' && charArr[1] == '0')
			{
				time = time.Replace('2', '8');
				time = time.Remove(1, 1);
				time = time + ":" + minutes + " PM";
			}
			if (charArr[0] == '2' && charArr[1] == '1')
			{
				time = time.Replace('2', '9');
				time = time.Remove(1, 1);
				time = time + ":" + minutes + " PM";
			}
			if (charArr[0] == '2' && charArr[1] == '2')
			{
				time = time.Replace('2', ' ');
				time = time.Replace('2', ' ');
				time = time.Replace(' ', '1');
				time = time.Replace(' ', '0');
				time = time + ":" + minutes + " PM";
			}
			if (charArr[0] == '2' && charArr[1] == '3')
			{
				time = time.Replace('2', ' ');
				time = time.Replace('3', ' ');
				time = time.Replace(' ', '1');
				time = time.Replace(' ', '1');
				time = time + ":" + minutes + " PM";
			}			
			return time;

		}
		public static string RemoveNonNumeric(string s)
        {
            return s.Replace("$", "");
        }
        public static String GetTimestamp(DateTime value)
        {
            return value.ToString("dd/mm/yyyy hh:mm");
        }
        string[] viewAlphabet(string[] arrayToSort, string[] dbFile)
        {
            int iterator = 1;


            for (int c = 3; c < dbFile.Length; c++)
            {

                if (dbFile[c - 3] == "For Sale:" && dbFile[c - 2] == SignIn.username)
                {
                    arrayToSort[iterator] = dbFile[c];
                    iterator++;

                }

            }
            Array.Sort(arrayToSort, StringComparer.Ordinal);

            return arrayToSort;
        }
        //Works for displaying items user is selling. NO BIDS.
        string[] arrayAlphabetSpecificSearch(string[] arrayToSort, string[] dbFile, string search)
        {
            int iterator = 1;


            for (int c = 4; c < dbFile.Length; c++)
            {
                //Check product name and description for positive .Contains()
                //Looking for matches in description
                if (dbFile[c].Contains(search) == true && dbFile[c - 4] == "For Sale:" && dbFile[c - 3] != SignIn.username)
                {
                    arrayToSort[iterator] = dbFile[c-1];
                    iterator++;

                }
                //Looking for matches in product name
                if ((dbFile[c].Contains(search) == true && dbFile[c - 3] == "For Sale:" && dbFile[c - 2] != SignIn.username))
                {
                    arrayToSort[iterator] = dbFile[c];
                    iterator++;

                }

            }
            Array.Sort(arrayToSort, StringComparer.Ordinal);

            return arrayToSort;
        }
        //Works
        string[] arrayAlphabetAllSearch(string[] arrayToSort, string[] dbFile)
        {
            int iterator = 0;


            for (int c = 3; c < dbFile.Length; c++)
            {
                //Check product name and description for positive .Contains()

                //Looking for matches in product name
                if (dbFile[c - 3].Contains("For Sale:") && dbFile[c - 2] != SignIn.username)
                {
                    arrayToSort[iterator] = dbFile[c];
                    iterator++;

                }                

            }
            Array.Sort(arrayToSort, StringComparer.Ordinal);

            return arrayToSort;
        }
        //Works
        string[] bidsAlphabet(string[] arrayToSort, string[] dbFile)
        {
            //look in text file "userDB.txt" for the line "For Sale:" and "SignIn.username"
            //make sure this item has a bet on it by making sure the sixth line is NOT empty
            int iterator = 0;
            for (int c = 0; c < dbFile.Length; c++)
            {

                if (dbFile[c] == "For Sale:" && dbFile[c + 6] != "" && dbFile[c + 1] == SignIn.username)
                {
                    arrayToSort[iterator] = dbFile[c + 3];
                    iterator++;

                }

            }
            Array.Sort(arrayToSort, StringComparer.Ordinal);

            return arrayToSort;
        }
        //Doesnt work yet
        string[] createArray(string DB)
        {
            string[] databaseFile = readDB(DB);
            string[] emptyArray = new string[databaseFile.Length + 1];
            return emptyArray;
        }

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
            lineChanger(SignIn.username, "userDB.txt", lineForEditing + 4);
            lineChanger(SignIn.email, "userDB.txt", lineForEditing + 5);
            lineChanger("$"+bid, "userDB.txt", lineForEditing + 6);
            



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

            string[] databaseFile = readDB("userDB.txt");
            WriteLine("\nSearch results\n--------------\n");
            WriteLine("Item #\tProduct name\tDescription\tList price\tBidder name\tBidder email\tBid amt");
            if (searchPhrase == "ALL" || searchPhrase == "all")
            {
                string lineForDeliveryWindow = "";
                string deliveryWindow = "";
                string deliveryWindowStart = "";
                int secondCount = 0;
                int count = 0;
                string[] str = createArray("userDB.txt");
                string[] sortedArray = createArray("userDB.txt");
                arrayAlphabetAllSearch(sortedArray, databaseFile);
                sortedArray = sortedArray.Where(c => !string.IsNullOrEmpty(c)).ToArray();
                while (true)
                {
                    for (int i = 0; i < databaseFile.Length - 3; i++)
                    {

                        if (databaseFile[i] == "For Sale:" && databaseFile[i + 1] != SignIn.username && databaseFile[i + 3] == sortedArray[count])
                        {

                            //Printing table for search result ALL
                            count++;//Table is working therefore lets start at index 1
                            if (count != 0)
                            {
                                Write(count + "\t");//Print the number
                                str[secondCount] = count.ToString();//Print the number to an array of string to choose from

                            }

                            //for the next 6 iterations after 3, print the following
                            for (int j = 3; j < 9; j++)
                            {

                                if (databaseFile[i + j] != "")
                                {
                                    Write("{0}\t", databaseFile[i + j]);

                                    str[j - 2 + secondCount] = databaseFile[i + j];
                                }
                                if (databaseFile[i + j] == "")
                                {
                                    Write("-\t");
                                    str[j - 2 + secondCount] = "-";

                                }


                            }
                            secondCount += 7;
                            Write("\n");



                        }
                        //Working
                        if (count == sortedArray.Length)
                        {
                            break;
                        }

                    }

                    if (count == sortedArray.Length)
                    {
                        break;
                    }
                }
                WriteLine("\n\nWould you like to place a bid on any of these items (yes or no)?");
                Write("> ");
                string YesOrNoBid = ReadLine();
                if (YesOrNoBid == "yes" || YesOrNoBid == "YES")
                {
                    WriteLine("\nPlease enter a non-negative integer between 1 and {0}:", count);
                    Write("> ");
                    string answer4 = ReadLine();

                    for (int a = 0; a < databaseFile.Length; a++)
                    {
                        if (answer4 == str[a])
                        {
                            lineForDeliveryWindow = str[a+1];
							if (str[a+6] == "-")
							{
                                str[a+6] = "$0.00";
							}
							WriteLine("\nBidding for {0} (regular price {1}), current highest bid {2}\n", str[a + 1], str[a + 3], str[a + 6]);
                            //Bid amount check. NO BROKEY'S



                            string bidAmount = "";
                            
                            WriteLine("\nHow much do you bid?");
                            while (true)
                            {
                                Write("> ");
                                bidAmount = ReadLine();
								if (bidAmount.Contains("$") == false)
								{
									WriteLine("\tInvalid currency");
									return;
								}
								bidAmount = RemoveNonNumeric(bidAmount);
                                string highestBid = str[a + 6];							
								highestBid = RemoveNonNumeric(highestBid);
                                if (Double.Parse(bidAmount) > Double.Parse(highestBid))
                                {
                                    break;
                                }
                                else 
                                {
                                    Write("\t");
                                    WriteLine("Bid amount must be greater than {0}\n", str[a+6]);

                                    WriteLine("\nHow much do you bid?");
                                }
                            }
                            productName = str[a + 1];
                            updateBid(bidAmount);
                            WriteLine("\nYour bid of ${0} for {1} is placed.", bidAmount, productName);
                            break;
                        }
                    }
                    WriteLine("\nDelivery Instructions\n---------------------");
                    Write("(1) Click and collect\n");
                    Write("(2) Home Delivery\n");
                    DateTime dt3;
                    DateTime dt2;
                    WriteLine("\nPlease select an option between 1 and 2");                    
                    while (true)
                    {
                        Write("> ");
                        string deliveryOption = ReadLine();
                        string dateHourStart = "";
                        string dateMonthStart = "";
                        string dateHourEnd = "";
                        string dateMonthEnd = "";
                        if (deliveryOption == "1")
                        {

                            WriteLine("\nDelivery window start (dd/mm/yyyy hh:mm)");
                            while (true)
                            {

								Write("> ");
								deliveryWindowStart = ReadLine();
								string[] hoursMonths = deliveryWindowStart.Split(' ');
								dateMonthStart = hoursMonths[0];
								dateHourStart = hoursMonths[1];
								string[] dateJustHour = dateHourStart.Split(':');
								dateHourStart = convert24to12(dateJustHour[0], dateJustHour[1]);
								DateTime dt1 = DateTime.ParseExact(deliveryWindowStart, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
								TimeSpan diff = dt1 - DateTime.Now;																
                                if (diff.TotalHours > 1)
                                {
                                    dt2 = dt1.AddHours(1);
                                    break;
                                }
                                else
                                {
                                    WriteLine("Delivery window must be at least 1 hour from now");
                                }
                            }
                            WriteLine("\nDelivery window end (dd/mm/yyyy hh:mm)");                            
                            while (true)
                            {

                                Write("> ");
                                deliveryWindow = ReadLine();
                                string[] hoursMonths = deliveryWindow.Split(' ');
                                dateMonthEnd = hoursMonths[0];
                                dateHourEnd = hoursMonths[1];								
								string[] dateJustHour = dateHourEnd.Split(':');
								dateHourEnd = convert24to12(dateJustHour[0], dateJustHour[1]);
								DateTime dt1 = DateTime.ParseExact(deliveryWindow, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                                if (dt1 > DateTime.Now && dt1 > dt2)
                                {
                                    dt3 = dt1;
                                    break;
                                }
                            }
                            WriteLine("\nThank you for your bid. If successful, the item will be provided via collection between {0} on {1} and {2} on {3}", dateHourStart, dateMonthStart, dateHourEnd, dateMonthEnd);
                            string TimeToDeliver = dateHourStart + " on " + dateMonthStart + " and " + dateHourEnd + " on " + dateMonthEnd;
                            for (int i = 0; i < databaseFile.Length; i++)
                            {
                                if (databaseFile[i] == lineForDeliveryWindow)
                                {
									lineChanger(TimeToDeliver, "userDB.txt", i+7);
									break;
								}
                            }
                            break;
                        }
                        if (deliveryOption == "2")
                        {
                            WriteLine("\nPlease provide your delivery address.\n");
                            //Home delivery stuff
                            while (true)
                            {

                                Console.WriteLine("Unit number (0 = none):");
                                Write("> ");
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
                                Write("> ");
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
                            Write("> ");
                            string streetName = Console.ReadLine();
                            homeAddy += streetName + " ";
                            Write("\n");
                            //No barrier needed

                            WriteLine("Street suffix:");
                            Write("> ");
                            string streetSuffix = Console.ReadLine();
                            homeAddy += streetSuffix + ", ";
                            Write("\n");
                            //No barrier needed

                            WriteLine("City:");
                            Write("> ");
                            string city = Console.ReadLine();
                            homeAddy += city + " ";
                            Write("\n");
                            //No barrier needed
                            string[] values = { "ACT", "act", "Act", "NSW", "nsw", "Nsw", "NT", "nt", "Nt", "QLD", "qld", "Qld", "SA", "sa", "Sa", "TAS", "tas", "Tas", "VIC", "vic", "Vic", "WA", "wa", "Wa" };
                            string deliveryState;
                            while (true)
                            {
                                WriteLine("State (ACT, NSW, NT, QLD, SA, TAS, VIC, WA):");
                                Write("> ");
                                deliveryState = Console.ReadLine();

                                if (values.Contains(deliveryState))
                                {
                                    deliveryState = deliveryState.ToUpper();
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

                                Console.WriteLine("Postcode (1000 .. 9999):");
                                Write("> ");
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

            }//Alot of stuff to do. Print the "For Sale:" items to the screen


            for (int i = 4; i < databaseFile.Length; i++)
            {

                if (databaseFile[i-3] == "For Sale:" && databaseFile[i].Contains(searchPhrase) || (databaseFile[i-4] == "For Sale:" && databaseFile[i].Contains(searchPhrase))) //HERE
                {

                    string lineForDeliveryWindow = "";
                    int count = 0;
                    int secondCount = 0;
                    string[] str = createArray("userDB.txt");
                    var sortedArray = createArray("userDB.txt");
                    arrayAlphabetSpecificSearch(sortedArray, databaseFile, searchPhrase);
                    sortedArray = sortedArray.Where(c => !string.IsNullOrEmpty(c)).ToArray();
					sortedArray = sortedArray.Distinct().ToArray();
					while (true)
                    {
                        
                        for (int b = 0; b < databaseFile.Length - 3; b++)
                        {
                            if (count == sortedArray.Length)
                            {
                                break;
                            }
                            if (databaseFile[b + 3] == sortedArray[count])
                            {
                                count++;
                                if (count != 0)
                                {
                                    Write(count + "\t");
                                    str[secondCount] = count.ToString();

                                }
                                for (int j = 3; j < 9; j++)
                                {

                                    if (databaseFile[b + j] != "")
                                    {
                                        Write("{0}\t", databaseFile[b + j]);

                                        str[j - 2 + secondCount] = databaseFile[b + j];
                                    }
                                    if (databaseFile[b + j] == "")
                                    {
                                        Write("-\t");
                                        str[j - 2 + secondCount] = "-";

                                    }


                                }
                                secondCount += 7;
                                Write("\n");


                            }


                        }
                        if (count == sortedArray.Length)
                        {
                            break;
                        }

                        if (count == 0)
                        {
                            WriteLine("\nNothing for sale");
                            break;
                        }
                    }
                    WriteLine("\n\nWould you like to place a bid on any of these items (yes or no)?");
                    Write("> ");
                    string YesOrNoBid = ReadLine();
                    if (YesOrNoBid == "yes" || YesOrNoBid == "YES")
                    {
                        WriteLine("\nPlease enter a non-negative integer between 1 and {0}:", count);
                        Write("> ");
                        string answer4 = ReadLine();

                        for (int a = 0; a < databaseFile.Length; a++)
                        {
                            if (answer4 == str[a])
                            {
								lineForDeliveryWindow = str[a + 1];
								if (str[a+6] == "-")
                                {
                                    str[a+6] = "$0.00";
                                }
                                WriteLine("\nBidding for {0} (regular price {1}), current highest bid {2}\n", str[a + 1], str[a + 3], str[a + 6]);
                                //Bid amount check. NO BROKEY'S



                                string bidAmount = "";

                                WriteLine("\nHow much do you bid?");                                
                                while (true)
                                {
                                    

                                    Write("> ");
                                    bidAmount = ReadLine();
                                    if (bidAmount.Contains("$") == false)
                                    {
                                        WriteLine("\tInvalid currency");
                                        return;
                                    }

                                    bidAmount = bidAmount.Replace(@"$", "");

                                    string highestBid = str[a + 6];
                                    
                                    highestBid = highestBid.Replace(@"$", "");
                                    
                                    if (Double.Parse(bidAmount) > Double.Parse(highestBid))
                                    {
                                        break;
                                    }
                                    else
                                    {
                                        Write("\t");
                                        WriteLine("Bid amount must be greater than {0}", str[a + 6]);
                                        WriteLine("\nHow much do you bid?");

                                    }
                                }
                                productName = str[a + 1];
                                updateBid(bidAmount);
                                WriteLine("\nYour bid of ${0} for {1} is placed.\n", bidAmount, productName);
                                break;
                            }
                        }
                        WriteLine("Delivery Instructions\n---------------------");
                        Write("(1) Click and collect\n");
                        Write("(2) Home Delivery\n\n");
                        DateTime dt2;
                        DateTime dt3;
                        WriteLine("Please select an option between 1 and 2");
                        while (true)
                        {
                            Write("> ");
                            string deliveryOption = ReadLine();
                            string dateHourStart = "";
                            string dateMonthStart = "";
                            string dateHourEnd = "";
                            string dateMonthEnd = "";
                            if (deliveryOption == "1")
                            {
                                
                                WriteLine("\nDelivery window start (dd/mm/yyyy hh:mm)");
                                while (true)
                                {

                                    Write("> ");
                                    string deliveryWindowStart = ReadLine();
                                    string[] hoursMonths = deliveryWindowStart.Split(' ');
                                    dateMonthStart = hoursMonths[0];
                                    dateHourStart = hoursMonths[1];
									string[] dateJustHour = dateHourStart.Split(':');
									dateHourStart = convert24to12(dateJustHour[0], dateJustHour[1]);
									DateTime dt1 = DateTime.ParseExact(deliveryWindowStart, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                                    TimeSpan diff = dt1 - DateTime.Now;
                                    if (diff.TotalHours > 1)
                                    {
                                        dt2 = dt1.AddHours(1);
                                        break;
                                    }
                                    else
                                    {
                                        WriteLine("Delivery window must be at least 1 hour from now");
                                    }
                                }
                                WriteLine("\nDelivery window end (dd/mm/yyyy hh:mm)");
                                while (true)
                                {

                                    Write("> ");
                                    string deliveryWindow = ReadLine();
                                    string[] hoursMonths = deliveryWindow.Split(' ');
                                    dateMonthEnd = hoursMonths[0];
                                    dateHourEnd = hoursMonths[1];
									string[] dateJustHour = dateHourEnd.Split(':');
									dateHourEnd = convert24to12(dateJustHour[0], dateJustHour[1]);
									DateTime dt1 = DateTime.ParseExact(deliveryWindow, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
                                    if (dt1 > DateTime.Now && dt1 > dt2)
                                    {
                                        dt3 = dt1;
                                        break;
                                    }
                                }
                                WriteLine("\nThank you for your bid. If successful, the item will be provided via collection between {0} on {1} and {2} on {3}", dateHourStart, dateMonthStart, dateHourEnd, dateMonthEnd);
								string TimeToDeliver = dateHourStart + " on " + dateMonthStart + " and " + dateHourEnd + " on " + dateMonthEnd;
								for (int f = 0; f < databaseFile.Length; f++)
								{
									if (databaseFile[f] == lineForDeliveryWindow)
									{
										lineChanger(TimeToDeliver, "userDB.txt", i + 7);
										break;
									}
								}
								break;
                            }
                            if (deliveryOption == "2")
                            {
                                WriteLine("\nPlease provide your delivery address.\n");
                                //Home delivery stuff
                                while (true)
                                {

                                    Console.WriteLine("Unit number (0 = none):");
                                    Write("> ");
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
                                    Write("> ");
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
                                Write("> ");
                                string streetName = Console.ReadLine();
                                homeAddy += streetName + " ";
                                Write("\n");
                                //No barrier needed

                                WriteLine("Street suffix:");
                                Write("> ");
                                string streetSuffix = Console.ReadLine();
                                homeAddy += streetSuffix + ", ";
                                Write("\n");
                                //No barrier needed

                                WriteLine("City:");
                                Write("> ");
                                string city = Console.ReadLine();
                                homeAddy += city + " ";
                                Write("\n");
                                //No barrier needed
                                string[] values = { "ACT", "act", "Act", "NSW", "nsw", "Nsw", "NT", "nt", "Nt", "QLD", "qld", "Qld", "SA", "sa", "Sa", "TAS", "tas", "Tas", "VIC", "vic", "Vic", "WA", "wa", "Wa" };
                                string deliveryState;
                                while (true)
                                {
                                    WriteLine("State (ACT, NSW, NT, QLD, SA, TAS, VIC, WA):");
                                    Write("> ");
                                    deliveryState = Console.ReadLine();

                                    if (values.Contains(deliveryState))
                                    {
                                        deliveryState = deliveryState.ToUpper();
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

                                    Console.WriteLine("Postcode (1000 .. 9999):");
                                    Write("> ");
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

            }//Alot of stuff to do. Print the "For Sale:" items to the screen if a specific match is found within its Name or Description
            //Finds alphabetically and orders them, the items that are for sale and match the product search
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
                WriteLine("\nPurchased Items for {0}({1})", SignIn.username, SignIn.email);
                int tempUnderline = "Purchased items for {0}({1})".Length + SignIn.username.Length + SignIn.email.Length - 6;
                lineUnderliner(tempUnderline);
                Write("\n");
				// Stuff for the table, PIPE deez
				int itemNum = 1;
				string[] databaseFile = readDB("userDB.txt");

                for (int j = 0; j < databaseFile.Length; j++)
                {

                    //Dont know how it is being formatted in text document, lets have a looky
                    //Here goes the stuff to check if it is a value or a "-"
                    if (databaseFile[j] == "Sold:" && databaseFile[j + 6] == SignIn.username)
                    {
						if (itemNum  == 1)
                        {
							WriteLine("Item #\tSeller email\tProduct name\tDescription\tList price\tAmt paid\tDelivery Option\t");
						}
						
						

                        Write(itemNum.ToString() + "\t");
                        Write(databaseFile[j + 2] + "\t");
                        Write(databaseFile[j + 3] + "\t");
                        Write(databaseFile[j + 4] + "\t");
                        Write(databaseFile[j + 5] + "\t");
                        Write(databaseFile[j + 8] + "\t");
                        if (databaseFile[j+9].Contains(":"))
                        {
                            Write("Collect between {0}", databaseFile[j + 9]);
                        }
                        if (!databaseFile[j+9].Contains(":"))
                        {
							Write("Deliver to {0}\t", databaseFile[j + 9]);
						}
                        
                        itemNum++;
                        Write("\n");
                        
                    }

                }
				if (itemNum == 1)
                {
				
						WriteLine("You have no purchased products at the moment.");
				}



			}
            void advertiseProduct()
            {
                WriteLine("\n\nProduct Advertisement for {0}({1})", SignIn.username, SignIn.email);
                string productAdString = "Product Advertisement for {0}({1})";
                int LineLength = productAdString.Length + SignIn.username.Length + SignIn.email.Length - 6;
                lineUnderliner(LineLength);



                WriteLine("\nProduct name");
                Write("> ");
                string productName = ReadLine();




                WriteLine("\nProduct description");
                Write("> ");
                string productDescription = ReadLine();


                string verifiedProductPrice;
                while (true)
                {
                    WriteLine("\nProduct price ($d.cc)");
                    Write("> ");
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

                WriteLine("\nSuccessfully added product {0}, {1}, {2}.", productName, productDescription, verifiedProductPrice);
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


                WriteLine("\nProduct List for {0}({1})", SignIn.username, SignIn.email);
                string anotherUnderline = "\nProduct List for {0}({1})";
                int lengthOfUnderline = anotherUnderline.Length + SignIn.email.Length + SignIn.username.Length - 6;
                lineUnderliner(lengthOfUnderline);
                WriteLine("\nItem #\tProduct name\tDescription\tList price\tBidder name\tBidder email\tBid amt");
                int counter = 0;
                string[] databaseFile = readDB("userDB.txt");
                string[] sortedArray = createArray("userDB.txt");
                viewAlphabet(sortedArray, databaseFile);
                sortedArray = sortedArray.Where(c => !string.IsNullOrEmpty(c)).ToArray();
				sortedArray = sortedArray.Distinct().ToArray();
				while (true)
                {
                    for (int i = 0; i < databaseFile.Length; i++)
                    {

                        if (databaseFile[i] == "For Sale:" && databaseFile[i + 1] == SignIn.username && databaseFile[i + 3] == sortedArray[counter])
                        {
                            counter++;
                            Write(counter + "\t");
                            for (int j = 3; j < 8; j++)
                            {
                                if (databaseFile[i + j] == "")
                                {
                                    Write("-\t");
                                }                                
                                Write(databaseFile[i + j] + "\t");
                            }
                            Write("\n");
                            if (counter == sortedArray.Length)
                            {
                                break;
                            }

                        }

                    }
                    if (counter == sortedArray.Length)
                    {
                        break;
                    }
                }
            }
            void goShopping()
            {
                //Time to place some bids.
                WriteLine("\nProduct Search for {0}({1})", SignIn.username, SignIn.email);
                string productSearch = "Product search for {0}({1)";
                int productSearchLen = productSearch.Length + SignIn.username.Length + SignIn.email.Length - 5;
                lineUnderliner(productSearchLen);
                while (true)
                {
                    //Lets begin, first open up a databaseFile, recalling it as changes may have been made.
                    string[] databaseFile = readDB("userDB.txt");

                    WriteLine("\n\nPlease supply a search phrase (ALL to see all products)");
                    //Use this readLine as a way of comparing to the databaseFile if a search is given
                    //IF not continue to display all "For Sale:" items
                    Write("> ");
                    string shoppingSearch = ReadLine();
                    beginSearch(shoppingSearch);
                    //Somewhere in begin search im going to get all the strings of the "For Sale:" products
                    //Order them
                    //Tell the search team to look for the first string in the ordered array
                    break;
                }
            }
            void viewBids()
            {

                //Check iF bro is broke and isnt advertising
                WriteLine("\n\nList Product Bids for {0}({1})", SignIn.username, SignIn.email);
                string anotherUnderline = "List Product Bids for {0}({1})";
                int lengthOfUnderline = anotherUnderline.Length + SignIn.email.Length + SignIn.username.Length - 6;				
				lineUnderliner(lengthOfUnderline);
                			
                
                int counter = 0;

                int tempArrCount = 0;
                string[] databaseFile = readDB("userDB.txt");
                string[] tempArr = new string[databaseFile.Length];
                bool noBids = false;
                string[] sortedArray = createArray("userDB.txt");
                bidsAlphabet(sortedArray, databaseFile);
                sortedArray = sortedArray.Where(c => !string.IsNullOrEmpty(c)).ToArray();
				sortedArray = sortedArray.Distinct().ToArray();
				while (true)
                {
                    for (int i = 0; i < databaseFile.Length; i++)
                    {
                        if (counter == sortedArray.Length)
                        {
                            break;
                        }

                        if (databaseFile[i] == "For Sale:" && databaseFile[i + 1] == SignIn.username && databaseFile[i + 8] != "" && sortedArray[counter] == databaseFile[i + 3])
                        {
                            
							
							if (databaseFile[i + 5] != "")
                            {
								if (counter < 1)
								{
									WriteLine("\nItem #\tProduct name\tDescription\tList price\tBidder name\tBidder email\tBid amt");
								}
								if (counter > 1)
                                {
                                    Write("\n");
                                }
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
                                
                            }


                        }


                    }
					if (counter == 0)
					{
						WriteLine("\nNo bids were found.");
                        noBids = true;
						break;
					}
					//Print no bids on your items brooke boi
					if (counter == sortedArray.Length)
                    {
                        break;
                    }
					

				}
                if (noBids == true)
                {
                    return;
                }
                Write("\n\nWould you like to sell something (yes or no)?\n");
                Write("> ");
                string yesOrNo = ReadLine();
                if (yesOrNo == "yes" || yesOrNo == "YES")
                {
                    Write("\nPlease enter an integer between 1 and {0}:\n", counter);
                    Write("> ");
                    string productIndex = ReadLine();
                    for (int a = 0; a < databaseFile.Length; a++)
                    {
                        if (tempArr[a] == productIndex)
                        {
                            for (int b = 0; b < databaseFile.Length; b++)
                            {
                                if (databaseFile[b] == "For Sale:" && databaseFile[b + 1] == SignIn.username && databaseFile[b + 3] == tempArr[a + 1])
                                {
                                    lineChanger("Sold:", "userDB.txt", b + 1);
                                    WriteLine("\nYou have sold {0} to {1} for {2}.", databaseFile[b + 3], databaseFile[b + 6], databaseFile[b + 8]);

                                    break;
                                }

                            }
                            break;

                        }

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
                        WriteLine("\nPlease provide your home address.");
                        //Whole bunch of main menu printing logic

                        while (true)
                        {

                            Console.WriteLine("\nUnit number (0 = none):");
                            Write("> ");
                            var input = Console.ReadLine();

                            
                            if (int.TryParse(input, out var value) && value > 0)
                            {
                                addy += value + "/";
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
                            Write("> ");
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
                        Write("> ");
                        string streetName = Console.ReadLine();
                        addy += streetName + " ";
                        Write("\n");
                        //No barrier needed

                        WriteLine("Street suffix:");
                        Write("> ");
                        string streetSuffix = Console.ReadLine();
                        addy += streetSuffix + ", ";
                        Write("\n");
                        //No barrier needed

                        WriteLine("City:");
                        Write("> ");
                        string city = Console.ReadLine();
                        addy += city + " ";
                        Write("\n");
                        //No barrier needed


                        string[] values = { "ACT", "act", "Act", "NSW", "nsw", "Nsw", "NT", "nt", "Nt", "QLD", "qld", "Qld", "SA", "sa", "Sa", "TAS", "tas", "Tas", "VIC", "vic", "Vic", "WA", "wa", "Wa" };
                        string state;
                        while (true)
                        {
                            WriteLine("State (ACT, NSW, NT, QLD, SA, TAS, VIC, WA):");
                            Write("> ");
                            state = Console.ReadLine();

                            if (values.Contains(state))
                            {
                                state = state.ToUpper();
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

                            Console.WriteLine("Postcode (1000 .. 9999):");
                            Write("> ");
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
                    string[] options = { "(1) Advertise Product", "(2) View My Product List", "(3) Search For Advertised Products", "(4) View Bids On My Products", "(5) View My Purchased Items", "(6) Log off\n" };
                    WriteLine("\nClient Menu\r\n-----------");
                    for (int i = 0; i < options.Length; i++)
                    {
                        string currentOption = options[i];
                        WriteLine($"{currentOption}");
                    }
                    WriteLine("Please select an option between 1 and 6");
                    string[] validvalues = new string[] { "1", "2", "3", "4", "5", "6" };
                    string mystring = "";
                    Write("> ");
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
