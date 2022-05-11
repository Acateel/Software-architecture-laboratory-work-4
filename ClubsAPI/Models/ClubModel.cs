using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entities.Clubs;
using Entities.TimeTables;

namespace ClubsAPI.Models
{
    public class ClubModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int Table_Id { get; set; }
        public String Table { get; set; }
        

        public ClubModel()
        {
        }

        public ClubModel(Club club)
        {
            Id = club.Id;
            Table = club.Table.Table;
            Table_Id = club.Table.Id;
            if(club is LocClub)
            {
                var locClub = club as LocClub;
                Location = locClub.Location;
                Name = locClub.Name;
            }
        }
    }
}