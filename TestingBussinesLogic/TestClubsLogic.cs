using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using BusinessLogic.Servises;
using UnitOfWork.Interfaces;
using Entities.Clubs;
using BusinessLogic.Interfaces;

namespace TestingBussinesLogic
{
    public class TestClubsLogic
    {
        [Fact]
        public void GetClubs()
        {
            // Arrange
            var clubRepositoryMock = new Mock<IClubRepository>();
            var clubLogicMock = new Mock<IClubLogic>();
            List<Club> clubs = new List<Club>();
            clubs.Add(new LocClub());
            clubRepositoryMock.Setup(a => a.GetAll()).Returns(clubs.AsQueryable<Club>());
            var logic = new ClubsLogic(clubRepositoryMock.Object, clubLogicMock.Object);

            // Act
            var list = logic.GetClubs();

            // Assert
            Assert.Equal(1, list.Count());
        }

        [Fact]
        public void CreateClub()
        {
            // Arrange
            var clubRepositoryMock = new Mock<IClubRepository>();
            var clubLogicMock = new Mock<IClubLogic>();
            Club club = new LocClub();
            var logic = new ClubsLogic(clubRepositoryMock.Object, clubLogicMock.Object);

            // Act
            logic.CreateClub(club);

            // Assert
            clubRepositoryMock.Verify(t => t.Insert(club));
            clubRepositoryMock.Verify(t => t.Save());
        }

        [Fact]
        public void DeleteClub()
        {
            // Arrange
            var clubRepositoryMock = new Mock<IClubRepository>();
            var clubLogicMock = new Mock<IClubLogic>();
            int id = 5;
            var logic = new ClubsLogic(clubRepositoryMock.Object, clubLogicMock.Object);

            // Act
            logic.DeleteClub(id);

            // Assert
            clubRepositoryMock.Verify(t => t.Delete(id));
            clubRepositoryMock.Verify(t => t.Save());
        }

        [Fact]
        public void SetClub()
        {
            // Arrange
            var clubRepositoryMock = new Mock<IClubRepository>();
            var clubLogicMock = new Mock<IClubLogic>();
            int id = 5;
            Club club = new LocClub();
            clubRepositoryMock.Setup(a => a.Get(id)).Returns(club);
            var logic = new ClubsLogic(clubRepositoryMock.Object, clubLogicMock.Object);

            // Act
            var result = logic.SetClub(id);

            // Assert
            Assert.Equal(club, result);            
        }
    }
}
