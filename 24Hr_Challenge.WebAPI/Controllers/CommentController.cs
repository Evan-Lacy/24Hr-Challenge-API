using _24Hr_Challenge.Data;
using _24Hr_Challenge.Models;
using _24Hr_Challenge.Services;
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

        public IHttpActionResult Get(Post postId)
        {
            CommentService commentService = CreateCommentService();
            var comments = commentService.GetCommentByPostId(postId);
            return Ok(comments);
        }

        public IHttpActionResult Post(CommentCreate comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var service = CreateCommentService();

            if (!service.CreateComment(comment))
            {
                return InternalServerError();
            }

            return Ok();
        }
    }
}
