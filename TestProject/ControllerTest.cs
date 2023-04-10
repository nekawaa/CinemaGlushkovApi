
using CinemaGlushkovApi.Controllers;
using CinemaGlushkovApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace TestProject
{
    [TestClass]
    public class MoviesControllerTest
    {
        private MoviesController _controller;
        private DbContextOptionsBuilder<CinemaGlushkovContext> _optionsBuilder;
        private CinemaGlushkovContext _dbContext;

        [TestInitialize]
        public void Setup()
        {
            _optionsBuilder = new DbContextOptionsBuilder<CinemaGlushkovContext>()
                .UseInMemoryDatabase(databaseName: "MoviesTestDb");
            _dbContext = new CinemaGlushkovContext(_optionsBuilder.Options);
            _controller = new MoviesController(_dbContext);
        }
        [TestMethod]
        public async Task GetMovie_ReturnsMovieWithGivenId()
        {
            // Arrange
            var movie = new Movie { IdMovie = 6, MovieName = "Movie 6" };
            _dbContext.Movies.Add(movie);
            await _dbContext.SaveChangesAsync();

            // Act
            var result = await _controller.GetMovie(movie.IdMovie);

            // Assert
            Assert.AreEqual(movie.IdMovie, result.Value.IdMovie);
        }
        [TestMethod]
        public async Task DeleteMovie_ReturnsNoContent_WhenMovieIsDeleted()
        {
            // Arrange
            var movie = new Movie { IdMovie = 7, MovieName = "Большой куш" };
            _dbContext.Movies.Add(movie);
            await _dbContext.SaveChangesAsync();

            // Act
            var result = await _controller.DeleteMovie(movie.IdMovie);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NoContentResult));
        }

        [TestMethod]
        public async Task DeleteMovie_ReturnsNotFound_WhenMovieWithGivenIdDoesNotExist()
        {
            // Arrange
            var movie = new Movie { IdMovie = 1, MovieName = "Большой куш" };
            _dbContext.Movies.Add(movie);
            await _dbContext.SaveChangesAsync();

            // Act
            var result = await _controller.DeleteMovie(2);

            // Assert
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }           
    }
   
}