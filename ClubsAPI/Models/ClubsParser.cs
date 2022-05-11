using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entities.Clubs;

namespace ClubsAPI.Models
{
    public class ClubsParser
    {
        public static IQueryable<ClubModel> GetClubsModel(IQueryable<Club> clubs)
        {
            List<ClubModel> clubModels = new List<ClubModel>();
            foreach(var club in clubs)
            {
                clubModels.Add(new ClubModel(club));
            }
            return clubModels.AsQueryable<ClubModel>();
        }

        public static ClubModel GetClubModel(Club club)
        {
            return new ClubModel(club);
        }
    }
}