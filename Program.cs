﻿
using AuctionMenu;
using System.Text.RegularExpressions;
using static System.Console;

namespace Program
{
    class Begin
    {
        static void Main(string[] args)
        {

            AuctionMainPage auction = new AuctionMainPage();//Includes the front menu
            auction.Start(@"+------------------------------+
| Welcome to the Auction House |
+------------------------------+
");//Includes registration menu (looped to send user back to front menu)
            //Exit of this first menu is done by loggin in successfully

            //Other page Start functions here

            FrontPage frontPage = new FrontPage();//First page passed signing up && || logging in
            frontPage.Start();//Begin to check if address has been already input or not

            //If not, get, then procedd with the front page load
        }
    }
}