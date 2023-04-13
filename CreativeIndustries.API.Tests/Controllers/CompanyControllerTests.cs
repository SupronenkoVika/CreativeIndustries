using CreativeIndustries.API.Controllers;
using CreativeIndustries.DS.Contracts;
using CreativeIndustries.DS.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CreativeIndustries.API.Tests.Controllers
{
    public class CompanyControllerTests
    {
        private readonly Mock<ICompanyService> _mock;
        private readonly CompanyController _controller;

        public CompanyControllerTests()
        {
            _mock = new Mock<ICompanyService>();
            /*_controller = new CompanyController(_mock.Object);*/ // how to pass all parameters and whether it is necessary
        }

        [Fact]
        public void CompanyIndex_ActionExecutes_ReturnsViewForIndex()
        {
            var result = _controller.CompanyIndex();
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void CompanyIndex_ActionExecutes_ReturnsExactNumberOfCompanies()
        {
            //Arrange
            _mock.Setup(s => s.GetList<Company>())
                .Returns(new List<Company>() { new Company(), new Company() });

            //Act
            var result = _controller.CompanyIndex();

            //Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var companies = Assert.IsType<List<Company>>(viewResult.Model);
            Assert.Equal(2, companies.Count);
        }

        [Fact]
        public void Create_ActionExecutes_ReturnsViewForCreate()
        {
            var result = _controller.CreateCompany();
            Assert.IsType<ViewResult>(result);
        }


        // Doesn't work
        //[Fact]
        //public void Create_POST_CreateCompany()
        //{
        //    //Arrange
        //    var company = new CompanyViewModel()
        //    {
        //        Id = 1,
        //        CompanyName = "TestName",
        //        Description = "TestDescription"
        //    };
        //    _mock.Setup(x => x.Create(company));

        //    //Act
        //    _controller.CreateCompany(company);

        //    //Assert
        //    _mock.Verify(x => x.Create(company), Times.Exactly(1));
        //}
    }
}
