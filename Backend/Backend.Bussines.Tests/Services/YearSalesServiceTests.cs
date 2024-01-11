using Backend.Business.Repositories;
using Backend.Business.Services;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Bussines.Tests.Services
{
    public class YearSalesServiceTests
    {
        private readonly YearSalesService sut;
        private readonly Mock<IYearSalesRepository> yearSalesRepository;

        public YearSalesServiceTests()
        {
            yearSalesRepository = new Mock<IYearSalesRepository>(MockBehavior.Strict);
            sut = new YearSalesService(yearSalesRepository.Object);
        }

        [Theory]
        [InlineData(1, 123)]
        public async Task GetYearSalesList_ShouldRetunRepositoryList(int? maxTotal, int? minTimeToShipInDays)
        {
            // Arrange
            var result = new YearSalesModel[0];
            yearSalesRepository.Setup(_ => _.GetYearSalesList(maxTotal, minTimeToShipInDays)).ReturnsAsync(result);

            // Act
            var actualResult = await sut.GetYearSalesList(maxTotal, minTimeToShipInDays);

            // Assert
            Assert.Equal(result, actualResult);
            yearSalesRepository.VerifyAll();
        }

    }
}
