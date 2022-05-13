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
using Entities.Carts;
using Entities.TimeTables;
using Entities.Timers;
using BusinessLogic.Interfaces;

namespace TestingBussinesLogic
{
    public class TestClubLogic
    {
        [Fact]
        public void BuyClubCart()
        {
            // Arrange
            var cartMock = new Mock<ICartRepository>();
            var clubMock = new Mock<IClubRepository>();
            Club club = new LocClub();
            ClubLogic logic = new ClubLogic(clubMock.Object, cartMock.Object);
            logic.Club = club;

            // Act
            var cart = logic.BuyClubCart(new TimeTable());

            // Assert
            Assert.True(cart is ClubCart);
            cartMock.Verify(t => t.Insert(cart));
            cartMock.Verify(t => t.Save());
        }

        [Fact]
        public void BuySpecialCart()
        {
            // Arrange
            var cartMock = new Mock<ICartRepository>();
            var clubMock = new Mock<IClubRepository>();
            Club club = new LocClub();
            ClubLogic logic = new ClubLogic(clubMock.Object, cartMock.Object);
            logic.Club = club;

            // Act
            var cart = logic.BuySpecialCart(new TimeTable());

            // Assert
            Assert.True(cart is SpecialCart);
            cartMock.Verify(t => t.Insert(cart));
            cartMock.Verify(t => t.Save());
        }

        [Fact]
        public void ChangeInfo()
        {
            // Arrange
            var cartMock = new Mock<ICartRepository>();
            var clubMock = new Mock<IClubRepository>();
            Club club = new LocClub();
            ClubLogic logic = new ClubLogic(clubMock.Object, cartMock.Object);

            // Act
            logic.ChangeInfo(club);

            // Assert
            clubMock.Verify(t => t.Update(club));
            clubMock.Verify(t => t.Save());
        }

        [Fact]
        public void GetClubInfo()
        {
            // Arrange
            var cartMock = new Mock<ICartRepository>();
            var clubMock = new Mock<IClubRepository>();
            Club club = new LocClub("None", "None", new TimeTable());
            ClubLogic logic = new ClubLogic(clubMock.Object, cartMock.Object);
            logic.Club = club;

            // Act
            string line = logic.GetClubInfo();

            // Assert
            Assert.Equal(club.ToString(), line);
        }

        [Fact]
        public void SingUp_Without_Cart()
        {
            // Arrange
            var cartMock = new Mock<ICartRepository>();
            var clubMock = new Mock<IClubRepository>();
            Club club = new LocClub();
            ClubLogic logic = new ClubLogic(clubMock.Object, cartMock.Object);
            logic.Club = club;
            int time = 15; // random time

            // Act
            Cart cart = logic.SingUp(time);

            // Assert
            Assert.True(cart is TempCart);
            cartMock.Verify(t => t.Insert(cart));
            cartMock.Verify(t => t.Save());
        }

        [Fact]
        public void SingUp_With_Cart_return_true()
        {
            // Arrange
            var cartMock = new Mock<ICartRepository>();
            var clubMock = new Mock<IClubRepository>();
            Club club = new LocClub();
            ClubLogic logic = new ClubLogic(clubMock.Object, cartMock.Object);
            logic.Club = club;
            int time = 15; // random time
            Cart cart = club.BuyClubCart(new TimeTable());

            // Act
            bool singing = logic.SingUp(cart, time);

            // Assert
            Assert.True(singing);
            Assert.True(cart.Table.IsTimeTemporary(time));
            cartMock.Verify(t => t.Update(cart));
            cartMock.Verify(t => t.Save());
        }

        [Fact]
        public void SingUp_With_Cart_return_false()
        {
            // Arrange
            var cartMock = new Mock<ICartRepository>();
            var clubMock = new Mock<IClubRepository>();
            Club club = new LocClub();
            ClubLogic logic = new ClubLogic(clubMock.Object, cartMock.Object);
            logic.Club = club;
            int time = 15; // random time
            Cart cart = club.BuyClubCart(new TimeTable());
            cart.Table.SetConsonant(time);

            // Act
            bool singing = logic.SingUp(cart, time);

            // Assert
            Assert.False(singing);
            Assert.False(cart.Table.IsTimeTemporary(time));
        }

        [Fact]
        public void VisitClub_without_cart()
        {
            // Arrange
            var cartMock = new Mock<ICartRepository>();
            var clubMock = new Mock<IClubRepository>();
            Club club = new LocClub();
            ClubLogic logic = new ClubLogic(clubMock.Object, cartMock.Object);
            logic.Club = club;

            // Act & Assert
            Assert.Throws<ClubException>(() => logic.VisitClub());
        }

        [Fact]
        public void VisitClub_with_ClubCart_return_true()
        {
            // Arrange
            var cartMock = new Mock<ICartRepository>();
            var clubMock = new Mock<IClubRepository>();
            Club club = new LocClub("None", "None", new TimeTable());
            ClubLogic logic = new ClubLogic(clubMock.Object, cartMock.Object);
            logic.Club = club;
            int time = 15; // random time
            Cart cart = club.BuyClubCart(new TimeTable());
            cart.Table.SetConsonant(time);
            ClasicTimer.setTime(time);

            // Act
            bool visiting = logic.VisitClub(cart);

            // Assert
            Assert.True(visiting);
        }

        [Fact]
        public void VisitClub_with_ClubCart_return_false()
        {
            // Arrange
            var cartMock = new Mock<ICartRepository>();
            var clubMock = new Mock<IClubRepository>();
            int time = 15; // random time
            Club club = new LocClub("None", "None", new TimeTable());
            club.Table.SetConsonant(time);
            ClubLogic logic = new ClubLogic(clubMock.Object, cartMock.Object);
            logic.Club = club;
            Cart cart = club.BuyClubCart(new TimeTable());
            cart.Table.SetConsonant(time);
            ClasicTimer.setTime(time);

            // Act
            bool visiting = logic.VisitClub(cart);

            // Assert
            Assert.False(visiting);
        }

        [Fact]
        public void VisitClub_with_SpecialCart_return_true()
        {
            // Arrange
            var cartMock = new Mock<ICartRepository>();
            var clubMock = new Mock<IClubRepository>();
            int time = 15; // random time
            Club club = new LocClub("None", "None", new TimeTable());
            ClubLogic logic = new ClubLogic(clubMock.Object, cartMock.Object);
            logic.Club = club;
            Cart cart = club.BuySpecialCart(new TimeTable());
            cart.Table.SetConsonant(time);
            ClasicTimer.setTime(time);

            // Act
            bool visiting = logic.VisitClub(cart);

            // Assert
            Assert.True(visiting);
        }

        [Fact]
        public void VisitClub_with_SpecialCart_return_false()
        {
            // Arrange
            var cartMock = new Mock<ICartRepository>();
            var clubMock = new Mock<IClubRepository>();
            int time = 15; // random time
            Club club = new LocClub("None", "None", new TimeTable());
            ClubLogic logic = new ClubLogic(clubMock.Object, cartMock.Object);
            logic.Club = club;
            Club otherClub = new LocClub(null, "Other", new TimeTable());
            Cart cart = otherClub.BuySpecialCart(new TimeTable());
            cart.Table.SetConsonant(time);
            ClasicTimer.setTime(time);

            // Act
            bool visiting = logic.VisitClub(cart);

            // Assert
            Assert.False(visiting);
        }

        [Fact]
        public void VisitClub_with_TempCart_return_true()
        {
            // Arrange
            var cartMock = new Mock<ICartRepository>();
            var clubMock = new Mock<IClubRepository>();
            int time = 15; // random time
            Club club = new LocClub("None", "None", new TimeTable());
            ClubLogic logic = new ClubLogic(clubMock.Object, cartMock.Object);
            logic.Club = club;
            Cart cart = club.SingUp(time);
            cart.Table.SetConsonant(time);
            ClasicTimer.setTime(time);

            // Act
            bool visiting = logic.VisitClub(cart);

            // Assert
            Assert.True(visiting);
            cartMock.Verify(t => t.Delete(cart.Id));
            cartMock.Verify(t => t.Save());
        }
    }
}
