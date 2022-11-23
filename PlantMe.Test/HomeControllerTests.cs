
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using Microsoft.Extensions.Logging;

using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Plantme.Controllers;
using Xunit;

namespace PlantMe_Tests
{
    
        
        [TestClass()]
        public class HomeControllerTests
        {


        [Fact]
        public void IndexTest()
            {

                var logger = Mock.Of<ILogger<HomeController>>();
                var controller = new HomeController(logger);

                var result = controller.Index();

                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(result);
            
            }

        [Fact]
        public void PrivacyTest()
            {

                var logger = Mock.Of<ILogger<HomeController>>();

                var controller = new HomeController(logger);


                var result = controller.Privacy();
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(result);
           
            }


        }

    
}
