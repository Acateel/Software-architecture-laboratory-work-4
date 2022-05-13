using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Moq;
using BusinessLogic.Servises;
using UnitOfWork.Interfaces;
using Entities.Carts;
using Entities.TimeTables;

namespace TestingBussinesLogic
{
    public class TestCartLogic
    {
        [Fact]
        public void GetCarts()
        {
            // Arrange
            List<Cart> carts = new List<Cart>();
            carts.Add(new ClubCart());
            carts.Add(new SpecialCart());
            var mock = new Mock<ICartRepository>();
            mock.Setup(a => a.GetAll()).Returns(carts.AsQueryable<Cart>());
            CartLogic cartLogic = new CartLogic(mock.Object);
            
            // Act
            var result = cartLogic.GetCarts();
            
            // Assert
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public void GetCartWihtId()
        {
            // Arrange
            int id = 5;
            var mock = new Mock<ICartRepository>();
            CartLogic cartLogic = new CartLogic(mock.Object);

            // Act
            var cart = cartLogic.GetCart(id);

            // Assert
            mock.Verify(t => t.Get(id));
        }

        [Fact]
        public void ChangeTimeTable()
        {
            // Arrange
            
            var mock = new Mock<ICartRepository>();
            Cart cart = new ClubCart();
            cart.Table = new TimeTable(0, "");
            TimeTable table = new TimeTable();
            mock.Setup(a => a.Get(It.IsAny<int>())).Returns(cart);
            CartLogic cartLogic = new CartLogic(mock.Object);

            // Act
            cartLogic.ChangeTimeTable(0, table);

            // Assert
            Assert.Equal(cart.Table.Table, table.Table);
            mock.Verify(t => t.Update(cart));
            mock.Verify(t => t.Save());
        }

        [Fact]
        public void GetTimeTable()
        {
            // Arrange

            var mock = new Mock<ICartRepository>();
            Cart cart = new ClubCart();
            TimeTable table = new TimeTable();
            cart.Table = table;
            mock.Setup(a => a.Get(It.IsAny<int>())).Returns(cart);
            CartLogic cartLogic = new CartLogic(mock.Object);

            // Act
            var result = cartLogic.GetTimeTable(0);

            // Assert
            Assert.True(result.Equals(table));
        }

        [Fact]
        public void RemoveCart()
        {
            // Arrange
            int id = 5;
            var mock = new Mock<ICartRepository>();
            CartLogic cartLogic = new CartLogic(mock.Object);

            // Act
            cartLogic.RemoveCart(id);

            // Assert
            mock.Verify(t => t.Delete(id));
            mock.Verify(t => t.Save());
        }
    }
}
