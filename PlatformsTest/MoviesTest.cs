
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PlatformInfo.API.Controllers;
using PlatformInfo.API.Entities;
using PlatformInfo.API.Models;
using PlatformInfo.API.Services;
using PlatformInfo.API.Profiles;
using System;

namespace PlatformsTest
{
    public class MoviesTest
    {

        private readonly PlatformsController platformsController;
        private readonly MoviesController moviesController;

        public MoviesTest()
        {
            var platformInfoMock = new Mock<IPlatformInfoRepository>();
            platformInfoMock.Setup(m => m.GetPlatformsAsync())
                .ReturnsAsync(new List<Platform>() {
                    new Platform("Nombre1")
                    {
                        Id = 1
                    }
                });

            platformInfoMock.Setup(m => m.GetMoviesForPlatformAsync(1))
                .ReturnsAsync(new List<Movie>() {
                    new Movie("Pelicula1")
                    {
                        Id = 1
                    }
                });


            var mapperConf = new MapperConfiguration(cfg => cfg.AddProfile<PlatformProfile>());
            var mapper = new Mapper(mapperConf);
            var loggerMock = new Mock<ILogger<MoviesController>>();
            var mailService = new Mock<IMailService>();

            platformsController = new PlatformsController(platformInfoMock.Object, mapper);
            moviesController = new MoviesController(loggerMock.Object, mailService.Object, platformInfoMock.Object, mapper);
        }


        [Fact]
        // Compruebo que el title no tenga mas de 50 caracteres
        public void checkLength_MovieTitle()
        {
            // Arrange
            MovieForCreationDto movie = new MovieForCreationDto()
            {
                Title = "Titulo de prueba",
                Description = "Texto descriptivo de prueba"
            };

            // Act
            var length = movie.Title.Length;

            // Assert
            Assert.True(length <= 50);
        }

        [Fact]
        // Compruebo que la description no tenga mas de 300 caracteres
        public void checkLength_MovieDescription()
        {
            // Arrange
            MovieForCreationDto movie = new MovieForCreationDto()
            {
                Title = "Titulo de prueba",
                Description = "Texto descriptivo de prueba"
            };

            // Act
            var length = movie.Description.Length;

            // Assert
            Assert.True(length <= 300);
        }




        [Fact]
        // Busco plataforma con id creado en mock data
        public async Task GetMovie_ReturnOk()
        {
            // Arrange
            int platformId = 1;
            int movieId = 1;

            // Act
            var movie = await moviesController.GetMovie(platformId, movieId);


            // Assert
            Assert.NotNull(movie);
        }

        [Fact]
        // Busco plataforma con id no existente en mock data
        public async Task GetMovie_TitleOk()
        {
            // Arrange
            MovieForCreationDto newMovie = new MovieForCreationDto() { Title = "Prueba" };

            // Assert
            Assert.Equal("Prueba", newMovie.Title);
        }

    }
}