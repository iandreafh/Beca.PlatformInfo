
using Microsoft.AspNetCore.Mvc;
using PlatformInfo.API.Entities;
using PlatformInfo.API.Models;
using PlatformInfo.API.Controllers;
using PlatformInfo.API.Services;
using PlatformInfo.API.Profiles;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace PlatformsTest
{
    public class PlatformsTest
    {
        private PlatformsController platformsController;

        public PlatformsTest()
        {
            var platformInfoMock = new Mock<IPlatformInfoRepository>();
            platformInfoMock.Setup(m => m.GetPlatformsAsync())
                .ReturnsAsync(new List<Platform>() {
                    new Platform("Nombre1")
                    {
                        Id = 1
                    }
                });

            var mapperConf = new MapperConfiguration(cfg => cfg.AddProfile<PlatformProfile>());
            var mapper = new Mapper(mapperConf);

            platformsController = new PlatformsController(platformInfoMock.Object, mapper);
        }

            [Fact]
        // Compruebo que el title no tenga mas de 50 caracteres
        public void checkLength_PlatformTitle()
        {
            // Arrange
            PlatformDto plataforma = new PlatformDto()
            {
                Title = "Titulo de prueba",
                Description = "Texto descriptivo de prueba"
            };

            // Act
            var length = plataforma.Description.Length;

            // Assert
            Assert.True(length <= 50);
        }

        [Fact]
        // Compruebo que la description no tenga mas de 300 caracteres
        public void checkLength_PlatformDescription()
        {
            // Arrange
            PlatformDto plataforma = new PlatformDto()
            {
                Title = "Titulo de prueba",
                Description = "Texto descriptivo de prueba"
            };

            // Act
            var length = plataforma.Description.Length;

            // Assert
            Assert.True(length <= 300);
        }

        [Fact]
        public async Task GetPlatform_ReturnOk()
        {
            // Arrange
            // Id de la plataforma creada de mock data
            int platformId = 1;

            // Act
            var platform = await platformsController.GetPlatform(platformId);


            // Assert
            Assert.NotNull(platform);
        }

        [Fact]
        public async Task GetPlatform_ReturnNotFound()
        {
            // Arrange
            int notExistingId = 3;

            // Act
            //Intento buscar una plataforma con id no existente
            var platform = await platformsController.GetPlatform(notExistingId);

            // Assert
            Assert.IsType<NotFoundResult>(platform);
        }
        
    }
}