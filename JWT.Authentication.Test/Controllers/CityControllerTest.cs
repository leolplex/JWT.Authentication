
using Moq;
using System.Collections.Generic;
using System.Linq;
using JWTAuthentication;
using JWTAuthentication.Controllers;
using JWTAuthentication.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Text.Json;

namespace JWT.Authentication.Test
{
    [TestFixture]
    public class CityControllerTest
    {
        private CityController _cityController;
        private Mock<ApplicationDbContext> _mockApplicationDbContext;

        [Test]
        public void GivenUserHasNotCities_whenGetAllCities_thenReturnOkNoCountryCitiesCreatedAsYet()
        {
            // Arrange
            _mockApplicationDbContext = new Mock<ApplicationDbContext>();
            _cityController = new CityController(_mockApplicationDbContext.Object);


            // Act
            var result = _cityController.GetAllCities("leolplex@gmail.com");
            var okResult = result as OkObjectResult;

            // Assert
            Assert.AreEqual("No Country-Cities created as yet.", okResult.Value);
            Assert.AreEqual(200, okResult.StatusCode);
        }


        [Test]
        public void GivenUserHasNotCitiesAndExist_whenGetAllCities_thenReturnNotFound()
        {
            // Arrange

            var data = new List<CountryInfo>
            {
                new CountryInfo { Id=1, Country = "Colombia", City = "Bogota", Email = "leolplex@gmail.com", Isfavourite = true },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<CountryInfo>>();
            mockSet.As<IQueryable<CountryInfo>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<CountryInfo>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<CountryInfo>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<CountryInfo>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());


            _mockApplicationDbContext = new Mock<ApplicationDbContext>();
            _mockApplicationDbContext.Setup(c => c.CountryInfos).Returns(mockSet.Object);

            _cityController = new CityController(_mockApplicationDbContext.Object);


            // Act
            var result = _cityController.GetAllCities("notfound@gmail.com");
            var notFoundResult = result as NotFoundObjectResult;

            // Assert
            Assert.AreEqual("No records against this UserEmailnotfound@gmail.com", notFoundResult.Value);
            Assert.AreEqual(404, notFoundResult.StatusCode);
        }


        [Test]
        public void GivenUserHasCities_whenGetAllCities_thenReturnOk()
        {
            // Arrange
            var data = new List<CountryInfo>
            {
                new CountryInfo { Id=1, Country = "Colombia", City = "Bogota", Email = "leolplex@gmail.com", Isfavourite = true },
            }.AsQueryable();

            var mockSet = new Mock<DbSet<CountryInfo>>();
            mockSet.As<IQueryable<CountryInfo>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<CountryInfo>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<CountryInfo>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<CountryInfo>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());


            _mockApplicationDbContext = new Mock<ApplicationDbContext>();
            _mockApplicationDbContext.Setup(c => c.CountryInfos).Returns(mockSet.Object);

            _cityController = new CityController(_mockApplicationDbContext.Object);


            // Act
            var result = _cityController.GetAllCities("leolplex@gmail.com");
            var okResult = result as OkObjectResult;

            // Assert            
            var expected = new[] { new
            {
                City = "Bogota",
                Email = "leolplex@gmail.com",
                Isfavourite = true
            }};

            string expectedJsonString = JsonSerializer.Serialize(expected);
            string actualJsonString = JsonSerializer.Serialize(okResult.Value);

            Assert.AreEqual(expectedJsonString, actualJsonString);
            Assert.AreEqual(200, okResult.StatusCode);
        }

    }
}