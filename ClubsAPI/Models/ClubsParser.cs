using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entities.Clubs;
using Entities.TimeTables;

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

        public static Club GetClub(ClubModel model)
        {
            Club club = new LocClub(model.Name, model.Location, new TimeTable(model.Table_Id, model.Table));
            club.Id = model.Id;
            return club;
        }

        public static void ChangeClubInfo(Club club, ClubModel model)
        {
            Club newClub = new LocClub(model.Name, model.Location, new TimeTable(model.Table_Id, model.Table));
            LocClub locClub = club as LocClub;
            LocClub newLocClub = newClub as LocClub;
            locClub.Location = newLocClub.Location;
            locClub.Name = newLocClub.Name;
        }
    }
}