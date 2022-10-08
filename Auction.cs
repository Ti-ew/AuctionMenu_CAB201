namespace AuctionMenu
{
    class Auction
    {
        public void Start()
        {
            string prompt = "Welcome to the Auction House";
            string[] options = { "Play", "About", "Exit" };
            Menu mainMenu = new Menu(prompt, options);
            mainMenu.Display();
            //Yuh
        }


    }
}
