using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Clubs
{
    public class ClubException : Exception
    {
        public ClubException(string message) : base(message)
        {
        }
    }
}
