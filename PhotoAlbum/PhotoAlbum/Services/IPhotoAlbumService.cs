using PhotoAlbum.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoAlbum.Services
{
    /// <summary>
    /// IPhotoAlbumService
    /// </summary>
    public interface IPhotoAlbumService
    {
        /// <summary>
        /// GetAlbumData
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>

        List<UserAlbums> GetAlbumData(int userId = 0);

     }
}
