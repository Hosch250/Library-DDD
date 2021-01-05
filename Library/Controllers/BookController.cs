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
    public class BookController : ControllerBase
    {
        private readonly FeatureFlags featureFlags;
        private readonly IBookApplication bookApplication;

        public BookController(IOptions<FeatureFlags> featureFlags, IBookApplication bookApplication)
        {
            this.featureFlags = featureFlags.Value;
            this.bookApplication = bookApplication;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            if (!featureFlags.EnableBook)
            {
                return new StatusCodeResult((int)System.Net.HttpStatusCode.NotImplemented);
            }

            var books = await bookApplication.GetAll();
            return Ok(books);
        }

        [HttpGet("{bookId}")]
        public IActionResult Get(Guid bookId)
        {
            // left as an exercise for the reader
            return new StatusCodeResult((int)System.Net.HttpStatusCode.NotImplemented);
        }

        [HttpPut]
        public IActionResult CreateBook()
        {
            // left as an exercise for the reader
            return new StatusCodeResult((int)System.Net.HttpStatusCode.NotImplemented);
        }

        [HttpPut("{bookId}/hold/{userId}")]
        public IActionResult HoldBook(Guid bookId, Guid userId)
        {
            // left as an exercise for the reader
            return new StatusCodeResult((int)System.Net.HttpStatusCode.NotImplemented);
        }
    }
}
