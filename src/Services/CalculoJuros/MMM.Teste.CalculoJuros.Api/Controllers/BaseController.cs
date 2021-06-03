using Microsoft.AspNetCore.Mvc;
using MMM.Test.Core.Models;
using MMM.Test.Core.Notifications;
using System.Collections.Generic;

namespace MMM.Teste.CalculoJuros.Api.Controllers
{
    public abstract class BaseController : Controller
    {
        protected readonly INotifier _notifier;

        protected BaseController(INotifier notifier)
        {
            _notifier = notifier;
        }

        protected ActionResult CustomResponse(object response = null)
        {
            ApiResponse<object> apiResponse = new ApiResponse<object>
            {
                Response = response,
                Messages = new List<string>()
            };

            if (_notifier.HasNotification(NotificationType.WARNING))
                apiResponse.Messages = _notifier.GetMessages(NotificationType.WARNING);

            if (IsValidOperation())
            {
                apiResponse.Success = true;
                return Ok(apiResponse);
            }

            apiResponse.Success = false;
            apiResponse.Messages.AddRange(_notifier.GetMessages(NotificationType.ERROR));

            return BadRequest(apiResponse);
        }

        protected bool IsValidOperation()
        {
            return !_notifier.HasNotification(NotificationType.ERROR);
        }
    }
}
