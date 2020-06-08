using GameShowApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GameShowApiTest
{
    [TestClass]
    public class GameShowControllerTest
    {
        [TestMethod]
        public void NotSwitchingDoorsIsCorrectLessThanFourtyPercent()
        {

            var controller = new GameShowController();

            bool switchDoors = false;
            var result = controller.Get(3000, switchDoors);

            Assert.IsTrue(result.Value < 1200);
        }

        [TestMethod]
        public void SwitchingDoorsIsCorrectMoreThanSixtyPercent()
        {

            var controller = new GameShowController();

            bool switchDoors = true;
            var result = controller.Get(3000, switchDoors);


            Assert.IsTrue(result.Value > 1800);
        }


        [TestMethod]
        public void ValueBelowRangeIsInvalid()
        {

            var controller = new GameShowController();
            controller.ModelState.AddModelError("NumberOfSimulations", "OutOfRange");

            bool switchDoors = true;
            var result = controller.Get(0, switchDoors);

            Assert.IsInstanceOfType(result.Result, typeof(BadRequestObjectResult));
        }

        [TestMethod]
        public void ValueAboveRangeIsInvalid()
        {

            var controller = new GameShowController();

            bool switchDoors = true;
            var result = controller.Get(100001, switchDoors);

            Assert.IsInstanceOfType(result.Result, typeof(BadRequestObjectResult));
        }
    }
}
