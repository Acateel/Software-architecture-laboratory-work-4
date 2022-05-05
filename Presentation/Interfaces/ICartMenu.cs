using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Interfaces
{
    interface ICartMenu
    {
        void ShowMenu();
        void Start();

        void GetCarts();
        void GetTimeTable();

        void ChangeTimeTable();

        void RemoveCart();
    }
}
