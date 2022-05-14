using PhotoAlbum.Model;
using PhotoAlbum.Helper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PhotoAlbum.Services
{
    /// <summary>
    /// PhotoAlbumService
    /// </summary>
    public class PhotoAlbumService : IPhotoAlbumService
    {
        private readonly IAdapter _restAdapter;

        /// <summary>
        /// PhotoAlbumService Constructor
        /// </summary>
        public PhotoAlbumService()
        {
            _restAdapter = new RestAdapter();
        }

        /// <summary>
        /// GetAlbumData
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<UserAlbums> GetAlbumData(int userId = 0)
        {
            List<PhotoModel> photoModelList = new List<PhotoModel>();
            List<AlbumModel> albumModelList = new List<AlbumModel>();
            List<AlbumModel> model = new List<AlbumModel>();
            List<UserAlbums> userAlbums = new List<UserAlbums>();

            try
            {
                var response = _restAdapter.Execute("http://jsonplaceholder.typicode.com/Albums", "GET");
                var response1 = _restAdapter.Execute("http://jsonplaceholder.typicode.com/Photos", "GET");

                //De-serialize Response Object & return
                albumModelList = JsonHelper.JsonDeserialize<List<AlbumModel>>(response.Content);
                photoModelList = JsonHelper.JsonDeserialize<List<PhotoModel>>(response1.Content);

                if ((albumModelList != null && albumModelList.Count > 0) && (photoModelList != null && photoModelList.Count > 0))
                {
                    List<AlbumModel> albumnUserList = new List<AlbumModel>();

                    if (userId != 0)
                    {
                        albumModelList = albumModelList.Where(j => j.userId == userId).ToList();
                    }

                    //Fetch the distinct user list.
                    var useridList = albumModelList.Select(x => x.userId).Distinct().ToList();

                    userAlbums = GetAlbumPhotos(useridList, photoModelList, albumModelList);

                    return userAlbums;
                }

                else
                {
                    return null;
                }
                
            }
            catch (Exception webException)
            {
                throw new Exception(webException.Message);
            }
        }

        /// <summary>
        /// Get Album Photos
        /// </summary>
        /// <param name="albumIdList"></param>
        /// <param name="photoModelList"></param>
        /// <param name="albumModelList"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        private List<UserAlbums> GetAlbumPhotos(List<int> useridList, List<PhotoModel> photoModelList, List<AlbumModel> albumModelList, int userId = 0)
        {

            List<UserAlbums> userAlbums = new List<UserAlbums>();           

            // Looping through each user fetch the album list with photolist
            foreach (var user in useridList)
            {
                UserAlbums userAlbum = new UserAlbums();
                userAlbum.userId = user;

                userAlbum.albumList = new List<AlbumModel>();

                userAlbum.albumList = albumModelList.Where(x => x.userId == user).ToList();

                foreach (AlbumModel album in userAlbum.albumList)
                {
                    album.PhotoModelList = new List<PhotoModel>();
                    album.PhotoModelList = photoModelList.Where(x => x.albumId == album.id).ToList();
                }

                userAlbums.Add(userAlbum);

            }

            return userAlbums;
        }

    }
}
