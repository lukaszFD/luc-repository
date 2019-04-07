using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogModel;

namespace BlogData
{
    public class BlogRepository : IDisposable
    {
        private readonly BloggingContext db = new BloggingContext();

        public void Add(Blog blog)
        {
            db.Blogs.Add(blog);
            db.SaveChanges();
        }

        public IEnumerable<Blog> GetAll()
        {
            // LINQ query to fetch all Blogs from the database 
            var query = from b in db.Blogs
                        orderby b.Name
                        select b;

            return query.AsEnumerable().Select(item =>
                new Blog() { BlogId = item.BlogId, Name = item.Name }
            );
        }

        public void Dispose()
        {
            // Clean up resources
            db.Dispose();
        }

    }
}
