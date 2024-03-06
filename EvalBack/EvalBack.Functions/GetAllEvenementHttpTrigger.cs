using EvalBack.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Net;

namespace EvalBack.Functions
{
    public class GetAllEvenementHttpTrigger
    {
        private readonly ILogger<GetAllEvenementHttpTrigger> _logger;
        private readonly IEvenementService _evenementService;

        public GetAllEvenementHttpTrigger(ILogger<GetAllEvenementHttpTrigger> logger, IEvenementService evenementService)
        {
            _logger = logger;
            _evenementService = evenementService;
        }

        [Function(nameof(GetAllEvenementHttpTrigger))]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Function, "get")] HttpRequestData req)
        {
            try
            {

                var evenements = await _evenementService.GetAllEvenements();

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
