
namespace Mezubo.Api.Controllers.Base
{
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        /// <summary>
        /// Constructor Base
        /// </summary>
        protected BaseController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
    }
}
