using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;
using WebApiCore.Controllers;
using WebApiCore.DTO;
using WebApiCore.Models;
using WebApiCore.Repositroy;

namespace WebApiCore_Test.Controller
{
    [TestClass]
    public class BindingControllerTest
    {
        [TestInitialize]
        public void Init()
        {

        }

        [TestCleanup]
        public void TestCleanup()
        {

        }

        [TestMethod]
        public void QueryProducts_Should_Return_Product()
        {
            var fakeProductRepository = Substitute.For<IProductRepository>();

            var expected = new Product { ProductID = 100, ProductName = "FakeProduct" };
            fakeProductRepository.GetProductById(Arg.Any<QueryDto>()).Returns(expected);

            var controller = new BindingController(fakeProductRepository);

            var queryDto = new QueryDto { ProductId = 100 };
            var actual = controller.QueryProducts(queryDto);

            actual.Should().BeEquivalentTo(expected);
        }
    }
}
