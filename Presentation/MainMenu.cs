using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presentation.Interfaces;
using Presentation.Servises;
using BusinessLogic;

namespace Presentation
{
    public static class MainMenu
    {
        public static void Start(Logic logic)
        {
            IClubsMenu clubsMenu = new ClubsMenu(logic);
            clubsMenu.Start();
        }
    }
}
