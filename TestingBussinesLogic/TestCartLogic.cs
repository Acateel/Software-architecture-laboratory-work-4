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
    }
}
