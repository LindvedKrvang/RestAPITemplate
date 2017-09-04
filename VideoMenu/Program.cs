using VideoMenuGUI.controller;

namespace VideoMenu
{
    public class Program
    {
        private static MenuController _menuController;

        static void Main(string[] args)
        {
            _menuController = new MenuController();
            _menuController.PrintWelcomeMessage();
            _menuController.MenuLoop();
        }
    }
}