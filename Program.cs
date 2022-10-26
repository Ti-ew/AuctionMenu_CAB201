
using AuctionMenu;
using System.Text.RegularExpressions;
using static System.Console;



namespace Program
{

    class Begin
    {


        static void Main(string[] args)
        {


            string prompt = "+------------------------------+\n| Welcome to the Auction House |\n+------------------------------+\n";

            while (true)
            {
                AuctionMainPage auction = new AuctionMainPage();//Includes the front menu
                auction.Start(prompt);//Includes registration menu (looped to send user back to front menu)
                                      //Exit of this first menu is done by loggin in successfully

                //Other page Start functions here
                if (File.Exists("userDB.txt"))
                {
                    FrontPage frontPage = new FrontPage();//First page passed signing up && || logging in
                    frontPage.Start();//Begin to check if address has been already input or not
                    prompt = "";
                }

                //NOTE: the .txt file working directory is located 
                // \AuctionMenu\AuctionMenu\bin\Debug\net6.0

            }




            //If not, get, then procedd with the front page load
        }
    }
}