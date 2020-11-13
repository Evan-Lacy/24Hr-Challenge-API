using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _24Hr_Challenge.WebAPI.Controllers
{
    public class CommentController : ApiController
    {
        private CommentService CreateCommentService()
        {
            var author = Guid.Parse(User.Identity.GetUserId());
            var commentService = new CommentService(author);
            return commentService;
        }

        public IHttpActionResult Get()
        {
            CommentService commentService = CreateCommentService();
            var comments = commentService.GetComments();
            return Ok(comments);
        }

        public IHttpActionResult Get(int postId)
        {
            CommentService commentService = CreateCommentService();
            var comments = commentService.GetCommentByPostId(postId);
            return Ok(comments);
        }
    }
}
