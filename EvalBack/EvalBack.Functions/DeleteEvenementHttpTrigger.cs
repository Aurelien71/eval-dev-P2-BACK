using EvalBack.Entities;
using EvalBack.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Net;

namespace EvalBack.Functions
{
    public class DeleteEvenementHttpTrigger
    {
        private readonly ILogger<DeleteEvenementHttpTrigger> _logger;
        private readonly IEvenementService _evenementService;

        public DeleteEvenementHttpTrigger(ILogger<DeleteEvenementHttpTrigger> logger, IEvenementService evenementService)
        {
            _logger = logger;
            _evenementService = evenementService;
        }

        [Function(nameof(DeleteEvenementHttpTrigger))]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "delete")] HttpRequestData req)
        {
            try
            {
                var evenement = await req.ReadFromJsonAsync<Evenement>();

                if (evenement is null)
                {
                    _logger.LogDebug("Invalid request body");

                    return req.CreateResponse(HttpStatusCode.BadRequest);
                }

                await _evenementService.DeleteEvenement(evenement);

                return req.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Internal server error");

                return req.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }
    }
}
