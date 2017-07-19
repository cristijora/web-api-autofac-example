using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoFacWebApi.Models;
using AutoFacWebApi.RequestModels;
using AutoFacWebApi.Services;

namespace AutoFacWebApi.Controllers
{
    public class TestController : ApiController
    {
        private readonly IUserService _userService;

        public TestController(IUserService userService)
        {
            _userService = userService;
        }

        public string Get()
        {
            return "Hello, world!";
        }

        public HttpResponseMessage Post([Required] AuthenticationRequest request)
        {
            if (!ModelState.IsValid)
            {
                var errors = new List<string>();
                foreach (var state in ModelState)
                {
                    foreach (var error in state.Value.Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }
                }
                return Request.CreateResponse(HttpStatusCode.BadRequest, errors);
            }

            var user = _userService.GetUser(request.Username, request.Password);
            if (user != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, user);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound);
        }
    }
}