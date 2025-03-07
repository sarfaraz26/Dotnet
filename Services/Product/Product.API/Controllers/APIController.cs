using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Product.API.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]/")]
    [ApiController]
    public class APIController : ControllerBase
    {
    }
}
