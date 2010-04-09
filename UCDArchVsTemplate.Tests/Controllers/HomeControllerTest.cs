using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcContrib.TestHelper;
using UCDArch.Testing;
using UCDArchVsTemplate.Controllers;
using System.Web.Routing;

namespace UCDArchVsTemplate.Tests.Controllers
{
    [TestClass]
    public class HomeControllerTest : ControllerTestBase<HomeController>
    {
        protected override void SetupController()
        {
            Controller = new HomeController();
        }

        protected override void RegisterRoutes()
        {
            RouteTable.Routes.Clear();
            RouteRegistrar.RegisterRoutesTo(RouteTable.Routes);
        }

        [TestMethod]
        public void Index()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            result.AssertViewRendered();
        }

        [TestMethod]
        public void About()
        {
            // Arrange
            var controller = new HomeController();

            // Act
            var result = controller.About() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void RootShouldMapToIndex()
        {
            "~/".ShouldMapTo<HomeController>(x => x.Index());
        }

        [TestMethod]
        public void AboutShouldRouteToHomeAbout()
        {
            "~/Home/About".ShouldMapTo<HomeController>(x => x.About());
        }

    }
}