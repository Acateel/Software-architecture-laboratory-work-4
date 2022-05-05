using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLogic;
using Entities.Carts;
using Entities.Clubs;
using Entities.TimeTables;
using Presentation.Interfaces;

namespace Presentation.Servises
{
    class ClubMenu : IClubMenu
    {
        private readonly Logic logic;

        public ClubMenu(Logic logic)
        {
            this.logic = logic;
        }

        public void BuyClubCart()
        {
            var table = InputHelper.GetTimeTable();
            var cart = logic.Club.BuyClubCart(table);
            Console.WriteLine(cart + "bought");
        }

        public void BuySpecialCart()
        {
            var table = InputHelper.GetTimeTable();
            var cart = logic.Club.BuySpecialCart(table);
            Console.WriteLine(cart + "bought");
        }

        public void ChangeInfo()
        {
            LocClub club = logic.Club.Club as LocClub;
            Console.WriteLine(club);
            Console.WriteLine("Write s for skip");
            string name = InputHelper.GetName();
            if(name != "s")
            {
                club.Name = name;
            }
            string location = InputHelper.GetLocation();
            if (location != "s")
            {
                club.Location = location;
            }
            logic.Club.ChangeInfo(club);
            Console.WriteLine(club + " changed");
        }

        public void GetClubInfo()
        {
            Console.WriteLine(logic.Club.GetClubInfo());
        }

        public void SingUp()
        {
            Console.WriteLine("With cart?(y/n)");
            bool command = InputHelper.GetYesOrNo();
            if (command)
            {
                SingUpWithCart();
            }
            else
            {
                SingUpWithoutCart();
            }
        }

        private void SingUpWithCart()
        {
            Console.WriteLine("Write cart id");
            int id = InputHelper.GetCommant();
            var cart = logic.Carts.GetCart(id);
            int time = InputHelper.GetTime();
            logic.Club.SingUp(cart, time);
            Console.WriteLine(cart);
            InputHelper.ShowTimeTable(cart.Table);
            Console.WriteLine("Sing up");
        }

        private void SingUpWithoutCart()
        {
            int time = InputHelper.GetTime();
            logic.Club.SingUp(time);
            Console.WriteLine("Sing up without cart: get temp cart");
        }

        public void VisitClub()
        {
            Console.WriteLine("With cart?(y/n)");
            bool command = InputHelper.GetYesOrNo();
            if (command)
            {
                VisitClubWithCart();
            }
            else
            {
                try
                {
                    logic.Club.VisitClub();
                }
                catch (ClubException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private void VisitClubWithCart()
        {
            Console.WriteLine("Write cart id");
            int id = InputHelper.GetCommant();
            var cart = logic.Carts.GetCart(id);
            bool visit = logic.Club.VisitClub(cart);
            if (visit)
            {
                Console.WriteLine("Wisit true");
            }
            else
            {
                Console.WriteLine("Wisit false");
            }
        }

        public void ShowMenu()
        {
            ConsoleColor color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("1 - ChangeInfo | 2 - BuyClubCart | 3 - BuySpecialCart | 4 - SingUp | 5 - VisitClub | 6 - Stop");
            Console.ForegroundColor = color;
        }

        public void Start()
        {
            bool running = true;
            while (running)
            {
                GetClubInfo();
                ShowMenu();
                int command = InputHelper.GetCommant();
                switch (command)
                {
                    case 1:
                        ChangeInfo();
                        break;
                    case 2:
                        BuyClubCart();
                        break;
                    case 3:
                        BuySpecialCart();
                        break;
                    case 4:
                        SingUp();
                        break;
                    case 5:
                        VisitClub();
                        break;
                    case 6:
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Command not found");
                        break;
                }
            }
        }
    }
}
