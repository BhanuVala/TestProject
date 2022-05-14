using System;
using Xunit;
using PhotoAlbum.Services;
using PhotoAlbum.Controllers;
using PhotoAlbum.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace PhotoAlbumWebAPITests
{
    public class PhotoAlbumContollerTest
    {
        PhotoAlbumController _controller;
        IPhotoAlbumService _service;

        public PhotoAlbumContollerTest()
        {
            _service = new PhotoAlbumService();
            _controller = new PhotoAlbumController(_service);

        }

        [Fact]
        public void GetAllTest()
        {
            //Arrange
            //Act
            var result = _controller.GetUserAlbums();

            //Assert
            Assert.IsType<OkObjectResult>(result.Result);

            var list = result.Result as OkObjectResult;

            Assert.IsType<List<UserAlbums>>(list.Value);
                
            Assert.NotNull(list.Value);
        }

        [Fact]
        public void GetByIdTest()
        {
            //Arrange
            //Act
            var result = _controller.GetUserPhotoAlbum(1);
            //Assert
            Assert.IsType<OkObjectResult>(result.Result);

            var list = result.Result as OkObjectResult;

            Assert.IsType<UserAlbums>(list.Value);

            Assert.NotNull(list.Value);
        }
    }
}
