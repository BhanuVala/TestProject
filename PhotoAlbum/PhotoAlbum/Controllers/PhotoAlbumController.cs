using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using PhotoAlbum.Filters;
using PhotoAlbum.Model;
using PhotoAlbum.Services;
using System.Linq;

namespace PhotoAlbum.Controllers
{
    [ApiExceptionFilter]
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoAlbumController : ControllerBase
    {
        private readonly IPhotoAlbumService _photoAlbumService;

        /// <summary>
        /// PhotoAlbumController constructor
        /// </summary>
        /// <param name="photoAlbumService"></param>
        public PhotoAlbumController(IPhotoAlbumService photoAlbumService)
        {
            _photoAlbumService = photoAlbumService;

        }
        // GET: api/PhotoAlbum
        [HttpGet]
        public ActionResult<IEnumerable<UserAlbums>> GetUserAlbums()
        {

            var data = _photoAlbumService.GetAlbumData();
            if(data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        // GET: api/PhotoAlbum/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult <UserAlbums> GetUserPhotoAlbum(int id)
        {
            List<UserAlbums> result = _photoAlbumService.GetAlbumData(id);
            var model = result.FirstOrDefault();
            
            if (result == null)
            {
                return NotFound();
            }
            return Ok(model);
        }

        [HttpGet]
        [Route("api/throw")]
        public object Throw()
        {
            throw new InvalidOperationException("This is an unhandled exception");
        }

    }
}
