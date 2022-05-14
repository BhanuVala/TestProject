using PhotoAlbum.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PhotoAlbumWebAPITests
{
    public class ModelTests
    {
        UserAlbums albums = new UserAlbums();
        List<PhotoModel> photomodelList = new List<PhotoModel>();


        [Fact]
        public void AlbumModelTest()
        {
            //Arrange
            albums.albumList = new List<AlbumModel>();
            //Act
            albums.userId = 1;
            photomodelList.Add(new PhotoModel
            {
                id = 1,
                title = "terus",
                albumId = 1,
                url = "https://via.placeholder.com/600/bee5c2",
                thumbnailUrl = "https://via.placeholder.com/150/bee5c2"
            });

            albums.albumList.Add(new AlbumModel
            {
                id = 1,
                title = "terus",
                PhotoModelList = photomodelList
            });

            //Assert

            Assert.NotNull(albums);
            
        }
    }
}
