using EvalBack.Entities;
using EvalBack.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Net;

namespace EvalBack.Functions
{
    public class EditEvenementHttpTrigger
    {
        private readonly ILogger<EditEvenementHttpTrigger> _logger;
        private readonly IEvenementService _evenementService;

        public EditEvenementHttpTrigger(ILogger<EditEvenementHttpTrigger> logger, IEvenementService evenementService)
        {
            _logger = logger;
            _evenementService = evenementService;
        }

        [Function(nameof(EditEvenementHttpTrigger))]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "put")] HttpRequestData req)
        {
            try
            {
                var evenement = await req.ReadFromJsonAsync<Evenement>();

                if (evenement is null)
                {
                    _logger.LogDebug("Invalid request body");

                    return req.CreateResponse(HttpStatusCode.BadRequest);
                }

                var evenements = await _evenementService.EditEvenement(evenement);

                var response = req.CreateResponse(HttpStatusCode.OK);

                await response.WriteAsJsonAsync(evenements);

                return response;
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Internal server error");

                return req.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }
    }
}
