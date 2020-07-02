using CalculoJuros.Infrastructure.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace CalculoJuros.Web.Api.Controllers
{
    [Route("showmethecode")]
    public class ShowMeTheCodeController : ApiControllerBase
    {
        public ShowMeTheCodeController(IRequestNotificator notifications) : base(notifications) { }
        [HttpGet]
        public IActionResult Get() => Result("https://github.com/juniorcesarrocha/calculojuros");
    }
}
