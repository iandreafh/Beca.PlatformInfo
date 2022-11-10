using Moq;
using PlatformInfo.API.Models;

namespace PlatformInfo.Test
{
    public class PlatformInfoTests
    {
        [Fact]
        public void CreateMovie_ConstructInternalMovie()
        {

            var platform = new PlatformDto();

            var movie = new MovieDto();
        }


        //Metodo con Mock
        [Fact]
        public async Task CreatePromotion_RequestPromotionForEligibleEmployee_MustPromoteEmployee()
        {
            // Arrange 
            var expectedMovieTitle = "Titulo de prueba";
            var currentJobLevel = 1;
            var promotionForCreationDto = new MovieForCreationDto()
            {
                Title = expectedEmployeeId
            };

            var employeeServiceMock = new Mock<IEmployeeService>();
            employeeServiceMock
                .Setup(m => m.FetchInternalEmployeeAsync(It.IsAny<Guid>()))
                .ReturnsAsync(
                    new InternalEmployee(
                        "Anna", "Johnson", 3, 3400, true, currentJobLevel)
                    {
                        Id = expectedEmployeeId,
                        SuggestedBonus = 500
                    });
        
        }
}