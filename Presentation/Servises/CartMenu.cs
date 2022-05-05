using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presentation.Interfaces;
using Entities.Carts;
using Entities.TimeTables;
using BusinessLogic;

namespace Presentation.Servises
{
    public class CartMenu : ICartMenu
    {
        readonly Logic logic;

        public CartMenu(Logic logic)
        {
            this.logic = logic;
        }

        public void ChangeTimeTable()
        {
            try
            {
                Console.WriteLine("Write Cart Id");
                int id = InputHelper.GetCommant();
                var table = logic.Carts.GetTimeTable(id);
                table = InputHelper.SetTimeTable(table);
                logic.Carts.ChangeTimeTable(id, table);
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Cart with id was not found");
            }
        }

        public void GetCarts()
        {
            foreach(var cart in logic.Carts.GetCarts())
            {
                Console.WriteLine(cart);
            }
        }

        public void GetTimeTable()
        {
            try
            {
                Console.WriteLine("Write cart id:");
                int id = InputHelper.GetCommant();
                InputHelper.ShowTimeTable(logic.Carts.GetTimeTable(id));
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Cart with id was not found");
            }
        }

        public void RemoveCart()
        {
            try
            {
                Console.WriteLine("Write cart id:");
                int id = InputHelper.GetCommant();
                logic.Carts.RemoveCart(id);
                Console.WriteLine("cart deleted");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("Cart with id was not found");
            }
        }

        public void ShowMenu()
        {
            ConsoleColor color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("1 - GetTimeTable | 2 - ChangeTimeTable | 3 - RemoveCart | 4 - Back");
            Console.ForegroundColor = color;
        }

        public void Start()
        {
            bool running = true;
            while (running)
            {
                GetCarts();
                ShowMenu();
                int command = InputHelper.GetCommant();
                switch (command)
                {
                    case 1:
                        GetTimeTable();
                        break;
                    case 2:
                        ChangeTimeTable();
                        break;
                    case 3:
                        RemoveCart();
                        break;
                    case 4:
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
