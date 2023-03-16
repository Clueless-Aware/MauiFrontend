using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectWork.Utilities
{
    public static class ArtistFilters
    {
        public static readonly List<string> UniqueProfessions = new()
        {
            "painter", "architect", "potter", "sculptor", "glass painter",
            "graphic artist", "goldsmith", "illuminator" ,"miniaturist",
            "tapestry weaver", "cabinet-maker", "automobile designer" ,"designer",
            "jeweller" ,"glass artist", "illustrator", "needlework artist"
        };

        public static List<string> UniqueSchool = new()
        {
            "Italian", "German", "Danish", "Spanish", "French", "Dutch", "Scottish",
                "Swedish", "Flemish", "Netherlandish", "Swiss", "Russian", "Greek", "Other",
                "American", "English", "Austrian", "Portuguese", "Bohemian", "Irish", "Belgian",
                "Hungarian", "Catalan", "Polish", "Norwegian", "Finnish" ,"german"
        };
    }
}
