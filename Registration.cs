using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace AuctionMenu
{
    public class Registration
    {
        string userName;
        string userEmail;
        public void userSignUp()
        {
            WriteLine("\nRegistration");
            WriteLine("----------");

            WriteLine("\nPlease enter your name");
            userName = Console.ReadLine();


        }
    }
}
