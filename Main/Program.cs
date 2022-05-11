using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.TimeTables;
using Entities.Clubs;
using Entities.Carts;
using Entities;
using System.Data.Entity;
using UnitOfWork;
using UnitOfWork.Interfaces;
using UnitOfWork.UnitOfWorks.Interfaces;
using UnitOfWork.UnitOfWorks.Services;
using BusinessLogic;
using Presentation;
using Presentation.Servises;
using Ninject;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel();
            kernel.Bind<IUnitOfWork>().To<UnitOfWork.UnitOfWorks.Services.UnitOfWork>();
            var logic = kernel.Get<Logic>();

            MainMenu.Start(logic);
        }
    }
}
