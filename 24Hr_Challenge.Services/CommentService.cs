using _24Hr_Challenge.Data;
using _24Hr_Challenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hr_Challenge.Services
{
    public class CommentService
    {
        private readonly int _commentId;
        private readonly Guid _author;

        public CommentService(int commentId)
        {
            _commentId = commentId;
        }


        public CommentService(Guid author)
        {
            _author = author;
        }

        public bool CreateComment(CommentCreate comment)
        {
            var entity = new Comment()
            {
                Id = _commentId,
                Text = comment.Text,
                Author = _author
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<CommentList> GetComments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query = ctx
                    .Comments
                    .Where(e => e.Author == _author)
                    .Select
                    (e => new CommentList
                    {
                        Id = e.Id,
                        Text = e.Text,
                    }
                    );
                return query.ToArray();
            }
        }

        public CommentDetail GetCommentByPostId(Post id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                ctx.Comments.Single(e => e.Post == id && e.Author == _author);
                return new CommentDetail
                {
                    Id = entity.Id,
                    Text = entity.Text
                };
            }
        }
    }
}
