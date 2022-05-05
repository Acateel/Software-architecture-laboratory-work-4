using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;
using Presentation.Interfaces;
using Entities.Clubs;
using Entities.TimeTables;

namespace Presentation.Servises
{
    class ClubsMenu : IClubsMenu
    {
        private readonly Logic logic;
        ICartMenu cartMenu;
        IClubMenu clubMenu;

        public ClubsMenu(Logic logic)
        {
            this.logic = logic;
            // initialise sum menu
        }

        public void CartMenu()
        {
            cartMenu.Show();
        }

        public void CreateClub()
        {
            Console.WriteLine("Create Club:");

            string name = "";

            string location = "";

            TimeTable table = new TimeTable();

            LocClub club = new LocClub(name, location, table);
        }

        public void DeleteClub()
        {
            throw new NotImplementedException();
        }

        public void GetClubs()
        {
            throw new NotImplementedException();
        }

        public void SetClub()
        {
            throw new NotImplementedException();
        }

        public void Show()
        {
            throw new NotImplementedException();
        }
    }
}
