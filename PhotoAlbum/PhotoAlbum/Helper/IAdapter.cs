using RestSharp;

namespace PhotoAlbum.Helper
{
    public interface IAdapter
    {
        /// <summary>
        /// Execute
        /// </summary>
        /// <param name="completeUrl"></param>
        /// <param name="methodType"></param>
        /// <returns></returns>
        IRestResponse Execute(string completeUrl, string methodType);
    }
}
