using Library.Application;
using Library.Infrastructure.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace Library.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly FeatureFlags featureFlags;
        private readonly IUserApplication userApplication;

        public UserController(IOptions<FeatureFlags> featureFlags, IUserApplication userApplication)
        {
            this.featureFlags = featureFlags.Value;
            this.userApplication = userApplication;
        }

        [HttpGet("{userId}")]
        public IActionResult Get(Guid userId)
        {
            // left as an exercise for the reader
            return new StatusCodeResult((int)System.Net.HttpStatusCode.NotImplemented);
        }

        [HttpPut]
        public async Task<IActionResult> CreateUser(string name)
        {
            if (!featureFlags.EnableUser) 
            {
                return new StatusCodeResult((int)System.Net.HttpStatusCode.NotImplemented);
            }

            var user = await userApplication.CreateUser(name);
            return Ok(user);
        }

        [HttpPut("{userId}/checkout/{bookId}")]
        public async Task<IActionResult> CheckoutBook(Guid userId, Guid bookId)
        {
            if (!featureFlags.EnableUser)
            {
                return new StatusCodeResult((int)System.Net.HttpStatusCode.NotImplemented);
            }

            await userApplication.CheckoutBook(userId, bookId);
            return NoContent();
        }

        [HttpPut("{userId}/return/{bookId}")]
        public async Task<IActionResult> ReturnBook(Guid userId, Guid bookId)
        {
            if (!featureFlags.EnableUser)
            {
                return new StatusCodeResult((int)System.Net.HttpStatusCode.NotImplemented);
            }

            await userApplication.ReturnBook(userId, bookId);
            return NoContent();
        }
    }
}
