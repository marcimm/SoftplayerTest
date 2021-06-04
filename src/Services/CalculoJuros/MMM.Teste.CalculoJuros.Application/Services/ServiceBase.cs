using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using MMM.Test.Core.Notifications;
using MMM.Teste.CalculoJuros.Application.Extensions;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MMM.Teste.CalculoJuros.Application.Services
{
    public abstract class ServiceBase
    {
        private readonly INotifier _notifier;
        protected readonly IMapper _mapper;

        protected ServiceBase(INotifier notifier, IMapper mapper)
        {
            _notifier = notifier;
            _mapper = mapper;
        }

        protected bool ValidateProperties<TV, TE>(TV validation, TE entity)
         where TV : AbstractValidator<TE> where TE : class
        {
            var validationResult = validation.Validate(entity);

            if (validationResult.IsValid)
                return true;

            Notify(validationResult);

            return false;
        }

        protected void Notify(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notify(new Notification(error.ErrorMessage, NotificationType.ERROR));
            }
        }

        protected void Notify(Notification notification)
        {
            _notifier.Handle(notification);
        }

        protected async Task<T> DeserializarObjetoResponse<T>(HttpResponseMessage responseMessage)
        {
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<T>(await responseMessage.Content.ReadAsStringAsync(), options);
        }

        protected bool TratarErrosResponse(HttpResponseMessage response)
        {
            int statusCode = (int)response.StatusCode;

            if ((statusCode < 200) || (statusCode > 208)) //[200, 208] = HTTP OK
            {
                _notifier.Handle(new Notification("Serviço de taxa de juros indisponível", NotificationType.ERROR));
                throw new CustomHttpRequestException(response.StatusCode);
            }

            response.EnsureSuccessStatusCode();
            return true;
        }
    }
}
