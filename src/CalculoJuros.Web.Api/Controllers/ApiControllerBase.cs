using CalculoJuros.Infrastructure.Notifications;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculoJuros.Web.Api.Controllers
{
    [ApiController]
    public class ApiControllerBase : ControllerBase
    {
        private readonly IRequestNotificator _notifications;

        protected ApiControllerBase(IRequestNotificator notifications)
        {
            _notifications = notifications;
        }

        protected ActionResult Result(object result = null)
        {
            if (_notifications.HasNotification())
            {
                return ResponseError(result);
            }

            return ResponseSuccess(result);
        }

        private ActionResult ResponseSuccess(object result = null)
        {
            return Ok(new
            {
                success = true,
                data = result
            });
        }

        private ActionResult ResponseError(object result = null)
        {
            return BadRequest(new
            {
                success = false,
                errors = _notifications.Get().Select(n => n.Menssage)
            });
        }
    }
}
