using System.Collections.Generic;

namespace VideoMenuGUI.model
{
    public class MenuModel
    {
        public List<string> MenuOptions { get; }

        public MenuModel()
        {
            MenuOptions = new List<string>()
            {
                "Show all vidoes",
                "Create new video",
                "Delete a video",
                "Update video",
                "Search videos",
                "Exit"
            };
        }
    }
}
