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
    public class PostController : ApiController
    {
        
        private PostService CreatePostService()
        {
            var author = Guid.Parse(User.Identity.GetUserId());
            var postService = new PostService(author);
            return postService;
        }

        public IHttpActionResult Get()
        {
            PostService postService = CreatePostService();
            var posts = postService.GetPosts();
            return Ok(posts);//200
        }

        public IHttpActionResult Get(int id)
        {
            PostService postService = CreatePostService();
            var posts = postService.GetPostById(id);
            return Ok(posts);//200
        }

        public IHttpActionResult Post(PostCreate post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);//400
            }

            var service = CreatePostService();

            if (!service.CreatePost(post))
            {
                return InternalServerError();//500
            }

            return Ok();//200
        }
    }
}
