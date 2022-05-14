using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhotoAlbum.Model
{
    public class UserAlbums
    {
        public int userId { get; set; }
        public List<AlbumModel> albumList { get; set; }        
    }

    public class AlbumModel
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public List<PhotoModel> PhotoModelList { get; set; }

    }

    public class PhotoModel
    {
        public int albumId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string url { get; set; }
        public string thumbnailUrl { get; set; }
    }
}
