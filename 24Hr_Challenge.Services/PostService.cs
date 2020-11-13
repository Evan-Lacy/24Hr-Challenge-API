using _24Hr_Challenge.Data;
using _24Hr_Challenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hr_Challenge.Services
{
    public class PostService
    {
        private readonly int _postId;
        private readonly Guid _author;

        public PostService(int postId)
        {
            _postId = postId;
        }


        public PostService(Guid author)
        {
            _author = author;
        }

        public bool CreatePost(PostCreate post)
        {
            var entity = new Post()
            {
                Id = _postId,
                Title = post.Title,
                Text = post.Text,
                Author = _author
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Posts.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<PostListItem> GetPosts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Posts
                    .Where(e => e.Author == _author)
                    .Select
                    (e => new PostListItem
                    {
                        PostId = e.Id,
                        Title = e.Title,
                    }
                    );
                return query.ToArray();
            }
        }

        public PostDetail GetPostById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                ctx.Posts.Single(e => e.Id == id && e.Author == _author);
                return new PostDetail
                {
                    PostId = entity.Id,
                    Title = entity.Title,
                    Text = entity.Text,
                    CreatedUtc = entity.CreatedUtc
                };
            }
        }


    }
}
