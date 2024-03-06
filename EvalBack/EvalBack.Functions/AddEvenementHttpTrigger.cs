using EvalBack.Services.Contracts;
using EvalBack.Services.Contracts.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Net;

namespace EvalBack.Functions
{
    public class AddEvenementHttpTrigger
    {
        private readonly ILogger<AddEvenementHttpTrigger> _logger;
        private readonly IEvenementService _evenementService;

        public AddEvenementHttpTrigger(ILogger<AddEvenementHttpTrigger> logger, IEvenementService evenementService)
        {
            _logger = logger;
            _evenementService = evenementService;
        }

        [Function(nameof(AddEvenementHttpTrigger))]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequestData req)
        {
            try
            {
                var evenement = await req.ReadFromJsonAsync<EvenementDTO>();

                if (evenement is null)
                {
                    _logger.LogDebug("Invalid request body");

                    return req.CreateResponse(HttpStatusCode.BadRequest);
                }

                await _evenementService.AddEvenement(evenement);

                return req.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Internal server errorwhile adding user in application");

                return req.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }
    }
}
