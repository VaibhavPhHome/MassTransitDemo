using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace Publisher.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishController : ControllerBase
    {
        private readonly IPublishEndpoint _publisher;

        public PublishController(IPublishEndpoint _publisher)
        {
            this._publisher = _publisher;
        }
        [HttpGet]
        public async Task<string> PublishMessage()
        {
            await _publisher.Publish(new Order { Name = "Vaibhav " + Guid.NewGuid().ToString() });

            return "Success";
        }
    }
}
