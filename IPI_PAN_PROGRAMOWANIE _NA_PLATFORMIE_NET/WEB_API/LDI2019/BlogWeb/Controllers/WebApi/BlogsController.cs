using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using BlogData;
using BlogModel;


namespace BlogWeb.Controllers.WebApi
{
    public class BlogsController : ApiController
    {
        public IEnumerable<Blog> GetAllBlogs()
        {
            using (var repository = new BlogRepository())
            {
                return repository.GetAll().ToList();
            }
        }
    }
}